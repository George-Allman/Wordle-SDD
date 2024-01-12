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
        private Color _baseColour = Color.FromArgb(20,20,20);
        private Color _alternateColour = Color.FromArgb(75,75,75);
        private Color _textColour = Color.Black;
        private bool _darkMode;

        public Color baseColour 
        {  
            get {  return _baseColour; }
            set {  _baseColour = value; }
        }
        public Color alternateColour 
        { 
            get { return _alternateColour; }
            set { _alternateColour = value; }
        }
        public bool darkMode 
        { 
            get { return _darkMode; } 
            set { _darkMode = value; } 
        }
        public Color textColour
        {
            get { return _textColour; }
            set { _textColour = value; }
        }
        public frmWordle()
        {
            InitializeComponent();
            if (darkMode == true)
            {
                alternateColour = Color.FromArgb(75, 75, 75);
                baseColour = Color.FromArgb(20, 20, 20);
            }
            else
            {
                alternateColour = Color.FromArgb(200,200,200);
                baseColour = Color.FromArgb(245,245,245);
            }
            this.BackColor = baseColour;
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
