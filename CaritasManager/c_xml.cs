using System;
using System.Collections.Generic;
using System.Xml;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace CaritasManager
{
	class c_xml
	{
		List<city> items = new List<city>();

		public c_xml(string xml_string)
		{
			TextReader sr = new StringReader(xml_string);
			XmlDocument document = new XmlDocument();
			document.InnerXml = xml_string;

			foreach (XmlNode v in document.FirstChild.ChildNodes)
			{
				try {
					items.Add(new city() { name = v.FirstChild.InnerText, zipcode = v.LastChild.InnerText });
				} catch(Exception ex) {
					Console.WriteLine($"Error while adding city to dictionary\r\nName: {v.FirstChild.InnerText}\r\nZipcode: {v.LastChild.InnerText}");
					Console.Error.WriteLine(ex.Message);
				}
			}
		}

		public string getCityName(string zipcode)
		{

			try
			{
				return items.Where(x => x.zipcode == zipcode).Select(x => x.name).First();
			}
			catch
			{
				return "";
			}
		}

		public int getZipcode(string cityName)
		{
			try
			{
				return Convert.ToInt32(items.Where(x => x.name == cityName).Select(x => x.zipcode).First());
			}
			catch
			{
				return -1;
			}
		}

		public List<city> getItems()
		{
			return items;
		}

		public city getCity(string cityName)
		{
			try
			{
				return items.Where(x => x.name == cityName).ToArray()[0];
			}
			catch
			{
				return null;
			}
		}
		public bool tryGetCity(string cityName, out city result)
		{
			try
			{
				city c = items.Where(x => x.name == cityName).ToArray()[0];
				if (c != null)
				{
					result = c;
					return true;
				}
				else
				{
					result = null;
					return false;
				}
			}
			catch
			{
				result = null;
				return false;
			}
		}

		public city getCityByZip(string zipcode)
		{
			try
			{
				return items.Where(x => x.zipcode == zipcode).ToArray()[0] ?? null;
			}
			catch
			{
				return null;
			}
		}
	}
	
}
