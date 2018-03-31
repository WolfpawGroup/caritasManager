using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaritasManager
{
	class c_Query_DBHandler
	{
		private static SQLiteDataReader reader = null;

		//Queries from main database

		/// <summary>
		/// Get list of user profiles
		/// </summary>
		/// <param name="sqlc">Current open SQLite Connection</param>
		/// <returns>List of profile objects</returns>
		public static List<profile> getProfiles(SQLiteConnection sqlc)
		{
			List<profile> proflist = new List<profile>();

			SQLiteCommand sqlk = new SQLiteCommand("SELECT * FROM profilok", sqlc);
			SQLiteDataReader r = sqlk.ExecuteReader();
			while (r.Read())
			{
				try
				{
					profile p = new profile();
					p.name = r.GetString(r.GetOrdinal("profil_name"));
					p.fontStyle = r.GetString(r.GetOrdinal("font_style"));
					p.fontSize = r.GetString(r.GetOrdinal("font_size"));
					p.fontFamily = r.GetString(r.GetOrdinal("font_family"));
					p.fontColor = r.GetString(r.GetOrdinal("font_color"));
					p.color_1 = r.GetString(r.GetOrdinal("color_1"));
					p.color_2 = r.GetString(r.GetOrdinal("color_2"));
					p.color_3 = r.GetString(r.GetOrdinal("color_3"));
					p.last_login = r.GetString(r.GetOrdinal("last_login"));

					proflist.Add(p);
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.ToString());
					System.Media.SystemSounds.Asterisk.Play();
				}
			}

			return proflist;
		}

		/// <summary>
		/// Get all rows for the mainData type (the type that is used to fill the main data table)
		/// </summary>
		/// <param name="sqlc">Current open SQLiteConnection</param>
		/// <returns>List containing every row in c_MainDataRow objects</returns>
		public static List<c_MainDataRow> getMainRowData(SQLiteConnection sqlc, string where)
		{
			string main_command = "SELECT id,nev,jovedelem_igazolas,azonosito,lakcim_varos,lakcim_uh,lakcim_zip,allapot,hozzaadas_datuma,utolso_tamogatas_idopontja FROM ugyfel " + where;

			List<c_MainDataRow> lst = new List<c_MainDataRow>();
			SQLiteCommand sqlk = new SQLiteCommand(main_command, sqlc);
			SQLiteDataReader r = sqlk.ExecuteReader();
			string current_azonosito = c_DBHandler.get_azonosito(sqlc);

			while (r.Read())
			{
				c_MainDataRow mdr = new c_MainDataRow();
				mdr.id = r.GetInt32(r.GetOrdinal("id"));
				mdr.name = c_DBHandler.checkvalueString(r.GetValue(r.GetOrdinal("nev")));  //--
				mdr.j = (c_DBHandler.checkvalueString(r.GetValue(r.GetOrdinal("jovedelem_igazolas"))) == "T" ? true : false);
				mdr.identification = c_DBHandler.checkvalueString(r.GetValue(r.GetOrdinal("azonosito")));
				mdr.city = c_DBHandler.checkvalueString(r.GetValue(r.GetOrdinal("lakcim_varos")));
				mdr.houseno = c_DBHandler.checkvalueString(r.GetValue(r.GetOrdinal("lakcim_uh")));
				mdr.zip = c_DBHandler.checkvalueString(r.GetValue(r.GetOrdinal("lakcim_zip")));
				mdr.state = c_DBHandler.checkvalueString(r.GetValue(r.GetOrdinal("allapot")));
				mdr.dateAdded = Convert.ToDateTime(c_DBHandler.checkDate(c_DBHandler.checkvalueString(r.GetValue(r.GetOrdinal("hozzaadas_datuma"))))); //TODO: Checkdate-ben lekezelni az üres értéket
				string d = c_DBHandler.checkvalueString(r.GetValue(r.GetOrdinal("utolso_tamogatas_idopontja")));
				try
				{
					mdr.lastSupport = (d != "" ? Convert.ToDateTime(c_DBHandler.checkDate(d)) : (DateTime?)null);
				}
				catch
				{
					mdr.lastSupport = null;
				}
				mdr.kin = new List<string>();


				string kin_command = "SELECT * FROM haztartasban_elok WHERE ugyfel_id=" + mdr.id;
				SQLiteCommand sqlk2 = new SQLiteCommand(kin_command, sqlc);
				SQLiteDataReader rr = sqlk2.ExecuteReader();

				while (rr.Read())
				{
					mdr.kin.Add(c_DBHandler.checkvalueString(rr.GetValue(rr.GetOrdinal("rokoni_kapcsolat"))) + ":" + c_DBHandler.checkvalueString(rr.GetValue(rr.GetOrdinal("nev"))));
				}


				if (c_DBHandler.greater(current_azonosito, mdr.identification))
				{
					current_azonosito = mdr.identification;
				}

				c_DBHandler.set_azonosito(sqlc, current_azonosito);

				lst.Add(mdr);
			}

			return lst;
		}

		//MEMO: ===== Return all customer data!!
		//MEMO: Le kell kezelni, hogy ne lehessen <NULL> értéket menteni
		//MEMO: Biztosra kell menni, hogy nincs szám értékként string oszlop lekérve
		public static customerAllData getCustomerAllData(SQLiteConnection sqlc, int custid)
		{
			customerAllData cad = new customerAllData();
			mainData md = new mainData();
			List<vagyon> _v = new List<vagyon>();
			List<rokon> _r = new List<rokon>();
			List<tamogatas> _t = new List<tamogatas>();

			//========== MainData

			string command = string.Format("SELECT * FROM ugyfel WHERE id={0}", custid);

			SQLiteCommand sqlk = new SQLiteCommand(command, sqlc);
			SQLiteDataReader r = sqlk.ExecuteReader();
			r.Read();
			reader = r;

			//Változó neve					--	Táblából lekérdezett érték								--	Üres érték kezelése

			md.id = custid;
			md.nev = c_DBHandler.checkvalueString(r.GetValue(r.GetOrdinal("nev")));
			md.születesi_nev = c_DBHandler.checkvalueString(r.GetValue(r.GetOrdinal("születesi_nev")));
			md.szig_szam = c_DBHandler.checkvalueString(r.GetValue(r.GetOrdinal("szig_szam")));
			md.lakcim_varos = c_DBHandler.checkvalueString(r.GetValue(r.GetOrdinal("lakcim_varos")));
			md.lakcim_uh = c_DBHandler.checkvalueString(r.GetValue(r.GetOrdinal("lakcim_uh")));
			md.lakcim_zip = c_DBHandler.checkvalueString(r.GetValue(r.GetOrdinal("lakcim_zip")));
			md.szul_datum = c_DBHandler.checkvalueString(r.GetValue(r.GetOrdinal("szul_datum")));
			md.szul_hely = c_DBHandler.checkvalueString(r.GetValue(r.GetOrdinal("szul_hely")));
			md.csaladi_allapot = c_DBHandler.checkvalueInt(r.GetValue(r.GetOrdinal("csaladi_allapot")));
			md.anyja_neve = c_DBHandler.checkvalueString(r.GetValue(r.GetOrdinal("anyja_neve")));
			md.vegzettseg = c_DBHandler.checkvalueString(r.GetValue(r.GetOrdinal("vegzettseg")));
			md.foglalkozas = c_DBHandler.checkvalueString(r.GetValue(r.GetOrdinal("foglalkozas")));
			md.szakkepzettseg = c_DBHandler.checkvalueString(r.GetValue(r.GetOrdinal("szakkepzettseg")));
			md.munkaltato = c_DBHandler.checkvalueString(r.GetValue(r.GetOrdinal("munkaltato")));
			md.azonosito = c_DBHandler.checkvalueString(r.GetValue(r.GetOrdinal("azonosito")));
			md.utolso_tamogatas_idopontja = c_DBHandler.checkvalueString(r.GetValue(r.GetOrdinal("utolso_tamogatas_idopontja")));
			md.jovedelem_igazolas = (c_DBHandler.checkvalueString((r.GetValue(r.GetOrdinal("jovedelem_igazolas")))) == "T" ? true : false);
			md.elhunyt = (c_DBHandler.checkvalueString((r.GetValue(r.GetOrdinal("elhunyt")))) == "T" ? true : false);
			md.allapot = c_DBHandler.checkvalueString(r.GetValue(r.GetOrdinal("allapot")));
			md.vallas = c_DBHandler.checkvalueString(r.GetValue(r.GetOrdinal("vallas")));
			md.környezettanulmanyt_végezte = c_DBHandler.checkvalueString(r.GetValue(r.GetOrdinal("környezettanulmanyt_végezte")));
			md.környezettanulmany_idopontja = c_DBHandler.checkvalueString(r.GetValue(r.GetOrdinal("környezettanulmany_idopontja")));
			md.hozzaadas_datuma = c_DBHandler.checkvalueString(r.GetValue(r.GetOrdinal("hozzaadas_datuma")));
			md.felvevo_profil = c_DBHandler.checkvalueString(r.GetValue(r.GetOrdinal("felvevo_profil")));
			md.legutobb_modositotta = c_DBHandler.checkvalueString(r.GetValue(r.GetOrdinal("legutobb_modositotta")));
			md.legutobbi_modositas_datuma = c_DBHandler.checkvalueString(r.GetValue(r.GetOrdinal("legutobbi_modositas_datuma")));


			cad.cust_0_mainData = md;

			r.Close();

			//========== Vagyon

			command = string.Format("SELECT * FROM vagyon WHERE ugyfel_id={0}", custid);
			sqlk = new SQLiteCommand(command, sqlc);
			r = sqlk.ExecuteReader();
			while (r.Read())
			{
				vagyon vv = new vagyon();

				vv.id = c_DBHandler.checkvalueInt(r.GetValue(r.GetOrdinal("id")));
				vv.szoveg = c_DBHandler.checkvalueString(r.GetValue(r.GetOrdinal("szoveg")));
				vv.osszeg = c_DBHandler.checkvalueInt(r.GetValue(r.GetOrdinal("osszeg")));
				vv.tipus = c_DBHandler.checkvalueString(r.GetValue(r.GetOrdinal("tipus")));

				_v.Add(vv);
			}

			cad.cust_1_vagyon = _v;

			r.Close();

			//========== SZOC_HELYZET

			command = string.Format("SELECT * FROM szoc_helyzet WHERE ugyfel_id={0}", custid);
			sqlk = new SQLiteCommand(command, sqlc);
			r = sqlk.ExecuteReader();

			if (r.Read())
			{

				cad.cust_2_lakas = (enums.lakás)c_DBHandler.checkvalueInt(r.GetValue(r.GetOrdinal("lakas")));
				cad.cust_3_alt_szoc_helyzet = (enums.általános_szociális_helyzet)c_DBHandler.checkvalueInt(r.GetValue(r.GetOrdinal("altalanos_szoc_helyzet")));
				cad.cust_4_rendsz_seg_szorul = (enums.rendszeres_segítségre_szorul)c_DBHandler.checkvalueInt(r.GetValue(r.GetOrdinal("rendszeres_segitsegre_szorul")));

			}
			r.Close();

			//========== HAZTARTASBAN_ELOK

			command = string.Format("SELECT * FROM haztartasban_elok WHERE ugyfel_id={0}", custid);
			sqlk = new SQLiteCommand(command, sqlc);
			r = sqlk.ExecuteReader();

			while (r.Read())
			{
				rokon rr = new rokon();

				rr.id = c_DBHandler.checkvalueInt(r.GetValue(r.GetOrdinal("id")));
				rr.nev = c_DBHandler.checkvalueString(r.GetValue(r.GetOrdinal("nev")));
				rr.kapcsolat = (enums.rokoni_kapcsolat)c_DBHandler.checkvalueInt(r.GetValue(r.GetOrdinal("rokoni_kapcsolat")));
				rr.havi_jovedelem = c_DBHandler.checkvalueInt(r.GetValue(r.GetOrdinal("havi_jovedelem")));

				_r.Add(rr);
			}

			cad.cust_5_rokonok = _r;

			r.Close();

			//========== TAMOGATASOK

			command = string.Format("SELECT * FROM tamogatasok WHERE ugyfel_id={0}", custid);
			sqlk = new SQLiteCommand(command, sqlc);
			r = sqlk.ExecuteReader();

			while (r.Read())
			{
				tamogatas tt = new tamogatas();

				tt.id = c_DBHandler.checkvalueInt(r.GetValue(r.GetOrdinal("id")));
				tt.datum = Convert.ToDateTime(c_DBHandler.checkDate(c_DBHandler.checkvalueString(r.GetValue(r.GetOrdinal("datum")))));
				tt.tamogatas_tipusa = c_DBHandler.checkvalueString(r.GetValue(r.GetOrdinal("tamogatas")));
				tt.tamogatas_mennyisege = c_DBHandler.checkvalueString(r.GetValue(r.GetOrdinal("tamogatas_mennyisege")));
				tt.tamogatas_egysége = c_DBHandler.checkvalueString(r.GetValue(r.GetOrdinal("tamogatas_egysége")));
				tt.megjegyzes = c_DBHandler.checkvalueString(r.GetValue(r.GetOrdinal("megjegyzes")));

				_t.Add(tt);
			}

			cad.cust_6_tamogatasok = _t;


			return cad;
		}


		//Queries from backups database

		/// <summary>
		/// Returns the deleted customer list or a single deleted customer (list if custid = -1)
		/// </summary>
		public static List<changes> getDeletedCustomers(SQLiteConnection sqlc2, int custid)
		{
			List<changes> lst = new List<changes>();

			string where = custid == -1 ? "" : " WHERE ugyfel_id=" + custid;

			string command = "SELECT * FROM deleted_customers" + where;
			SQLiteCommand sqlk = new SQLiteCommand(command, sqlc2);
			reader = sqlk.ExecuteReader();

			while (reader.Read())
			{
				changes c = new changes();

				c.id = c_DBHandler.checkvalueInt(reader.GetInt32(reader.GetOrdinal("id")));
				c.cust_id = c_DBHandler.checkvalueInt(reader.GetInt32(reader.GetOrdinal("ugyfel_id")));
				c.table = "ugyfel";
				c.before = c_DBHandler.checkvalueString(reader.GetInt32(reader.GetOrdinal("customer_data")));
				c.after = "";
				c.whochanged = c_DBHandler.checkvalueString(reader.GetInt32(reader.GetOrdinal("who_deleted")));
				c.whenchanged = c_DBHandler.checkvalueString(reader.GetInt32(reader.GetOrdinal("when_deleted")));

				lst.Add(c);
			}

			return lst;
		}

		/// <summary>
		/// Returns list of changes for single customer or all of the changes (all changes if custid = -1)
		/// </summary>
		public static List<changes> getChanges(SQLiteConnection sqlc2, int cust_id)
		{
			List<changes> lst = new List<changes>();

			string where = cust_id == -1 ? "" : " WHERE ugyfel_id=" + cust_id;

			string command = "SELECT * FROM changelog";
			SQLiteCommand sqlk = new SQLiteCommand(command, sqlc2);
			reader = sqlk.ExecuteReader();

			while (reader.Read())
			{
				changes c = new changes();

				c.id = c_DBHandler.checkvalueInt(reader.GetInt32(reader.GetOrdinal("id")));
				c.cust_id = c_DBHandler.checkvalueInt(reader.GetInt32(reader.GetOrdinal("ugyfel_id")));
				c.table = c.before = c_DBHandler.checkvalueString(reader.GetInt32(reader.GetOrdinal("table")));
				c.before = c_DBHandler.checkvalueString(reader.GetInt32(reader.GetOrdinal("before_change")));
				c.after = c.before = c_DBHandler.checkvalueString(reader.GetInt32(reader.GetOrdinal("after_change")));
				c.whochanged = c_DBHandler.checkvalueString(reader.GetInt32(reader.GetOrdinal("who_changed")));
				c.whenchanged = c_DBHandler.checkvalueString(reader.GetInt32(reader.GetOrdinal("when_changed")));

				lst.Add(c);
			}

			return lst;
		}
		
	}
}
