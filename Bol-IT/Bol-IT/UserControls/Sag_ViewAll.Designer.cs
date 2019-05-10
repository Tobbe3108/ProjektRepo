namespace Bol_IT
{
    partial class Sag_ViewAll
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvSager = new System.Windows.Forms.DataGridView();
            this.Rediger = new System.Windows.Forms.DataGridViewButtonColumn();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.btnCreateSag = new System.Windows.Forms.Button();
            this.btnToFile = new System.Windows.Forms.Button();
            this.btnStatistic = new System.Windows.Forms.Button();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.rtbSearch = new System.Windows.Forms.RichTextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.cbSoldFlag = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSager)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 2.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 95F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 2.5F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 2.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 95F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 2.5F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1584, 897);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.dgvSager, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel4, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(39, 22);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1504, 852);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // dgvSager
            // 
            this.dgvSager.AllowUserToAddRows = false;
            this.dgvSager.AllowUserToDeleteRows = false;
            this.dgvSager.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSager.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvSager.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSager.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Rediger});
            this.dgvSager.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSager.Location = new System.Drawing.Point(6, 133);
            this.dgvSager.Margin = new System.Windows.Forms.Padding(6);
            this.dgvSager.Name = "dgvSager";
            this.dgvSager.ReadOnly = true;
            this.dgvSager.Size = new System.Drawing.Size(1492, 627);
            this.dgvSager.TabIndex = 0;
            this.dgvSager.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSager_CellContentClick);
            // 
            // Rediger
            // 
            this.Rediger.HeaderText = "Rediger";
            this.Rediger.Name = "Rediger";
            this.Rediger.ReadOnly = true;
            this.Rediger.Text = "Rediger";
            this.Rediger.ToolTipText = "Rediger";
            this.Rediger.UseColumnTextForButtonValue = true;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 4;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel3.Controls.Add(this.btnCreateSag, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnToFile, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnStatistic, 2, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 766);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1504, 86);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // btnCreateSag
            // 
            this.btnCreateSag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(251)))));
            this.btnCreateSag.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCreateSag.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(217)))), ((int)(((byte)(228)))));
            this.btnCreateSag.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateSag.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateSag.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(74)))), ((int)(((byte)(80)))));
            this.btnCreateSag.Location = new System.Drawing.Point(6, 6);
            this.btnCreateSag.Margin = new System.Windows.Forms.Padding(6);
            this.btnCreateSag.Name = "btnCreateSag";
            this.btnCreateSag.Size = new System.Drawing.Size(288, 74);
            this.btnCreateSag.TabIndex = 0;
            this.btnCreateSag.Text = "Tilføj sag";
            this.btnCreateSag.UseVisualStyleBackColor = false;
            this.btnCreateSag.Click += new System.EventHandler(this.btnCreateSag_Click);
            // 
            // btnToFile
            // 
            this.btnToFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(251)))));
            this.btnToFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnToFile.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(217)))), ((int)(((byte)(228)))));
            this.btnToFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToFile.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnToFile.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(74)))), ((int)(((byte)(80)))));
            this.btnToFile.Location = new System.Drawing.Point(306, 6);
            this.btnToFile.Margin = new System.Windows.Forms.Padding(6);
            this.btnToFile.Name = "btnToFile";
            this.btnToFile.Size = new System.Drawing.Size(288, 74);
            this.btnToFile.TabIndex = 1;
            this.btnToFile.Text = "Udskriv fil";
            this.btnToFile.UseVisualStyleBackColor = false;
            this.btnToFile.Click += new System.EventHandler(this.btnToFile_Click);
            // 
            // btnStatistic
            // 
            this.btnStatistic.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(251)))));
            this.btnStatistic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnStatistic.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(217)))), ((int)(((byte)(228)))));
            this.btnStatistic.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStatistic.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStatistic.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(74)))), ((int)(((byte)(80)))));
            this.btnStatistic.Location = new System.Drawing.Point(606, 6);
            this.btnStatistic.Margin = new System.Windows.Forms.Padding(6);
            this.btnStatistic.Name = "btnStatistic";
            this.btnStatistic.Size = new System.Drawing.Size(288, 74);
            this.btnStatistic.TabIndex = 2;
            this.btnStatistic.Text = "Udskriv statistik";
            this.btnStatistic.UseVisualStyleBackColor = false;
            this.btnStatistic.Click += new System.EventHandler(this.btnStatistic_Click);
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel4.Controls.Add(this.rtbSearch, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.lblSearch, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.cbSoldFlag, 1, 1);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 66.66666F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(1504, 127);
            this.tableLayoutPanel4.TabIndex = 2;
            // 
            // rtbSearch
            // 
            this.rtbSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbSearch.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbSearch.Location = new System.Drawing.Point(6, 48);
            this.rtbSearch.Margin = new System.Windows.Forms.Padding(6);
            this.rtbSearch.Name = "rtbSearch";
            this.rtbSearch.Size = new System.Drawing.Size(740, 73);
            this.rtbSearch.TabIndex = 1;
            this.rtbSearch.Text = "";
            this.rtbSearch.TextChanged += new System.EventHandler(this.rtbSearch_TextChanged);
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSearch.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(74)))), ((int)(((byte)(80)))));
            this.lblSearch.Location = new System.Drawing.Point(6, 0);
            this.lblSearch.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(740, 42);
            this.lblSearch.TabIndex = 2;
            this.lblSearch.Text = "Søg efter: Navn (Mangler resten)";
            this.lblSearch.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // cbSoldFlag
            // 
            this.cbSoldFlag.AutoSize = true;
            this.cbSoldFlag.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbSoldFlag.Font = new System.Drawing.Font("Tahoma", 8.142858F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSoldFlag.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(74)))), ((int)(((byte)(80)))));
            this.cbSoldFlag.Location = new System.Drawing.Point(762, 45);
            this.cbSoldFlag.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.cbSoldFlag.Name = "cbSoldFlag";
            this.cbSoldFlag.Size = new System.Drawing.Size(739, 79);
            this.cbSoldFlag.TabIndex = 3;
            this.cbSoldFlag.Text = "Inkluder solgte boligere";
            this.cbSoldFlag.UseVisualStyleBackColor = true;
            this.cbSoldFlag.CheckedChanged += new System.EventHandler(this.cbSoldFlag_CheckedChanged);
            // 
            // Sag_ViewAll
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "Sag_ViewAll";
            this.Size = new System.Drawing.Size(1584, 897);
            this.Load += new System.EventHandler(this.Sag_ViewAll_Load);
            this.SizeChanged += new System.EventHandler(this.Sag_ViewAll_SizeChanged);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSager)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.DataGridView dgvSager;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.RichTextBox rtbSearch;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.Button btnCreateSag;
        private System.Windows.Forms.Button btnStatistic;
        private System.Windows.Forms.Button btnToFile;
        private System.Windows.Forms.DataGridViewButtonColumn Rediger;
        private System.Windows.Forms.CheckBox cbSoldFlag;
    }
}
