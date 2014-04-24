using System.Collections.Generic;
using System.Xml;
using MindTouch.Xml;

namespace MusicXml
{
	public class Part
	{
		private readonly XDoc theDocument;
		private readonly XmlNode _partNode;

		internal Part(XDoc aDocument, XmlNode partNode)
		{
			theDocument = aDocument;
			_partNode = partNode;
		}

		public string Id
		{
			get
			{
				if (_partNode.Attributes == null)
					return null;

				return _partNode.Attributes["id"].InnerText;
				//return theDocument["@id"].AsText;
			}
		}

		public string Name
		{
			get { return theDocument["part-name"].AsText; }
		}

		public List<Measure> Measures
		{
			get
			{
				var measures = new List<Measure>();
				foreach (XDoc measure in theDocument["//part[@id='" + Id + "']/measure"])
				{
					measures.Add(new Measure(measure));
				}
				return measures;
			}
		}
	}
}
