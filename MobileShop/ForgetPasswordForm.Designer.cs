
namespace MobileShop
{
    partial class ForgetPasswordForm
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
            this.respond = new System.Windows.Forms.Label();
            this.submitBtn = new System.Windows.Forms.Button();
            this.txtHint = new System.Windows.Forms.TextBox();
            this.txtUser = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.linkLoginPage = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // respond
            // 
            this.respond.AutoSize = true;
            this.respond.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.respond.Location = new System.Drawing.Point(225, 325);
            this.respond.Name = "respond";
            this.respond.Size = new System.Drawing.Size(0, 32);
            this.respond.TabIndex = 14;
            // 
            // submitBtn
            // 
            this.submitBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.submitBtn.Location = new System.Drawing.Point(400, 241);
            this.submitBtn.Name = "submitBtn";
            this.submitBtn.Size = new System.Drawing.Size(119, 50);
            this.submitBtn.TabIndex = 13;
            this.submitBtn.Text = "Submit";
            this.submitBtn.UseVisualStyleBackColor = true;
            this.submitBtn.Click += new System.EventHandler(this.submitBtn_Click);
            // 
            // txtHint
            // 
            this.txtHint.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtHint.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHint.Location = new System.Drawing.Point(344, 171);
            this.txtHint.Margin = new System.Windows.Forms.Padding(4);
            this.txtHint.Name = "txtHint";
            this.txtHint.Size = new System.Drawing.Size(233, 30);
            this.txtHint.TabIndex = 12;
            // 
            // txtUser
            // 
            this.txtUser.AutoSize = true;
            this.txtUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUser.Location = new System.Drawing.Point(223, 178);
            this.txtUser.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(46, 25);
            this.txtUser.TabIndex = 11;
            this.txtUser.Text = "Hint";
            // 
            // txtUsername
            // 
            this.txtUsername.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsername.Location = new System.Drawing.Point(344, 94);
            this.txtUsername.Margin = new System.Windows.Forms.Padding(4);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(233, 30);
            this.txtUsername.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(223, 101);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 25);
            this.label1.TabIndex = 9;
            this.label1.Text = "UserName";
            // 
            // linkLoginPage
            // 
            this.linkLoginPage.AutoSize = true;
            this.linkLoginPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLoginPage.ForeColor = System.Drawing.SystemColors.ControlText;
            this.linkLoginPage.LinkColor = System.Drawing.Color.DeepPink;
            this.linkLoginPage.Location = new System.Drawing.Point(551, 356);
            this.linkLoginPage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.linkLoginPage.Name = "linkLoginPage";
            this.linkLoginPage.Size = new System.Drawing.Size(151, 32);
            this.linkLoginPage.TabIndex = 15;
            this.linkLoginPage.TabStop = true;
            this.linkLoginPage.Text = "login Page";
            this.linkLoginPage.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLoginPage_LinkClicked);
            // 
            // ForgetPasswordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Linen;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.linkLoginPage);
            this.Controls.Add(this.respond);
            this.Controls.Add(this.submitBtn);
            this.Controls.Add(this.txtHint);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.label1);
            this.Name = "ForgetPasswordForm";
            this.Text = "ForgetPasswordForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label respond;
        private System.Windows.Forms.Button submitBtn;
        private System.Windows.Forms.TextBox txtHint;
        private System.Windows.Forms.Label txtUser;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel linkLoginPage;
    }
}