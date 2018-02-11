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
	public partial class f_DateSelector : Form
	{
		public DateTime selection { get; set; }

		public f_DateSelector()
		{
			InitializeComponent();
		}

		private void btn_Save_Click(object sender, EventArgs e)
		{
			selection = cal.SelectionStart;
			this.Close();
		}

		private void btn_Cancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
