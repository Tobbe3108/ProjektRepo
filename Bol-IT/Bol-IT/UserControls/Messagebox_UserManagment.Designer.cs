namespace Bol_IT
{
    partial class Messagebox_UserManagment
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblTitleLogin = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblMessage = new System.Windows.Forms.Label();
            this.lblForgotPassword = new System.Windows.Forms.Label();
            this.btnUpdateUser = new System.Windows.Forms.Button();
            this.btnMakeNewUser = new System.Windows.Forms.Button();
            this.tbUsername = new System.Windows.Forms.TextBox();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.Controls.Add(this.lblTitleLogin, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblUsername, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblPassword, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.lblMessage, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblForgotPassword, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.btnUpdateUser, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.btnMakeNewUser, 2, 5);
            this.tableLayoutPanel1.Controls.Add(this.tbUsername, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.tbPassword, 2, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 8;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(769, 381);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // lblTitleLogin
            // 
            this.lblTitleLogin.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.lblTitleLogin, 2);
            this.lblTitleLogin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitleLogin.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitleLogin.Location = new System.Drawing.Point(79, 38);
            this.lblTitleLogin.Name = "lblTitleLogin";
            this.lblTitleLogin.Size = new System.Drawing.Size(608, 57);
            this.lblTitleLogin.TabIndex = 0;
            this.lblTitleLogin.Text = "Brugerhåndtering";
            this.lblTitleLogin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblUsername.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsername.Location = new System.Drawing.Point(79, 148);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(301, 53);
            this.lblUsername.TabIndex = 1;
            this.lblUsername.Text = "Brugernavn";
            this.lblUsername.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPassword.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.Location = new System.Drawing.Point(79, 201);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(301, 53);
            this.lblPassword.TabIndex = 4;
            this.lblPassword.Text = "Kodeord";
            this.lblPassword.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.lblMessage, 2);
            this.lblMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMessage.Location = new System.Drawing.Point(79, 95);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(608, 53);
            this.lblMessage.TabIndex = 7;
            this.lblMessage.Text = "Forkert brugernavn eller kodeord. Prøv igen.";
            this.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMessage.Visible = false;
            // 
            // lblForgotPassword
            // 
            this.lblForgotPassword.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.lblForgotPassword, 2);
            this.lblForgotPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblForgotPassword.Location = new System.Drawing.Point(79, 299);
            this.lblForgotPassword.Name = "lblForgotPassword";
            this.lblForgotPassword.Size = new System.Drawing.Size(608, 41);
            this.lblForgotPassword.TabIndex = 8;
            this.lblForgotPassword.Text = "Glemt kodeord? Tryk her for et kodeords reset.";
            this.lblForgotPassword.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnUpdateUser
            // 
            this.btnUpdateUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnUpdateUser.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateUser.Location = new System.Drawing.Point(79, 257);
            this.btnUpdateUser.Name = "btnUpdateUser";
            this.btnUpdateUser.Size = new System.Drawing.Size(301, 39);
            this.btnUpdateUser.TabIndex = 9;
            this.btnUpdateUser.Text = "Opdater bruger";
            this.btnUpdateUser.UseVisualStyleBackColor = true;
            this.btnUpdateUser.Click += new System.EventHandler(this.btnUpdateUser_Click);
            // 
            // btnMakeNewUser
            // 
            this.btnMakeNewUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMakeNewUser.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMakeNewUser.Location = new System.Drawing.Point(386, 257);
            this.btnMakeNewUser.Name = "btnMakeNewUser";
            this.btnMakeNewUser.Size = new System.Drawing.Size(301, 39);
            this.btnMakeNewUser.TabIndex = 10;
            this.btnMakeNewUser.Text = "Lav ny bruger";
            this.btnMakeNewUser.UseVisualStyleBackColor = true;
            this.btnMakeNewUser.Click += new System.EventHandler(this.btnMakeNewUser_Click);
            // 
            // tbUsername
            // 
            this.tbUsername.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.tbUsername.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.RecentlyUsedList;
            this.tbUsername.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbUsername.Location = new System.Drawing.Point(386, 151);
            this.tbUsername.Name = "tbUsername";
            this.tbUsername.Size = new System.Drawing.Size(301, 20);
            this.tbUsername.TabIndex = 11;
            // 
            // tbPassword
            // 
            this.tbPassword.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.tbPassword.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.RecentlyUsedList;
            this.tbPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbPassword.Location = new System.Drawing.Point(386, 204);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(301, 20);
            this.tbPassword.TabIndex = 12;
            // 
            // Messagebox_UserManagment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(769, 381);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Messagebox_UserManagment";
            this.Text = "Messagebox_UserManagment";
            this.Load += new System.EventHandler(this.Messagebox_UserManagment_Load);
            this.SizeChanged += new System.EventHandler(this.Messagebox_UserManagment_SizeChanged);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblTitleLogin;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Label lblForgotPassword;
        private System.Windows.Forms.Button btnUpdateUser;
        private System.Windows.Forms.Button btnMakeNewUser;
        private System.Windows.Forms.TextBox tbUsername;
        private System.Windows.Forms.TextBox tbPassword;
    }
}