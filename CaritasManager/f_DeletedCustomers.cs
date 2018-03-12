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
	public partial class f_DeletedCustomers : Form
	{
		//TODO: feltölteni sorokkal a törölt ügyfelek táblából
		//TODO: megoldani, hogy vissza lehessen állítani a törölt ügyfelet (jelszó??)

		public f_DeletedCustomers()
		{
			InitializeComponent();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
