using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CaritasManager
{
	public partial class f_help : Form
	{
		public const int WM_NCLBUTTONDOWN = 0xA1;
		public const int HT_CAPTION = 0x2;

		[DllImportAttribute("user32.dll")]
		public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
		[DllImportAttribute("user32.dll")]
		public static extern bool ReleaseCapture();

		ImageList il = new ImageList();

		public f_help()
		{
			InitializeComponent();
			Load += Help_Load;
		}

		private void Help_Load(object sender, EventArgs e)
		{
			il.ColorDepth = ColorDepth.Depth4Bit;
			il.Images.Add("Paw",Properties.Resources.pawprint_32);
			il.Images.Add("Q32",Properties.Resources.question_32);
			il.Images.Add("Q64",Properties.Resources.question_64);
			il.Images.Add("I32",Properties.Resources.info_32);
			il.Images.Add("I64",Properties.Resources.info_64);
			il.Images.Add("S48",Properties.Resources.skype_48);
			il.Images.Add("S64",Properties.Resources.skype_64);
			il.Images.Add("P32",Properties.Resources.paper_32);

			tc_Tabs.ImageList = il;
			tp_Help.ImageKey = "Q32";
			tp_Info.ImageKey = "I32";
			tp_Licenses.ImageKey = "P32";
		}

		private void pb_GameIcons_Click(object sender, EventArgs e)
		{
			System.Diagnostics.Process.Start("https://game-icons.net/");
		}

		private void pb_CCBY40_Click(object sender, EventArgs e)
		{
			System.Diagnostics.Process.Start("https://creativecommons.org/licenses/by/4.0/legalcode");
		}

		private void pb_Icons8_Click(object sender, EventArgs e)
		{
			System.Diagnostics.Process.Start("https://icons8.com/icons");
		}

		private void pb_CCBYND30_Click(object sender, EventArgs e)
		{
			System.Diagnostics.Process.Start("https://creativecommons.org/licenses/by-nd/3.0/legalcode");
		}

		private void btn_Close_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void tc_Tabs_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				ReleaseCapture();
				SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
			}
		}
	}
}
