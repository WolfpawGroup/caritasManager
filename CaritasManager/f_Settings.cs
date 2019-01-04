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
	public partial class f_Settings : Form
	{

		public SQLiteConnection sqlc { get; set; }
		public SQLiteConnection sqlc2 { get; set; }
		public profile prof { get; set; }
		public bool OK = false;

		public f_Settings()
		{
			InitializeComponent();
			Load += F_Settings_Load;
		}

		private void F_Settings_Load(object sender, EventArgs e)
		{
			lbl_Profile.Text = prof.name;
		}

		private void btn_EditProfile_Click(object sender, EventArgs e)
		{
			f_EditProfile fedp = new f_EditProfile();
			fedp.prof = prof;
			fedp.edit = true;
			fedp.sqlc = sqlc;
			fedp.ShowDialog();

			foreach (profile p in c_DBHandler.getProfiles(sqlc))
			{
				if (p.name == prof.name) { prof = p; }
			}
		}

		private void btn_ChangePass_Click(object sender, EventArgs e)
		{
			f_EditPassword fedp = new f_EditPassword();
			fedp.sqlc = sqlc;
			fedp.empty = false;
			fedp.ShowDialog();
		}

		private void btn_ShowDeletedCustomers_Click(object sender, EventArgs e)
		{
			f_DeletedCustomers fdc = new f_DeletedCustomers() {
				sqlc = sqlc2
			};
			fdc.ShowDialog();
		}

		private void btn_Cancel_Click(object sender, EventArgs e)
		{
			OK = false;
			this.Close();
		}

		private void btn_Save_Click(object sender, EventArgs e)
		{
			OK = true;
			//TODO: Don't forget to add settings
			this.Close();
		}
	}
}
