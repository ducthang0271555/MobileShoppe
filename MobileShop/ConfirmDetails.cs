using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace MobileShop
{
    public partial class ConfirmDetails : Form
    {
        public ConfirmDetails(string customerName,
        string mobileNumber,
        string address,
        string email,
        string companyName,
        string modelNumber,
        string imei,
        string price
        )
        {
            InitializeComponent();
            customerNameLabel.Text = customerName;
            mobileNumberLabel.Text = mobileNumber;
            addressLabel.Text = address;
            emailIDLabel.Text = email;
            compNameLabel.Text = companyName;
            modelNumberLabel.Text = modelNumber;
            IMEILabel.Text = imei;
            priceLabel.Text = price;

            //
            string warranty = GetWarrantyByImei(imei);
            // Parse string sang số nguyên
            int warrantyYears = int.Parse(warranty);
            // Cộng năm bảo hành vào ngày hiện tại
            DateTime warrantyDate = DateTime.Today.AddYears(warrantyYears);
            // Hiển thị định dạng dd/MM/yyyy
            string warrantyDateString = warrantyDate.ToString("dd/MM/yyyy");
            //
            warrantyLabel.Text = "Warranty: " + warrantyDateString;


        }

        private void cust_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
        private String GetWarrantyByImei(String imei) {
            SqlConnection con = DatabaseHelper.GetConnection();
            con.Open();
            SqlCommand cmd2 = new SqlCommand("SELECT Warranty FROM Mobile WHERE IMEINO = @imei", con);
            cmd2.Parameters.AddWithValue("@imei", imei.ToString());
            SqlDataReader dr = cmd2.ExecuteReader();
            while (dr.Read())
            {
                return dr["warranty"].ToString();
            }
            return null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = DatabaseHelper.GetConnection();
            con.Open();
            SqlTransaction transaction = con.BeginTransaction(); // để rollback nếu có lỗi
            try {
                // 1. Insert vào bảng Customers
                SqlCommand cmd1 = new SqlCommand(@"
                INSERT INTO Customers (CustName, MobileNo, MailID, Address)
                VALUES (@name, @mobile, @email, @address);
                SELECT SCOPE_IDENTITY();", con, transaction);

                cmd1.Parameters.AddWithValue("@name", customerNameLabel.Text.ToString());
                cmd1.Parameters.AddWithValue("@mobile", mobileNumberLabel.Text.ToString());
                cmd1.Parameters.AddWithValue("@email", emailIDLabel.Text.ToString());
                cmd1.Parameters.AddWithValue("@address", addressLabel.Text.ToString());
                int customerID = Convert.ToInt32(cmd1.ExecuteScalar());

                // 2. Insert vào bảng Sales
                SqlCommand cmd2 = new SqlCommand(@"
                INSERT INTO Sales (IMEINo, SalesDate, Price, CustID)
                VALUES (@imei, @date, @price, @custid);", con, transaction);

                cmd2.Parameters.AddWithValue("@imei", IMEILabel.Text.ToString());
                cmd2.Parameters.AddWithValue("@date", DateTime.Today);
                cmd2.Parameters.AddWithValue("@price", priceLabel.Text.ToString());
                cmd2.Parameters.AddWithValue("@custid", customerID);
                cmd2.ExecuteNonQuery();

                // 3. Update Mobile: set Status = 'Sold'
                SqlCommand cmd3 = new SqlCommand(@"
                UPDATE Mobile SET Status = 'Sold' WHERE IMEINo = @imei;", con, transaction);
                cmd3.Parameters.AddWithValue("@imei", IMEILabel.Text.ToString());
                cmd3.ExecuteNonQuery();

                // 4. Giảm AvailableQty trong bảng Model
                SqlCommand cmd4 = new SqlCommand(@"
                UPDATE Model SET AvailableQty = AvailableQty - 1
                WHERE ModelID = (SELECT ModelID FROM Mobile WHERE IMEINo = @imei);", con, transaction);
                cmd4.Parameters.AddWithValue("@imei", IMEILabel.Text.ToString());
                cmd4.ExecuteNonQuery();
                transaction.Commit();
                MessageBox.Show("Giao dịch thành công!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close(); // hoặc quay về form chính

            }
            catch (Exception ex)
            {
                transaction.Rollback();
                MessageBox.Show("Lỗi khi lưu dữ liệu: " + ex.Message);
            }
            finally
            {
                con.Close();
            }

        }
    }
}
