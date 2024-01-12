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
        private bool _darkMode = true;
        private bool _highContrastMode = false;
        private bool _onScreenKeyboard = true;

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
        public Color textColour
        {
            get { return _textColour; }
            set { _textColour = value; }
        }
        public bool darkMode 
        { 
            get { return _darkMode; } 
            set { _darkMode = value; } 
        }
        public bool highContrastMode
        {
            get { return _highContrastMode; }
            set { _highContrastMode = value; }
        }
        public bool onScreenKeyboard
        {
            get { return _onScreenKeyboard; }
            set { _onScreenKeyboard = value; }
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

        public void resetForms()
        {
            // Iterate through all open forms in the application
            foreach (Form form in Application.OpenForms)
            {
                // Trigger redraw for each form using a helper method
                RedrawForm(form);
            }
        }
        private static void RedrawForm(Form form)
        {
            // Trigger redraw for the given form
            form.Invalidate();
            form.Update();
            form.Refresh();
        }
    }
}
