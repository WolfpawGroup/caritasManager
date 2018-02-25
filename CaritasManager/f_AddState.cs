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
	public partial class f_AddState : Form
	{
		public bool edit { get; set; }
		public string custName { get; set; }
		public string previousState { get; set; }
		public bool OK = false;
		public string state { get; set; }

		public f_AddState()
		{
			InitializeComponent();

			Load += F_AddState_Load;
		}

		private void F_AddState_Load(object sender, EventArgs e)
		{
			if(custName == "") { custName = "Új"; }
			lbl_StateGreeting.Text = lbl_StateGreeting.Text.Replace("<name>", custName);


			if (edit && previousState != "")
			{
				btn_Add.Text = "Módosítás";
				Text = "Állapot módosítása";
				cb_States.Text = previousState;
			}
		}

		private void btn_Add_Click(object sender, EventArgs e)
		{
			OK = true;
			state = cb_States.Text;
			this.Close();
		}

		private void btn_Cancel_Click(object sender, EventArgs e)
		{
			OK = false;
			this.Close();
		}
	}
}
