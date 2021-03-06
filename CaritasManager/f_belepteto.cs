﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SQLite;

namespace CaritasManager
{
	public partial class f_belepteto : Form
	{
		SQLiteConnection _sqlc;
		SQLiteConnection _sqlc2;
		List<profile> _profs = new List<profile>();

		public f_belepteto()
		{
			InitializeComponent();

			Load += F_belepteto_Load;
		}
		
		private void F_belepteto_Load(object sender, EventArgs e)
		{
            try
            {
                c_DBHandler.createDBFile();
				SQLiteConnection[] conns = c_DBHandler.connectToDB();

				_sqlc = conns[0];
                _sqlc.Open();

				_sqlc2 = conns[1];
				_sqlc2.Open();

                c_DBHandler.createTables(_sqlc, _sqlc2);
            }
			catch (Exception ex)
			{
				MessageBox.Show($"Hiba lépett fel.\r\n\r\nHibakód: {ex.Message}", "Hiba!", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

			try
            {
                if (!c_DBHandler.checkPassword(_sqlc))
                {
                    MessageBox.Show("Jelenleg nincs a programban jelszó beállítva.\r\nAz OK gombra kattintás után, megjelenő ablakban állíthat be új érvényes jelszót.", "Nincs jelszó Beállítva", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    f_EditPassword fe = new f_EditPassword();
                    fe.empty = true;
                    fe.sqlc = _sqlc;
                    fe.ShowDialog();
                }
            }
            catch(Exception ex)
            {
				MessageBox.Show($"Hiba lépett fel.\r\n\r\nHibakód: {ex.Message}", "Hiba!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

			fillProfiles();


			//TODO::TESTING
			cb_UserProfile.SelectedIndex = 0;
			tb_Password.Text = "test";
			btn_Login_Click(null, null);
		}

		public void fillProfiles()
		{
			cb_UserProfile.Items.Clear();
			lbl_LastLoginInfo.Text = "";

			_profs = c_DBHandler.getProfiles(_sqlc);
			foreach(profile p in _profs)
			{
				cb_UserProfile.Items.Add(p.name);
			}
		}

		private void btn_AllSeeingEye_Click(object sender, EventArgs e)
		{
			if(tb_Password.PasswordChar == '•')
			{
				tb_Password.PasswordChar = '\0';
			}
			else
			{
				tb_Password.PasswordChar = '•';
			}
		}

		private void btn_Exit_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		public void login()
		{
			if (cb_UserProfile.SelectedIndex < 0)
			{
				MessageBox.Show("Jelenleg nincs profil kiválasztva.\r\nKérjük válasszon ki egy profilt a belépéshez.\r\nHa nincs profilja, hozzon létre egyet.", "Válasszon ki egy profilt!", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			profile p = new profile();

			foreach (profile pp in _profs)
			{
				if (cb_UserProfile.Text == pp.name)
				{
					p = pp;
					break;
				}
			}

			//TODO: handle profile

			if (c_DBHandler.login(_sqlc, tb_Password.Text, p))
			{
				Form1 f = new Form1();
				f.Login_profile = p;
				f.Sqlc = _sqlc;
				f.Sqlc2 = _sqlc2;
				this.Hide();
				f.ShowDialog();
				this.Show();
				fillProfiles();
				tb_Password.Text = "";
				cb_UserProfile.SelectedIndex = -1;
				lbl_BadPass.Visible = false;
			}
			else
			{
				lbl_BadPass.Visible = true;
			}
		}

		private void btn_Login_Click(object sender, EventArgs e)
		{
			login();
		}

		private void btn_NewProfile_Click(object sender, EventArgs e)
		{
			f_EditProfile ep = new f_EditProfile();
			ep.sqlc = _sqlc;
			ep.edit = false;
			ep.ShowDialog();
			fillProfiles();
		}

		private void cb_UserProfile_SelectedIndexChanged(object sender, EventArgs e)
		{
			foreach(profile p in _profs)
			{
				if(cb_UserProfile.Text == p.name)
				{
					lbl_LastLoginInfo.Text = p.last_login;
					return;
				}
			}
		}

		private void keyDown1(object sender, PreviewKeyDownEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				login();
			}
			else if (e.KeyCode == Keys.Escape)
			{
				Application.Exit();
			}
		}

		private void keyDown(object sender, PreviewKeyDownEventArgs e)
		{
			keyDown1(sender, e);
		}
	}
}
