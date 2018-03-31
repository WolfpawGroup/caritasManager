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
	public partial class f_AddRokon : Form
	{
		public SQLiteConnection sqlc { get; set; }
		public int customer_id { get; set; }
		public int id { get; set; }
		public bool edit { get; set; }
		public bool OK = false;


		public f_AddRokon()
		{
			InitializeComponent();
			Load += F_AddRokon_Load;
		}

		public void loaddata()
		{
			if (id > 0)
			{
				List<rokon> _rokon = c_DBHandler.getCustomerAllData(sqlc, customer_id).cust_5_rokonok;
				foreach (rokon r in _rokon)
				{
					if (r.id == id)
					{
						tb_Name.Text = r.nev;
						
						foreach(string s in Enum.GetNames(typeof(enums.rokoni_kapcsolat)))
						{
							if(s == Enum.GetName(typeof(enums.rokoni_kapcsolat), r.kapcsolat))
							{
								cb_Rokon.Text = s;
							}
						}

						num_Income.Value = r.havi_jovedelem;
					}
				}
			}
		}

		private void F_AddRokon_Load(object sender, EventArgs e)
		{
			foreach (string s in Enum.GetNames(typeof(enums.rokoni_kapcsolat)))
			{
				cb_Rokon.Items.Add(s.Replace("_", " "));
			}

			loaddata();
		}

		private void btn_Cancel_Click(object sender, EventArgs e)
		{
			OK = false;
			this.Close();
		}

		private void btn_Save_Click(object sender, EventArgs e)
		{
			if (tb_Name.Text != "" && cb_Rokon.Text != "")
			{
				OK = true;

				if (edit)
				{
					c_DBHandler.modifyHaztartasbanElok(sqlc, id, tb_Name.Text, cb_Rokon.SelectedIndex.ToString(), (int)num_Income.Value, false);
				}
				else
				{
					c_DBHandler.addRowToHaztartasbanElok(sqlc, customer_id, tb_Name.Text, cb_Rokon.SelectedIndex.ToString(), (int)num_Income.Value);
				}

				this.Close();
			}
			else
			{
				if(tb_Name.Text == "") { tb_Name.BackColor = Color.LightPink; } else { tb_Name.BackColor = Color.White; }
				if(cb_Rokon.Text == "") { MessageBox.Show("Nincs rokoni kapcsolat kiválasztva","Hiba!",MessageBoxButtons.OK,MessageBoxIcon.Error); }
			}
		}
	}
}
