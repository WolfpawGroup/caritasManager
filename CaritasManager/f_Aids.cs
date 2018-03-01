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
	public partial class f_Aids : Form
	{
		List<Panel> plist = new List<Panel>();
		public int customer_id { get; set; }
		public System.Data.SQLite.SQLiteConnection sqlc { get; set; }
		bool extreme = false;
		string aid_type = "";
		string aid_amount = "";
		string aid_unit = "";

		public f_Aids()
		{
			InitializeComponent();

			Load += F_Aids_Load;
		}

		private void F_Aids_Load(object sender, EventArgs e)
		{
			plist.Add(p_Food);
			plist.Add(p_Clothes);
			plist.Add(p_Bills);
			plist.Add(p_Medicine);
			plist.Add(p_Housing);
			plist.Add(p_Meal);
			plist.Add(p_Furniture);
			plist.Add(p_ExtremeAid);

			selectAid(p_Food);
		}

		public void selectAid(Panel p)
		{
			unselectAll();
			p.BackColor = Color.Red;

			if (p.Tag != null && p.Tag.ToString().Length > 0)
			{
				string[] tag = p.Tag.ToString().Split('|');
				if (tag[1] != "??")
				{
					p_Extreme.Visible = false;
					extreme = false;

					lbl_AidType.Text = tag[0];
					lbl_AidUnit.Text = tag[1];

					tb_AidAmount.Left = lbl_AidType.Right + 10;

					if (lbl_AidUnit.Text.Length > 0)
					{
						tb_AidAmount.Width = Width - 33 - tb_AidAmount.Left - 40;
					}
					else
					{
						tb_AidAmount.Width = Width - 33 - tb_AidAmount.Left;
					}
				}
				else
				{
					p_Extreme.Visible = true;
					extreme = true;
				}
			}

		}

		public void unselectAll()
		{
			foreach(Panel p in plist) { p.BackColor = Color.Transparent; }
		}

		private void selectAid(object sender, EventArgs e)
		{
			selectAid(((Panel)sender));
		}

		public void getData()
		{
			if (extreme)
			{
				aid_type = cb_ExtremeType.Text;
				aid_unit = cb_ExtremeUnit.Text;
				aid_amount = tb_ExtremeAmount.Text;
			}
			else
			{
				aid_type = lbl_AidType.Text;
				aid_unit = lbl_AidUnit.Text;
				aid_amount = tb_AidAmount.Text;
			}
		}

		private void btn_AddAid_Click(object sender, EventArgs e)
		{
			getData();

			c_DBHandler.addRowToTamogatasok(sqlc, customer_id, DateTime.Now.ToShortDateString(), aid_type, aid_amount, aid_unit, (extreme ? "Rendkívüli Segély" : ""));
			c_DBHandler.modifyUgyfelRow(sqlc, new Dictionary<string, string>() { { "utolso_tamogatas_idopontja", DateTime.Now.ToShortDateString() } }, customer_id, false);

			this.Close();
		}

		private void btn_Cancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
