using System;
using System.IO;
using System.Text;
using System.Xml;
using MusicXml.Domain;
using Encoding = MusicXml.Domain.Encoding;

namespace MusicXml
{
	public static class MusicXmlParser
	{
		public static Score GetScore(string filename)
		{
			var document = GetXmlDocument(filename);

			var score = new Score();

			var movementTitleNode = document.SelectSingleNode("score-partwise/movement-title");
			score.MovementTitle = movementTitleNode != null ? movementTitleNode.InnerText : string.Empty;
			
			var identificationNode = document.SelectSingleNode("score-partwise/identification");
			if (identificationNode != null)
			{
				score.Identification = new Identification();
				
				var composerNode = identificationNode.SelectSingleNode("creator[@type='composer']");
				score.Identification.Composer = composerNode != null ? composerNode.InnerText : string.Empty;

				var rightsNode = identificationNode.SelectSingleNode("rights");
				score.Identification.Rights = rightsNode != null ? rightsNode.InnerText : string.Empty;

				var encodingNode = identificationNode.SelectSingleNode("encoding");
				score.Identification.Encoding = new Encoding();

				if (encodingNode != null)
				{
					score.Identification.Encoding.Software = GetInnerTextOfChildTag(encodingNode, "software");

					score.Identification.Encoding.Description = GetInnerTextOfChildTag(encodingNode, "encoding-description");
					
					var encodingDate = encodingNode.SelectSingleNode("encoding-date");
					if (encodingDate != null) score.Identification.Encoding.EncodingDate = Convert.ToDateTime(encodingDate.InnerText);
				}
			}

			var partNodes = document.SelectNodes("score-partwise/part-list/score-part");
			
			if (partNodes != null)
			{
				foreach (XmlNode partNode in partNodes)
				{
					var part = new Part();
					score.Parts.Add(part);

					if (partNode.Attributes != null)
						part.Id = partNode.Attributes["id"].InnerText;
					
					var partNameNode = partNode.SelectSingleNode("part-name");
					
					if (partNameNode != null)
						part.Name = partNameNode.InnerText;

					var measuresXpath = string.Format("//part[@id='{0}']/measure", part.Id);

					var measureNodes = partNode.SelectNodes(measuresXpath);

					if (measureNodes != null)
					{
						foreach (XmlNode measure in measureNodes)
						{
							part.Measures.Add(new Measure(measure));
						}
					}

				}
			}

			return score;
		}

		private static string GetInnerTextOfChildTag(XmlNode encodingNode, string tagName)
		{
			var softwareStringBuilder = new StringBuilder();
			
			var encodingSoftwareNodes = encodingNode.SelectNodes(tagName);

			if (encodingSoftwareNodes != null)
			{
				foreach (XmlNode node in encodingSoftwareNodes)
				{
					softwareStringBuilder.AppendLine(node.InnerText);
				}
			}

			return softwareStringBuilder.ToString();
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
