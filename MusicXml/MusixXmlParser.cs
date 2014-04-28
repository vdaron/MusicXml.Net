using System.IO;
using System.Xml;
using MusicXml.Domain;

namespace MusicXml
{
	public static class MusixXmlParser
	{
		public static Score GetScore(string filename)
		{
			var document = new XmlDocument();

			var xml = GetXml(filename);
			document.XmlResolver = null;
			document.LoadXml(xml);

			return new Score(document);
		}

		private static string GetXml(string filename)
		{
			using (var fileStream = new FileStream(filename, FileMode.Open))
			using (var streamReader = new StreamReader(fileStream))
			{
				return streamReader.ReadToEnd();
			}
		}
	}
}
