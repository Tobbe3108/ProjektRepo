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
            this.pnlSizerBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMenuBarTop
            // 
            this.pnlMenuBarTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMenuBarTop.Location = new System.Drawing.Point(96, 0);
            this.pnlMenuBarTop.Name = "pnlMenuBarTop";
            this.pnlMenuBarTop.Size = new System.Drawing.Size(859, 54);
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
            this.pnlContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContainer.Location = new System.Drawing.Point(96, 0);
            this.pnlContainer.Name = "pnlContainer";
            this.pnlContainer.Size = new System.Drawing.Size(864, 540);
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
            this.pnlSizerRight.Location = new System.Drawing.Point(955, 0);
            this.pnlSizerRight.Name = "pnlSizerRight";
            this.pnlSizerRight.Size = new System.Drawing.Size(5, 535);
            this.pnlSizerRight.TabIndex = 5;
            this.pnlSizerRight.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlSizerRight_MouseDown);
            this.pnlSizerRight.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlSizerRight_MouseMove);
            this.pnlSizerRight.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnlSizerRight_MouseUp);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 540);
            this.Controls.Add(this.pnlMenuBarTop);
            this.Controls.Add(this.pnlSizerRight);
            this.Controls.Add(this.pnlSizerBottom);
            this.Controls.Add(this.pnlContainer);
            this.Controls.Add(this.pnlMenuBarLeft);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.pnlSizerBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlMenuBarTop;
        private System.Windows.Forms.Panel pnlMenuBarLeft;
        private System.Windows.Forms.Panel pnlContainer;
        private System.Windows.Forms.Panel pnlSizerBottom;
        private System.Windows.Forms.Panel pnlSizerCorner;
        private System.Windows.Forms.Panel pnlSizerRight;
    }
}

