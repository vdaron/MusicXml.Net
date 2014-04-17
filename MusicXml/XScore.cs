using System.Collections.Generic;
using System.IO;
using System.Xml;
using MindTouch.Dream;
using MindTouch.Xml;

namespace MusicXml
{
	public class XScore
	{
		private readonly XDoc theDocument;
		private XmlDocument _document;

		public XScore(string aFileName)
		{
			theDocument = XDocFactory.LoadFrom(aFileName, MimeType.XML);
			_document = new XmlDocument();

			var xml = GetXml(aFileName);
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

		public XScore(XDoc aDocument)
		{
			theDocument = aDocument;
		}

		public string MovementTitle
		{
			get
			{
				var selectSingleNode = _document.SelectSingleNode("score-partwise/movement-title");
				if (selectSingleNode != null)
				{
					return selectSingleNode.InnerText;
				}
				return string.Empty;
			}
		}

		public Identification Identification
		{
			get
			{
				return new Identification(theDocument["identification"]);
			}
		}

		public List<Part> Parts
		{
			get
			{
				var parts = new List<Part>();
				foreach (var part in theDocument["part-list/score-part"])
				{
					parts.Add(new Part(part));
				}
				return parts;
			}
		}
	}
}
