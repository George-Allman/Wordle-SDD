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
    public partial class UILine : UserControl
    {
        private frmWordle FrmWordle;
        public UILine(frmWordle _frmWordle)
        {
            InitializeComponent();
            this.Width = 300;
            this.Height = 3;
            FrmWordle = _frmWordle;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Color baseColor = FrmWordle.baseColour;
            Color alternateColor = FrmWordle.alternateColour;
            Font charFont = new Font("Arial", 24, FontStyle.Bold);

            base.OnPaint(e);

            Graphics g = e.Graphics;

            ControlPaint.DrawBorder(e.Graphics, ClientRectangle,
                alternateColor, 0, ButtonBorderStyle.Solid,
                alternateColor, 1, ButtonBorderStyle.Solid,
                alternateColor, 0, ButtonBorderStyle.Solid,
                alternateColor, 0, ButtonBorderStyle.Solid
                );
        }
    }
}
