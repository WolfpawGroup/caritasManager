using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SQLite;
using System.IO;

namespace CaritasManager
{
	public partial class Form1 : Form
	{
		public SQLiteConnection sqlc = null;
		public bool showKin = false;
		public profile login_profile { get; set; }
		DataGridViewCellEventArgs showKinArgs = null;

		int showKinCheck = 0;

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

			createIdFile();

			lbl_LoggedInAs.Text = "Belépve mint: " + login_profile.name;

			Color[] c = new Color[] {
				Color.FromArgb(Convert.ToInt32(login_profile.color_1)),
				Color.FromArgb(Convert.ToInt32(login_profile.color_2)),
				Color.FromArgb(Convert.ToInt32(login_profile.color_3))
			};

			dg_DataTable.colors = c;

			fillMainList();

			dg_DataTable.Invalidate();
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
			dg_DataTable.Rows.Clear();

			List<c_MainDataRow> lst = c_DBHandler.getMainRowData(sqlc);
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
				int lasts = (mdr.lastSupport as DateTime?) != null ? (int)Math.Floor((new DateTime(n.Year, n.Month, n.Day) - (DateTime)mdr.lastSupport).TotalDays) : 30;

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

				Color c = lasts <= 28 ? Color.LightGreen : (lasts <= 365 ? Color.Orange : Color.LightPink);

				dg_DataTable.Rows[I].DefaultCellStyle.BackColor = c;
				dg_DataTable.Rows[I].DefaultCellStyle.SelectionBackColor = c;

				I++;
			}

			lbl_NumOfCustomers.Text = "Ügyfelek száma: " + dg_DataTable.Rows.Count;
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
			fad.ShowDialog();
		}

		int selectedrow = 0;

		private void dg_DataTable_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			selectedrow = e.RowIndex;
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
		}

		private void dg_DataTable_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
		{
			try
			{
				if(e.RowIndex == selectedrow)
				{
					//e.Graphics.DrawRectangle(Pens.Black, e.RowBounds);
				}
			}
			catch
			{

			}
			
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
					f_Aids fa = new f_Aids()
					{
						sqlc = sqlc,
						customer_id = Convert.ToInt32((dg_DataTable.Rows[e.RowIndex].Cells[0].Tag as object[])[1].ToString())
					};
					fa.ShowDialog();

					fillMainList();
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
	}
}
