using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MobileShop
{
    public partial class AdminLoginForm : Form
    {
        public AdminLoginForm()
        {
            InitializeComponent();
        }

        private void linkBack_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            UserLoginForm form1 = new UserLoginForm();
            form1.Show();
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tên đăng nhập và mật khẩu!");
                return;
            }
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string sql = @"SELECT EmployeeName 
                           FROM Users 
                           WHERE Username = @u 
                             AND Pwd      = @p 
                             AND Actions  = 'Admin'";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@u", username);
                        cmd.Parameters.AddWithValue("@p", password);

                        object result = cmd.ExecuteScalar();

                        if (result != null)
                        {
                            // ✅ Đăng nhập thành công
                            AdminHomepage adminHomepage = new AdminHomepage();
                            adminHomepage.Show();
                            this.Hide();
                           
                        }
                        else
                        {
                            MessageBox.Show("Tài khoản không có quyền Admin hoặc thông tin đăng nhập sai!",
                                            "Đăng nhập thất bại");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối: " + ex.Message);
            }
        }
    }
}
