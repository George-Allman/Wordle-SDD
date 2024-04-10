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
    public partial class letterBox : Button
    {
        private Color _baseColour = Color.FromArgb(20,20,20);
        private Color _alternateColour = Color.FromArgb(75,75,75);
        private Color _textColour = Color.White;
        private string _letter = "X";

        public string letter
        {
            get { return _letter; }
            set { 
                _letter = value; 
                Invalidate();
            }
        }
        public Color baseColour
        {
            get { return _baseColour; }
            set
            {
                _baseColour = value;
                this.BackColor = baseColour;
                
            }
        }
        public Color alternateColour
        {
            get { return _alternateColour; }
            set
            {
                _alternateColour = value;
                this.FlatAppearance.BorderColor = alternateColour;
                
            }
        }
        public Color textColour
        {
            get { return _textColour; }
            set
            {
                _textColour = value;
                this.ForeColor = textColour;
            }
        }


        public letterBox()
        {
            InitializeComponent();
            this.Width = 125;
            this.Height = 125;
            this.Padding = new System.Windows.Forms.Padding(6,0,0,0);
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 3;
            this.FlatAppearance.BorderColor = _alternateColour;
            this.BackColor = _baseColour;
            this.Text = "";
            this.Enabled = false;
            this.Font = new System.Drawing.Font("Arial", 28, FontStyle.Bold);
            this.ForeColor = _baseColour;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Font letterFont = new Font("Arial", 24, FontStyle.Bold);
            base.OnPaint(e);
            Graphics g = e.Graphics;

            int x = (ClientSize.Width - (int)g.MeasureString(letter, letterFont).Width) / 2;
            int y = (ClientSize.Height - (int)g.MeasureString(letter, letterFont).Height) / 2;
            Brush brush = new SolidBrush(this.textColour);
            g.DrawString(letter, letterFont, brush, x, y);
        }
    }
}
