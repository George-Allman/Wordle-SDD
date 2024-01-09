using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wordle_SDD
{
    public partial class frmWordle : Form
    {
        public Color baseColor 
        {  
            get {  return baseColor; }
            set {  baseColor = value; }
        }
        public Color alternateColor 
        { 
            get { return alternateColor; }
            set { alternateColor = value; }
        }
        public bool darkMode 
        { 
            get { return darkMode; } 
            set {  darkMode = value; } 
        }
        public frmWordle()
        {
            InitializeComponent();
            if (darkMode == true)
            {
                alternateColor = Color.FromArgb(75, 75, 75);
                baseColor = Color.FromArgb(20, 20, 20);
            }
            else
            {
                alternateColor = Color.FromArgb(200,200,200);
                baseColor = Color.FromArgb(245,245,245);
            }
            this.BackColor = baseColor;
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            Form frmSettings = new frmSettings();
            frmSettings.Show();
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            Form frmHelp = new frmHelp();
            frmHelp.Show();
        }
    }
}
