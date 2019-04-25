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
            this.menuBar_Top1 = new Bol_IT.UserControls.MenuBar_Top();
            this.pnlMenuBarLeft = new System.Windows.Forms.Panel();
            this.menuBar_Left1 = new Bol_IT.UserControls.MenuBar_Left();
            this.pnlMainUserControl = new System.Windows.Forms.Panel();
            this.pnlMenuBarTop.SuspendLayout();
            this.pnlMenuBarLeft.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMenuBarTop
            // 
            this.pnlMenuBarTop.Controls.Add(this.menuBar_Top1);
            this.pnlMenuBarTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMenuBarTop.Location = new System.Drawing.Point(0, 0);
            this.pnlMenuBarTop.Name = "pnlMenuBarTop";
            this.pnlMenuBarTop.Size = new System.Drawing.Size(960, 54);
            this.pnlMenuBarTop.TabIndex = 1;
            // 
            // menuBar_Top1
            // 
            this.menuBar_Top1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.menuBar_Top1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menuBar_Top1.Location = new System.Drawing.Point(0, 0);
            this.menuBar_Top1.Name = "menuBar_Top1";
            this.menuBar_Top1.Size = new System.Drawing.Size(960, 54);
            this.menuBar_Top1.TabIndex = 0;
            // 
            // pnlMenuBarLeft
            // 
            this.pnlMenuBarLeft.Controls.Add(this.menuBar_Left1);
            this.pnlMenuBarLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMenuBarLeft.Location = new System.Drawing.Point(0, 54);
            this.pnlMenuBarLeft.Name = "pnlMenuBarLeft";
            this.pnlMenuBarLeft.Size = new System.Drawing.Size(96, 486);
            this.pnlMenuBarLeft.TabIndex = 2;
            // 
            // menuBar_Left1
            // 
            this.menuBar_Left1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.menuBar_Left1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menuBar_Left1.Location = new System.Drawing.Point(0, 0);
            this.menuBar_Left1.Name = "menuBar_Left1";
            this.menuBar_Left1.Size = new System.Drawing.Size(96, 486);
            this.menuBar_Left1.TabIndex = 0;
            // 
            // pnlMainUserControl
            // 
            this.pnlMainUserControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMainUserControl.Location = new System.Drawing.Point(96, 54);
            this.pnlMainUserControl.Name = "pnlMainUserControl";
            this.pnlMainUserControl.Size = new System.Drawing.Size(864, 486);
            this.pnlMainUserControl.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 540);
            this.Controls.Add(this.pnlMainUserControl);
            this.Controls.Add(this.pnlMenuBarLeft);
            this.Controls.Add(this.pnlMenuBarTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.pnlMenuBarTop.ResumeLayout(false);
            this.pnlMenuBarLeft.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlMenuBarTop;
        private UserControls.MenuBar_Top menuBar_Top1;
        private System.Windows.Forms.Panel pnlMenuBarLeft;
        private UserControls.MenuBar_Left menuBar_Left1;
        private System.Windows.Forms.Panel pnlMainUserControl;
    }
}

