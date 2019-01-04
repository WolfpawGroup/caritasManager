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

using Newtonsoft.Json;

namespace CaritasManager
{
	public partial class f_DeletedCustomers : Form
	{
		public SQLiteConnection sqlc { get; set; }

		//TODO: feltölteni sorokkal a törölt ügyfelek táblából
		//TODO: megoldani, hogy vissza lehessen állítani a törölt ügyfelet (jelszó!!)

		public f_DeletedCustomers()
		{
			InitializeComponent();

			Load += F_DeletedCustomers_Load;
		}

		private void F_DeletedCustomers_Load(object sender, EventArgs e)
		{
			fillList();
		}

		public void fillList()
		{
			listView1.Items.Clear();
			List<changes> lst = c_DBHandler.getDeletedCustomers(sqlc);

			foreach(changes c in lst)
			{
				ListViewItem lvi = new ListViewItem();

				var conv = JsonConvert.DeserializeObject<mainData>(c.before);

				//TODO: parse	
				//TODO: Fill LVI with data
				//TODO: Set lvi style

				
				listView1.Items.Add(lvi);
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
