using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace CaritasManager
{
	public partial class f_AddCustomer : Form
	{
		public bool otherReligion = false;
		public profile login_profile { get; set; }
		public bool edit { get; set; }
		public string current_id = "";

		public f_AddCustomer()
		{
			InitializeComponent();

			Load += F_AddCustomer_Load;
		}

		protected override CreateParams CreateParams
		{
			get
			{
				CreateParams handleParam = base.CreateParams;
				handleParam.ExStyle |= 0x02000000;   // WS_EX_COMPOSITED
				return handleParam;
			}
		}

		public void loadData()
		{
			//TODO: load data from DB
		}

		private void F_AddCustomer_Load(object sender, EventArgs e)
		{
			tb_Customer_Name.Select();

			if (edit)
			{
				Text = "Adatlap Szerkesztése";
				loadData();
			}
			else
			{
				
			}
		}

		public void incrementID()
		{
			//IMPORTANT: ne felejtsük el inkrementálni az ID fájl értékét
			string lastID = File.ReadAllText("last_id.ini");
			//TODO:DB handlerbe esetleg felvenni új methodot ami ellenőrzi a legnagyobb ID-t az azonosítók között
			int lid = 0;
			Int32.TryParse(lastID, out lid);
			current_id = (lid + 1).ToString().PadLeft(6, '0');
			File.WriteAllText("last_id.ini", current_id);
		}

		private void cb_Religion_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cb_Religion.SelectedIndex == cb_Religion.Items.Count - 1)
			{
				lbl_OtherReligion.Visible = true;
				tb_OtherReligion.Visible = true;
				otherReligion = true;
			}
			else
			{
				lbl_OtherReligion.Visible = false;
				tb_OtherReligion.Visible = false;
				otherReligion = false;
			}
		}

		private void btn_SelectBirthDate_Click(object sender, EventArgs e)
		{
			f_DateSelector date = new f_DateSelector();
			date.ShowDialog();
			if(date.selection != null) { tb_Customer_BirthDate.Text = date.selection.ToShortDateString(); }
		}

		private void tb_Customer_BirthDate_Leave(object sender, EventArgs e)
		{
			try
			{
				string datestr = tb_Customer_BirthDate.Text;
				Regex r = new Regex(@"(\d{4})[^\d]*(\d{1,2})[^\d]*(\d{1,2})[^\d]*");
				GroupCollection gc = r.Match(datestr).Groups;
				if (gc.Count == 4)
				{
					tb_Customer_BirthDate.Text = gc[1].Value + "." + gc[2].Value.PadLeft(2, '0') + "." + gc[3].Value.PadLeft(2, '0') + ".";
				}
			}
			catch(Exception ex)
			{
				tb_Customer_BirthDate.BackColor = Color.LightPink;
				Console.WriteLine("Error:\r\n" + ex);
			}
		}
	}
}
