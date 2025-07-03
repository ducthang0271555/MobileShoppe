namespace MobileShop
{
    partial class AdminHomepage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mainTabControl = new System.Windows.Forms.TabControl();
            this.Add = new System.Windows.Forms.TabPage();
            this.tabAddSub = new System.Windows.Forms.TabControl();
            this.Company = new System.Windows.Forms.TabPage();
            this.btnAddCompany = new System.Windows.Forms.Button();
            this.txtCompanyName = new System.Windows.Forms.TextBox();
            this.txtCompanyID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Model = new System.Windows.Forms.TabPage();
            this.cboCompanyName = new System.Windows.Forms.ComboBox();
            this.txtAvailableQty = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnAddModel = new System.Windows.Forms.Button();
            this.txtModelName = new System.Windows.Forms.TextBox();
            this.txtModelID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Mobile = new System.Windows.Forms.TabPage();
            this.cboModelName = new System.Windows.Forms.ComboBox();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnAddMobile = new System.Windows.Forms.Button();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.txtIMEINO = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.UpdateStock = new System.Windows.Forms.TabPage();
            this.SaleReport = new System.Windows.Forms.TabPage();
            this.Employee = new System.Windows.Forms.TabPage();
            this.btnLogout = new System.Windows.Forms.Button();
            this.mainTabControl.SuspendLayout();
            this.Add.SuspendLayout();
            this.tabAddSub.SuspendLayout();
            this.Company.SuspendLayout();
            this.Model.SuspendLayout();
            this.Mobile.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainTabControl
            // 
            this.mainTabControl.Controls.Add(this.Add);
            this.mainTabControl.Controls.Add(this.UpdateStock);
            this.mainTabControl.Controls.Add(this.SaleReport);
            this.mainTabControl.Controls.Add(this.Employee);
            this.mainTabControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainTabControl.Location = new System.Drawing.Point(0, 1);
            this.mainTabControl.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.mainTabControl.Name = "mainTabControl";
            this.mainTabControl.SelectedIndex = 0;
            this.mainTabControl.Size = new System.Drawing.Size(872, 418);
            this.mainTabControl.TabIndex = 0;
            // 
            // Add
            // 
            this.Add.Controls.Add(this.tabAddSub);
            this.Add.Location = new System.Drawing.Point(4, 29);
            this.Add.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Add.Name = "Add";
            this.Add.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Add.Size = new System.Drawing.Size(864, 385);
            this.Add.TabIndex = 0;
            this.Add.Text = "Add";
            this.Add.UseVisualStyleBackColor = true;
            // 
            // tabAddSub
            // 
            this.tabAddSub.Controls.Add(this.Company);
            this.tabAddSub.Controls.Add(this.Model);
            this.tabAddSub.Controls.Add(this.Mobile);
            this.tabAddSub.Location = new System.Drawing.Point(0, 0);
            this.tabAddSub.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabAddSub.Name = "tabAddSub";
            this.tabAddSub.SelectedIndex = 0;
            this.tabAddSub.Size = new System.Drawing.Size(860, 388);
            this.tabAddSub.TabIndex = 0;
            // 
            // Company
            // 
            this.Company.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Company.Controls.Add(this.btnAddCompany);
            this.Company.Controls.Add(this.txtCompanyName);
            this.Company.Controls.Add(this.txtCompanyID);
            this.Company.Controls.Add(this.label2);
            this.Company.Controls.Add(this.label1);
            this.Company.Location = new System.Drawing.Point(4, 29);
            this.Company.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Company.Name = "Company";
            this.Company.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Company.Size = new System.Drawing.Size(852, 355);
            this.Company.TabIndex = 0;
            this.Company.Text = "Company";
            this.Company.UseVisualStyleBackColor = true;
            // 
            // btnAddCompany
            // 
            this.btnAddCompany.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddCompany.Location = new System.Drawing.Point(405, 241);
            this.btnAddCompany.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAddCompany.Name = "btnAddCompany";
            this.btnAddCompany.Size = new System.Drawing.Size(140, 48);
            this.btnAddCompany.TabIndex = 14;
            this.btnAddCompany.Text = "ADD";
            this.btnAddCompany.UseVisualStyleBackColor = true;
            this.btnAddCompany.Click += new System.EventHandler(this.btnAddCompany_Click);
            // 
            // txtCompanyName
            // 
            this.txtCompanyName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCompanyName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCompanyName.Location = new System.Drawing.Point(367, 158);
            this.txtCompanyName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtCompanyName.Name = "txtCompanyName";
            this.txtCompanyName.Size = new System.Drawing.Size(233, 30);
            this.txtCompanyName.TabIndex = 13;
            // 
            // txtCompanyID
            // 
            this.txtCompanyID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCompanyID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCompanyID.Location = new System.Drawing.Point(367, 78);
            this.txtCompanyID.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtCompanyID.Name = "txtCompanyID";
            this.txtCompanyID.Size = new System.Drawing.Size(233, 30);
            this.txtCompanyID.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(117, 165);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 25);
            this.label2.TabIndex = 11;
            this.label2.Text = "CompanyName";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(117, 85);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 25);
            this.label1.TabIndex = 10;
            this.label1.Text = "CompanyID";
            // 
            // Model
            // 
            this.Model.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Model.Controls.Add(this.cboCompanyName);
            this.Model.Controls.Add(this.txtAvailableQty);
            this.Model.Controls.Add(this.label6);
            this.Model.Controls.Add(this.label5);
            this.Model.Controls.Add(this.btnAddModel);
            this.Model.Controls.Add(this.txtModelName);
            this.Model.Controls.Add(this.txtModelID);
            this.Model.Controls.Add(this.label3);
            this.Model.Controls.Add(this.label4);
            this.Model.Location = new System.Drawing.Point(4, 29);
            this.Model.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Model.Name = "Model";
            this.Model.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Model.Size = new System.Drawing.Size(852, 355);
            this.Model.TabIndex = 1;
            this.Model.Text = "Model";
            this.Model.UseVisualStyleBackColor = true;
            // 
            // cboCompanyName
            // 
            this.cboCompanyName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCompanyName.FormattingEnabled = true;
            this.cboCompanyName.Location = new System.Drawing.Point(432, 202);
            this.cboCompanyName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboCompanyName.Name = "cboCompanyName";
            this.cboCompanyName.Size = new System.Drawing.Size(232, 33);
            this.cboCompanyName.TabIndex = 23;
            // 
            // txtAvailableQty
            // 
            this.txtAvailableQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAvailableQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAvailableQty.Location = new System.Drawing.Point(432, 145);
            this.txtAvailableQty.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtAvailableQty.Name = "txtAvailableQty";
            this.txtAvailableQty.Size = new System.Drawing.Size(233, 30);
            this.txtAvailableQty.TabIndex = 22;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(112, 212);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(154, 25);
            this.label6.TabIndex = 21;
            this.label6.Text = "Company Name";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(112, 153);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(170, 25);
            this.label5.TabIndex = 20;
            this.label5.Text = "Available Quantity";
            // 
            // btnAddModel
            // 
            this.btnAddModel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddModel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddModel.Location = new System.Drawing.Point(477, 273);
            this.btnAddModel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAddModel.Name = "btnAddModel";
            this.btnAddModel.Size = new System.Drawing.Size(140, 48);
            this.btnAddModel.TabIndex = 19;
            this.btnAddModel.Text = "ADD";
            this.btnAddModel.UseVisualStyleBackColor = true;
            this.btnAddModel.Click += new System.EventHandler(this.btnAddModel_Click);
            // 
            // txtModelName
            // 
            this.txtModelName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtModelName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtModelName.Location = new System.Drawing.Point(432, 89);
            this.txtModelName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtModelName.Name = "txtModelName";
            this.txtModelName.Size = new System.Drawing.Size(233, 30);
            this.txtModelName.TabIndex = 18;
            // 
            // txtModelID
            // 
            this.txtModelID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtModelID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtModelID.Location = new System.Drawing.Point(432, 22);
            this.txtModelID.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtModelID.Name = "txtModelID";
            this.txtModelID.Size = new System.Drawing.Size(233, 30);
            this.txtModelID.TabIndex = 17;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(112, 96);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 25);
            this.label3.TabIndex = 16;
            this.label3.Text = "Model Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(112, 30);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 25);
            this.label4.TabIndex = 15;
            this.label4.Text = "Model ID";
            // 
            // Mobile
            // 
            this.Mobile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Mobile.Controls.Add(this.cboModelName);
            this.Mobile.Controls.Add(this.txtStatus);
            this.Mobile.Controls.Add(this.label7);
            this.Mobile.Controls.Add(this.label8);
            this.Mobile.Controls.Add(this.btnAddMobile);
            this.Mobile.Controls.Add(this.txtPrice);
            this.Mobile.Controls.Add(this.txtIMEINO);
            this.Mobile.Controls.Add(this.label9);
            this.Mobile.Controls.Add(this.label10);
            this.Mobile.Location = new System.Drawing.Point(4, 29);
            this.Mobile.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Mobile.Name = "Mobile";
            this.Mobile.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Mobile.Size = new System.Drawing.Size(852, 355);
            this.Mobile.TabIndex = 2;
            this.Mobile.Text = "Mobile";
            this.Mobile.UseVisualStyleBackColor = true;
            // 
            // cboModelName
            // 
            this.cboModelName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboModelName.FormattingEnabled = true;
            this.cboModelName.Location = new System.Drawing.Point(467, 92);
            this.cboModelName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboModelName.Name = "cboModelName";
            this.cboModelName.Size = new System.Drawing.Size(232, 33);
            this.cboModelName.TabIndex = 32;
            // 
            // txtStatus
            // 
            this.txtStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStatus.Location = new System.Drawing.Point(467, 151);
            this.txtStatus.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.Size = new System.Drawing.Size(233, 30);
            this.txtStatus.TabIndex = 31;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(147, 218);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 25);
            this.label7.TabIndex = 30;
            this.label7.Text = "Price";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(147, 159);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(68, 25);
            this.label8.TabIndex = 29;
            this.label8.Text = "Status";
            // 
            // btnAddMobile
            // 
            this.btnAddMobile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddMobile.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddMobile.Location = new System.Drawing.Point(512, 279);
            this.btnAddMobile.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAddMobile.Name = "btnAddMobile";
            this.btnAddMobile.Size = new System.Drawing.Size(140, 48);
            this.btnAddMobile.TabIndex = 28;
            this.btnAddMobile.Text = "ADD";
            this.btnAddMobile.UseVisualStyleBackColor = true;
            this.btnAddMobile.Click += new System.EventHandler(this.btnAddMobile_Click);
            // 
            // txtPrice
            // 
            this.txtPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrice.Location = new System.Drawing.Point(467, 215);
            this.txtPrice.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(233, 30);
            this.txtPrice.TabIndex = 27;
            // 
            // txtIMEINO
            // 
            this.txtIMEINO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIMEINO.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIMEINO.Location = new System.Drawing.Point(467, 28);
            this.txtIMEINO.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtIMEINO.Name = "txtIMEINO";
            this.txtIMEINO.Size = new System.Drawing.Size(233, 30);
            this.txtIMEINO.TabIndex = 26;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(147, 102);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(123, 25);
            this.label9.TabIndex = 25;
            this.label9.Text = "Model Name";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(147, 36);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(82, 25);
            this.label10.TabIndex = 24;
            this.label10.Text = "IMEI No";
            // 
            // UpdateStock
            // 
            this.UpdateStock.Location = new System.Drawing.Point(4, 29);
            this.UpdateStock.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.UpdateStock.Name = "UpdateStock";
            this.UpdateStock.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.UpdateStock.Size = new System.Drawing.Size(864, 385);
            this.UpdateStock.TabIndex = 1;
            this.UpdateStock.Text = "Update Stock";
            this.UpdateStock.UseVisualStyleBackColor = true;
            // 
            // SaleReport
            // 
            this.SaleReport.Location = new System.Drawing.Point(4, 29);
            this.SaleReport.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.SaleReport.Name = "SaleReport";
            this.SaleReport.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.SaleReport.Size = new System.Drawing.Size(864, 385);
            this.SaleReport.TabIndex = 2;
            this.SaleReport.Text = "Sale Report";
            this.SaleReport.UseVisualStyleBackColor = true;
            // 
            // Employee
            // 
            this.Employee.Location = new System.Drawing.Point(4, 29);
            this.Employee.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Employee.Name = "Employee";
            this.Employee.Size = new System.Drawing.Size(864, 385);
            this.Employee.TabIndex = 3;
            this.Employee.Text = "Employee";
            this.Employee.UseVisualStyleBackColor = true;
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.Khaki;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.ForeColor = System.Drawing.Color.OrangeRed;
            this.btnLogout.Location = new System.Drawing.Point(683, 441);
            this.btnLogout.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(140, 48);
            this.btnLogout.TabIndex = 15;
            this.btnLogout.Text = "Log Out";
            this.btnLogout.UseVisualStyleBackColor = false;
            // 
            // AdminHomepage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Linen;
            this.ClientSize = new System.Drawing.Size(876, 514);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.mainTabControl);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "AdminHomepage";
            this.Text = "AdminHomepage";
            this.mainTabControl.ResumeLayout(false);
            this.Add.ResumeLayout(false);
            this.tabAddSub.ResumeLayout(false);
            this.Company.ResumeLayout(false);
            this.Company.PerformLayout();
            this.Model.ResumeLayout(false);
            this.Model.PerformLayout();
            this.Mobile.ResumeLayout(false);
            this.Mobile.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl mainTabControl;
        private System.Windows.Forms.TabPage Add;
        private System.Windows.Forms.TabPage UpdateStock;
        private System.Windows.Forms.TabPage SaleReport;
        private System.Windows.Forms.TabPage Employee;
        private System.Windows.Forms.TabControl tabAddSub;
        private System.Windows.Forms.TabPage Company;
        private System.Windows.Forms.TabPage Model;
        private System.Windows.Forms.TabPage Mobile;
        private System.Windows.Forms.Button btnAddCompany;
        private System.Windows.Forms.TextBox txtCompanyName;
        private System.Windows.Forms.TextBox txtCompanyID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnAddModel;
        private System.Windows.Forms.TextBox txtModelName;
        private System.Windows.Forms.TextBox txtModelID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboCompanyName;
        private System.Windows.Forms.TextBox txtAvailableQty;
        private System.Windows.Forms.ComboBox cboModelName;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnAddMobile;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.TextBox txtIMEINO;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnLogout;
    }
}