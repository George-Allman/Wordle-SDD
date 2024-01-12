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
            this.button1 = new System.Windows.Forms.Button();
            this.chkOnScreenKeyboard = new System.Windows.Forms.CheckBox();
            this.chkHighContrast = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkDarkMode = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.chkOnScreenKeyboard);
            this.panel1.Controls.Add(this.chkHighContrast);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.chkDarkMode);
            this.panel1.Location = new System.Drawing.Point(0, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(272, 360);
            this.panel1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::Wordle_SDD.Properties.Resources.imgCrossIconLight;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.button1.Location = new System.Drawing.Point(222, 10);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(34, 29);
            this.button1.TabIndex = 4;
            this.button1.UseVisualStyleBackColor = true;
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Rockwell", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(9, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "Graphics:";
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkDarkMode;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox chkOnScreenKeyboard;
        private System.Windows.Forms.CheckBox chkHighContrast;
    }
}