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
	public partial class f_DeleteCustomer : Form
	{
		public SQLiteConnection		sqlc			{ get; set; }
		public string				customerName	{ get; set; }
		public int					custid			{ get; set; }
		public bool					OK				= false;

		public SQLiteConnection		sqlc2			{ get; set; }
		public mainData				maindata		{ get; set; }
		public string				who_deleted		{ get; set; }

		public f_DeleteCustomer()
		{
			InitializeComponent();

			Load += F_DeleteCustomer_Load;
		}

		private void F_DeleteCustomer_Load(object sender, EventArgs e)
		{
			lbl_CustName.Text = customerName;
			Text += customerName;
		}

		private void btn_AllSeeingEye_Click(object sender, EventArgs e)
		{
			if (tb_Password.PasswordChar == '•')
			{
				tb_Password.PasswordChar = '\0';
			}
			else
			{
				tb_Password.PasswordChar = '•';
			}
		}

		private void btn_DeleteCustomer_Click(object sender, EventArgs e)
		{
			if (c_DBHandler.login(sqlc, tb_Password.Text, null))
			{
				c_DBHandler.modifyUgyfelRow(sqlc, null, custid, true);

				if (MessageBox.Show("Sikeresen törölte a [ " + customerName + " ] nevű ügyfelet.", "Ügyfél törölve!", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
				{
					OK = true;

					c_DBHandler.addRowToDeletedUserBackupTable(sqlc2, maindata, custid.ToString(), who_deleted, DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString());

					this.Close();
				}
			}
			else
			{
				MessageBox.Show("A jelszó amit megadott nem megfelelő.\r\nKérem próbálja újra!", "Hibás jelszó!", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void btn_Cancel_Click(object sender, EventArgs e)
		{
			OK = false;
			this.Close();
		}
	}
}
