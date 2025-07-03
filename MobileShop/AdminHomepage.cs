using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MobileShop
{
    public partial class AdminHomepage : Form
    {
        public AdminHomepage()
        {
            InitializeComponent();
            LoadCompaniesToComboBox();
            LoadModelsToComboBox();
        }

        private void btnAddCompany_Click(object sender, EventArgs e)
        {
            string companyID = txtCompanyID.Text.Trim();
            string companyName = txtCompanyName.Text.Trim();

            if (string.IsNullOrEmpty(companyID) || string.IsNullOrEmpty(companyName))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Lỗi nhập liệu",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCompanyID.Focus();
                return;
            }

            if (companyID.Length > 20)
            {
                MessageBox.Show("Company ID không được vượt quá 20 ký tự.",
                                "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCompanyID.Focus();
                return;
            }

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                try
                {
                    conn.Open();

                    string insertSql = "INSERT INTO Company (CompID, CompName) VALUES (@id, @name)";
                    using (SqlCommand insertCmd = new SqlCommand(insertSql, conn))
                    {
                        insertCmd.Parameters.AddWithValue("@id", companyID);
                        insertCmd.Parameters.AddWithValue("@name", companyName);

                        int rows = insertCmd.ExecuteNonQuery();
                        if (rows > 0)
                        {
                            MessageBox.Show("Thêm công ty thành công!",
                                            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            LoadCompaniesToComboBox();

                            txtCompanyID.Clear();
                            txtCompanyName.Clear();
                            txtCompanyID.Focus();
                        }
                        else
                        {
                            MessageBox.Show("Thêm không thành công!",
                                            "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Lỗi SQL: " + ex.Message,
                                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message,
                                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LoadCompaniesToComboBox()
        {
            try
            {
                using (SqlConnection connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT CompID, CompName FROM Company ORDER BY CompName";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        SqlDataAdapter da = new SqlDataAdapter(command);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        cboCompanyName.DataSource = dt;
                        cboCompanyName.ValueMember = "CompID";
                        cboCompanyName.DisplayMember = "CompName";

                        cboCompanyName.SelectedIndex = -1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách công ty: " + ex.Message, "Lỗi tải dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddModel_Click(object sender, EventArgs e)
        {
            string modelID = txtModelID.Text.Trim();
            string modelName = txtModelName.Text.Trim();
            string availableQtyText = txtAvailableQty.Text.Trim();
            string compID = "";

            if (cboCompanyName.SelectedValue != null)
            {
                compID = cboCompanyName.SelectedValue.ToString();
            }

            if (string.IsNullOrEmpty(modelID))
            {
                MessageBox.Show("Vui lòng nhập Model ID.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtModelID.Focus();
                return;
            }

            if (string.IsNullOrEmpty(modelName))
            {
                MessageBox.Show("Vui lòng nhập Model Name.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtModelName.Focus();
                return;
            }

            if (string.IsNullOrEmpty(availableQtyText))
            {
                MessageBox.Show("Vui lòng nhập Available Quantity.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAvailableQty.Focus();
                return;
            }

            if (!int.TryParse(availableQtyText, out int availableQty))
            {
                MessageBox.Show("Available Quantity phải là số nguyên hợp lệ.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAvailableQty.Focus();
                return;
            }

            if (string.IsNullOrEmpty(compID))
            {
                MessageBox.Show("Vui lòng chọn Company Name.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboCompanyName.Focus();
                return;
            }

            if (modelID.Length > 20)
            {
                MessageBox.Show("Model ID không được vượt quá 20 ký tự.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtModelID.Focus();
                return;
            }
            if (modelName.Length > 20)
            {
                MessageBox.Show("Model Name không được vượt quá 20 ký tự.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtModelName.Focus();
                return;
            }

            try
            {
                using (SqlConnection connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();

                    string checkSql = "SELECT COUNT(*) FROM Model WHERE ModelID = @ModelID";
                    using (SqlCommand checkCmd = new SqlCommand(checkSql, connection))
                    {
                        checkCmd.Parameters.AddWithValue("@ModelID", modelID);
                        int count = (int)checkCmd.ExecuteScalar();
                        if (count > 0)
                        {
                            MessageBox.Show("Model ID này đã tồn tại. Vui lòng nhập ID khác.", "Lỗi trùng lặp", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtModelID.Focus();
                            return;
                        }
                    }

                    string insertQuery = "INSERT INTO Model (ModelID, CompID, ModelName, AvailableQty) VALUES (@ModelID, @CompID, @ModelName, @AvailableQty)";

                    using (SqlCommand command = new SqlCommand(insertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@ModelID", modelID);
                        command.Parameters.AddWithValue("@CompID", compID);
                        command.Parameters.AddWithValue("@ModelName", modelName);
                        command.Parameters.AddWithValue("@AvailableQty", availableQty);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Thêm Model thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadModelsToComboBox();
                            txtModelID.Clear();
                            txtModelName.Clear();
                            txtAvailableQty.Clear();
                            cboCompanyName.SelectedIndex = -1;
                            txtModelID.Focus();
                        }
                        else
                        {
                            MessageBox.Show("Không thể thêm Model. Vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi cơ sở dữ liệu: " + ex.Message, "Lỗi SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadModelsToComboBox()
        {
            try
            {
                using (SqlConnection connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT ModelID, ModelName FROM Model ORDER BY ModelName";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        SqlDataAdapter da = new SqlDataAdapter(command);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        cboModelName.DataSource = dt;
                        cboModelName.ValueMember = "ModelID";
                        cboModelName.DisplayMember = "ModelName";

                        cboModelName.SelectedIndex = -1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách Model: " + ex.Message, "Lỗi tải dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddMobile_Click(object sender, EventArgs e)
        {
            string imeino = txtIMEINO.Text.Trim();
            string modelID = "";
            string status = txtStatus.Text.Trim();
            string priceText = txtPrice.Text.Trim();

            if (cboModelName.SelectedValue != null)
            {
                modelID = cboModelName.SelectedValue.ToString();
            }

            if (string.IsNullOrEmpty(imeino))
            {
                MessageBox.Show("Vui lòng nhập IMEI No.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtIMEINO.Focus();
                return;
            }

            if (string.IsNullOrEmpty(modelID))
            {
                MessageBox.Show("Vui lòng chọn Model Name.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboModelName.Focus();
                return;
            }

            if (string.IsNullOrEmpty(status))
            {
                MessageBox.Show("Vui lòng nhập Status.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtStatus.Focus();
                return;
            }

            if (string.IsNullOrEmpty(priceText))
            {
                MessageBox.Show("Vui lòng nhập Price.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPrice.Focus();
                return;
            }

            if (!decimal.TryParse(priceText, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out decimal price))
            {
                MessageBox.Show("Price phải là một số hợp lệ.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPrice.Focus();
                return;
            }

            if (imeino.Length > 50)
            {
                MessageBox.Show("IMEI No. không được vượt quá 50 ký tự.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtIMEINO.Focus();
                return;
            }
            if (status.Length > 20)
            {
                MessageBox.Show("Status không được vượt quá 20 ký tự.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtStatus.Focus();
                return;
            }

            try
            {
                using (SqlConnection connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();

                    string checkSql = "SELECT COUNT(*) FROM Mobile WHERE IMEINO = @IMEINO";
                    using (SqlCommand checkCmd = new SqlCommand(checkSql, connection))
                    {
                        checkCmd.Parameters.AddWithValue("@IMEINO", imeino);
                        int count = (int)checkCmd.ExecuteScalar();
                        if (count > 0)
                        {
                            MessageBox.Show("IMEI No. này đã tồn tại. Vui lòng nhập IMEI khác.", "Lỗi trùng lặp", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtIMEINO.Focus();
                            return;
                        }
                    }

                    string insertQuery = "INSERT INTO Mobile (ModelId, IMEINO, Status, Price) VALUES (@ModelId, @IMEINO, @Status, @Price)";

                    using (SqlCommand command = new SqlCommand(insertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@ModelId", modelID);
                        command.Parameters.AddWithValue("@IMEINO", imeino);
                        command.Parameters.AddWithValue("@Status", status);
                        command.Parameters.AddWithValue("@Price", price);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Thêm Mobile thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtIMEINO.Clear();
                            cboModelName.SelectedIndex = -1;
                            txtStatus.Clear();
                            txtPrice.Clear();
                            txtIMEINO.Focus();
                        }
                        else
                        {
                            MessageBox.Show("Không thể thêm Mobile. Vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi cơ sở dữ liệu: " + ex.Message, "Lỗi SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}