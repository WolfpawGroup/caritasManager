﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Common;
using System.Data.SQLite;
using System.IO;
using System.Xml;

namespace CaritasManager
{
	public partial class Form1 : Form
	{
		public	profile						login_profile			{ get; set; }
		public	SQLiteConnection			sqlc					= null;
		public	bool						showKin					= false;
		public	bool						backupForCurrentDate	= false;
		public	bool						scrollMovePosition		= false;
		private	int							showKinCheck			= 0;
		private List<city>					cities					= new List<city>();
		private	DataGridViewCellEventArgs	showKinArgs				= null;

		public Form1()
		{
			InitializeComponent();

			Load += Form1_Load;

		}

		private void Form1_Load(object sender, EventArgs e)
		{
			//TODO: Remove This!
			//sqlc = c_DBHandler.connectToDB()[0];
			//sqlc.Open();
			//login_profile = c_DBHandler.getProfiles(sqlc)[0];
			
			try
			{
				XmlDocument xmld = new XmlDocument();
				xmld.LoadXml(Properties.Resources.cityList);
				XmlNode xe = xmld.FirstChild;

				foreach (XmlNode x in xmld.GetElementsByTagName("city"))
				{
					city _c = new city() { name = x.FirstChild.InnerText, zipcode = x.LastChild.InnerText };
					cities.Add(_c);
				}
			}
			catch
			{

			}

			createIdFile();

			lbl_LoggedInAs.Text = "Belépve mint: " + login_profile.name;

			Color[] c = new Color[] {
				Color.FromArgb(Convert.ToInt32(login_profile.color_1)),
				Color.FromArgb(Convert.ToInt32(login_profile.color_2)),
				Color.FromArgb(Convert.ToInt32(login_profile.color_3))
			};

			scrollMovePosition = Properties.Settings.Default.s_ScrollMovePosition;

			tb_Filter_City.AutoCompleteCustomSource.AddRange(Properties.Resources.telepulesek.Replace("\r", "").Split('\n'));

			dg_DataTable.colors = c;

			fillMainList();

			dg_DataTable.Invalidate();

			dg_DataTable.MouseWheel += Dg_DataTable_MouseWheel;
		}

		private void Dg_DataTable_MouseWheel(object sender, MouseEventArgs e)
		{
			if (scrollMovePosition)
			{
				((HandledMouseEventArgs)e).Handled = true;

				if (e.Delta > 0)
				{
					SendKeys.SendWait("{UP}");
				}
				else
				{
					SendKeys.SendWait("{DOWN}");
				}
			}
		}

		public void createIdFile()
		{
			if (!File.Exists("last_id.ini"))
			{
				File.Create("last_id.ini").Close();
				File.WriteAllText("last_id.ini", "0");

				//TODO: Warn that file changed
			}
		}
		
		private void dg_DataTable_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
		{
			showKin = false;
			t_Timer.Stop();
			tt_Tooltip.hide();
		}

		private void dataGridView1_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
		{
			if (e.ColumnIndex == 0)
			{
				try
				{
					showKin = true;
					showKinArgs = e;
					showKinCheck = 0;
					t_Timer.Start();
				}
				catch
				{

				}
			}
			else
			{
				showKin = false;
				t_Timer.Stop();
				tt_Tooltip.hide();
			}
			//
		}

