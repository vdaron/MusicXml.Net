using System.Collections.Generic;
using System.Xml;

namespace MusicXml.Domain
{
	public class Score
	{
		private readonly XmlDocument _document;

		internal Score(XmlDocument document)
		{
			_document = document;
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
