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
			}
		}

		public string Name
		{
			get
			{
				var partNameNode = _partNode.SelectSingleNode("part-name");
				if (partNameNode == null)
					return null;

				return partNameNode.InnerText;
			}
		}

		public List<Measure> Measures
		{
			get
			{
				var measures = new List<Measure>();

				var measuresXpath = "//part[@id='" + Id + "']/measure";

				var measureNodes = _partNode.SelectNodes(measuresXpath);
				var counter = 0;

				foreach (var measure in theDocument[measuresXpath])
				{
					measures.Add(new Measure(measure, measureNodes[counter]));
					counter++;
				}

				return measures;
			}
		}
	}
}
