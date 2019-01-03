using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CaritasManager
{
	public partial class f_Splash : Form
	{
		private int _parts = 0;
		private int percent_per_part = 0;
		private int parts = 0;
		Bitmap bmp = new Bitmap(300, 10);
		public f_Splash(int Parts)
		{
			InitializeComponent();
			_parts = Parts;
			percent_per_part = (int)((300 * 1.0f) / (_parts * 1.0f));
		}

		public void incrementLoad(string message = "")
		{
			Invoke(new Action(() => delegateWriter(message)));
		}

		public void incrementParts(int p)
		{
			_parts += p;
			percent_per_part = (int)((300 * 1.0f) / (_parts * 1.0f));
			parts--;
			Invoke(new Action(() => delegateWriter("")));
		}

		private delegate void myDelegate();
		private void delegateWriter(string message)
		{
			parts++;
			drawPercentage();
		}
		public void drawPercentage()
		{
			int pix = parts * percent_per_part * 3;
			using (Graphics g = Graphics.FromImage(bmp))
			{
				g.Clear(Color.FromArgb(255, 218, 37, 28));
				g.FillRectangle(Brushes.White, new Rectangle(0, 0, pix, 10));
			}
			p_LoadingBar.BackgroundImage = bmp;
		}
	}
}
