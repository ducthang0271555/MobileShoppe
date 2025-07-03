using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace MobileShop
{
    public partial class UserHomePage : Form
    {
        public UserHomePage()
        {
            InitializeComponent();
            SqlConnection con = DatabaseHelper.GetConnection();
            con.Open();

            SqlCommand cmd = new SqlCommand("SELECT CompName FROM Company", con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                comboBoxCompany.Items.Add(dr["CompName"].ToString());
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

            SqlCommand cmd2 = new SqlCommand("SELECT IMEINo FROM Mobile WHERE ModelID = @modelID", con);
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
            }
            else {
                ConfirmDetails form = new ConfirmDetails();
                this.Hide();
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
    }
}
