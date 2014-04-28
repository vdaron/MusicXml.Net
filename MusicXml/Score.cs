using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace MusicXml
{
	public class Score
	{
		private readonly XmlDocument _document;

		public Score(string filename)
		{
			_document = new XmlDocument();

			var xml = GetXml(filename);
			_document.XmlResolver = null;
			_document.LoadXml(xml);
		}

		private static string GetXml(string filename)
		{
			using (var fileStream = new FileStream(filename, FileMode.Open))
			using (var streamReader = new StreamReader(fileStream))
			{
				return streamReader.ReadToEnd();
			}
		}

		public string MovementTitle
		{
			get
			{
				var movementTitleNode = _document.SelectSingleNode("score-partwise/movement-title");
				return movementTitleNode != null ? movementTitleNode.InnerText : string.Empty;
			}
		}

		public Identification Identification
		{
			get
			{
				var identificationNode = _document.SelectSingleNode("score-partwise/identification");
				return new Identification(identificationNode);
			}
		}

		public List<Part> Parts
		{
			get
			{
				var parts = new List<Part>();

				var partNodes = _document.SelectNodes("score-partwise/part-list/score-part");

				foreach (XmlNode partNode in partNodes)
				{
					parts.Add(new Part(partNode));
				}

				return parts;
			}
		}
	}
}
