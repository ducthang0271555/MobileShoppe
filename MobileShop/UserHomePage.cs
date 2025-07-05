using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;

namespace MobileShop
{
    public partial class UserHomePage : Form
    {
        public UserHomePage()
        {
            InitializeComponent();
            getCompName(comboBoxCompany);
            getCompName(comboBoxCompName);
        }
        private void getCompName(ComboBox cb) {
            SqlConnection con = DatabaseHelper.GetConnection();
            con.Open();

            SqlCommand cmd = new SqlCommand("SELECT CompName FROM Company", con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                cb.Items.Add(dr["CompName"].ToString());
            }

            con.Close();
        }
        private bool IsValid12DigitNumber(TextBox textbox)
        {
            string input = textbox.Text.Trim();

            // Kiểm tra: chỉ gồm số và độ dài đúng 12
            if (input.Length == 12 && input.All(char.IsDigit))
            {
                return true;
            }

            return false;
        }
        private bool IsValidTextOnly(TextBox textbox)
        {
            string input = textbox.Text.Trim();

            // Kiểm tra rỗng
            if (string.IsNullOrEmpty(input))
                return false;

            // Kiểm tra xem tất cả ký tự có phải là chữ hoặc khoảng trắng
            return input.All(c => char.IsLetter(c) || char.IsWhiteSpace(c));
        }
        private bool IsValidEmail(TextBox textbox)
        {
            string email = textbox.Text.Trim();

            if (string.IsNullOrEmpty(email))
                return false;

            // Biểu thức chính quy kiểm tra email hợp lệ
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, pattern);
        }

        private void cbbCompany_selectedIndexChanged(ComboBox comboBoxCompany, ComboBox comboBoxModel) {
            comboBoxModel.Items.Clear();
            string selectedCompName = comboBoxCompany.SelectedItem.ToString();
            SqlConnection con = DatabaseHelper.GetConnection();
            con.Open();

            // Lấy CompID từ Company Name
            SqlCommand cmd1 = new SqlCommand("SELECT CompID FROM Company WHERE CompName = @compName", con);
            cmd1.Parameters.AddWithValue("@compName", selectedCompName);
            string compID = cmd1.ExecuteScalar().ToString();
            // Lấy Model theo CompID
            SqlCommand cmd2 = new SqlCommand("SELECT ModelName FROM Model WHERE CompID = @compID", con);
            cmd2.Parameters.AddWithValue("@compID", compID);
            SqlDataReader dr = cmd2.ExecuteReader();

            while (dr.Read())
            {
                comboBoxModel.Items.Add(dr["ModelName"].ToString());
            }
            // ✅ Tự động chọn model đầu tiên nếu có
            if (comboBoxModel.Items.Count > 0)
            {
                comboBoxModel.SelectedIndex = 0;
            }

            con.Close();
        }
        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void comboBoxModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxIMEI.Items.Clear();
            string selectedModelName = comboBoxModel.SelectedItem.ToString();
            SqlConnection con = DatabaseHelper.GetConnection();
            con.Open();
            SqlCommand cmd1 = new SqlCommand("SELECT ModelID FROM Model WHERE ModelName = @modelName", con);
            cmd1.Parameters.AddWithValue("@modelName", selectedModelName);
            string modelId = cmd1.ExecuteScalar().ToString();

            SqlCommand cmd2 = new SqlCommand("SELECT IMEINo FROM Mobile WHERE ModelID = @modelID and status = 'available' ", con);
            cmd2.Parameters.AddWithValue("@modelID", modelId);
            SqlDataReader dr = cmd2.ExecuteReader();
            while (dr.Read())
            {
                comboBoxIMEI.Items.Add(dr["IMEINo"].ToString());
            }
            if (comboBoxIMEI.Items.Count > 0)
            {
                comboBoxIMEI.SelectedIndex = 0;
            }

            con.Close();
        }

        private void comboBoxCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbbCompany_selectedIndexChanged(comboBoxCompany, comboBoxModel);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCustomerName.Text) ||
                   string.IsNullOrWhiteSpace(txtMobileNumber.Text) ||
                   string.IsNullOrWhiteSpace(txtAddress.Text) ||
                   string.IsNullOrWhiteSpace(txtEmail.Text) ||
                   comboBoxCompany.SelectedIndex == -1 ||
                   comboBoxModel.SelectedIndex == -1 ||
                   comboBoxIMEI.SelectedIndex == -1 ||
                   string.IsNullOrWhiteSpace(txtPrice.Text)
               )
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thiếu dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            } else if(!IsValid12DigitNumber(txtMobileNumber)) {
                MessageBox.Show("IMEI phải là 12 chữ số!");
                return;
            }
            else if (!IsValidTextOnly(txtCustomerName))
            {
                MessageBox.Show("Tên chỉ được chứa chữ cái và khoảng trắng.");
                return;
            }
            else if (!IsValidTextOnly(txtAddress))
            {
                MessageBox.Show("Địa chỉ chỉ được chứa chữ cái và khoảng trắng.");
                return;
            }
            else if (!IsValidEmail(txtEmail))
            {
                MessageBox.Show("Email không hợp lệ!");
                return;
            }
            else {
                ConfirmDetails form = new ConfirmDetails(
                    txtCustomerName.Text, txtMobileNumber.Text, txtAddress.Text, txtEmail.Text,
                    comboBoxCompany.SelectedItem.ToString(), comboBoxModel.SelectedItem.ToString(),
                    comboBoxIMEI.SelectedItem.ToString(), txtPrice.Text);
                //this.Hide();
                form.Show();
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
       

        private void txtPrice_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void comboBoxIMEI_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBoxCompName_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbbCompany_selectedIndexChanged(comboBoxCompName, comboBoxMobile);

        }

        private void UserHomePage_Load(object sender, EventArgs e)
        {

        }

        private void comboBoxMobile_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = DatabaseHelper.GetConnection();
            con.Open();
            SqlCommand cmd1 = new SqlCommand("SELECT AvailableQty FROM MODEL WHERE ModelName = @modelName", con);
            cmd1.Parameters.AddWithValue("@modelName", comboBoxMobile.Text.ToString());
            string quantity = cmd1.ExecuteScalar().ToString();
            txtAvailabel.Text = quantity;
            con.Close();
        }

     

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void search_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = DatabaseHelper.GetConnection())
            {
                string query = @"
            SELECT 
                C.CustName AS CustomerName,
                C.MobileNo AS MobileNumber,
                C.MailID AS EmailId,
                C.Address,
                S.SalesDate,
                S.Price
            FROM 
                Customers C
            JOIN 
                Sales S ON C.CustID = S.CustID
            WHERE
                S.IMEINo = @imei";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@imei", imeiInput.Text);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                
                    DataTable table = new DataTable();
                    adapter.Fill(table);

                if (table.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy thông tin với IMEI này!", "IMEI Không tồn tại", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dataGridView1.DataSource = null; // clear lưới nếu có dữ liệu cũ
                }
                else
                {
                    dataGridView1.DataSource = table;
                }
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            UserLoginForm loginForm = new UserLoginForm();
            loginForm.Show();
            this.Close();
        }
    }
}
