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
using System.Data.SQLite;

namespace CaritasManager
{
	public partial class f_AddCustomer : Form
	{
		public SQLiteConnection sqlc { get; set; }
		public profile login_profile { get; set; }
		public int customer_id { get; set; }
		public bool edit { get; set; }
		public bool otherReligion = false;
		public string current_id = "";

		public List<string> States { get; set; }

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
			customerAllData cad = c_DBHandler.getCustomerAllData(sqlc, customer_id);
			
		}

		private void F_AddCustomer_Load(object sender, EventArgs e)
		{
			tb_Customer_Name.Select();

			tb_Customer_BirthPlace.AutoCompleteCustomSource = new AutoCompleteStringCollection();
			tb_Customer_BirthPlace.AutoCompleteCustomSource.AddRange(Properties.Resources.telepulesek.Replace("\r", "").Split('\n'));
			tb_Customer_BirthPlace.AutoCompleteSource = AutoCompleteSource.CustomSource;
			tb_Customer_BirthPlace.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

			lbl_ProfileName.Text = login_profile.name; 

			if (edit)
			{
				Text = "Adatlap Szerkesztése";
				loadData();
			}
			else
			{
				States = new List<string>();
				lbl_CreationDate.Text = DateTime.Now.ToShortDateString();
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
				tb_OtherReligion.Focus();
				tb_OtherReligion.Select();
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
			if(date.selection != null && date.OK) { tb_Customer_BirthDate.Text = date.selection.ToShortDateString(); }
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

		private void btn_SelectStudyDate_Click(object sender, EventArgs e)
		{
			f_DateSelector date = new f_DateSelector();
			date.selection = DateTime.Now;
			date.ShowDialog();
			if (date.selection != null && date.OK) { tb_StudyOn.Text = date.selection.ToShortDateString(); }
		}

		private void btn_SameAsCreator_Click(object sender, EventArgs e)
		{
			tb_StudyBy.Text = lbl_ProfileName.Text;
		}

		private void btn_State_Add_Click(object sender, EventArgs e)
		{
			f_AddState fads = new f_AddState();
			fads.custName = tb_Customer_Name.Text;
			fads.edit = false;
			fads.ShowDialog();
			if (fads.OK)
			{
				if(fads.state != "" && !States.Contains(fads.state))
				{
					States.Add(fads.state);
					loadCustomerStates();
				}
			}
		}

		public void loadCustomerStates()
		{
			lv_States.Items.Clear();

			foreach(string s in States)
			{
				ListViewItem lvi = new ListViewItem();

				lvi.Text = (States.IndexOf(s) + 1) + "";
				lvi.SubItems.Add(s);

				lv_States.Items.Add(lvi);
			}
		}

		private void btn_State_Remove_Click(object sender, EventArgs e)
		{
			if(lv_States.FocusedItem != null)
			{
				string s = lv_States.FocusedItem.SubItems[1].Text;
				States.Remove(s);
				loadCustomerStates();
			}
		}

		private void btn_State_Edit_Click(object sender, EventArgs e)
		{
			if (lv_States.FocusedItem != null)
			{
				string s = lv_States.FocusedItem.SubItems[1].Text;

				f_AddState fads = new f_AddState();
				fads.custName = tb_Customer_Name.Text;
				fads.edit = true;
				fads.previousState = s;
				fads.ShowDialog();
				if (fads.OK)
				{
					if (fads.state != "" && !States.Contains(fads.state))
					{
						States[States.IndexOf(s)] = fads.state;
						loadCustomerStates();
					}
				}
			}
		}

		private void cb_Customer_OriginalName_CheckedChanged(object sender, EventArgs e)
		{
			if (cb_Customer_OriginalName.Checked)
			{
				tb_Customer_OriginalName.Visible = true;
			}
			else
			{
				tb_Customer_OriginalName.Visible = false;
			}
		}
	}
}
