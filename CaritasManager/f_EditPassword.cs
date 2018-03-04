﻿using System;
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
	public partial class f_EditPassword : Form
	{
		public bool empty { get; set; }
		public SQLiteConnection sqlc { get; set; }

		public f_EditPassword()
		{
			InitializeComponent();

			Load += F_EditPassword_Load;
		}

		private void F_EditPassword_Load(object sender, EventArgs e)
		{
			if (empty)
			{
				tb_NewPassWord.Select();
				btn_AllSeeingEye_Old.Enabled = false;
				tb_OldPassWord.Enabled = false;
				btn_Cancel.Enabled = false;
				label1.Enabled = false;
			}
			else
			{
				tb_OldPassWord.Select();

			}
		}

		private void btn_Cancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void btn_SetPassword_Click(object sender, EventArgs e)
		{
			save();
		}

		private void save()
		{
			//VERY IMPORTANT:add modify as well!!!
			if (empty)
			{
				if (tb_NewPassWord.Text.Length > 0)
				{
					c_DBHandler.editPassword(sqlc, tb_NewPassWord.Text);
				}
			}
			else
			{
				if(c_DBHandler.login(sqlc, tb_OldPassWord.Text, null) && tb_NewPassWord.Text.Length > 0)
				{
					c_DBHandler.editPassword(sqlc, tb_NewPassWord.Text);
				}
			}

			this.Close();
		}


		private void btn_AllSeeingEye_Old_Click(object sender, EventArgs e)
		{
			if (tb_OldPassWord.PasswordChar == '•')
			{
				tb_OldPassWord.PasswordChar = '\0';
			}
			else
			{
				tb_OldPassWord.PasswordChar = '•';
			}
		}

		private void btn_AllSeeingEye_New_Click(object sender, EventArgs e)
		{
			if (tb_NewPassWord.PasswordChar == '•')
			{
				tb_NewPassWord.PasswordChar = '\0';
			}
			else
			{
				tb_NewPassWord.PasswordChar = '•';
			}
		}

		private void f_EditPassword_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				save();
			}
			else if (e.KeyCode == Keys.Escape)
			{
				this.Close();
			}
		}

		private void tb_OldPassWord_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
		{
			f_EditPassword_PreviewKeyDown(sender, e);
		}
	}
}
