using System.IO;
using System.Xml;
using MusicXml.Domain;

namespace MusicXml
{
	public static class MusixXmlParser
	{
		public static Score GetScore(string filename)
		{
			var document = GetXmlDocument(filename);

			var score = new Score(document);

			return score;
		}

		private static XmlDocument GetXmlDocument(string filename)
		{
			var document = new XmlDocument();

			var xml = GetFileContents(filename);
			document.XmlResolver = null;
			document.LoadXml(xml);

			return document;
		}

		private static string GetFileContents(string filename)
		{
			using (var fileStream = new FileStream(filename, FileMode.Open))
			using (var streamReader = new StreamReader(fileStream))
			{
				return streamReader.ReadToEnd();
			}
		}
	}
}
