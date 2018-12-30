using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CaritasManager
{
	public partial class f_EditProfile : Form
	{
		public bool edit = false;
		public profile prof { get; set; }
		public SQLiteConnection sqlc { get; set; }

		Font fnt			= null;

		string fontFamily	= "";
		string fontSize		= "";
		string fontStyle	= "";
		string fontColor	= "";
		string color_1		= "";
		string color_2		= "";
		string color_3		= "";

		string[] tests		= new string[] { "Teszt", "Félkövér", "Dőlt", "Félkövér és Dőlt", "0123456789 ! ? . ,", "Árvíztűrő tükörfúrógép", "aábcdeéfghiíjklmnoóöőpqrstuúüűvwxyz", "AÁBCDEÉFGHIÍJKLMNOÓÖŐPQRSTUÚÜŰVWXYZ" };

		public f_EditProfile()
		{
			InitializeComponent();
		}

		public void fillData()
		{
			if(prof != null)
			{
				tb_ProfileName.Text		= prof.name;
				fontFamily				= prof.fontFamily;
				fontSize				= prof.fontSize;
				fontStyle				= prof.fontStyle;
				fontColor				= prof.fontColor;
				color_1					= prof.color_1;
				color_2					= prof.color_2;
				color_3					= prof.color_3;
				
				p_FontColor.BackColor	= Color.FromArgb(Convert.ToInt32(fontColor));
				p_Color1.BackColor		= Color.FromArgb(Convert.ToInt32(color_1));
				p_Color2.BackColor		= Color.FromArgb(Convert.ToInt32(color_2));
				p_Color3.BackColor		= Color.FromArgb(Convert.ToInt32(color_3));

				generateTestText();
			}
		}

		private void form_loaded(object sender, EventArgs e)
		{
			if (edit)
			{
				tb_ProfileName.Enabled = false;
				fillData();
			}
			else
			{
				Text = "Új Profil Létrehozása";
			}
		}

		private void btn_SelectFont_Click(object sender, EventArgs e)
		{
			FontDialog fd = new FontDialog();

			fd.Font = new Font(fontFamily, (float)Convert.ToDouble(fontSize), (FontStyle)Convert.ToInt32(fontStyle));

			if(fd.ShowDialog() == DialogResult.OK)
			{
				fontFamily = fd.Font.FontFamily.Name;
				fontSize = fd.Font.Size.ToString();
				fontStyle = ((int)fd.Font.Style).ToString();
				generateTestText();
			}
		}

		private void p_FontColor_Click(object sender, EventArgs e)
		{
			Panel p = sender as Panel;

			if (p != null)
			{
				ColorDialog cd = new ColorDialog();
				cd.Color = p.BackColor;
				if (cd.ShowDialog() == DialogResult.OK)
				{
					p.BackColor = cd.Color;
				}
			}
		}

		private void btn_Save_Click(object sender, EventArgs e)
		{
			fontColor = p_FontColor.BackColor.ToArgb().ToString();
			color_1 = p_Color1.BackColor.ToArgb().ToString();
			color_2 = p_Color2.BackColor.ToArgb().ToString();
			color_3 = p_Color3.BackColor.ToArgb().ToString();

			profile p = new profile();
			p.name = tb_ProfileName.Text;
			p.fontFamily = fontFamily;
			p.fontSize = fontSize;
			p.fontStyle = fontStyle;
			p.fontColor = fontColor;
			p.color_1 = color_1;
			p.color_2 = color_2;
			p.color_3 = color_3;

			string ret = c_DBHandler.editProfile(sqlc, p, edit);
			if (!ret.Contains("ERROR"))
			{
				this.Close();
			}
			else
			{
				ret = ret.Substring(ret.IndexOf(":") + 1);
				if (ret == "0")
				{
					MessageBox.Show($"Már létezik profil ezzel a névvel\r\n[ {p.name} ]", "Hiba!", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				else if (ret == "-1")
				{
					MessageBox.Show($"Hiba az adatbáziskapcsolattal!\r\nNem tudtam létrehozni a profilt.", "Hiba!", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				else if (ret == "NONAME")
				{
					MessageBox.Show($"A név mező kitöltése kötelező!", "Hiba!", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				else
				{
					MessageBox.Show($"Ismeretlen hiba!\r\nHibaüzenet: [ {ret} ]", "Hiba!", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}

			
		}

		private void btn_Cancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void btn_FactorySettings_Click(object sender, EventArgs e)
		{
			p_FontColor.BackColor = Color.FromArgb(-16777216);
			p_Color1.BackColor = Color.FromArgb(-7078960);
			p_Color2.BackColor = Color.FromArgb(-6987);
			p_Color3.BackColor = Color.FromArgb(-17991);
		}

		public void generateTestText()
		{
			Bitmap b = new Bitmap(1000, 1000);
			fnt = new Font(fontFamily, (float)Convert.ToDouble(fontSize), (FontStyle)Convert.ToInt32(fontStyle));
			int left = 5;
			int top = 5;
			Size tr = new Size();
			using (Graphics g = Graphics.FromImage(b))
			{
				g.Clear(BackColor);
				fnt = new Font(fnt, FontStyle.Regular);
				g.DrawString(tests[0], fnt, new SolidBrush(p_FontColor.BackColor), new Point(left, top));
				tr = TextRenderer.MeasureText(tests[0],fnt);
				left += tr.Width + 5;
				fnt = new Font(fnt, FontStyle.Italic);
				g.DrawString(tests[1], fnt, new SolidBrush(p_FontColor.BackColor), new Point(left, top));
				tr = TextRenderer.MeasureText(tests[1], fnt);
				left += tr.Width + 5;
				fnt = new Font(fnt, FontStyle.Bold);
				g.DrawString(tests[2], fnt, new SolidBrush(p_FontColor.BackColor), new Point(left, top));
				tr = TextRenderer.MeasureText(tests[2], fnt);
				left += tr.Width + 5;
				fnt = new Font(fnt, FontStyle.Bold | FontStyle.Italic);
				g.DrawString(tests[3], fnt, new SolidBrush(p_FontColor.BackColor), new Point(left, top));
				tr = TextRenderer.MeasureText(tests[3], fnt);
				left = 5;
				top += tr.Height + 5;
				fnt = new Font(fnt, FontStyle.Regular);
				g.DrawString(tests[4], fnt, new SolidBrush(p_FontColor.BackColor), new Point(left, top));
				tr = TextRenderer.MeasureText(tests[4], fnt);
				left = 5;
				top += tr.Height + 5;
				g.DrawString(tests[5], fnt, new SolidBrush(p_FontColor.BackColor), new Point(left, top));
				tr = TextRenderer.MeasureText(tests[5], fnt);
				left = 5;
				top += tr.Height + 5;
				g.DrawString(tests[6], fnt, new SolidBrush(p_FontColor.BackColor), new Point(left, top));
				tr = TextRenderer.MeasureText(tests[6], fnt);
				left = 5;
				top += tr.Height + 5;
				g.DrawString(tests[7], fnt, new SolidBrush(p_FontColor.BackColor), new Point(left, top));
			}
			GC.Collect();
			p_TextTest.BackgroundImage = b;
		}
	}
}
