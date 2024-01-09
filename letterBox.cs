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
        private frmWordle wordleForm = new frmWordle();
        public letterBox()
        {
            InitializeComponent();
            this.Width = 70;
            this.Height = 70;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Color baseColor = wordleForm.baseColour;
            Color alternateColor = wordleForm.alternateColour;
            Font charFont = new Font("Arial", 24, FontStyle.Bold);

            base.OnPaint(e);

            Graphics g = e.Graphics;

            ControlPaint.DrawBorder(e.Graphics, ClientRectangle,
                alternateColor, 2, ButtonBorderStyle.Solid,
                alternateColor, 2, ButtonBorderStyle.Solid,
                alternateColor, 2, ButtonBorderStyle.Solid,
                alternateColor, 2, ButtonBorderStyle.Solid
                );

            BackColor = baseColor;

            string letter = "X";
            int x = (ClientSize.Width - (int)g.MeasureString(letter, charFont).Width) / 2;
            int y = (ClientSize.Height - (int)g.MeasureString(letter, charFont).Height) / 2;

            g.DrawString(letter, charFont, Brushes.White, x, y);
        }
    }
}
