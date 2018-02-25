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
	public partial class myDataGridView : DataGridView
	{
		public int selectedRow = 0;
		Color c = Color.Red;
		public Color[] colors { get; set; }

		public myDataGridView()
		{
			InitializeComponent();
		}

		protected override void OnStyleChanged(EventArgs e)
		{
			c = this[0, 0].Style.BackColor;
			base.OnStyleChanged(e);

		}

		protected override void OnCellClick(DataGridViewCellEventArgs e)
		{
			try
			{
				c = this[e.ColumnIndex, e.RowIndex].Style.BackColor;

				base.OnCellClick(e);

				selectedRow = e.RowIndex;
				Invalidate();
			}
			catch
			{

			}
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);

			try
			{
				Color cc = new Color();

				DateTime ls = Convert.ToDateTime(this[6, selectedRow].Value);
				DateTime n = DateTime.Now;
				int lasts = (int)Math.Floor((new DateTime(n.Year, n.Month, n.Day) - ls).TotalDays);
				c = lasts <= 28 ? Color.LightGreen : (lasts <= 365 ? Color.Orange : Color.LightPink);

				Rectangle rec = GetRowDisplayRectangle(selectedRow, false);

				e.Graphics.DrawRectangle(Pens.Black, new Rectangle(rec.Left , rec.Top -1, rec.Width - 2, rec.Height - 2));
				e.Graphics.DrawRectangle(Pens.Black, new Rectangle(rec.Left + 1, rec.Top , rec.Width - 2, rec.Height - 2));

				foreach(DataGridViewCell cel in Rows[selectedRow].Cells)
				{
					cel.Style.SelectionBackColor = c;
				}

				cc = Color.FromArgb(255, c.R > 100 ? c.R - 100 : c.R, c.G > 100 ? c.G - 100 : c.G, c.B > 100 ? c.B - 100 : c.B);
				

				//e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(22, Color.Blue)), rec);
				e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(70, cc)), new Rectangle(rec.Left, rec.Top + (Rows[selectedRow].Height / 5 * 4),rec.Width,Rows[selectedRow].Height / 5));
				e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(50, cc)), new Rectangle(rec.Left, rec.Top + (Rows[selectedRow].Height / 5 * 3),rec.Width,Rows[selectedRow].Height / 5));
				e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(30, cc)), new Rectangle(rec.Left, rec.Top + (Rows[selectedRow].Height / 5 * 2),rec.Width,Rows[selectedRow].Height / 5));
			}
			catch
			{

			}
		}


	}
}
