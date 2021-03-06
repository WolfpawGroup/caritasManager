﻿using System;
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
using System.Xml;
using System.Threading;

namespace CaritasManager
{
	public partial class f_AddCustomer : Form
	{
		public	SQLiteConnection	sqlc			{ get; set; }
		public	SQLiteConnection	sqlc2			{ get; set; }
		public	profile				login_profile	{ get; set; }
		public	List<string>		States			{ get; set; }
		public	string				customerName	= "";
		public	string				current_id		= "";
		public	bool				otherReligion	= false;
		public	bool				reload			= false;
		public	bool				edit			{ get; set; }
		public	bool				OK				= false;
		public	int					customer_id		{ get; set; }

		private	TextBox				ziptb			= null;
		private	Thread				_t				= null;
		private	string				_city			= "";
		private	string				_zip			= "";

		private	c_xml				_xml			= new c_xml(Properties.Resources.cities);
		private mainData			m				= null;


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

			m = cad.cust_0_mainData;

			Text = "Adatlap Szerkesztése - " + m.nev;

			//------------- Személyes Adatok

			cbb_PassedAway.Checked = m.elhunyt;



			if (cbb_PassedAway.Checked)
			{
				//TODO: kiszürkíteni mindent
				tb_Customer_Name.Enabled			= false;
				cb_Customer_OriginalName.Enabled	= false;
				tb_Customer_OriginalName.Enabled	= false;
				tb_Customer_City.Enabled			= false;
				tb_Customer_UH.Enabled				= false;
				tb_Customer_BirthDate.Enabled		= false;
				btn_SelectBirthDate.Enabled			= false;
				tb_Customer_BirthPlace.Enabled		= false;
				tb_Customer_PIDNum.Enabled			= false;
				tb_Customer_MothersName.Enabled		= false;
				tb_Customer_Schooling.Enabled		= false;
				tb_Customer_Skill.Enabled			= false;
				tb_Customer_Work.Enabled			= false;
				tb_Customer_Employer.Enabled		= false;
				cb_Religion.Enabled					= false;
				tb_OtherReligion.Enabled			= false;
				btn_Income_Add.Enabled				= false;
				btn_Income_Remove.Enabled			= false;
				btn_Income_Edit.Enabled				= false;
				btn_Expenditure_Add.Enabled			= false;
				btn_Expenditure_Remove.Enabled		= false;
				btn_Expenditure_Edit.Enabled		= false;
				tb_Vagyon_Megjegyzés.Enabled		= false;
				cb_Dwelling.Enabled					= false;
				btn_SocialState_Add.Enabled			= false;
				btn_SocialState_Remove.Enabled		= false;
				btn_SocialState_Edit.Enabled		= false;
				cb_GeneralSocialState.Enabled		= false;
				cb_RequiresConstantCare.Enabled		= false;
				btn_State_Add.Enabled				= false;
				btn_State_Remove.Enabled			= false;
				btn_State_Edit.Enabled				= false;
				tb_StudyBy.Enabled					= false;
				tb_StudyOn.Enabled					= false;
				btn_SameAsCreator.Enabled			= false;
				btn_EditAid.Enabled					= false;
				
			}

			tb_Customer_Name.Text					=	m.nev;
			customerName							=	m.nev;
			tb_Customer_OriginalName.Text			=	m.születesi_nev;
			cb_Customer_OriginalName.Checked		=	(tb_Customer_OriginalName.Text != tb_Customer_Name.Text);
			tb_CustomerIdentification.Text			=	m.azonosito;

			tb_Customer_City.Text					=	m.lakcim_varos;
			tb_Customer_UH.Text						=	m.lakcim_uh;

			tb_Customer_BirthDate.Text				=	m.szul_datum;
			tb_Customer_BirthPlace.Text				=	m.szul_hely;
			tb_Customer_PIDNum.Text					=	m.szig_szam;
			tb_Customer_MothersName.Text			=	m.anyja_neve;

			tb_Customer_Schooling.Text				=	m.vegzettseg;
			tb_Customer_Skill.Text					=	m.szakkepzettseg;
			tb_Customer_Work.Text					=	m.foglalkozas;
			tb_Customer_Employer.Text				=	m.munkaltato;
			
