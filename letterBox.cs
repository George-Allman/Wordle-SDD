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
    public partial class letterBox : UserControl
    {
        private frmWordle FrmWordle = new frmWordle();
        private Color baseColour;
        private Color alternateColour;
        private string _letter;

        public string letter
        {
            get { return _letter; }
            set { 
                _letter = value; 
                Invalidate();
            }
        }

        public letterBox()
        {
            InitializeComponent();
            this.Width = 70;
            this.Height = 70;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            baseColour = FrmWordle.baseColour;
            alternateColour = FrmWordle.alternateColour;
            Font letterFont = new Font("Arial", 24, FontStyle.Bold);

            base.OnPaint(e);

            Graphics g = e.Graphics;

            ControlPaint.DrawBorder(e.Graphics, ClientRectangle,
                alternateColour, 2, ButtonBorderStyle.Solid,
                alternateColour, 2, ButtonBorderStyle.Solid,
                alternateColour, 2, ButtonBorderStyle.Solid,
                alternateColour, 2, ButtonBorderStyle.Solid
                );

            BackColor = baseColour;

            int x = (ClientSize.Width - (int)g.MeasureString(letter, letterFont).Width) / 2;
            int y = (ClientSize.Height - (int)g.MeasureString(letter, letterFont).Height) / 2;

            g.DrawString(letter, letterFont, Brushes.White, x, y);
        }
    }
}
