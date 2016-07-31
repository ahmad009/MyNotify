namespace MyNotify
{
    partial class frmNotify
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
            this.components = new System.ComponentModel.Container();
            this.Message_lbl = new System.Windows.Forms.Label();
            this.Title_lbl = new System.Windows.Forms.Label();
            this.icon = new System.Windows.Forms.PictureBox();
            this.hideTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.icon)).BeginInit();
            this.SuspendLayout();
            // 
            // Message_lbl
            // 
            this.Message_lbl.AutoSize = true;
            this.Message_lbl.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.Message_lbl.ForeColor = System.Drawing.Color.White;
            this.Message_lbl.Location = new System.Drawing.Point(11, 67);
            this.Message_lbl.Name = "Message_lbl";
            this.Message_lbl.Size = new System.Drawing.Size(68, 21);
            this.Message_lbl.TabIndex = 8;
            this.Message_lbl.Text = "Message";
            // 
            // Title_lbl
            // 
            this.Title_lbl.AutoSize = true;
            this.Title_lbl.Font = new System.Drawing.Font("Segoe UI Light", 15.75F);
            this.Title_lbl.ForeColor = System.Drawing.Color.White;
            this.Title_lbl.Location = new System.Drawing.Point(46, 19);
            this.Title_lbl.Name = "Title_lbl";
            this.Title_lbl.Size = new System.Drawing.Size(49, 30);
            this.Title_lbl.TabIndex = 7;
            this.Title_lbl.Text = "Title";
            // 
            // icon
            // 
            this.icon.Location = new System.Drawing.Point(15, 24);
            this.icon.Name = "icon";
            this.icon.Size = new System.Drawing.Size(25, 25);
            this.icon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.icon.TabIndex = 6;
            this.icon.TabStop = false;
            // 
            // hideTimer
            // 
            this.hideTimer.Interval = 5000;
            this.hideTimer.Tick += new System.EventHandler(this.hideTimer_Tick);
            // 
            // frmNotify
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(192)))), ((int)(((byte)(222)))));
            this.ClientSize = new System.Drawing.Size(284, 113);
            this.ControlBox = false;
            this.Controls.Add(this.Message_lbl);
            this.Controls.Add(this.Title_lbl);
            this.Controls.Add(this.icon);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmNotify";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmNotify_Load);
            ((System.ComponentModel.ISupportInitialize)(this.icon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Message_lbl;
        private System.Windows.Forms.Label Title_lbl;
        private System.Windows.Forms.PictureBox icon;
        public System.Windows.Forms.Timer hideTimer;
    }
}