			if(m.lakcim_zip == "")
			{
				_city								= m.lakcim_varos.ToLower();
				_zip								= _xml.getZipcode(_city).ToString();

				if (_zip != "") { lbl_ZipCode.Invoke(new myDelegate(setZip)); }

				GC.Collect();
			}
			else
			{
				lbl_ZipCode.Text					= m.lakcim_zip;
			}

			cbb_SZJI.Checked						=	m.jovedelem_igazolas;
			string vallas							=	m.vallas;

			if (int.TryParse(vallas, out int _v))
			{
				try
				{
					cb_Religion.SelectedIndex = _v;
				}
				catch
				{
					cb_Religion.SelectedIndex = 0;
				}
			}
			else
			{
				cb_Religion.SelectedIndex	= 7;
				tb_OtherReligion.Text		= vallas;
			}

			//------------- Vagyoni helyzet

			fillCustomerVagyon(cad.cust_1_vagyon);

			//------------- Szociális helyzet

			cb_Dwelling.SelectedIndex				= (int)cad.cust_2_lakas;
			cb_GeneralSocialState.SelectedIndex		= (int)cad.cust_3_alt_szoc_helyzet;
			cb_RequiresConstantCare.SelectedIndex	= (int)cad.cust_4_rendsz_seg_szorul;
			
			fillCustomerRokonok(cad);

			string[] állapot						= m.allapot.Split('|');
			foreach (string _állapot in állapot)
			{
				if (_állapot != "")
				{
					ListViewItem állapot_lvi = new ListViewItem();
					állapot_lvi.Text		 = (lv_States.Items.Count + 1) + "";

					állapot_lvi.SubItems.Add(_állapot);
					lv_States.Items.Add(állapot_lvi);
				}
			}

			//------------- Felhasználói Információ

			lbl_ProfileName.Text					= m.felvevo_profil;
			lbl_CreationDate.Text					= m.hozzaadas_datuma;
			lbl_LastUpdatedBy.Text					= m.legutobb_modositotta;
			lbl_LastUpdateDate.Text					= m.legutobbi_modositas_datuma;
			tb_StudyBy.Text							= m.környezettanulmanyt_végezte;
			tb_StudyOn.Text							= m.környezettanulmany_idopontja;

			//------------- Támogatások

			List<tamogatas> támogatáslista			= cad.cust_6_tamogatasok;

			int num									= 0, 
				allnum								= 0;
			List<aidsclass> aids					= new List<aidsclass>();
			List<aidsclass> all_aids				= new List<aidsclass>();
			List<string> types						= new List<string>();

			foreach (tamogatas _támogatás in támogatáslista)
			{
				ListViewItem támogatás_lvi	= new ListViewItem();
				támogatás_lvi.Tag			= new object[] { _támogatás.id, _támogatás.tamogatas_tipusa, _támogatás.tamogatas_mennyisege, _támogatás.tamogatas_egysége };
				támogatás_lvi.Text			= (lv_Aids.Items.Count + 1) + "";

				támogatás_lvi.SubItems.Add(_támogatás.datum.ToShortDateString());
				támogatás_lvi.SubItems.Add(_támogatás.tamogatas_mennyisege + " " + _támogatás.tamogatas_egysége + " " + _támogatás.tamogatas_tipusa);
				támogatás_lvi.SubItems.Add(_támogatás.megjegyzes);
				lv_Aids.Items.Add(támogatás_lvi);

				var aid = new aidsclass()
				{
					type = _támogatás.tamogatas_tipusa,
					value = _támogatás.tamogatas_mennyisege,
					denoimination = _támogatás.tamogatas_egysége
				};

				allnum++;
				all_aids.Add(aid);
				if (_támogatás.datum.Year == DateTime.Now.Year)
				{
					num++;
					aids.Add(aid);
				}

				if (!types.Contains(_támogatás.tamogatas_tipusa))
				{
					types.Add(_támogatás.tamogatas_tipusa);
				}
			}

			lbl_All_Num.Text						= allnum + "";
			lbl_ThisYear_Num.Text					= num + "";

			string tmp								= "", 
				tmp1								= "";

