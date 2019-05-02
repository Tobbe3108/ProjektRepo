namespace Bol_IT
{
    partial class Form1
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
            this.pnlMenuBarTop = new System.Windows.Forms.Panel();
            this.pnlMenuBarLeft = new System.Windows.Forms.Panel();
            this.pnlContainer = new System.Windows.Forms.Panel();
            this.pnlSizerBottom = new System.Windows.Forms.Panel();
            this.pnlSizerCorner = new System.Windows.Forms.Panel();
            this.pnlSizerRight = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.MaxPriceRtb = new System.Windows.Forms.RichTextBox();
            this.MinPriceRtb = new System.Windows.Forms.RichTextBox();
            this.PropertyTypeCb = new System.Windows.Forms.ComboBox();
            this.pnlContainer.SuspendLayout();
            this.pnlSizerBottom.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMenuBarTop
            // 
            this.pnlMenuBarTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMenuBarTop.Location = new System.Drawing.Point(96, 0);
            this.pnlMenuBarTop.Name = "pnlMenuBarTop";
            this.pnlMenuBarTop.Size = new System.Drawing.Size(864, 54);
            this.pnlMenuBarTop.TabIndex = 2;
            // 
            // pnlMenuBarLeft
            // 
            this.pnlMenuBarLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMenuBarLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlMenuBarLeft.Name = "pnlMenuBarLeft";
            this.pnlMenuBarLeft.Size = new System.Drawing.Size(96, 540);
            this.pnlMenuBarLeft.TabIndex = 1;
            // 
            // pnlContainer
            // 
            this.pnlContainer.Controls.Add(this.panel1);
            this.pnlContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContainer.Location = new System.Drawing.Point(96, 54);
            this.pnlContainer.Name = "pnlContainer";
            this.pnlContainer.Size = new System.Drawing.Size(864, 486);
            this.pnlContainer.TabIndex = 3;
            // 
            // pnlSizerBottom
            // 
            this.pnlSizerBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(104)))), ((int)(((byte)(162)))));
            this.pnlSizerBottom.Controls.Add(this.pnlSizerCorner);
            this.pnlSizerBottom.Cursor = System.Windows.Forms.Cursors.SizeNS;
            this.pnlSizerBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlSizerBottom.Location = new System.Drawing.Point(96, 535);
            this.pnlSizerBottom.Name = "pnlSizerBottom";
            this.pnlSizerBottom.Size = new System.Drawing.Size(864, 5);
            this.pnlSizerBottom.TabIndex = 4;
            this.pnlSizerBottom.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlSizerBottom_MouseDown);
            this.pnlSizerBottom.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlSizerBottom_MouseMove);
            this.pnlSizerBottom.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnlSizerBottom_MouseUp);
            // 
            // pnlSizerCorner
            // 
            this.pnlSizerCorner.Cursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.pnlSizerCorner.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlSizerCorner.Location = new System.Drawing.Point(859, 0);
            this.pnlSizerCorner.Name = "pnlSizerCorner";
            this.pnlSizerCorner.Size = new System.Drawing.Size(5, 5);
            this.pnlSizerCorner.TabIndex = 0;
            this.pnlSizerCorner.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlSizerCorner_MouseDown);
            this.pnlSizerCorner.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlSizerCorner_MouseMove);
            this.pnlSizerCorner.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnlSizerCorner_MouseUp);
            // 
            // pnlSizerRight
            // 
            this.pnlSizerRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(104)))), ((int)(((byte)(162)))));
            this.pnlSizerRight.Cursor = System.Windows.Forms.Cursors.SizeWE;
            this.pnlSizerRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlSizerRight.Location = new System.Drawing.Point(955, 54);
            this.pnlSizerRight.Name = "pnlSizerRight";
            this.pnlSizerRight.Size = new System.Drawing.Size(5, 481);
            this.pnlSizerRight.TabIndex = 5;
            this.pnlSizerRight.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlSizerRight_MouseDown);
            this.pnlSizerRight.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlSizerRight_MouseMove);
            this.pnlSizerRight.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnlSizerRight_MouseUp);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.MaxPriceRtb);
            this.panel1.Controls.Add(this.MinPriceRtb);
            this.panel1.Controls.Add(this.PropertyTypeCb);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(864, 486);
            this.panel1.TabIndex = 5;
            // 
            // MaxPriceRtb
            // 
            this.MaxPriceRtb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.MaxPriceRtb.Location = new System.Drawing.Point(764, 0);
            this.MaxPriceRtb.Name = "MaxPriceRtb";
            this.MaxPriceRtb.Size = new System.Drawing.Size(97, 38);
            this.MaxPriceRtb.TabIndex = 2;
            this.MaxPriceRtb.Text = "";
            // 
            // MinPriceRtb
            // 
            this.MinPriceRtb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.MinPriceRtb.Location = new System.Drawing.Point(666, 0);
            this.MinPriceRtb.Name = "MinPriceRtb";
            this.MinPriceRtb.Size = new System.Drawing.Size(97, 38);
            this.MinPriceRtb.TabIndex = 1;
            this.MinPriceRtb.Text = "";
            // 
            // PropertyTypeCb
            // 
            this.PropertyTypeCb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PropertyTypeCb.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PropertyTypeCb.FormattingEnabled = true;
            this.PropertyTypeCb.Location = new System.Drawing.Point(3, 1);
            this.PropertyTypeCb.Name = "PropertyTypeCb";
            this.PropertyTypeCb.Size = new System.Drawing.Size(657, 39);
            this.PropertyTypeCb.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 540);
            this.Controls.Add(this.pnlSizerRight);
            this.Controls.Add(this.pnlSizerBottom);
            this.Controls.Add(this.pnlContainer);
            this.Controls.Add(this.pnlMenuBarTop);
            this.Controls.Add(this.pnlMenuBarLeft);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.pnlContainer.ResumeLayout(false);
            this.pnlSizerBottom.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlMenuBarTop;
        private System.Windows.Forms.Panel pnlMenuBarLeft;
        private System.Windows.Forms.Panel pnlContainer;
        private System.Windows.Forms.Panel pnlSizerBottom;
        private System.Windows.Forms.Panel pnlSizerCorner;
        private System.Windows.Forms.Panel pnlSizerRight;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RichTextBox MaxPriceRtb;
        private System.Windows.Forms.RichTextBox MinPriceRtb;
        private System.Windows.Forms.ComboBox PropertyTypeCb;
    }
}

