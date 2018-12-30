using System;
using System.Collections.Generic;
using System.Xml;
using System.IO;
using System.Linq;

namespace CaritasManager
{
	class c_xml
	{
		Dictionary<string, string> items = new Dictionary<string, string>();

		public c_xml(string xml_string)
		{
			TextReader sr = new StringReader(xml_string);
			XmlDocument document = new XmlDocument();
			document.InnerXml = xml_string;

			foreach (XmlNode v in document.FirstChild.ChildNodes)
			{
				try {
					items.Add(v.FirstChild.InnerText, v.LastChild.InnerText);
				} catch(Exception ex) {
					Console.WriteLine($"Error while adding city to dictionary\r\nName: {v.FirstChild.InnerText}\r\nZipcode: {v.LastChild.InnerText}");
					Console.Error.WriteLine(ex.Message);
				}
			}
		}

		public string getCityName(string zipcode)
		{
			return items.Where(x => x.Value == zipcode).Select(x=>x.Key).First();
		}

		public int getZipcode(string cityName)
		{
			return Convert.ToInt32(items[cityName]);
		}
	}
}