			foreach (string t in types)
			{
				{
					tmp += t + ": ";
					int i = 0;
					string tt = "";
					foreach (aidsclass a in all_aids)
					{
						if (a.type.ToLower() == t.ToLower())
						{
							int tmp_i = 0;
							int.TryParse(a.value, out tmp_i);
							i += tmp_i;
							tt = a.denoimination;
						}
					}

					tmp += i + tt + "\r\n";
				}

				{
					tmp1 += "";
					int i = 0;
					string tt = "";
					foreach (aidsclass a in aids)
					{
						if (a.type.ToLower() == t.ToLower())
						{
							int tmp_i = 0;
							int.TryParse(a.value, out tmp_i);
							i += tmp_i;
							tt = a.denoimination;
						}
					}

					if(i > 0)
					tmp1 += t + ": " + i + tt + "\r\n";
				}


			}

			lbl_All_ValueSum.Text = tmp;
			lbl_ThisYear_ValueSum.Text = tmp1;
		}

		public void fillCustomerRokonok(customerAllData cad)
		{
			int összjöv = 0;

			lv_Relatives.Items.Clear();

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
		}

		public string getNextTmpId()
		{
			string tmp = c_DBHandler.get_azonosito(sqlc);
			
			if(tmp != "" && tmp.Length == 6)
			{
				int i = 0;
				if (int.TryParse(tmp, out i))
				{
					i++;
					tmp = i.ToString().PadLeft(6, '0');
				}
			}

			return tmp;
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
				tc_Tabs.TabPages.Remove(tp_Misc);
				States = new List<string>();
				lbl_CreationDate.Text = DateTime.Now.ToShortDateString();
				tb_CustomerIdentification.Text = getNextTmpId();
				btn_EditCustomerIdentification.Visible = false;
			}

			
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
				mainData m = new mainData();

				m.nev				= tb_Customer_Name.Text;
				m.születesi_nev		= tb_Customer_OriginalName.Text;
				m.lakcim_varos		= tb_Customer_City.Text;
				m.lakcim_uh			= tb_Customer_UH.Text;
				m.lakcim_zip		= lbl_ZipCode.Text;
				m.szul_datum		= tb_Customer_BirthDate.Text;
				m.szul_hely			= tb_Customer_BirthPlace.Text;
				m.szig_szam			= tb_Customer_PIDNum.Text;
				m.anyja_neve		= tb_Customer_MothersName.Text;
				m.vegzettseg		= tb_Customer_Schooling.Text;
				m.szakkepzettseg	= tb_Customer_Skill.Text;
				m.foglalkozas		= tb_Customer_Work.Text;
				m.munkaltato		= tb_Customer_Employer.Text;
				m.vallas			= cb_Religion.SelectedIndex < 7 ? cb_Religion.SelectedIndex + "" : tb_OtherReligion.Text;

				m.azonosito			= c_DBHandler.getNextAzonosito(sqlc);

				string allapot		= "";

				foreach(ListViewItem lvi in lv_States.Items)
				{
					allapot						+= lvi.SubItems[1].Text + "|";
				}

				allapot							= allapot.Trim('|');
				m.allapot						= allapot;

				m.felvevo_profil				= lbl_ProfileName.Text;
				m.hozzaadas_datuma				= lbl_CreationDate.Text;
				m.legutobb_modositotta			= "";
				m.legutobbi_modositas_datuma	= "";
				m.környezettanulmanyt_végezte	= tb_StudyBy.Text;
				m.környezettanulmany_idopontja	= tb_StudyOn.Text;

				customer_id						= c_DBHandler.addNewCustomerAllData(sqlc, m);
				OK								= true;
				reload							= true;

