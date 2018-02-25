using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CaritasManager
{
	public partial class uc_cb_Button : Button
	{
		private bool _checked = false;
		public bool Checked { get { return _checked; } set { _checked = value; Invalidate(); } }
		public uc_cb_Button()
		{
			InitializeComponent();

			TextChanged += Uc_cb_Button_TextChanged;
			Click += Uc_cb_Button_Click;
		}

		private void Uc_cb_Button_Click(object sender, EventArgs e)
		{
			Checked = !Checked;
		}

		private void Uc_cb_Button_TextChanged(object sender, EventArgs e)
		{
			Width = TextRenderer.MeasureText(Text,Font).Width + 35;
			TextAlign = ContentAlignment.MiddleLeft;
			Padding = new Padding(10, 0, 0, 0);
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);

			e.Graphics.DrawRectangle(Pens.Black, new Rectangle(new Point(Width - 20, Height / 2 - 7), new Size(14, 14)));
			e.Graphics.FillRectangle(Brushes.White, new Rectangle(new Point(Width - 19, Height / 2 - 6), new Size(12, 12)));

			if (_checked)
			{
				e.Graphics.DrawString("✗", new Font("Arial",14,FontStyle.Regular), Brushes.Red, new Point(Width - 26, Height / 2 - 9));
			}
		}
	}
}
