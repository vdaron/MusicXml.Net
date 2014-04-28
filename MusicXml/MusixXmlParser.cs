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

			var score = new Score();

			var movementTitleNode = document.SelectSingleNode("score-partwise/movement-title");
			score.MovementTitle = movementTitleNode != null ? movementTitleNode.InnerText : string.Empty;
			
			var identificationNode = document.SelectSingleNode("score-partwise/identification");
			score.Identification = new Identification(identificationNode);
			
			var partNodes = document.SelectNodes("score-partwise/part-list/score-part");
			
			if (partNodes != null)
			{
				foreach (XmlNode partNode in partNodes)
				{
					score.Parts.Add(new Part(partNode));
				}
			}

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