				this.Close();
			}
		}

		private void btn_TEstFill_Click(object sender, EventArgs e)
		{
			tb_Customer_BirthDate.Text = DateTime.Now.ToShortDateString();
			tb_Customer_BirthPlace.Text = "TEST_" + new Random().Next();
			tb_Customer_City.Text = "TEST_" + new Random().Next();
			tb_Customer_Employer.Text = "TEST_" + new Random().Next();
			tb_Customer_MothersName.Text = "TEST_" + new Random().Next();
			tb_Customer_Name.Text = "TEST_" + new Random().Next();
			tb_Customer_OriginalName.Text = "TEST_" + new Random().Next();
			tb_Customer_PIDNum.Text = "TEST_" + new Random().Next();
			tb_Customer_Schooling.Text = "TEST_" + new Random().Next();
			tb_Customer_Skill.Text = "TEST_" + new Random().Next();
			tb_Customer_UH.Text = "TEST_" + new Random().Next();
			tb_Customer_Work.Text = "TEST_" + new Random().Next();
			tb_StudyBy.Text = "TEST_" + new Random().Next();
			tb_StudyOn.Text = DateTime.Now.ToShortDateString();
		}
		
		public void addIncomeExpenditure(bool expenditure)
		{
			f_AddVagyon f_vagy = new f_AddVagyon()
			{
				sqlc = sqlc,
				edit = false,
				customer_id = customer_id,
				expenditure = expenditure
			};

			f_vagy.ShowDialog();

			if (f_vagy.OK)
			{
				fillCustomerVagyon(c_DBHandler.getCustomerAllData(sqlc, customer_id).cust_1_vagyon);
			}
		}

		public void removeIncomeExpenditure(bool expenditure)
		{
			if (lv_CustomerIncome.FocusedItem != null)
			{
				if (MessageBox.Show("Törölni készül egy sort az ügyfél vagyon táblából.\r\nA törlés ha végbement, már nem vonható vissza.\r\n\r\nBiztosan folytatja?", "Figyelem!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
					if (expenditure)
					{
						c_DBHandler.modifyVagyonRow(sqlc, Convert.ToInt32(lv_CustomerExpenditure.FocusedItem.Tag), "", 0, "", true);
					}
					else
					{
						c_DBHandler.modifyVagyonRow(sqlc, Convert.ToInt32(lv_CustomerIncome.FocusedItem.Tag), "", 0, "", true);
					}
				}

				fillCustomerVagyon(c_DBHandler.getCustomerAllData(sqlc, customer_id).cust_1_vagyon);
			}
		}

		public void editIncomeExpenditure(bool expenditure)
		{
			if ((!expenditure && lv_CustomerIncome.FocusedItem != null) || 
				(expenditure && lv_CustomerExpenditure.FocusedItem != null))
			{
				f_AddVagyon f_vagy = new f_AddVagyon()
				{
					sqlc = sqlc,
					edit = true,
					id = expenditure ? Convert.ToInt32(lv_CustomerExpenditure.FocusedItem.Tag) : Convert.ToInt32(lv_CustomerIncome.FocusedItem.Tag),
					customer_id = customer_id,
					expenditure = expenditure
				};

				f_vagy.ShowDialog();

				if (f_vagy.OK)
				{
					fillCustomerVagyon(c_DBHandler.getCustomerAllData(sqlc, customer_id).cust_1_vagyon);
				}
			}
		}


		public void fillCustomerVagyon(List<vagyon> vagyonlista)
		{
			int bevétel = 0;
			int kiadás = 0;

			lv_CustomerIncome.Items.Clear();
			lv_CustomerExpenditure.Items.Clear();

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

			kiadás *= -1;

			tb_Income_Sum.Text = bevétel + "";
			tb_Expenditure_Sum.Text = kiadás + "";
			tb_Net_Income.Text = (kiadás + bevétel) + "";
		}

		private void btn_Income_Add_Click(object sender, EventArgs e)
		{
			addIncomeExpenditure(false);
		}

		private void btn_Income_Remove_Click(object sender, EventArgs e)
		{
			removeIncomeExpenditure(false);
		}

		private void btn_Income_Edit_Click(object sender, EventArgs e)
		{
			editIncomeExpenditure(false);
		}

		private void btn_Expenditure_Add_Click(object sender, EventArgs e)
		{
			addIncomeExpenditure(true);
		}

		private void btn_Expenditure_Remove_Click(object sender, EventArgs e)
		{
			removeIncomeExpenditure(true);
		}

		private void btn_Expenditure_Edit_Click(object sender, EventArgs e)
		{
			editIncomeExpenditure(true);
		}

		private void tb_Customer_City_Leave(object sender, EventArgs e)
		{
			_city = tb_Customer_City.Text.ToLower();

			if (_t == null)
			{
				_t = new Thread(new ThreadStart(checkZipCode));
				_t.Start();
			}
		}

		public void checkZipCode()
		{
			if (_xml.tryGetCity(_city, out city c))
			{
				_zip = c.zipcode;
				lbl_ZipCode.Invoke(new myDelegate(setZip));
			}
			_t = null;
			GC.Collect();
		}

		public delegate void myDelegate();
		public void setZip()
		{
			lbl_ZipCode.Text = _zip;
		}

		private void btn_EditZipCode_Click(object sender, EventArgs e)
		{
			TextBox tb = new TextBox();
			tb.Name = "tb_ZipCode";
			tb.Parent = gb_PlaceOfResidence;
			tb.Top = lbl_ZipCode.Top - 2;
			tb.Left = lbl_ZipCode.Left + 2;
			tb.Text = lbl_ZipCode.Text;
			tb.BringToFront();
			ziptb = tb;
			

			Button btn = new Button();
			btn.Parent = gb_PlaceOfResidence;
			btn.Text = "Mentés";
			btn.AutoSize = false;
			btn.Height-=1;
			btn.Left = tb.Right + 2;
			btn.Top = tb.Top - 1;
			btn.Click += Btn_Click;

			btn_EditZipCode.Hide();
			ziptb.Tag = btn;
			ziptb.KeyDown += Ziptb_KeyDown;

		}

		private void Ziptb_KeyDown(object sender, KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Enter)
			{
				if(((TextBox)sender).Tag != null)
				{
					((Button)((TextBox)sender).Tag).PerformClick();
				}
			}
		}

		private void Btn_Click(object sender, EventArgs e)
		{
			if(ziptb.Text != "")
			{
				lbl_ZipCode.Text = ziptb.Text;
				tb_Customer_City.Text = _xml.getCityName(ziptb.Text);
				((Button)sender).Dispose();
				ziptb.Dispose();
				btn_EditZipCode.Show();
			}
		}

		private void btn_DeleteCustomer_Click(object sender, EventArgs e)
		{
			f_DeleteCustomer fd = new f_DeleteCustomer
			{
				sqlc = sqlc,
				customerName = customerName,
				custid = customer_id,
				maindata = m,
				sqlc2 = sqlc2,
				who_deleted = login_profile.name
			};
			fd.ShowDialog();
			if (fd.OK) { reload = true; this.Close(); }
		}

		private void btn_SocialState_Add_Click(object sender, EventArgs e)
		{
			f_AddRokon ar = new f_AddRokon() {
				sqlc = sqlc,
				customer_id = customer_id,
				edit = false
			};
			ar.ShowDialog();
			fillCustomerRokonok(c_DBHandler.getCustomerAllData(sqlc, customer_id));
		}

		private void btn_SocialState_Remove_Click(object sender, EventArgs e)
		{
			if (lv_Relatives.FocusedItem != null)
			{
				if (MessageBox.Show("Törölni készül egy sort az ügyfél Egy Háztartásban Élők táblából.\r\nA törlés ha végbement, már nem vonható vissza.\r\n\r\nBiztosan folytatja?", "Figyelem!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
					c_DBHandler.modifyHaztartasbanElok(sqlc, Convert.ToInt32(lv_Relatives.FocusedItem.Tag), "", "", 0, true);
				}

				fillCustomerRokonok(c_DBHandler.getCustomerAllData(sqlc, customer_id));
			}
		}

		private void btn_SocialState_Edit_Click(object sender, EventArgs e)
		{
			editRokon();
		}

		public void editRokon()
		{
			if (lv_Relatives.FocusedItem != null)
			{
				f_AddRokon f_rokon = new f_AddRokon()
				{
					sqlc = sqlc,
					edit = true,
					id = Convert.ToInt32(lv_Relatives.FocusedItem.Tag),
					customer_id = customer_id
				};

				f_rokon.ShowDialog();

				if (f_rokon.OK)
				{
					fillCustomerRokonok(c_DBHandler.getCustomerAllData(sqlc, customer_id));
				}
			}
		}

		private void lv_Relatives_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			if(lv_Relatives.FocusedItem != null) { editRokon(); }
		}

		private void btn_EditCustomerIdentification_Click(object sender, EventArgs e)
		{
			tb_CustomerIdentification.ReadOnly = false;
			tb_CustomerIdentification.SelectAll();
		}
	}

	public class city
	{
		public string name { get; set; }
		public string zipcode { get; set; }
		
	}

	public class aidsclass
	{
		public string type { get; set; }
		public string value { get; set; }
		public string denoimination { get; set; }
	}
}