		private void ShowKin(DataGridViewCellEventArgs e)
		{
			try
			{
				if (e.RowIndex > -1)
				{
					List<string> k = (dg_DataTable[e.ColumnIndex, e.RowIndex].Tag as object[])[0] as List<string>;
					string kin = "";

					foreach (string s in k)
					{
						kin += (s.Split(':')[0] + " - ").PadRight(12, ' ');
						kin += s.Split(':')[1] + "\r\n";
					}

					kin = kin.Trim();

					if (kin.Length > 3)
					{
						Point p = PointToClient(Cursor.Position);

						int rowTop = 0;
						int colRight = dg_DataTable[e.ColumnIndex, e.RowIndex].Size.Width;

						rowTop += ts_Tools.Height;
						rowTop += dg_DataTable.ColumnHeadersHeight;
						for (int i = 0; i < e.RowIndex; i++) { rowTop += dg_DataTable[0, i].Size.Height; }
						rowTop -= dg_DataTable.VerticalScrollingOffset;

						tt_Tooltip.font = new Font("Consolas", 14, FontStyle.Regular);
						tt_Tooltip.text = kin;
						tt_Tooltip.title = "Háztartásban élők";
						tt_Tooltip.show(new Point(colRight, rowTop));
					}
					else
					{
						tt_Tooltip.hide();
					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
			}
		}

		private void fillMainList()
		{
			List<c_MainDataRow> lst = c_DBHandler.getMainRowData(sqlc, " where 1=1");

			fillRows(lst);

			lbl_NumOfCustomers.Text = "Ügyfelek száma: " + dg_DataTable.Rows.Count;
		}

		public void fillRows(List<c_MainDataRow> lst)
		{
			dg_DataTable.Rows.Clear();

			int I = 0;

			Bitmap img = new Bitmap(22, 22);
			Bitmap img2 = new Bitmap(22, 22);
			using (Graphics g = Graphics.FromImage(img))
			{
				g.FillEllipse(Brushes.White, new Rectangle(1, 1, 18, 18));
				g.DrawImage(Properties.Resources.checkmark_icon_2, new Point(0, 0));
			}

			foreach (c_MainDataRow mdr in lst)
			{
				DateTime n = DateTime.Now;
				int lasts = 0;// (mdr.lastSupport as DateTime?) != null ? (int)Math.Floor((new DateTime(n.Year, n.Month, n.Day) - (DateTime)mdr.lastSupport).TotalDays) : 30;

				if((mdr.lastSupport as DateTime?) == null)
				{
					lasts = 1;
				}
				else
				{
					if(mdr.lastSupport.Value.Year == DateTime.Now.Year && mdr.lastSupport.Value.Month == DateTime.Now.Month) { lasts = 0; }
					else if((n - mdr.lastSupport.Value).TotalDays >= 365) { lasts = 2; }
					else { lasts = 1; }
				}


				dg_DataTable.Rows.Insert(
					I,
					new object[] {
						mdr.name + (mdr.kin.Count > 0 ? "  (" + (mdr.kin.Count + 1) + ")" : ""),
						mdr.j == true ? img : img2,
						mdr.identification,
						mdr.city,
						mdr.state,
						mdr.dateAdded.ToShortDateString(),
						mdr.lastSupport != null ? ((DateTime)mdr.lastSupport).ToShortDateString() : "",
						"Támogatás"
					}
				);
				dg_DataTable.Rows[I].Cells[0].Tag = new object[] { mdr.kin, mdr.id };

				Color c = lasts == 0 ? Color.FromArgb(Convert.ToInt32(login_profile.color_1)) : (lasts == 1 ? Color.FromArgb(Convert.ToInt32(login_profile.color_2)) : Color.FromArgb(Convert.ToInt32(login_profile.color_3)));

				dg_DataTable.Rows[I].DefaultCellStyle.BackColor = c;
				dg_DataTable.Rows[I].DefaultCellStyle.SelectionBackColor = c;

				dg_DataTable.Rows[I].DefaultCellStyle.Font = new Font(login_profile.fontFamily, (float)Convert.ToDouble(login_profile.fontSize), (FontStyle)Convert.ToInt32(login_profile.fontStyle));

				I++;
			}
		}

		private void t_Timer_Tick(object sender, EventArgs e)
		{
			if (showKinCheck >= 8)
			{
				if (showKin == true)
				{
					t_Timer.Stop();
					ShowKin(showKinArgs);
				}
				showKinCheck = 0;
			}

			showKinCheck++;
		}

		private void btn_Exit_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void btn_NewCustomer_Click(object sender, EventArgs e)
		{
			f_AddCustomer fad = new f_AddCustomer();
			fad.login_profile = login_profile;
			fad.sqlc = sqlc;
			fad.cities = cities;
			fad.ShowDialog();
			if (fad.reload) { fillMainList(); }
			int cid = -1;
			if (fad.OK)
			{
				cid = fad.customer_id;
				fillMainList();
				fad = new f_AddCustomer();
				fad.login_profile = login_profile;
				fad.sqlc = sqlc;
				fad.cities = cities;
				fad.edit = true;
				fad.customer_id = cid;
				fad.ShowDialog();
			}
		}

		int selectedrow = 0;

		private void dg_DataTable_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			selectedrow = e.RowIndex;
			lbl_SelectedCustomer_Name.Text = dg_DataTable.Rows[selectedrow].Cells[0].Value.ToString();
			//dg_DataTable.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;

			//TODO: add some form of selection marker to this thing...
			/*
				foreach(DataGridViewRow v in dg_DataTable.Rows)
				{
					v.DefaultCellStyle = new DataGridViewCellStyle() { Font = new Font(dg_DataTable.Font.FontFamily, dg_DataTable.Font.Size, FontStyle.Regular) };
				}

				dg_DataTable[e.ColumnIndex, e.RowIndex].Style = new DataGridViewCellStyle()
				{
					Font = new Font(dg_DataTable.Font.FontFamily, dg_DataTable.Font.Size, FontStyle.Underline)
				};
			*/
			/*Ehh... good enough...*/
		}

		private void dg_DataTable_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
		{
			
		}


		private void button2_Click(object sender, EventArgs e)
		{
			f_Aids faids = new f_Aids();
			faids.ShowDialog();
		}

		private void dg_DataTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			if(e.ColumnIndex == 7)
			{
				try
				{
					int index = dg_DataTable.SelectedRows[0].Index;
					int col = dg_DataTable.SortedColumn != null ? dg_DataTable.SortedColumn.Index : 0;
					//DataGridViewColumnSortMode mod = dg_DataTable.SortedColumn.SortMode;

					f_Aids fa = new f_Aids()
					{
						sqlc = sqlc,
						customer_id = Convert.ToInt32((dg_DataTable.Rows[e.RowIndex].Cells[0].Tag as object[])[1].ToString())
					};
					fa.ShowDialog();

					fillMainList();

					//dg_DataTable.Columns[col].SortMode = mod;
					dg_DataTable.Sort(dg_DataTable.Columns[col], ListSortDirection.Ascending);
					dg_DataTable.Rows[index].Selected = true;
				}
				catch(Exception ex)
				{
					Console.WriteLine("ERROR:\r\n" + ex);
				}
			}
		}

