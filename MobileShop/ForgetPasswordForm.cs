using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MobileShop
{
    public partial class ForgetPasswordForm : Form
    {
        public ForgetPasswordForm()
        {
            InitializeComponent();
        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                string query = "SELECT Pwd FROM Users WHERE UserName = @user AND Hint = @hint";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@user", txtUsername.Text.Trim());
                cmd.Parameters.AddWithValue("@hint", txtHint.Text.Trim());

                conn.Open();
                var result = cmd.ExecuteScalar();
                if (result != null)
                {
                    respond.Text = "Your Password is: " + result.ToString();
                }
                else
                {
                    MessageBox.Show("Invalid username or hint!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void linkLoginPage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            UserLoginForm form = new UserLoginForm();
            this.Hide();
            form.Show();
        }
    }
}
