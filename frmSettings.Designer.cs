namespace Wordle_SDD
{
    partial class frmSettings
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.chkOnScreenKeyboard = new System.Windows.Forms.CheckBox();
            this.chkHighContrast = new System.Windows.Forms.CheckBox();
            this.lblGraphicsTitle = new System.Windows.Forms.Label();
            this.chkDarkMode = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.chkOnScreenKeyboard);
            this.panel1.Controls.Add(this.chkHighContrast);
            this.panel1.Controls.Add(this.lblGraphicsTitle);
            this.panel1.Controls.Add(this.chkDarkMode);
            this.panel1.Location = new System.Drawing.Point(0, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(272, 360);
            this.panel1.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.BackgroundImage = global::Wordle_SDD.Properties.Resources.imgCrossIconLight;
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btnClose.Location = new System.Drawing.Point(222, 10);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(34, 29);
            this.btnClose.TabIndex = 4;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // chkOnScreenKeyboard
            // 
            this.chkOnScreenKeyboard.AutoSize = true;
            this.chkOnScreenKeyboard.Checked = true;
            this.chkOnScreenKeyboard.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkOnScreenKeyboard.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkOnScreenKeyboard.ForeColor = System.Drawing.SystemColors.Control;
            this.chkOnScreenKeyboard.Location = new System.Drawing.Point(25, 111);
            this.chkOnScreenKeyboard.Name = "chkOnScreenKeyboard";
            this.chkOnScreenKeyboard.Size = new System.Drawing.Size(219, 26);
            this.chkOnScreenKeyboard.TabIndex = 3;
            this.chkOnScreenKeyboard.Text = "On Screen Keyboard";
            this.chkOnScreenKeyboard.UseVisualStyleBackColor = true;
            this.chkOnScreenKeyboard.CheckedChanged += new System.EventHandler(this.chkOnScreenKeyboard_CheckedChanged);
            // 
            // chkHighContrast
            // 
            this.chkHighContrast.AutoSize = true;
            this.chkHighContrast.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkHighContrast.ForeColor = System.Drawing.SystemColors.Control;
            this.chkHighContrast.Location = new System.Drawing.Point(25, 79);
            this.chkHighContrast.Name = "chkHighContrast";
            this.chkHighContrast.Size = new System.Drawing.Size(155, 26);
            this.chkHighContrast.TabIndex = 2;
            this.chkHighContrast.Text = "High Contrast";
            this.chkHighContrast.UseVisualStyleBackColor = true;
            this.chkHighContrast.CheckedChanged += new System.EventHandler(this.chkHighContrast_CheckedChanged);
            // 
            // lblGraphicsTitle
            // 
            this.lblGraphicsTitle.AutoSize = true;
            this.lblGraphicsTitle.Font = new System.Drawing.Font("Rockwell", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGraphicsTitle.ForeColor = System.Drawing.SystemColors.Control;
            this.lblGraphicsTitle.Location = new System.Drawing.Point(9, 10);
            this.lblGraphicsTitle.Name = "lblGraphicsTitle";
            this.lblGraphicsTitle.Size = new System.Drawing.Size(131, 29);
            this.lblGraphicsTitle.TabIndex = 1;
            this.lblGraphicsTitle.Text = "Graphics:";
            // 
            // chkDarkMode
            // 
            this.chkDarkMode.AutoSize = true;
            this.chkDarkMode.Checked = true;
            this.chkDarkMode.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDarkMode.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDarkMode.ForeColor = System.Drawing.SystemColors.Control;
            this.chkDarkMode.Location = new System.Drawing.Point(25, 47);
            this.chkDarkMode.Name = "chkDarkMode";
            this.chkDarkMode.Size = new System.Drawing.Size(128, 26);
            this.chkDarkMode.TabIndex = 0;
            this.chkDarkMode.Text = "Dark Mode";
            this.chkDarkMode.UseVisualStyleBackColor = true;
            this.chkDarkMode.CheckedChanged += new System.EventHandler(this.chkDarkMode_CheckedChanged);
            // 
            // frmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.ClientSize = new System.Drawing.Size(268, 450);
            this.Controls.Add(this.panel1);
            this.Name = "frmSettings";
            this.Text = "Settings";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblGraphicsTitle;
        private System.Windows.Forms.CheckBox chkDarkMode;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.CheckBox chkOnScreenKeyboard;
        private System.Windows.Forms.CheckBox chkHighContrast;
    }
}