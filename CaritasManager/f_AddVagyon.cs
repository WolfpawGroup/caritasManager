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
	public partial class f_AddVagyon : Form
	{
		public SQLiteConnection sqlc { get; set; }
		public int customer_id { get; set; }
		public int id { get; set; }
		public bool edit { get; set; }
		public bool OK = false;

		public f_AddVagyon()
		{
			InitializeComponent();
			Load += F_AddVagyon_Load;
		}

		public void loaddata()
		{
			if(id > 0)
			{
				List<vagyon> _vagyon = c_DBHandler.getCustomerAllData(sqlc, customer_id).cust_1_vagyon;
				foreach (vagyon v in _vagyon)
				{
					if (v.id == id)
					{
						tb_Name.Text = v.szoveg;

						if (v.tipus == "B") { rb_Income.Checked = true; }
						else { rb_Expenditure.Checked = true; }

						num_Amount.Value = v.osszeg;
					}
				}
			}
		}

		private void F_AddVagyon_Load(object sender, EventArgs e)
		{
			if (edit)
			{
				Text = "Bevétel / Kiadás módosítása";
				loaddata();
			}
		}

		private void btn_Cancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void btn_Save_Click(object sender, EventArgs e)
		{
			OK = true;

			if (edit)
			{
				c_DBHandler.modifyVagyonRow(sqlc, id, tb_Name.Text, (int)Math.Abs(num_Amount.Value), (rb_Income.Checked ? "B" : "K"), false);
			}
			else
			{
				c_DBHandler.addRowToVagyon(sqlc, customer_id, tb_Name.Text, (int)Math.Abs(num_Amount.Value), (rb_Income.Checked ? "B" : "K"));
			}

			this.Close();

		}
	}
}
