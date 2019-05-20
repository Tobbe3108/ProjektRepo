namespace Bol_IT
{
    partial class Messagebox_PriceCalculator
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
            this.btnCalculate = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.cbGardenFlag = new System.Windows.Forms.CheckBox();
            this.cbBathroom = new System.Windows.Forms.ComboBox();
            this.cbKitchen = new System.Windows.Forms.ComboBox();
            this.cbStyle = new System.Windows.Forms.ComboBox();
            this.cbInteriorDesign = new System.Windows.Forms.ComboBox();
            this.cbCondition = new System.Windows.Forms.ComboBox();
            this.cbZipcode = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCalculate
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.btnCalculate, 2);
            this.btnCalculate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCalculate.Location = new System.Drawing.Point(3, 220);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(287, 32);
            this.btnCalculate.TabIndex = 0;
            this.btnCalculate.Text = "Beregn pris";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 66.66666F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.label7, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.cbZipcode, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.cbCondition, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.cbInteriorDesign, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.cbStyle, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.cbKitchen, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.cbBathroom, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.cbGardenFlag, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.btnCalculate, 0, 7);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 8;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(293, 255);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // cbGardenFlag
            // 
            this.cbGardenFlag.AutoSize = true;
            this.cbGardenFlag.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbGardenFlag.Location = new System.Drawing.Point(100, 189);
            this.cbGardenFlag.Name = "cbGardenFlag";
            this.cbGardenFlag.Size = new System.Drawing.Size(190, 25);
            this.cbGardenFlag.TabIndex = 7;
            this.cbGardenFlag.UseVisualStyleBackColor = true;
            // 
            // cbBathroom
            // 
            this.cbBathroom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbBathroom.FormattingEnabled = true;
            this.cbBathroom.Items.AddRange(new object[] {
            "Gammelt",
            "Standart",
            "Nyt"});
            this.cbBathroom.Location = new System.Drawing.Point(100, 158);
            this.cbBathroom.Name = "cbBathroom";
            this.cbBathroom.Size = new System.Drawing.Size(190, 21);
            this.cbBathroom.TabIndex = 13;
            // 
            // cbKitchen
            // 
            this.cbKitchen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbKitchen.FormattingEnabled = true;
            this.cbKitchen.Items.AddRange(new object[] {
            "Gammelt",
            "Standart",
            "Nyt"});
            this.cbKitchen.Location = new System.Drawing.Point(100, 127);
            this.cbKitchen.Name = "cbKitchen";
            this.cbKitchen.Size = new System.Drawing.Size(190, 21);
            this.cbKitchen.TabIndex = 12;
            // 
            // cbStyle
            // 
            this.cbStyle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbStyle.FormattingEnabled = true;
            this.cbStyle.Items.AddRange(new object[] {
            "Dårlig",
            "Normal",
            "Fin"});
            this.cbStyle.Location = new System.Drawing.Point(100, 96);
            this.cbStyle.Name = "cbStyle";
            this.cbStyle.Size = new System.Drawing.Size(190, 21);
            this.cbStyle.TabIndex = 11;
            // 
            // cbInteriorDesign
            // 
            this.cbInteriorDesign.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbInteriorDesign.FormattingEnabled = true;
            this.cbInteriorDesign.Items.AddRange(new object[] {
            "Dårlig",
            "Normal",
            "Fin"});
            this.cbInteriorDesign.Location = new System.Drawing.Point(100, 65);
            this.cbInteriorDesign.Name = "cbInteriorDesign";
            this.cbInteriorDesign.Size = new System.Drawing.Size(190, 21);
            this.cbInteriorDesign.TabIndex = 10;
            // 
            // cbCondition
            // 
            this.cbCondition.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbCondition.FormattingEnabled = true;
            this.cbCondition.Items.AddRange(new object[] {
            "Dårlig",
            "Normal",
            "Fin"});
            this.cbCondition.Location = new System.Drawing.Point(100, 34);
            this.cbCondition.Name = "cbCondition";
            this.cbCondition.Size = new System.Drawing.Size(190, 21);
            this.cbCondition.TabIndex = 9;
            // 
            // cbZipcode
            // 
            this.cbZipcode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbZipcode.FormattingEnabled = true;
            this.cbZipcode.Location = new System.Drawing.Point(100, 3);
            this.cbZipcode.Name = "cbZipcode";
            this.cbZipcode.Size = new System.Drawing.Size(190, 21);
            this.cbZipcode.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Location = new System.Drawing.Point(3, 186);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(91, 31);
            this.label7.TabIndex = 6;
            this.label7.Text = "Have";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Location = new System.Drawing.Point(3, 155);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 31);
            this.label6.TabIndex = 5;
            this.label6.Text = "Badeværelse(r)";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(3, 124);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 31);
            this.label5.TabIndex = 4;
            this.label5.Text = "Køkken";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(3, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 31);
            this.label4.TabIndex = 3;
            this.label4.Text = "Stil";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 31);
            this.label3.TabIndex = 2;
            this.label3.Text = "Indretning";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 31);
            this.label2.TabIndex = 1;
            this.label2.Text = "Stand";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Postnummer";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Messagebox_PriceCalculator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(293, 255);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Messagebox_PriceCalculator";
            this.Text = "Messagebox_PriceCalculator";
            this.Load += new System.EventHandler(this.Messagebox_PriceCalculator_Load);
            this.SizeChanged += new System.EventHandler(this.Messagebox_PriceCalculator_SizeChanged);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbZipcode;
        private System.Windows.Forms.ComboBox cbCondition;
        private System.Windows.Forms.ComboBox cbInteriorDesign;
        private System.Windows.Forms.ComboBox cbStyle;
        private System.Windows.Forms.ComboBox cbKitchen;
        private System.Windows.Forms.ComboBox cbBathroom;
        private System.Windows.Forms.CheckBox cbGardenFlag;
    }
}