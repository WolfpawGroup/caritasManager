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
		public bool OK = false;

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

			mainData m = cad.cust_0_mainData;

			Text = "Adatlap Szerkesztése - " + m.nev;

			//------------- Személyes Adatok

			cbb_PassedAway.Checked = m.elhunyt;



			if (cbb_PassedAway.Checked)
			{
				//TODO: kiszürkíteni mindent
				tb_Customer_Name.Enabled = false;
				cb_Customer_OriginalName.Enabled = false;
				tb_Customer_OriginalName.Enabled = false;
				tb_Customer_City.Enabled = false;
				tb_Customer_UH.Enabled = false;
				tb_Customer_BirthDate.Enabled = false;
				btn_SelectBirthDate.Enabled = false;
				tb_Customer_BirthPlace.Enabled = false;
				tb_Customer_PIDNum.Enabled = false;
				tb_Customer_MothersName.Enabled = false;
				tb_Customer_Schooling.Enabled = false;
				tb_Customer_Skill.Enabled = false;
				tb_Customer_Work.Enabled = false;
				tb_Customer_Employer.Enabled = false;
				cb_Religion.Enabled = false;
				tb_OtherReligion.Enabled = false;
				btn_Income_Add.Enabled = false;
				btn_Income_Remove.Enabled = false;
				btn_Income_Edit.Enabled = false;
				btn_Expenditure_Add.Enabled = false;
				btn_Expenditure_Remove.Enabled = false;
				btn_Expenditure_Edit.Enabled = false;
				tb_Vagyon_Megjegyzés.Enabled = false;
				cb_Dwelling.Enabled = false;
				btn_SocialState_Add.Enabled = false;
				btn_SocialState_Remove.Enabled = false;
				btn_SocialState_Edit.Enabled = false;
				cb_GeneralSocialState.Enabled = false;
				cb_RequiresConstantCare.Enabled = false;
				btn_State_Add.Enabled = false;
				btn_State_Remove.Enabled = false;
				btn_State_Edit.Enabled = false;
				tb_StudyBy.Enabled = false;
				tb_StudyOn.Enabled = false;
				btn_SameAsCreator.Enabled = false;
				btn_EditAid.Enabled = false;
				
			}

			tb_Customer_Name.Text =				m.nev;
			tb_Customer_OriginalName.Text =		m.születesi_nev;
			cb_Customer_OriginalName.Checked =	(tb_Customer_OriginalName.Text != tb_Customer_Name.Text);

			tb_Customer_City.Text =				m.lakcim_varos;
			tb_Customer_UH.Text =				m.lakcim_uh;

			tb_Customer_BirthDate.Text =		m.szul_datum;
			tb_Customer_BirthPlace.Text =		m.szul_hely;
			tb_Customer_PIDNum.Text =			m.szig_szam;
			tb_Customer_MothersName.Text =		m.anyja_neve;

			tb_Customer_Schooling.Text =		m.vegzettseg;
			tb_Customer_Skill.Text =			m.szakkepzettseg;
			tb_Customer_Work.Text =				m.foglalkozas;
			tb_Customer_Employer.Text =			m.munkaltato;

			cbb_SZJI.Checked =					m.jovedelem_igazolas;

			string vallas = m.vallas;
			int _v = 1;

			if(int.TryParse(vallas, out _v))
			{
				cb_Religion.SelectedIndex = _v;
			}
			else
			{
				cb_Religion.SelectedIndex = 7;
				tb_OtherReligion.Text = vallas;
			}

			//------------- Vagyoni helyzet
			int bevétel = 0;
			int kiadás = 0;

			List<vagyon> vagyonlista = cad.cust_1_vagyon;
			foreach (vagyon v_1 in vagyonlista)
			{
				if (v_1.tipus == "M")
				{
					tb_Vagyon_Megjegyzés.Text = v_1.szoveg;
				}
				else
				{
					ListViewItem lvi_1 = new ListViewItem();
					lvi_1.Tag = v_1.id;
					lvi_1.SubItems.Add(v_1.szoveg);
					lvi_1.SubItems.Add(v_1.osszeg + "");
									
					if (v_1.tipus == "B")
					{
						bevétel += v_1.osszeg;
						lvi_1.Text = (lv_CustomerIncome.Items.Count + 1) + "";
						lv_CustomerIncome.Items.Add(lvi_1);
					}
					else
					{
						kiadás += v_1.osszeg;
						lvi_1.Text = (lv_CustomerExpenditure.Items.Count + 1) + "";
						lv_CustomerExpenditure.Items.Add(lvi_1);
					}
				}
			}

			tb_Income_Sum.Text = bevétel + "";
			tb_Expenditure_Sum.Text = kiadás + "";
			tb_Net_Income.Text = (kiadás + bevétel) + "";

			//------------- Szociális helyzet

			cb_Dwelling.SelectedIndex = (int)cad.cust_2_lakas;
			cb_GeneralSocialState.SelectedIndex = (int)cad.cust_3_alt_szoc_helyzet;
			cb_RequiresConstantCare.SelectedIndex = (int)cad.cust_4_rendsz_seg_szorul;

			int összjöv = 0;

			List<rokon> rokonlista = cad.cust_5_rokonok;
			foreach (rokon r_1 in rokonlista)
			{
				ListViewItem rokon_lvi = new ListViewItem();
				rokon_lvi.Tag = r_1.id;
				rokon_lvi.Text = (lv_Relatives.Items.Count + 1) + "";
				rokon_lvi.SubItems.Add(r_1.nev);
				rokon_lvi.SubItems.Add(r_1.kapcsolat.ToString().Replace("_", " "));
				rokon_lvi.SubItems.Add(r_1.havi_jovedelem + "");
				lv_Relatives.Items.Add(rokon_lvi);

				összjöv += r_1.havi_jovedelem;
			}

			tb_FamilyIncomeSum.Text = összjöv + "";

			String[] állapot = m.allapot.Split('|');
			foreach (string _állapot in állapot)
			{
				if (_állapot != "")
				{
					ListViewItem állapot_lvi = new ListViewItem();
					állapot_lvi.Text = (lv_States.Items.Count + 1) + "";
					állapot_lvi.SubItems.Add(_állapot);
					lv_States.Items.Add(állapot_lvi);
				}
			}

			//------------- Felhasználói Információ

			lbl_ProfileName.Text = m.felvevo_profil;
			lbl_CreationDate.Text = m.hozzaadas_datuma;
			lbl_LastUpdatedBy.Text = m.legutobb_modositotta;
			lbl_LastUpdateDate.Text = m.legutobbi_modositas_datuma;
			tb_StudyBy.Text = m.környezettanulmanyt_végezte;
			tb_StudyOn.Text = m.környezettanulmany_idopontja;

			//------------- Támogatások

			List<tamogatas> támogatáslista = cad.cust_6_tamogatasok;
			foreach (tamogatas _támogatás in támogatáslista)
			{
				ListViewItem támogatás_lvi = new ListViewItem();
				támogatás_lvi.Tag = new object[] { _támogatás.id, _támogatás.tamogatas_tipusa, _támogatás.tamogatas_mennyisege, _támogatás.tamogatas_egysége };
				támogatás_lvi.Text = (lv_Aids.Items.Count + 1) + "";
				támogatás_lvi.SubItems.Add(_támogatás.datum.ToShortDateString());
				támogatás_lvi.SubItems.Add(_támogatás.tamogatas_mennyisege + " " + _támogatás.tamogatas_egysége + " " + _támogatás.tamogatas_tipusa);
				támogatás_lvi.SubItems.Add(_támogatás.megjegyzes);
				lv_Aids.Items.Add(támogatás_lvi);

			}

		}

		private void F_AddCustomer_Load(object sender, EventArgs e)
		{
			tb_Customer_Name.Focus();

			tb_Customer_BirthPlace.AutoCompleteCustomSource = new AutoCompleteStringCollection();
			tb_Customer_BirthPlace.AutoCompleteCustomSource.AddRange(Properties.Resources.telepulesek.Replace("\r", "").Split('\n'));
			tb_Customer_BirthPlace.AutoCompleteSource = AutoCompleteSource.CustomSource;
			tb_Customer_BirthPlace.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

			lbl_ProfileName.Text = login_profile.name; 

			if (edit)
			{
				lbl_HelpText.Hide();
				loadData();
				
			}
			else
			{
				tc_Tabs.TabPages.Remove(tp_AIDS);
				tc_Tabs.TabPages.Remove(tp_MoneyData);
				tc_Tabs.TabPages.Remove(tp_SocialData);
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

		private void btn_Save_Click(object sender, EventArgs e)
		{
			if (edit)
			{
				//TODO: módosítást létrehozni
				this.Close();
			}
			else
			{
				customerAllData cad = new customerAllData();

				mainData m = new mainData();
				List<vagyon> lst_v = new List<vagyon>();
				List<rokon> lst_r = new List<rokon>();

				m.nev = tb_Customer_Name.Text;
				m.születesi_nev = tb_Customer_OriginalName.Text;
				m.lakcim_varos = tb_Customer_City.Text;
				m.lakcim_uh = tb_Customer_UH.Text;
				m.szul_datum = tb_Customer_BirthDate.Text;
				m.szul_hely = tb_Customer_BirthPlace.Text;
				m.szig_szam = tb_Customer_PIDNum.Text;
				m.anyja_neve = tb_Customer_MothersName.Text;
				m.vegzettseg = tb_Customer_Schooling.Text;
				m.szakkepzettseg = tb_Customer_Skill.Text;
				m.foglalkozas = tb_Customer_Work.Text;
				m.munkaltato = tb_Customer_Employer.Text;
				m.vallas = cb_Religion.SelectedIndex < 7 ? cb_Religion.SelectedIndex + "" : tb_OtherReligion.Text;

				string allapot = "";

				foreach(ListViewItem lvi in lv_States.Items)
				{
					allapot += lvi.SubItems[1].Text + "|";
				}

				allapot = allapot.Trim('|');

				m.allapot = allapot;

				m.felvevo_profil = lbl_ProfileName.Text;
				m.hozzaadas_datuma = lbl_CreationDate.Text;
				m.legutobb_modositotta = "";
				m.legutobbi_modositas_datuma = "";
				m.környezettanulmanyt_végezte = tb_StudyBy.Text;
				m.környezettanulmany_idopontja = tb_StudyOn.Text;

				/*
				foreach (ListViewItem lvi in lv_CustomerIncome.Items)
				{
					vagyon v = new vagyon();
					int osszeg = 0;
					v.szoveg = lvi.SubItems[1].Text;
					int.TryParse(lvi.SubItems[2].Text, out osszeg);
					v.osszeg = osszeg;
					v.tipus = "B";
					lst_v.Add(v);
				}

				foreach (ListViewItem lvi in lv_CustomerExpenditure.Items)
				{
					int osszeg = 0;
					int.TryParse(lvi.SubItems[2].Text, out osszeg);

					vagyon v = new vagyon()
					{
						szoveg = lvi.SubItems[1].Text,
						osszeg = osszeg,
						tipus = "K"
					};

					lst_v.Add(v);
				}

				lst_v.Add(new vagyon() { tipus = "M", szoveg = tb_Vagyon_Megjegyzés.Text, osszeg = 0 });

				foreach(ListViewItem lvi in lv_Relatives.Items)
				{
					int jovedelem = 0;
					int.TryParse(lvi.SubItems[3].Text, out jovedelem);

					rokon r = new rokon();
					r.nev = lvi.SubItems[1].Text;
					r.kapcsolat = (enums.rokoni_kapcsolat)Enum.Parse(typeof(enums.rokoni_kapcsolat), lvi.SubItems[2].Text.Replace(" ", "_"));
					r.havi_jovedelem = jovedelem;
					lst_r.Add(r);
				}
				*/

				cad.cust_0_mainData = m;
				cad.cust_1_vagyon = lst_v;
				cad.cust_5_rokonok = lst_r;

				c_DBHandler.addNewCustomerAllData(sqlc, cad);

				customer_id = m.id;
				OK = true;

				this.Close();
			}
		}
	}
}
