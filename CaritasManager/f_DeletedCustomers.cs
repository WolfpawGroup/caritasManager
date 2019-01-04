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
				var definition = new
				{
					id =							00,
					nev =							"",
					születesi_nev =					"",
					szig_szam =						"",
					lakcim_varos =					"",
					lakcim_uh =						"",
					lakcim_zip =					"",
					szul_datum =					"",
					szul_hely =						"",
					csaladi_allapot =				00,
					anyja_neve =					"",
					vegzettseg =					"",
					foglalkozas =					"",
					szakkepzettseg =				"",
					munkaltato =					"",
					azonosito =						"",
					utolso_tamogatas_idopontja =	"",
					jovedelem_igazolas =			"",
					elhunyt =						"",
					allapot =						"",
					vallas =						00,
					környezettanulmanyt_végezte =	"",
					környezettanulmany_idopontja =	"",
					hozzaadas_datuma =				"",
					felvevo_profil =				"",
					legutobb_modositotta =			"",
					legutobbi_modositas_datuma =	""
				};

				var conv = JsonConvert.DeserializeAnonymousType(c.before, definition);

				ListViewItem lvi = new ListViewItem() {
					Tag = conv,
					Text = conv.azonosito,
					BackColor = listView1.Items.Count % 2 == 0 ? Color.LightGray : Color.LightYellow
				};

				lvi.SubItems.AddRange(new ListViewItem.ListViewSubItem[] {
					new ListViewItem.ListViewSubItem(){ Text = conv.nev },															//ch_CustomerName
					new ListViewItem.ListViewSubItem(){ Text = conv.lakcim_varos + " " + conv.lakcim_zip + " " + conv.lakcim_uh},	//ch_Address
					new ListViewItem.ListViewSubItem(){ Text = conv.szul_datum },													//ch_Birth
					new ListViewItem.ListViewSubItem(){ Text = conv.anyja_neve },													//ch_MothersName
					new ListViewItem.ListViewSubItem(){ Text = conv.utolso_tamogatas_idopontja },									//ch_LastAid
					new ListViewItem.ListViewSubItem(){ Text = conv.elhunyt == "T" ? "PIPA" : "IKSZ" },								//ch_PassedAway
					new ListViewItem.ListViewSubItem(){ Text = c.whochanged },														//ch_WhoDeleted
					new ListViewItem.ListViewSubItem(){ Text = c.whenchanged },														//ch_WhenDeleted
				});
				
				listView1.Items.Add(lvi);
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