		private void dg_DataTable_KeyDown(object sender, KeyEventArgs e)
		{
			
		}

		private void toolStripButton1_Click(object sender, EventArgs e)
		{
			if(dg_DataTable.SelectedRows != null && dg_DataTable.SelectedRows.Count > 0 && dg_DataTable.SelectedRows[0].Cells[0].Tag != null)
			{
				object[] oo = dg_DataTable.SelectedRows[0].Cells[0].Tag as object[];
				if (oo.Length == 2)
				{
					f_AddCustomer fa = new f_AddCustomer()
					{
						edit = true,
						sqlc = sqlc,
						cities = cities,
						customer_id = Convert.ToInt32(oo[1]),
						login_profile = login_profile
					};

					fa.ShowDialog();
					if (fa.reload) { fillMainList(); }
				}

			}
		}




		

		private void btn_DatabaseBackup_Click(object sender, EventArgs e)
		{
			string loc = Properties.Settings.Default.s_BackupLocation;
			try
			{
				if (loc == "" || !Directory.Exists(loc))
				{
					loc = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\CaritasManager Adatbázis biztonsági mentés" + (backupForCurrentDate ? " " + DateTime.Now.ToShortDateString() : "");
					Directory.CreateDirectory(loc);
				}

				File.Copy("database.sqlite", loc + "\\database.sqlite");
				File.Copy("changes.sqlite", loc + "\\changes.sqlite");

				System.Diagnostics.Process.Start(loc);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString(), "Hiba a mentés közben!", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void btn_Filter_Click(object sender, EventArgs e)
		{
			string where = " where ";

			if (tb_Filter_Name.Text != "")
			{
				if (cb_FullMatch.Checked)
				{
					where += $" lower(nev) = '{tb_Filter_Name.Text.ToLower()}'";
				}
				else
				{
					where += $" lower(nev) LIKE '%{tb_Filter_Name.Text.ToLower()}%'";
				}
			}

			if (tb_Filter_City.Text != "")
			{
				if (where.Trim() != "where") { where += " AND "; }
				where += $" trim(lower(lakcim_varos)) LIKE '%{tb_Filter_City.Text.ToLower().Trim()}%'";
			}

			if (cb_Filter_State.Text != "")
			{
				if (where.Trim() != "where") { where += " AND "; }
				where += $" trim(instr(lower(allapot)), '{cb_Filter_State.Text.ToLower().Trim()}')";
			}

			if (where.ToLower().Trim() == "where") { where = ""; }

			List<c_MainDataRow> lst = c_DBHandler.getMainRowData(sqlc, where);

			fillRows(lst);

			lbl_NumOfCustomers.Text = "Kiszűrt ügyfelek száma: " + dg_DataTable.Rows.Count;
		}

		private void btn_ClearFilter_Click(object sender, EventArgs e)
		{
			List<c_MainDataRow> lst = c_DBHandler.getMainRowData(sqlc, "");

			fillRows(lst);

			lbl_NumOfCustomers.Text = "Ügyfelek száma: " + dg_DataTable.Rows.Count;

			
		}

		private void dg_DataTable_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
		{

		}

		private void btn_Settings_Click(object sender, EventArgs e)
		{
			f_Settings fs = new f_Settings();
			fs.sqlc = sqlc;
			fs.prof = login_profile;
			fs.ShowDialog();
			foreach(profile p in c_DBHandler.getProfiles(sqlc))
			{
				if(p.name == login_profile.name) { login_profile = p; }
			}

			dg_DataTable.colors = new Color[] { Color.FromArgb(Convert.ToInt32(login_profile.color_1)), Color.FromArgb(Convert.ToInt32(login_profile.color_2)), Color.FromArgb(Convert.ToInt32(login_profile.color_3)) };

			fillMainList();
		}

		private void dg_DataTable_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			toolStripButton1_Click(null,null);
		}

		private void dg_DataTable_CellClick_1(object sender, DataGridViewCellEventArgs e)
		{
			selectedrow = e.RowIndex;
			fillOtherData();
		}

		private void dg_DataTable_SelectionChanged(object sender, EventArgs e)
		{
			selectedrow = dg_DataTable.CurrentRow.Index;
			fillOtherData();
		}

		public void fillOtherData()
		{
			//TODO: Add select for some extended data for customer selection
			//var cust = getSomeData();
			lbl_SelectedCustomer_Name.Text = dg_DataTable.Rows[selectedrow].Cells[0].Value.ToString();
			lbl_SelectedCustomer_ID.Text = "#" + dg_DataTable.Rows[selectedrow].Cells[2].Value.ToString();
		}

		private void panel1_Paint(object sender, PaintEventArgs e)
		{

		}
	}
}
