using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Data.SQLite;

namespace CaritasManager
{
	public static class c_DBHandler
	{
		public static SHA512CryptoServiceProvider sha5 = new SHA512CryptoServiceProvider();
		private static SQLiteDataReader reader = null;
		private static string ptwvnq9 = "fDo6Y2FyaXRh";
		private static string pfoaywe = "c19jaGFuZ2Vz";
		private static string powv89w = "OjpjYXJpdGFz";
		private static string pfinwhk = "LnNxbGl0ZTo6";
		private static string pthwnqc = "X2RhdGFiYXNl";
		
		//Metódusok amik lekérdeznek adatokat az adatbázis(ok)ból
		#region Lekérdezés

		/// <summary>
		/// Get list of user profiles
		/// </summary>
		/// <param name="sqlc">Current open SQLite Connection</param>
		/// <returns>List of profile objects</returns>
		public static List<profile> getProfiles(SQLiteConnection sqlc)
		{
			if (!connectioinOpen(sqlc)) { return null; }

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



		public static string getNextAzonosito(SQLiteConnection sqlc)
		{
			incrementAzonosito(sqlc);
			return get_azonosito(sqlc);
		}


		public static void incrementAzonosito(SQLiteConnection sqlc)
		{
			string azonosito = get_azonosito(sqlc);
			if(azonosito != "")
			{
				int tmp = 0;
				if(int.TryParse(azonosito, out tmp))
				{
					tmp++;

					set_azonosito(sqlc, tmp.ToString().PadLeft(6, '0'));
				}
			}
		}


		/// <summary>
		/// Returns current user identification number
		/// </summary>
		/// <param name="sqlc">Current open SQLiteConnection</param>
		/// <returns>string type user identification number</returns>
		public static string get_azonosito(SQLiteConnection sqlc)
		{
			if (!connectioinOpen(sqlc)) { return ""; }
			string azonosito = "";

			try
			{
				SQLiteCommand sqlk = new SQLiteCommand("SELECT ugyfel_azonosito FROM ugyfel_azonosito WHERE id=1", sqlc);
				azonosito = sqlk.ExecuteScalar() as String;
			}
			catch
			{
				azonosito = "";
			}

			return azonosito;
		}

		/// <summary>
		/// Get all rows for the mainData type (the type that is used to fill the main data table)
		/// </summary>
		/// <param name="sqlc">Current open SQLiteConnection</param>
		/// <returns>List containing every row in c_MainDataRow objects</returns>
		public static List<c_MainDataRow> getMainRowData(SQLiteConnection sqlc, string where)
		{
			if (!connectioinOpen(sqlc)) { return null; }
			
			string main_command = "SELECT id,nev,jovedelem_igazolas,azonosito,lakcim_varos,lakcim_uh,allapot,hozzaadas_datuma,utolso_tamogatas_idopontja FROM ugyfel " + where;

			List<c_MainDataRow> lst = new List<c_MainDataRow>();
			SQLiteCommand sqlk = new SQLiteCommand(main_command, sqlc);
			SQLiteDataReader r = sqlk.ExecuteReader();
			string current_azonosito = get_azonosito(sqlc);

			while (r.Read())
			{
				c_MainDataRow mdr =		new c_MainDataRow();
				mdr.id =				r.GetInt32(r.GetOrdinal("id"));
				mdr.name =				checkvalueString(r.GetValue(r.GetOrdinal("nev")));  //--
				mdr.j =					(checkvalueString(r.GetValue(r.GetOrdinal("jovedelem_igazolas"))) == "T" ? true : false);
				mdr.identification =	checkvalueString(r.GetValue(r.GetOrdinal("azonosito")));
				mdr.city =				checkvalueString(r.GetValue(r.GetOrdinal("lakcim_varos")));
				mdr.houseno =			checkvalueString(r.GetValue(r.GetOrdinal("lakcim_uh")));
				mdr.state =				checkvalueString(r.GetValue(r.GetOrdinal("allapot")));
				mdr.dateAdded =			Convert.ToDateTime(checkDate(checkvalueString(r.GetValue(r.GetOrdinal("hozzaadas_datuma"))))); //TODO: Checkdate-ben lekezelni az üres értéket
				string d =				checkvalueString(r.GetValue(r.GetOrdinal("utolso_tamogatas_idopontja")));
				try
				{
					mdr.lastSupport =	(d != "" ? Convert.ToDateTime(checkDate(d)) : (DateTime?)null);
				}
				catch
				{
					mdr.lastSupport =	null;
				}
				mdr.kin =				new List<string>();


				string kin_command = "SELECT * FROM haztartasban_elok WHERE ugyfel_id=" + mdr.id;
				SQLiteCommand sqlk2 = new SQLiteCommand(kin_command, sqlc);
				SQLiteDataReader rr = sqlk2.ExecuteReader();

				while (rr.Read())
				{
					mdr.kin.Add(checkvalueString(rr.GetValue(rr.GetOrdinal("rokoni_kapcsolat"))) + ":" + checkvalueString(rr.GetValue(rr.GetOrdinal("nev"))));
				}


				if (greater(current_azonosito, mdr.identification))
				{
					current_azonosito = mdr.identification;
				}

				set_azonosito(sqlc, current_azonosito);

				lst.Add(mdr);
			}
			
			return lst;
		}

		public static int checkvalueInt(object v)
		{
			int ret = 0;

			if (v is DBNull)
			{ ret = 0; }
			else { int.TryParse(v.ToString(), out ret); }

			return ret;
		}

		public static String checkvalueString(object v)
		{
			String ret = "";
			
			if (v is DBNull)
			{ ret = ""; }
			else { ret = v.ToString(); }

			return ret;
		}

		//MEMO: ===== Return all customer data!!
		//MEMO: Le kell kezelni, hogy ne lehessen <NULL> értéket menteni
		//MEMO: Biztosra kell menni, hogy nincs szám értékként string oszlop lekérve
		public static customerAllData getCustomerAllData(SQLiteConnection sqlc, int custid)
		{
			if (!connectioinOpen(sqlc)) { return null; }

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

			md.id =								custid;
			md.nev =							checkvalueString(	r.GetValue(r.GetOrdinal("nev"							)));
			md.születesi_nev =					checkvalueString(	r.GetValue(r.GetOrdinal("születesi_nev"					)));
			md.szig_szam =						checkvalueString(	r.GetValue(r.GetOrdinal("szig_szam"						)));
			md.lakcim_varos =					checkvalueString(	r.GetValue(r.GetOrdinal("lakcim_varos"					)));
			md.lakcim_uh =						checkvalueString(	r.GetValue(r.GetOrdinal("lakcim_uh"						)));
			md.szul_datum =						checkvalueString(	r.GetValue(r.GetOrdinal("szul_datum"					)));
			md.szul_hely =						checkvalueString(	r.GetValue(r.GetOrdinal("szul_hely"						)));
			md.csaladi_allapot =				checkvalueInt(		r.GetValue(r.GetOrdinal("csaladi_allapot"				)));
			md.anyja_neve =						checkvalueString(	r.GetValue(r.GetOrdinal("anyja_neve"					)));
			md.vegzettseg =						checkvalueString(	r.GetValue(r.GetOrdinal("vegzettseg"					)));
			md.foglalkozas =					checkvalueString(	r.GetValue(r.GetOrdinal("foglalkozas"					)));
			md.szakkepzettseg =					checkvalueString(	r.GetValue(r.GetOrdinal("szakkepzettseg"				)));
			md.munkaltato =						checkvalueString(	r.GetValue(r.GetOrdinal("munkaltato"					)));
			md.azonosito =						checkvalueString(	r.GetValue(r.GetOrdinal("azonosito"						)));
			md.utolso_tamogatas_idopontja =		checkvalueString(	r.GetValue(r.GetOrdinal("utolso_tamogatas_idopontja"	)));
			md.jovedelem_igazolas =				(checkvalueString((	r.GetValue(r.GetOrdinal("jovedelem_igazolas"			)))) == "T" ? true : false);
			md.elhunyt =						(checkvalueString((	r.GetValue(r.GetOrdinal("elhunyt"						)))) == "T" ? true : false);
			md.allapot =						checkvalueString(	r.GetValue(r.GetOrdinal("allapot"						)));
			md.vallas =							checkvalueString(	r.GetValue(r.GetOrdinal("vallas"						)));
			md.környezettanulmanyt_végezte =	checkvalueString(	r.GetValue(r.GetOrdinal("környezettanulmanyt_végezte"	)));
			md.környezettanulmany_idopontja =	checkvalueString(	r.GetValue(r.GetOrdinal("környezettanulmany_idopontja"	)));
			md.hozzaadas_datuma =				checkvalueString(	r.GetValue(r.GetOrdinal("hozzaadas_datuma"				)));
			md.felvevo_profil =					checkvalueString(	r.GetValue(r.GetOrdinal("felvevo_profil"				)));
			md.legutobb_modositotta =			checkvalueString(	r.GetValue(r.GetOrdinal("legutobb_modositotta"			)));
			md.legutobbi_modositas_datuma =		checkvalueString(	r.GetValue(r.GetOrdinal("legutobbi_modositas_datuma"	)));


			cad.cust_0_mainData = md;

			r.Close();

			//========== Vagyon

			command = string.Format("SELECT * FROM vagyon WHERE ugyfel_id={0}", custid);
			sqlk = new SQLiteCommand(command, sqlc);
			r = sqlk.ExecuteReader();
			while (r.Read())
			{
				vagyon vv = new vagyon();

				vv.id =							checkvalueInt(		r.GetValue(r.GetOrdinal("id"		)));
				vv.szoveg =						checkvalueString(	r.GetValue(r.GetOrdinal("szoveg"	)));
				vv.osszeg =						checkvalueInt(		r.GetValue(r.GetOrdinal("osszeg"	)));
				vv.tipus =						checkvalueString(	r.GetValue(r.GetOrdinal("tipus"		)));

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
				
				cad.cust_2_lakas =				(enums.lakás)							checkvalueInt(r.GetValue(r.GetOrdinal("lakas"						)));
				cad.cust_3_alt_szoc_helyzet =	(enums.általános_szociális_helyzet)		checkvalueInt(r.GetValue(r.GetOrdinal("altalanos_szoc_helyzet"		)));
				cad.cust_4_rendsz_seg_szorul =	(enums.rendszeres_segítségre_szorul)	checkvalueInt(r.GetValue(r.GetOrdinal("rendszeres_segitsegre_szorul")));

			}
			r.Close();

			//========== HAZTARTASBAN_ELOK

			command = string.Format("SELECT * FROM haztartasban_elok WHERE ugyfel_id={0}", custid);
			sqlk = new SQLiteCommand(command, sqlc);
			r = sqlk.ExecuteReader();

			while (r.Read())
			{
				rokon rr = new rokon();

				rr.id =												checkvalueInt(r.GetValue(r.GetOrdinal("id"					)));
				rr.nev =											checkvalueString(r.GetValue(r.GetOrdinal("nev"				)));
				rr.kapcsolat =		(enums.rokoni_kapcsolat)		checkvalueInt(r.GetValue(r.GetOrdinal("rokoni_kapcsolat"	)));
				rr.havi_jovedelem =									checkvalueInt(r.GetValue(r.GetOrdinal("havi_jovedelem"		)));

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

				tt.id =						checkvalueInt(r.GetValue(r.GetOrdinal("id"										)));
				tt.datum =					Convert.ToDateTime(checkDate(checkvalueString(r.GetValue(r.GetOrdinal("datum"	)))));
				tt.tamogatas_tipusa =		checkvalueString(r.GetValue(r.GetOrdinal("tamogatas"							)));
				tt.tamogatas_mennyisege =	checkvalueString(r.GetValue(r.GetOrdinal("tamogatas_mennyisege"					)));
				tt.tamogatas_egysége =		checkvalueString(r.GetValue(r.GetOrdinal("tamogatas_egysége"					)));
				tt.megjegyzes =				checkvalueString(r.GetValue(r.GetOrdinal("megjegyzes"							)));

				_t.Add(tt);
			}

			cad.cust_6_tamogatasok = _t;


			return cad;
		}

		public static int getLastInsertRowId(SQLiteConnection sqlc)
		{
			string command = "select last_insert_rowid();";

			SQLiteCommand sqlk = new SQLiteCommand(command, sqlc);

			int i = -1;

			if(int.TryParse(sqlk.ExecuteScalar().ToString(), out i)) { } else { i = -1; }

			return i;
		}

		public static int addNewCustomerAllData(SQLiteConnection sqlc, mainData md)
		{
			if (!connectioinOpen(sqlc)) { return -1; }

			string command = string.Format(
				"INSERT INTO ugyfel " +
				" ( " +
					"nev, születesi_nev, szig_szam, lakcim_varos, " +
					"lakcim_uh, szul_datum, szul_hely, csaladi_allapot, " +
					"anyja_neve,  vegzettseg, foglalkozas, szakkepzettseg, " +
					"munkaltato, azonosito, utolso_tamogatas_idopontja, jovedelem_igazolas, " +
					"elhunyt, allapot, vallas, környezettanulmanyt_végezte, " +
					"környezettanulmany_idopontja, hozzaadas_datuma, felvevo_profil, " +
					"legutobb_modositotta, legutobbi_modositas_datuma" +
				" ) " +
				"VALUES " +
				" (" +
					"'{0}',  " +
					"'{1}',  " +
					"'{2}',  " +
					"'{3}',  " +
					"'{4}',  " +
					"'{5}',  " +
					"'{6}',  " +
					"{7},    " +
					"'{8}',  " +
					"'{9}',  " +
					"'{10}', " +
					"'{11}', " +
					"'{12}', " +
					"'{13}', " +
					"'{14}', " +
					"'{15}', " +
					"'{16}', " +
					"'{17}', " +
					"'{18}', " +
					"'{19}', " +
					"'{20}', " +
					"'{21}', " +
					"'{22}', " +
					"'{23}', " +
					"'{24}'  " +
				");",
					md.nev,
					md.születesi_nev,
					md.szig_szam,
					md.lakcim_varos,
					md.lakcim_uh,
					md.szul_datum,
					md.szul_hely,
					md.csaladi_allapot,
					md.anyja_neve,
					md.vegzettseg,
					md.foglalkozas,
					md.szakkepzettseg,
					md.munkaltato,
					md.azonosito,
					md.utolso_tamogatas_idopontja,
					md.jovedelem_igazolas,
					md.elhunyt,
					md.allapot,
					md.vallas,
					md.környezettanulmanyt_végezte,
					md.környezettanulmany_idopontja,
					md.hozzaadas_datuma,
					md.felvevo_profil,
					md.legutobb_modositotta,
					md.legutobbi_modositas_datuma
				);

			SQLiteCommand sqlk = new SQLiteCommand(command, sqlc);
			executeNonQuery(sqlk);

			int custid = 0;
			
			custid = getLastInsertRowId(sqlc);
			if (custid > 0)
			{
				command = string.Format("INSERT INTO vagyon (ugyfel_id,osszeg,szoveg,tipus) VALUES ({0},{1},'{2}','{3}')", custid, 0, "", "M");
				sqlk.CommandText = command;
				executeNonQuery(sqlk);
			}


			/*
				if (custid > 0)
				{
					foreach (vagyon v in cad.cust_1_vagyon)
					{
						command = string.Format("INSERT INTO vagyon (ugyfel_id,osszeg,szoveg,tipus) VALUES ({0},{1},'{2}','{3}')", custid, v.osszeg, v.szoveg, v.tipus);
						sqlk.CommandText = command;
						executeNonQuery(sqlk);
					}

					command = string.Format("INSERT INTO szoc_helyzet (ugyfel_id,lakas,altalanos_szoc_helyzet,rendszeres_segitsegre_szorul) VALUES ({0}, {1}, {2}, {3})", custid, (int)cad.cust_2_lakas, (int)cad.cust_3_alt_szoc_helyzet, (int)cad.cust_4_rendsz_seg_szorul);
					sqlk.CommandText = command;
					executeNonQuery(sqlk);

					foreach (rokon r in cad.cust_5_rokonok)
					{
						command = string.Format("INSERT INTO haztartasban_elok (ugyfel_id,nev,rokoni_kapcsolat,havi_jovedelem) VALUES ({0},'{1}',{2},{3})", custid, r.nev, (int)r.kapcsolat, r.havi_jovedelem);
						sqlk.CommandText = command;
						executeNonQuery(sqlk);
					}
				}
				else
				{
					throw new Exception("Nem megy...");
				}
			*/

			return custid;
		}


		#endregion

		

		//===== Metódusok amik írnak adatokat az adatbázis(ok)ba (új sor vagy update) =====//
		#region Új Sor és Módosítás

		//-------------------------- PASSWORD
		/// <summary>
		/// Edits password line //There is only one line in password table
		/// </summary>
		/// <param name="sqlc">Current Open SQLiteConnection</param>
		/// <param name="password">Password string</param>
		public static void editPassword(SQLiteConnection sqlc, string password)
		{
			if (!connectioinOpen(sqlc)) { return; }

			if (password.Length > 0)
			{
				string pwd = password;
				byte[] bytes = Encoding.UTF8.GetBytes(pwd);     //Generates byte[] from string
				pwd = "";
				foreach (byte b in sha5.ComputeHash(bytes))     //Iterates through bytes in array
				{
					pwd += b.ToString("X2");                        //adds new hexadecimal characters to password string (byte.tostring(x2))
				}
				SQLiteCommand sqlk = new SQLiteCommand("UPDATE password SET passwd='" + pwd + "'", sqlc);
				sqlk.ExecuteNonQuery();
			}
		}

		//-------------------------- PROFILE
		/// <summary>
		/// Adds new profile line or edits an existing one
		/// </summary>
		/// <param name="sqlc">Current Open SQLiteConnection</param>
		/// <param name="p">Profile object containing the data to be added</param>
		/// <param name="edit">Bool, if true, new line is not added, but existing one is edited</param>
		/// <returns>String containing error data</returns>
		public static string editProfile(SQLiteConnection sqlc, profile p, bool edit)
		{
			if (!connectioinOpen(sqlc)) { return "ERROR:-1"; }

			//TODO: NE ENGEDJÜK MEG, HOGY ÜRES LEGYEN A NEVE!!!!!

			string command = string.Format("SELECT id FROM profilok WHERE lower(profil_name)='{0}'", p.name.ToLower());
			SQLiteCommand sqlk = new SQLiteCommand(command, sqlc);

			if (!edit)
			{
				if (sqlk.ExecuteScalar() == null)
				{
					command = string.Format("INSERT INTO profilok (profil_name,last_login,font_family,font_size,font_style,font_color,color_1,color_2,color_3) " +
											" VALUES " +
											" (" +
												"'{0}'," +
												"'{1}'," +
												"'{2}'," +
												"'{3}'," +
												"'{4}'," +
												"'{5}'," +
												"'{6}'," +
												"'{7}'," +
												"'{8}'" +
											");",
												p.name,
												DateTime.Now.ToShortDateString(),
												p.fontFamily,
												p.fontSize,
												p.fontStyle,
												p.fontColor,
												p.color_1,
												p.color_2,
												p.color_3
											);

					sqlk.CommandText = command;
					sqlk.ExecuteNonQuery();

				}
				else
				{
					return "ERROR:0";   //ERROR 0 = Not edit but line already exists
				}
			}
			else
			{
				if (sqlk.ExecuteScalar() != null)
				{
					command = string.Format("UPDATE profilok SET " +
							" last_login='{0}', " +
							" font_family='{1}', " +
							" font_size='{2}'," +
							" font_style='{3}'," +
							" font_color='{4}'," +
							" color_1='{5}'," +
							" color_2='{6}'," +
							" color_3='{7}'" +
						" WHERE lower(profil_name) = '{8}';",
							DateTime.Now.ToShortDateString(),
							p.fontFamily,
							p.fontSize,
							p.fontStyle,
							p.fontColor,
							p.color_1,
							p.color_2,
							p.color_3,
							p.name.ToLower()
						);

					sqlk.CommandText = command;
					sqlk.ExecuteNonQuery();
				}
				else
				{
					return "ERROR:1";   //ERROR 1 = Edit but line doesn't exist yet
				}
			}

			return "";
		}

		//--------------------------- ÜGYFÉL TÁBLA
		/// <summary>
		/// Sort ad hozzá az ugyfel táblához
		/// </summary>
		/// <param name="sqlc">Current open SQLiteConneciton</param>
		/// <param name="cust">mainData class containing all customer data</param>
		public static void addRowToUgyfel(SQLiteConnection sqlc, mainData cust)
		{

			if (!connectioinOpen(sqlc)) { return; }

			string command = string.Format(
												"INSERT INTO ugyfel " +
												"(" +
													"nev, " +
													"születesi_nev, " +
													"szig_szam, " +
													"lakcim_varos, " +
													"lakcim_uh, " +
													"szul_datum, " +
													"szul_hely, " +
													"csaladi_allapot, " +
													"anyja_neve, " +
													"vegzettseg, " +
													"foglalkozas, " +
													"szakkepzettseg, " +
													"munkaltato, " +
													"azonosito," +
													"utolso_tamogatas_idopontja, " +
													"jovedelem_igazolas, " +
													"allapot," +
													"elhunyt, " + 
													"környezettanulmanyt_végezte, " +
													"környezettanulmany_idopontja, " + 
													"felvevo_profil," +
													"hozzaadas_datuma, " +
													"legutobb_modositotta," +
													"legutobbi_modositas_datuma" +
												") VALUES (" +
													"'{0}', " +
													"'{1}', " +
													"'{2}', " +
													"'{3}', " +
													"'{4}', " +
													"'{5}', " +
													"'{6}', " +
													"{7}, " +
													"'{8}', " +
													"'{9}', " +
													"'{10}', " +
													"'{11}', " +
													"'{12}', " +
													"'{13}', " +
													"'{14}', " +
													"'{15}', " +
													"'{16}', " +
													"'{17}', " +
													"'{18}', " +
													"'{19}', " +
													"'{20}', " +
													"'{21}', " + 
													"'{22}', " +
													"'{23}' " +
												")",
													cust.nev,
													cust.születesi_nev,					//Empty (or '-' ?) for same as name
													cust.szig_szam,                     //Can be empty?
													cust.lakcim_varos,
													cust.lakcim_uh,
													cust.szul_datum,					//Can be empty
													cust.szul_hely,                     //Can be empty
													cust.csaladi_allapot,				//From enums->családi_állapot
													cust.anyja_neve,
													cust.vegzettseg,
													cust.foglalkozas,
													cust.szakkepzettseg,
													cust.munkaltato,
													cust.azonosito,
													cust.utolso_tamogatas_idopontja,	//Can be empty
													cust.jovedelem_igazolas,			//T=true | F=false
													cust.allapot,
													cust.elhunyt,						//T=true | F=false
													cust.környezettanulmanyt_végezte,	//Can be empty - Checkbox for 'Same as creator'
													cust.környezettanulmany_idopontja,	//Can be empty
													cust.felvevo_profil,				//!!Can NOT be empty
													cust.hozzaadas_datuma,				//!!Can NOT be empty
													cust.legutobb_modositotta,          //Can be empty
													cust.legutobbi_modositas_datuma     //Can be empty
										);

			SQLiteCommand sqlk = new SQLiteCommand(command, sqlc);
			executeNonQuery(sqlk);
		}

		/// <summary>
		/// Modify or delete line from ugyfel table
		/// </summary>
		/// <param name="sqlc">Current open SQLiteConnection</param>
		/// <param name="mod">Data to be modified</param>
		/// <param name="id">ID of row to update/delete</param>
		/// <param name="delete">Bool, if false than update else delete</param>
		public static void modifyUgyfelRow(SQLiteConnection sqlc, Dictionary<String, String> mod, int id, bool delete)
		{
			if (!connectioinOpen(sqlc)) { return; }

			String command = "";

			if (delete)
			{
				command = "DELETE FROM ugyfel WHERE id=" + id;
			}
			else
			{
				command = "UPDATE ugyfel SET ";

				foreach (KeyValuePair<string, string> kvp in mod)
				{
					if (kvp.Key == "csaladi_allapot")
					{
						command += kvp.Key + "=" + kvp.Value;
					}
					else
					{
						command += kvp.Key + "= '" + kvp.Value + "' ";
					}

					if (mod.Last().Key != kvp.Key)
					{
						command += ", ";
					}
				}

				command += " WHERE id=" + id;
			}

			SQLiteCommand sqlk = new SQLiteCommand(command, sqlc);
			executeNonQuery(sqlk);
		}

		//-------------------------- VAGYON TÁBLA
		/// <summary>
		/// Add row to table 'vagyon'
		/// </summary>
		/// <param name="sqlc">Current open SQLiteConnection</param>
		/// <param name="ugyfel_id">id of customer</param>
		/// <param name="szoveg">Message of added row</param>
		/// <param name="osszeg">Value of added row</param>
		/// <param name="tipus">Type of added row</param>
		public static void addRowToVagyon(SQLiteConnection sqlc, int ugyfel_id, string szoveg, int osszeg, string tipus)
		{
			if (!connectioinOpen(sqlc)) { return; }

			string command = string.Format("INSERT INTO vagyon " +
												"(" +
													"ugyfel_id, " +
													"szoveg, " +
													"osszeg, " +
													"tipus " +
												") VALUES (" +
													"'{0}', " +
													"'{1}', " +
													"{2}, " +
													"'{3}' " +
												")",
													ugyfel_id,
													szoveg,
													osszeg,
													tipus
										);

			SQLiteCommand sqlk = new SQLiteCommand(command, sqlc);
			executeNonQuery(sqlk);
		}


		/// <summary>
		/// Update or delete row in table 'vagyon'
		/// </summary>
		/// <param name="sqlc">Current open SQLiteConnection</param>
		/// <param name="id">ID of row in Vagyon table</param>
		/// <param name="szoveg">Message of updated row</param>
		/// <param name="osszeg">Value of updated row</param>
		/// <param name="tipus">Type of updated row</param>
		/// <param name="delete">Bool, if true than delete else update</param>
		public static void modifyVagyonRow(SQLiteConnection sqlc, int id, string szoveg, int osszeg, string tipus, bool delete)
		{
			if (!connectioinOpen(sqlc)) { return; }

			string command = "";

			if (delete)
			{
				command = string.Format("DELETE FROM vagyon WHERE id={0}", id);
			}
			else
			{
				command = string.Format("UPDATE vagyon SET szoveg='{0}', osszeg={1}, tipus='{2}' WHERE id={3}", szoveg, osszeg, tipus, id);
			}

			SQLiteCommand sqlk = new SQLiteCommand(command, sqlc);
			executeNonQuery(sqlk);
		}

		//-------------------------- SZOCIÁLIS HELYZET TÁBLA
		/// <summary>
		/// Add row to table 'szoc_helyzet'
		/// </summary>
		/// <param name="sqlc">Current open SQLiteConnection</param>
		/// <param name="ugyfel_id">ID of customer</param>
		/// <param name="lakas">Type of customer home</param>
		/// <param name="altalanos_szoc_helyzet">Type of customer state</param>
		/// <param name="rendszeres_segitsegre_szorul">Type containing if customer requires constant care</param>
		public static void addRowToSzocHelyzet(SQLiteConnection sqlc, int ugyfel_id, int lakas, int altalanos_szoc_helyzet, int rendszeres_segitsegre_szorul)
		{
			if (!connectioinOpen(sqlc)) { return; }

			string command = string.Format("INSERT INTO szoc_helyzet " +
												"(" +
													"ugyfel_id, " +
													"lakas, " +
													"altalanos_szoc_helyzet, " +
													"rendszeres_segitsegre_szorul" +
												") VALUES (" +
													"{0}," +
													"{1}," +
													"{2}," +
													"{3}" +
												")",
													ugyfel_id,
													lakas,
													altalanos_szoc_helyzet,
													rendszeres_segitsegre_szorul
										);

			SQLiteCommand sqlk = new SQLiteCommand(command, sqlc);
			executeNonQuery(sqlk);
		}

		/// <summary>
		/// Update or delete row from table 'szoc_helyzet'
		/// </summary>
		/// <param name="sqlc">Current open SQLiteConnection</param>
		/// <param name="ugyfel_id">ID of customer</param>
		/// <param name="lakas">Type of customer home</param>
		/// <param name="altalanos_szoc_helyzet">Type of customer state</param>
		/// <param name="rendszeres_segitsegre_szorul">Type containing if customer requires constant care</param>
		/// <param name="delete">Bool, if true than delete else update</param>
		public static void modifySzocHelyzet(SQLiteConnection sqlc, int ugyfel_id, int lakas, int altalanos_szoc_helyzet, int rendszeres_segitsegre_szorul, bool delete)
		{
			if (!connectioinOpen(sqlc)) { return; }

			string command = "";
			if (delete)
			{
				command = string.Format("DELETE FROM szoc_helyzet WHERE ugyfel_id={0}", ugyfel_id);
			}
			else
			{
				command = string.Format("UPDATE szoc_helyzet SET lakas={0}, altalanos_szoc_helyzet={1}, rendszeres_segitsegre_szorul={2} WHERE ugyfel_id={3}",
				lakas, altalanos_szoc_helyzet, rendszeres_segitsegre_szorul, ugyfel_id);
			}

			SQLiteCommand sqlk = new SQLiteCommand(command, sqlc);
			executeNonQuery(sqlk);
		}

		//-------------------------- HÁZTARTÁSBAN ÉLŐK TÁBLA
		/// <summary>
		/// Add row to table 'haztartasban_elok'
		/// </summary>
		/// <param name="sqlc">Current open SQLiteConnection</param>
		/// <param name="ugyfel_id">ID of customer</param>
		/// <param name="nev">Name of family member</param>
		/// <param name="rokoni_kapcsolat">Type of connection</param>
		/// <param name="havi_jovedelem">Monthly income</param>
		public static void addRowToHaztartasbanElok(SQLiteConnection sqlc, int ugyfel_id, string nev, string rokoni_kapcsolat, int havi_jovedelem)
		{
			if (!connectioinOpen(sqlc)) { return; }

			string command = string.Format("INSERT INTO  haztartasban_elok " +
											"(" +
												"ugyfel_id, " +
												"nev, " +
												"rokoni_kapcsolat, " +
												"havi_jovedelem " +
											") VALUES (" +
												"{0}," +
												"'{1}'," +
												"'{2}'," +
												"{3}" +
											")",
												ugyfel_id,
												nev,
												rokoni_kapcsolat,
												havi_jovedelem
											);
			SQLiteCommand sqlk = new SQLiteCommand(command, sqlc);
			executeNonQuery(sqlk);
		}

		/// <summary>
		/// Update or delete row from table 'haztartasban_elok'
		/// </summary>
		/// <param name="sqlc">Current open SQLiteConnection</param>
		/// <param name="id">ID of customer</param>
		/// <param name="nev">Name of family member</param>
		/// <param name="rokoni_kapcsolat">Type of connection</param>
		/// <param name="havi_jovedelem">Monthly income</param>
		/// <param name="delete">Bool, if true than delete else update</param>
		public static void modifyHaztartasbanElok(SQLiteConnection sqlc, int id, string nev, string rokoni_kapcsolat, int havi_jovedelem, bool delete)
		{
			if (!connectioinOpen(sqlc)) { return; }

			string command = "";

			if (delete)
			{
				command = string.Format("DELETE FROM haztartasban_elok WHERE id={0}", id);
			}
			else
			{
				command = string.Format("UPDATE haztartasban_elok SET nev='{0}', rokoni_kapcsolat='{1}', havi_jovedelem={2} WHERE id={3}",
				nev, rokoni_kapcsolat, havi_jovedelem, id);
			}

			SQLiteCommand sqlk = new SQLiteCommand(command, sqlc);
			executeNonQuery(sqlk);
		}

		//-------------------------- TÁMOGATÁSOK TÁBLA
		/// <summary>
		/// Add row to table 'tamogatasok'
		/// </summary>
		/// <param name="sqlc">Current open SQLiteConnection</param>
		/// <param name="ugyfel_id">ID of customer</param>
		/// <param name="datum">Date of last support</param>
		/// <param name="tamogatas">Type of support</param>
		public static void addRowToTamogatasok(SQLiteConnection sqlc, int ugyfel_id, string datum, string tamogatas, string mennyiseg, string mertekegyseg, string megjegyzes)
		{
			if (!connectioinOpen(sqlc)) { return; }

			string command = string.Format("INSERT INTO tamogatasok " +
												"(" +
													"ugyfel_id, " +
													"datum, " +
													"tamogatas, " +
													"tamogatas_mennyisege, " +
													"tamogatas_egysége, " +
													"megjegyzes" +
												") VALUES (" +
													"{0}, " +
													"'{1}', " +
													"'{2}', " +
													"'{3}', " +
													"'{4}', " +
													"'{5}'" +
												")",
													ugyfel_id,
													datum,
													tamogatas,
													mennyiseg,
													mertekegyseg,
													megjegyzes
											);
			SQLiteCommand sqlk = new SQLiteCommand(command, sqlc);
			executeNonQuery(sqlk);

		}

		/// <summary>
		/// Update or delete row from table 'tamogatasok'
		/// </summary>
		/// <param name="sqlc">Current open SQLiteConnection</param>
		/// <param name="id">ID of customer</param>
		/// <param name="datum">Date of last support</param>
		/// <param name="tamogatas">Type of support</param>
		/// <param name="delete">Bool, if true than delete else update</param>
		public static void modifyTamogatasok(SQLiteConnection sqlc, int id, string datum, string tamogatas, string mennyiseg, string mertekegyseg, string megjegyzes, bool delete)
		{
			if (!connectioinOpen(sqlc)) { return; }

			string command = "";

			if (delete)
			{
				command = "DELETE FROM tamogatasok WHERE id=" + id;
			}
			else
			{
				command = "UPDATE tamogatasok SET datum='" + datum + "', tamogatas='" + tamogatas + "', tamogatas_mennyisege='" + mennyiseg + "', tamogatas_egysége='" + mertekegyseg + "', megjegyzes='" + megjegyzes + "' WHERE id=" + id;
			}

			SQLiteCommand sqlk = new SQLiteCommand(command, sqlc);
			executeNonQuery(sqlk);
		}

		//-------------------------- AZONOSÍTÓ
		/// <summary>
		/// Sets new value for user_identification number
		/// </summary>
		/// <param name="sqlc">Current open SQLiteConnection</param>
		/// <param name="azonosito">User identification number to set</param>
		public static void set_azonosito(SQLiteConnection sqlc, string azonosito)
		{
			if (!connectioinOpen(sqlc)) { return; }

			SQLiteCommand sqlk = new SQLiteCommand("UPDATE ugyfel_azonosito SET ugyfel_azonosito = '" + azonosito + "' WHERE id=1;", sqlc);
			executeNonQuery(sqlk);
		}

		#endregion



		//===== Metódusok amik segédfeladatokat hajtanak végre =====//
		#region Management functions

		/// <summary>
		/// Check input date, fix if it's faulty
		/// </summary>
		/// <param name="date">String date</param>
		/// <returns>string date (fixed if faulty)</returns>
		public static string checkDate(string date)
		{
			try
			{
				DateTime d = Convert.ToDateTime(date);
				return date;
			}
			catch
			{
				date = date.Replace(" ", "").Replace("\\", ".").Replace(",", ".").Replace("-", ".").Replace("|", ".").Replace("/", ".").Replace("_", ".").Replace("*", ".");

				if (!date.Contains("."))
				{
					//TODO: FINISH DATE STUFF!

					int year = 0;
					int month = 0;
					int day = 0;

					if (date.Length > 6)
					{
						year = Convert.ToInt32(date.Substring(0, 4));
						date = date.Remove(0, 4);

						if (date.Length == 4)
						{
							month = Convert.ToInt32(date.Substring(0, 2));
							date = date.Remove(0, 2);
							day = Convert.ToInt32(date);
						}
						else
						{
							if (date[0] == '0')
							{
								month = Convert.ToInt32(date.Substring(0, 2));
								day = Convert.ToInt32(date[2].ToString());
							}
							else if (date[2] == '0')
							{
								month = Convert.ToInt32(date.Substring(0, 1));
								day = Convert.ToInt32(date.Substring(1, 2));
							}
							else
							{
								month = Convert.ToInt32(date.Substring(0, 2));
								day = Convert.ToInt32(date[2].ToString());
							}
						}
					}
					else if (date.Length == 6)
					{

					}
					else if (date.Length > 3)
					{

					}
					else
					{
						year = 1; month = 1; day = 1;
					}

					DateTime correct = new DateTime(year, month, day);

				}
				else
				{
					try
					{
						DateTime d = Convert.ToDateTime(date);
						return date;
					}
					catch { }
				}
				return DateTime.Now.ToShortDateString();
			}
		}

		/// <summary>
		/// checks which of 2 numbers (stored as strings) are greater
		/// </summary>
		/// <param name="current_id"></param>
		/// <param name="new_id"></param>
		/// <returns></returns>
		public static bool greater(string current_id, string new_id)
		{
			bool ret = false;

			try
			{
				int _current = -1;
				int _new = -1;

				int.TryParse(current_id, out _current);
				int.TryParse(new_id, out _new);

				ret = _new > _current;

				if (_current == -1 || _new == -1) { Console.WriteLine("PARSE ERROR! @ c_DBHandler -> greater"); return false; }
			}
			catch (Exception ex) { Console.WriteLine(ex); }

			return ret;
		}

		/// <summary>
		/// Létrehozza a DB fájlt
		/// </summary>
		public static void createDBFile()
		{
			string p = genp();


			if (!File.Exists("database.sqlite"))
			{
				File.Create("database.sqlite").Close();

				SQLiteConnection conn = new SQLiteConnection("Data Source=database.sqlite;Version=3;");
				conn.SetPassword(p.Split('|')[0]);
				conn.Open();
			}

			if (!File.Exists("changes.sqlite"))
			{
				File.Create("changes.sqlite").Close();

				SQLiteConnection conn = new SQLiteConnection("Data Source=database.sqlite;Version=3;");
				conn.SetPassword(p.Split('|')[1]);
				conn.Open();
			}
		}

		/// <summary>
		/// Checks if the current SQLiteConnection (sqlc) is available and open
		/// </summary>
		/// <param name="sqlc">The current SQLiteConnection sqlc</param>
		/// <returns>Bool, true if sqlc is available and open</returns>
		public static bool connectioinOpen(SQLiteConnection sqlc)
		{
			bool ret = false;

			if (sqlc != null && sqlc.State == System.Data.ConnectionState.Open) { ret = true; }

			return ret;
		}

		/// <summary>
		/// Checks if the table 'tableName' exists
		/// </summary>
		/// <param name="sqlc">Current open SQLiteConnection</param>
		/// <param name="tableName">The name of the table in question</param>
		/// <returns>Bool, true if the table exists</returns>
		public static bool tableExists(SQLiteConnection sqlc, string tableName)
		{
			bool ret = true;

			SQLiteCommand sqlk = new SQLiteCommand() { Connection = sqlc };
			sqlk.CommandText = ("SELECT name FROM sqlite_master WHERE type='table' AND name='" + tableName + "'");
			if (sqlk.ExecuteScalar() is null) { ret = false; }

			return ret;
		}

		/// <summary>
		/// Runs the executeNonQuery for an SQLiteCommand centrally so I can manage the exceptions
		/// </summary>
		/// <param name="sqlk">SQL Command containing command text and open connection</param>
		/// <returns>Bool, true if command ran successfully</returns>
		public static bool executeNonQuery(SQLiteCommand sqlk)
		{
			bool ret = false;

			if (sqlk.Connection == null || sqlk.Connection.State != System.Data.ConnectionState.Open)
			{
				Console.WriteLine("==================== START EXCEPTION ====================");
				Console.WriteLine("Command has no open connection");
				Console.WriteLine("===================== END EXCEPTION =====================");

				return false;
			}

			try
			{
				sqlk.ExecuteNonQuery();
				ret = true;

			}
			catch (Exception ex)
			{
				Console.WriteLine("\r\n==================== START EXCEPTION ====================");
				Console.WriteLine("=========== c_DBHandler - executeNonQuery (ln:65) ===========");
				Console.WriteLine(ex);
				Console.WriteLine("===================== END EXCEPTION =====================\r\n");
			}

			return ret;
		}

		/// <summary>
		/// Létrehozza a táblákat az adatbázisban
		/// </summary>
		/// <param name="sqlc">Jelenlegi nyitott SQL kapcsolat</param>
		public static void createTables(SQLiteConnection sqlc, SQLiteConnection sqlc2)
		{
			//Kilép a method-ból, ha nincs nyitott SQLite kapcsolat (sqlc)
			//Ezt minden lekérdezős method-ba beletesszük, hogy ne legyen problémája
			if (!connectioinOpen(sqlc)) { return; }

			SQLiteCommand sqlk = new SQLiteCommand(sqlc);
			SQLiteCommand sqlk2 = new SQLiteCommand(sqlc2);

			//Ellenőrzi, hogy létezik-e a tábla, ha nem, létrehozza
			if (!tableExists(sqlc, "ugyfel"))               //------- UGYFEL tábla
			{
				sqlk.CommandText = "CREATE TABLE ugyfel " +
									"(" +
										"id INTEGER PRIMARY KEY AUTOINCREMENT, " +
										"nev TEXT, " +
										"születesi_nev TEXT, " +
										"szig_szam TEXT, " +
										"lakcim_varos TEXT, " +
										"lakcim_uh TEXT, " +
										"szul_datum TEXT, " +
										"szul_hely TEXT, " +
										"csaladi_allapot INTEGER, " +
										"anyja_neve TEXT, " +
										"vegzettseg TEXT, " +
										"foglalkozas TEXT, " +
										"szakkepzettseg TEXT, " +
										"munkaltato TEXT, " +
										"azonosito TEXT, " +
										"utolso_tamogatas_idopontja TEXT, " +
										"jovedelem_igazolas TEXT, " +
										"elhunyt TEXT, " +
										"allapot TEXT," +   //nagycsaládos, hajléktalan, hátrányos helyzetű...
										"vallas TEXT, " +	//INT if general religion, name of religion if MISC
										"környezettanulmanyt_végezte TEXT, " +
										"környezettanulmany_idopontja TEXT, " +
										"hozzaadas_datuma TEXT, " +
										"felvevo_profil TEXT," +
										"legutobb_modositotta TEXT," +
										"legutobbi_modositas_datuma TEXT" +
									")";

				executeNonQuery(sqlk);
			}


			if (!tableExists(sqlc, "ugyfel_azonosito"))               //------- VAGYON tábla
			{
				sqlk.CommandText = "CREATE TABLE ugyfel_azonosito " +
									"( " +
										"id INTEGER PRIMARY KEY AUTOINCREMENT, " +
										"ugyfel_azonosito TEXT" +
									"); INSERT INTO ugyfel_azonosito (ugyfel_azonosito) VALUES ('000000');";

				executeNonQuery(sqlk);
			}


			if (!tableExists(sqlc, "vagyon"))               //------- VAGYON tábla
			{
				sqlk.CommandText = "CREATE TABLE vagyon " +
									"( " +
										"id INTEGER PRIMARY KEY AUTOINCREMENT, " +
										"ugyfel_id INTEGER, " +		//Ügyfél
										"szoveg TEXT, " +			//kiadás vagy bevétel megnevezése ill megjegyzés szövege
										"osszeg INTEGER, " +		//Összeg (0 if megjegyzés)
										"tipus TEXT" +				//Tipus: K=Kiadás, B=Bevétel, M=Megjegyzés
									")";

				executeNonQuery(sqlk);
			}


			if (!tableExists(sqlc, "szoc_helyzet"))         //------- SZOCIALIS HELYZET 1 tábla
			{
				sqlk.CommandText = "CREATE TABLE szoc_helyzet " +
									"( " +
										"id INTEGER PRIMARY KEY AUTOINCREMENT, " +
										"ugyfel_id INTEGER, " +
										"lakas INTEGER, " +
										"altalanos_szoc_helyzet INTEGER, " +
										"rendszeres_segitsegre_szorul INTEGER" +
									")";

				executeNonQuery(sqlk);
			}


			if (!tableExists(sqlc, "haztartasban_elok"))    //------- SZOCIALIS HELYZET 2 tábla
			{
				sqlk.CommandText = "CREATE TABLE haztartasban_elok " +
									"( " +
										"id INTEGER PRIMARY KEY AUTOINCREMENT, " +
										"ugyfel_id INTEGER, " +
										"nev TEXT, " +
										"rokoni_kapcsolat TEXT, " +
										"havi_jovedelem INTEGER" +
									")";

				executeNonQuery(sqlk);
			}


			if (!tableExists(sqlc, "tamogatasok"))          //------- TAMOGATASOK tábla
			{
				sqlk.CommandText = "CREATE TABLE tamogatasok " +
									"( " +
										"id INTEGER PRIMARY KEY AUTOINCREMENT, " +
										"ugyfel_id INTEGER, " +
										"datum TEXT, " +
										"tamogatas TEXT, " +
										"tamogatas_mennyisege TEXT, " +
										"tamogatas_egysége TEXT, " +
										"megjegyzes TEXT" +
									")";

				executeNonQuery(sqlk);
			}


			if (!tableExists(sqlc, "password"))             //------- Felhasználói Profilok
			{
				sqlk.CommandText = "CREATE TABLE password " +
									"( " +
										"id INTEGER PRIMARY KEY AUTOINCREMENT, " +
										"passwd TEXT" +
									"); INSERT INTO password (passwd) VALUES ('')";

				executeNonQuery(sqlk);
			}


			if (!tableExists(sqlc, "profilok"))             //------- Felhasználói Profilok
			{
				sqlk.CommandText = "CREATE TABLE profilok " +
									"( " +
										"id INTEGER PRIMARY KEY AUTOINCREMENT, " +
										"profil_name INTEGER, " +
										"last_login TEXT, " +
										"font_family TEXT, " +
										"font_size TEXT, " +
										"font_style TEXT, " +
										"font_color TEXT, " +
										"color_1 TEXT, " +      //zöld ügyfél
										"color_2 TEXT, " +      //sárga ügyfél
										"color_3 TEXT  " +      //piros ügyfél
									")";

				executeNonQuery(sqlk);
			}

			//---- Changes
			//IMPORTANT: Befejezni a change és delete backupot!!!
			//Le kell kérdezni a változás előtti adatot és az azt követően beszúrt új adatot is és mindkettőt kiírni a changes táblába!

			if (!tableExists(sqlc2, "changelog"))             //------- changelog
			{
				sqlk2.CommandText = "CREATE TABLE changelog " +
									"( " +
										"id INTEGER PRIMARY KEY AUTOINCREMENT, " +
										"ugyfel_id TEXT, " +
										"table TEXT, " +
										"before_change TEXT, " +
										"after_change TEXT, " +
										"who_changed TEXT, " +
										"when_changed TEXT " +
									")";

				executeNonQuery(sqlk2);
			}

			if (!tableExists(sqlc2, "deleted_customers"))             //------- deleted_customers
			{
				sqlk2.CommandText = "CREATE TABLE deleted_customers " +
									"( " +
										"id INTEGER PRIMARY KEY AUTOINCREMENT, " +
										"ugyfel_id TEXT, " +
										"customer_data TEXT, " +
										"who_deleted TEXT, " +
										"when_deleted TEXT " +
									")";

				executeNonQuery(sqlk2);
			}



			//TODO: add table creation for backups db
		}

		/// <summary>
		/// Connects to the default database file
		/// </summary>
		/// <returns>Current SQLiteConnection</returns>
		public static SQLiteConnection[] connectToDB()
		{
			string p = genp();
			SQLiteConnection sqlc = new SQLiteConnection("Data Source=database.sqlite;Version=3;Password=" + p.Split('|')[0] + ";");
			SQLiteConnection sqlc2 = new SQLiteConnection("Data Source=changes.sqlite;Version=3;Password=" + p.Split('|')[1] + ";");
			return new SQLiteConnection[] { sqlc, sqlc2 };
		}

		/// <summary>
		/// Generates pwd
		/// </summary>
		/// <returns>pwd</returns>
		public static string genp()
		{
			FromBase64Transform fbt = new FromBase64Transform();
			List<byte> ib = new List<byte>();
			List<byte> ob = new List<byte>();

			byte[] b = new byte[8881];
			byte[] bb = new byte[3311];

			ib.AddRange(Encoding.UTF8.GetBytes(powv89w));
			ib.AddRange(Encoding.UTF8.GetBytes(pthwnqc));
			ib.AddRange(Encoding.UTF8.GetBytes(pfinwhk));
			ib.AddRange(Encoding.UTF8.GetBytes(ptwvnq9));
			ib.AddRange(Encoding.UTF8.GetBytes(pfoaywe));
			ib.AddRange(Encoding.UTF8.GetBytes(pfinwhk));

			b = ib.ToArray();
			bb = new byte[b.Length];
			fbt.TransformBlock(b, 0, b.Length, bb, 0);

			string tmp = "";

			foreach (byte _bb_ in bb)
			{ tmp += ((char)_bb_).ToString(); }

			tmp = tmp.Trim('\0');

			string poiohgwuj = tmp.Split('|')[0];
			string ptsdvlsfd = tmp.Split('|')[1];

			MD5CryptoServiceProvider m5 = new MD5CryptoServiceProvider();

			tmp = "";

			foreach (byte _b__ in m5.ComputeHash(Encoding.UTF8.GetBytes(poiohgwuj)))
			{
				tmp += _b__.ToString("X2");
			}

			poiohgwuj = "";

			tmp += "|";

			foreach (byte __b in m5.ComputeHash(Encoding.UTF8.GetBytes(ptsdvlsfd)))
			{
				tmp += __b.ToString("X2");
			}

			ptsdvlsfd = ""; b = null; bb = null; ib = null; ob = null; GC.Collect(); return tmp;
		}

		/// <summary>
		/// Checks if password is filled out in DB
		/// </summary>
		/// <param name="sqlc">Current open SQLiteConnection</param>
		/// <returns></returns>
		public static bool checkPassword(SQLiteConnection sqlc)
		{
			if (!connectioinOpen(sqlc)) { return false; }

			bool ret = false;

			SQLiteCommand sqlk = new SQLiteCommand("SELECT passwd FROM password WHERE id=1;", sqlc);

			ret = sqlk.ExecuteScalar().ToString() == "" ? false : true;

			return ret;
		}

		/// <summary>
		/// Login - Checks password againstr the one saved in DB
		/// </summary>
		/// <param name="sqlc">Current open SQLiteConnection</param>
		/// <param name="password">String containing password</param>
		/// <returns>Bool, true if Password is OK</returns>
		public static bool login(SQLiteConnection sqlc, string password, profile prof)
		{
			if (!connectioinOpen(sqlc)) { return false; }

			bool ret = false;
			string pwd = password;
			byte[] bytes = Encoding.UTF8.GetBytes(pwd);
			//pwd = Encoding.UTF8.GetString();
			pwd = "";
			foreach (byte b in sha5.ComputeHash(bytes))
			{
				pwd += b.ToString("X2");
			}

			SQLiteCommand sqlk = new SQLiteCommand("SELECT id FROM password WHERE passwd='" + pwd + "';", sqlc);

			ret = sqlk.ExecuteScalar() == null ? false : true;

			//Updateljük a last login-t a profilon
			if (ret && prof != null)
			{
				sqlk = new SQLiteCommand("UPDATE profilok SET last_login='" + DateTime.Now.ToShortDateString() + "' WHERE lower(profil_name) = '" + prof.name.ToLower() + "';", sqlc);
				executeNonQuery(sqlk);
			}

			return ret;
		}

		#endregion
		
	}


	
}


	/*
	 
		Vallás:
		0 : Római katolikus 
		1 : Evangélikus 
		2 : Református 
		3 : Metodista 
		4 : Baptista 
		5 : Unitárius 
		6 : Nem hívő
		7 : Egyéb

		Lakás:
		0 : Saját Lakás
		1 : Albérlő
		2 : Társbérlő
		3 : Hajléktalan
		4 : Szívességi Lakáshasználó

		Ált. Szoc. Helyzet:
		0 : Jó
		1 : Közepes
		2 : Megfelelő
		3 : Rossz

		Rendszeres segítségre szorul:
		0 : Igen
		1 : Nem
		2 : Esetenként

		Családi állapot:
		0 : nős
		1 : nőtlen
		2 : férjezett
		3 : hajadon
		4 : özvegy
		5 : elvált
				
	*/
