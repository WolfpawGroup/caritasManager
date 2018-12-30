using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaritasManager
{
	/// <summary>
	/// MainDataRow Class - Contains only data required for the main screen
	/// </summary>
	public class c_MainDataRow
	{
		/// <summary>
		/// Ügyfél ID
		/// </summary>
		public int id { get; set; }

		/// <summary>
		/// Ügyfél neve
		/// </summary>
		public string name { get; set; }

		/// <summary>
		/// Jövedelem igazolását leadta
		/// </summary>
		public bool j { get; set; }

		/// <summary>
		/// Ügyfél azonosító száma eg: 001112
		/// </summary>
		public string identification { get; set; }

		/// <summary>
		/// Ügyfél lakhelye (Város)
		/// </summary>
		public string city { get; set; }

		/// <summary>
		/// Ügyfél lakhelye (Utca, Házszám)
		/// </summary>
		public string houseno { get; set; }

		/// <summary>
		/// Ügyfél lakhelye (zipcode)
		/// </summary>
		public string zip { get; set; }

		/// <summary>
		/// Ügyfél állapota
		/// </summary>
		public string state { get; set; }

		/// <summary>
		/// Mikor lett felvéve az ügyfél az adatbázisba (SDT)
		/// </summary>
		public DateTime dateAdded { get; set; }
		
		/// <summary>
		/// Mikor lett felvéve az ügyfél az adatbázisba (SDT)
		/// </summary>
		public string dtadded { get; set; }

		/// <summary>
		/// Mikor kapott utoljára segélyt az ügyfél
		/// </summary>
		public DateTime? lastSupport { get; set; }

		/// <summary>
		/// Ügyfél hozzátartozói
		/// </summary>
		public List<string> kin { get; set; }
	}

	/// <summary>
	/// Enums for later
	/// </summary>
	public class enums
	{
		public enum vallás
		{
			Római_katolikus,
			Evangélikus,
			Református,
			Metodista,
			Baptista,
			Unitárius,
			Nem_hívő,
			Egyéb
		}

		public enum lakás
		{
			Saját_Lakás,
			Albérlő,
			Társbérlő,
			Hajléktalan,
			Szívességi_Lakáshasználó
		}

		public enum általános_szociális_helyzet
		{
			Jó,
			Közepes,
			Megfelelő,
			Rossz
		}

		public enum rendszeres_segítségre_szorul
		{
			Igen,
			Nem,
			Esetenként
		}

		public enum családi_állapot
		{
			Nős,
			Nőtlen,
			Férjezett,
			Hajadon,
			Özvegy,
			Elvált
		}

		public enum rokoni_kapcsolat
		{
			Szülő,
			Nagyszülő,
			Gyermek,
			Testvér,
			Férj,
			Feleség,
			Egyéb_rokon
		}
	}
	
	/// <summary>
	/// MainData Class - Contains all the data required for the main customer data lines
	/// </summary>
	public class mainData
	{
		public int id { get; set; }
		public string nev { get; set; }
		public string születesi_nev { get; set; }
		public string szig_szam { get; set; }
		public string lakcim_varos { get; set; }
		public string lakcim_uh { get; set; }
		public string lakcim_zip { get; set; }
		public string szul_datum { get; set; }
		public string szul_hely { get; set; }
		public int csaladi_allapot { get; set; }
		public string anyja_neve { get; set; }
		public string vegzettseg { get; set; }
		public string foglalkozas { get; set; }
		public string szakkepzettseg { get; set; }
		public string munkaltato { get; set; }
		public string azonosito { get; set; }
		public string utolso_tamogatas_idopontja { get; set; }
		public bool jovedelem_igazolas { get; set; }
		public bool elhunyt { get; set; }
		public string allapot { get; set; }
		public string vallas { get; set; }
		public string környezettanulmanyt_végezte { get; set; }
		public string környezettanulmany_idopontja { get; set; }
		public string hozzaadas_datuma { get; set; }
		public string felvevo_profil { get; set; }
		public string legutobb_modositotta { get; set; }
		public string legutobbi_modositas_datuma { get; set; }
	}

	/// <summary>
	/// Profile Class - 
	/// Contains all data added to the profile table
	/// </summary>
	public class profile
	{
		public string name { get; set; }
		public string fontFamily { get; set; }
		public string fontSize { get; set; }
		public string fontStyle { get; set; }
		public string fontColor { get; set; }
		public string color_1 { get; set; }
		public string color_2 { get; set; }
		public string color_3 { get; set; }
		public string last_login { get; set; }
	}

	/// <summary>
	/// Vagyon Class - Contains data required for Vagyon rows
	/// </summary>
	public class vagyon
	{
		public int id { get; set; }
		public string szoveg { get; set; }
		public int osszeg { get; set; }
		public string tipus { get; set; } //B = Bevétel | K = Kiadás | M = Megjegyzés
	}

	/// <summary>
	/// Rokon Class - Contains data required for Rokon rows
	/// </summary>
	public class rokon
	{
		public int id { get; set; }
		public string nev { get; set; }
		public enums.rokoni_kapcsolat kapcsolat { get; set; }
		public int havi_jovedelem { get; set; }
	}

	/// <summary>
	/// Tamogatas Class - Contains data required for Tamogatas rows
	/// </summary>
	public class tamogatas
	{
		public int id { get; set; }
		public DateTime datum { get; set; }
		public string tamogatas_tipusa { get; set; }
		public string tamogatas_mennyisege { get; set; }
		public string tamogatas_egysége { get; set; }
		public string megjegyzes { get; set; }
	}

	/// <summary>
	/// Customer all Data Class - Contains all the data that is required to be SELECTED / UPDATED when editing user profile
	/// </summary>
	public class customerAllData
	{
		public mainData cust_0_mainData { get; set; }
		public List<vagyon> cust_1_vagyon { get; set; }
		public enums.lakás cust_2_lakas { get; set; }
		public enums.általános_szociális_helyzet cust_3_alt_szoc_helyzet { get; set; }
		public enums.rendszeres_segítségre_szorul cust_4_rendsz_seg_szorul { get; set; }
		public List<rokon> cust_5_rokonok { get; set; }
		public List<tamogatas> cust_6_tamogatasok { get; set; }
	}

	public class changes
	{
		public int id { get; set; }
		public int cust_id { get; set; }
		public string table { get; set; }			//Ugyfel when deleted user
		public string before { get; set; }			//Customer data when deleted user
		public string after { get; set; }			//empty when deleted user
		public string whochanged { get; set; }		//whodeleted
		public string whenchanged { get; set; }		//whendeleted
	}
}
