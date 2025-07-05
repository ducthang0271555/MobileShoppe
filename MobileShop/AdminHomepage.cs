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
            LoadCompaniesToComboBox1();
            LoadModelsToComboBox();
            txtCompanyID.Text = GenerateRandomCompanyID();
            txtModelID.Text = GenerateRandomModelID();
            txtTransID.Text = GenerateRandomTransID();
            cboCompName.SelectedIndexChanged += cboCompName_SelectedIndexChanged;
            cboModName.SelectedIndexChanged += cboModName_SelectedIndexChanged;
            cboWarranty.Items.AddRange(new object[] { "1 Year", "2 Years", "3 Years", "4 Years", "5 Years" });
            cboWarranty.SelectedIndex = 0;

        }

        private void btnAddCompany_Click(object sender, EventArgs e)
        {
            string companyID = txtCompanyID.Text.Trim();
            string companyName = txtCompanyName.Text.Trim();

            if (string.IsNullOrEmpty(companyName))
            {
                MessageBox.Show("Vui lòng nhập tên công ty!", "Lỗi nhập liệu",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                            LoadCompaniesToComboBox1();
                            txtCompanyID.Text = GenerateRandomCompanyID();
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

        private string GenerateRandomCompanyID()
        {
            Random random = new Random();
            string newID = "";

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();

                while (true)
                {
                    int randomNumber = random.Next(0, 1000);
                    newID = randomNumber.ToString("D3");

                    string query = "SELECT COUNT(*) FROM Company WHERE CompID = @id";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", newID);
                        int count = (int)cmd.ExecuteScalar();

                        if (count == 0)
                            break;
                    }
                }
            }

            return newID;
        }

        private string GenerateRandomModelID()
        {
            Random random = new Random();
            string newID = "";

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();

                while (true)
                {
                    char letter1 = (char)random.Next('A', 'Z' + 1);
                    char letter2 = (char)random.Next('A', 'Z' + 1);

                    int number = random.Next(0, 1000);

                    newID = $"{letter1}{letter2}{number:D3}"; 
                    string query = "SELECT COUNT(*) FROM Model WHERE ModelID = @id";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", newID);
                        int count = (int)cmd.ExecuteScalar();

                        if (count == 0)
                            break;
                    }
                }
            }

            return newID;
        }

        private string GenerateRandomTransID()
        {
            Random random = new Random();
            string newID = "";

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();

                while (true)
                {
                    char letter1 = (char)random.Next('A', 'Z' + 1);
                    char letter2 = (char)random.Next('A', 'Z' + 1);
                    char letter3 = (char)random.Next('A', 'Z' + 1);

                    int number = random.Next(0, 10000);

                    newID = $"{letter1}{letter2}{letter3}{number:D4}";
                    string query = "SELECT COUNT(*) FROM Transactions WHERE TransID = @id";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", newID);
                        int count = (int)cmd.ExecuteScalar();

                        if (count == 0)
                            break;
                    }
                }
            }

            return newID;
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

        private void LoadCompaniesToComboBox1()
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

                        cboCompName.DataSource = dt;
                        cboCompName.ValueMember = "CompID";
                        cboCompName.DisplayMember = "CompName";

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
                            txtModelID.Text = GenerateRandomModelID();
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
            string warranty = cboWarranty.Text.Trim();
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

            if (string.IsNullOrEmpty(warranty))
            {
                MessageBox.Show("Vui lòng chọn Warranty.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                    string insertQuery = "INSERT INTO Mobile (ModelId, IMEINO, Status, Price, Warranty) VALUES (@ModelId, @IMEINO, @Status, @Price, @Warranty)";

                    using (SqlCommand command = new SqlCommand(insertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@ModelId", modelID);
                        command.Parameters.AddWithValue("@IMEINO", imeino);
                        command.Parameters.AddWithValue("@Status", status);
                        command.Parameters.AddWithValue("@Price", price);
                        command.Parameters.AddWithValue("@Warranty", warranty);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Thêm Mobile thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtIMEINO.Clear();
                            cboModelName.SelectedIndex = -1;
                            txtStatus.Clear();
                            txtPrice.Clear();
                            cboWarranty.SelectedIndex = 0;
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

        private void LoadModelsByCompany(string compID)
        {
            try
            {
                using (SqlConnection connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT ModelID, ModelName FROM Model WHERE CompID = @compID ORDER BY ModelName";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@compID", compID);
                        SqlDataAdapter da = new SqlDataAdapter(command);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        cboModName.DataSource = dt;
                        cboModName.DisplayMember = "ModelName";
                        cboModName.ValueMember = "ModelID";
                        cboModName.SelectedIndex = -1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách Model: " + ex.Message,
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboCompName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCompName.SelectedIndex == -1 || cboCompName.SelectedValue == null)
            {
                cboModName.DataSource = null;
                return;
            }

            string selectedCompID = cboCompName.SelectedValue.ToString();
            LoadModelsByCompany(selectedCompID);
        }

        private void cboModName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboModName.SelectedIndex == -1 || cboModName.SelectedValue == null)
            {
                txtQuantity.Text = "";
                return;
            }

            string selectedModelID = cboModName.SelectedValue.ToString();

            try
            {
                using (SqlConnection connection = DatabaseHelper.GetConnection())
                {
                    connection.Open();

                    string query = "SELECT AvailableQty FROM Model WHERE ModelID = @modelID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@modelID", selectedModelID);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtQuantity.Text = reader["AvailableQty"].ToString();
                            }
                            else
                            {
                                txtQuantity.Text = "";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy thông tin model: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdateStock_Click(object sender, EventArgs e)
        {
            string transID = txtTransID.Text.Trim();
            string modelID = cboModName.SelectedValue?.ToString();
            string quantityText = txtQuantity.Text.Trim();
            string amountText = txtAmount.Text.Trim();

            if (string.IsNullOrEmpty(modelID))
            {
                MessageBox.Show("Vui lòng chọn Model Name!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboModName.Focus();
                return;
            }

            if (!int.TryParse(quantityText, out int quantity) || quantity <= 0)
            {
                MessageBox.Show("Số lượng phải là số nguyên dương!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtQuantity.Focus();
                return;
            }

            if (!decimal.TryParse(amountText, out decimal amount) || amount < 0)
            {
                MessageBox.Show("Số tiền không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAmount.Focus();
                return;
            }

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                try
                {
                    conn.Open();

                    SqlTransaction transaction = conn.BeginTransaction();

                    try
                    {
                        // 1. Thêm vào Transactions
                        string insertSql = @"INSERT INTO Transactions (TransID, ModelID, Quantity, Date, Amount)
                                     VALUES (@TransID, @ModelID, @Quantity, @Date, @Amount)";
                        using (SqlCommand cmd = new SqlCommand(insertSql, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@TransID", transID);
                            cmd.Parameters.AddWithValue("@ModelID", modelID);
                            cmd.Parameters.AddWithValue("@Quantity", quantity);
                            cmd.Parameters.AddWithValue("@Date", DateTime.Now);
                            cmd.Parameters.AddWithValue("@Amount", amount);

                            cmd.ExecuteNonQuery();
                        }

                        // 2. Cập nhật Model.AvailableQty = Quantity
                        string updateSql = "UPDATE Model SET AvailableQty = @Qty WHERE ModelID = @ModelID";
                        using (SqlCommand cmd2 = new SqlCommand(updateSql, conn, transaction))
                        {
                            cmd2.Parameters.AddWithValue("@Qty", quantity);
                            cmd2.Parameters.AddWithValue("@ModelID", modelID);
                            cmd2.ExecuteNonQuery();
                        }

                        transaction.Commit();

                        MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Reset form
                        txtTransID.Text = GenerateRandomTransID();
                        cboModName.SelectedIndex = -1;
                        txtQuantity.Clear();
                        txtAmount.Clear();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Lỗi khi cập nhật: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kết nối CSDL: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void linkSearchInDate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DateTime selectedDate = dateTimePicker1.Value.Date;
            string query = @"SELECT 
                        ROW_NUMBER() OVER (ORDER BY s.SalesDate) AS Stdd,
                        c.CompName AS [Company Name],
                        m.ModelName AS [Model Name],
                        mo.IMEINo AS [EMEI NO],
                        s.Price
                     FROM 
                        Sales s
                        JOIN Mobile mo ON s.IMEINo = mo.IMEINo
                        JOIN Model m ON mo.ModelID = m.ModelID
                        JOIN Company c ON m.CompID = c.CompID
                     WHERE 
                        CAST(s.SalesDate AS DATE) = @SelectedDate";

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@SelectedDate", selectedDate);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;

                string sumQuery = @"SELECT ISNULL(SUM(Price), 0) FROM Sales
                            WHERE CAST(SalesDate AS DATE) = @SelectedDate";

                using (SqlCommand sumCmd = new SqlCommand(sumQuery, conn))
                {
                    sumCmd.Parameters.AddWithValue("@SelectedDate", selectedDate);
                    conn.Open();
                    object result = sumCmd.ExecuteScalar();
                    conn.Close();

                    decimal total = Convert.ToDecimal(result);
                    labelTotal.Text = $"Total Sales Amount of {selectedDate:dd/MM/yyyy} is {total:N0}";
                }
            }
        }

        private void linkSearchDateToDate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DateTime fromDate = dateTimePickerFrom.Value.Date;
            DateTime toDate = dateTimePickerTo.Value.Date;

            string query = @"SELECT 
                        ROW_NUMBER() OVER (ORDER BY s.SalesDate) AS Stdd,
                        c.CompName AS [Company Name],
                        m.ModelName AS [Model Name],
                        mo.IMEINo AS [EMEI NO],
                        s.Price
                    FROM 
                        Sales s
                        JOIN Mobile mo ON s.IMEINo = mo.IMEINo
                        JOIN Model m ON mo.ModelID = m.ModelID
                        JOIN Company c ON m.CompID = c.CompID
                    WHERE 
                        CAST(s.SalesDate AS DATE) BETWEEN @FromDate AND @ToDate";

            string sumQuery = @"SELECT ISNULL(SUM(Price), 0) FROM Sales
                        WHERE CAST(SalesDate AS DATE) BETWEEN @FromDate AND @ToDate";

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            using (SqlCommand sumCmd = new SqlCommand(sumQuery, conn))
            {
                cmd.Parameters.AddWithValue("@FromDate", fromDate);
                cmd.Parameters.AddWithValue("@ToDate", toDate);

                sumCmd.Parameters.AddWithValue("@FromDate", fromDate);
                sumCmd.Parameters.AddWithValue("@ToDate", toDate);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView2.AutoGenerateColumns = false;
                dataGridView2.DataSource = dt;

                conn.Open();
                object result = sumCmd.ExecuteScalar();
                conn.Close();

                decimal total = Convert.ToDecimal(result);
                labelTotal1.Text = $"Total Sales Amount from {fromDate:dd/MM/yyyy} to {toDate:dd/MM/yyyy} is {total:N0}";
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            AdminLoginForm loginForm = new AdminLoginForm();
            loginForm.Show();
            this.Close();
        }

        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text != txtRetypePassword.Text)
            {
                MessageBox.Show("Passwords do not match!", "Error");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtUserName.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text) ||
                string.IsNullOrWhiteSpace(txtEmployeeName.Text))
            {
                MessageBox.Show("Please fill in all required fields.", "Warning");
                return;
            }

            string query = @"INSERT INTO Users (Username, Pwd, EmployeeName, Address, Actions, MobileNo, Hint)
                     VALUES (@Username, @Pwd, @EmployeeName, @Address, @Actions, @MobileNo, @Hint)";

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@Username", txtUserName.Text.Trim());
                cmd.Parameters.AddWithValue("@Pwd", txtPassword.Text.Trim());
                cmd.Parameters.AddWithValue("@EmployeeName", txtEmployeeName.Text.Trim());
                cmd.Parameters.AddWithValue("@Address", txtAddress.Text.Trim());
                cmd.Parameters.AddWithValue("@Actions", "Employee");
                cmd.Parameters.AddWithValue("@MobileNo", txtMobile.Text.Trim());
                cmd.Parameters.AddWithValue("@Hint", txtHint.Text.Trim());

                try
                {
                    conn.Open();
                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        MessageBox.Show("User Saved Successfully.", "Success");
                        txtUserName.Clear();
                        txtAddress.Clear();
                        txtMobile.Clear();
                        txtEmployeeName.Clear();
                        txtPassword.Clear();
                        txtRetypePassword.Clear();
                        txtHint.Clear();
                    }
                    else
                        MessageBox.Show("Insert failed.", "Error");
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Database error: " + ex.Message, "Error");
                }
            }
        }
    }
}