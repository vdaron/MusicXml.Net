using System.Collections.Generic;
using System.Xml;

namespace MusicXml
{
	public class Part
	{
		private readonly XmlNode _partNode;

		internal Part(XmlNode partNode)
		{
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
			
				if (measureNodes == null)
					return measures;
			
				foreach (XmlNode measure in measureNodes)
				{
					measures.Add(new Measure(measure));
				}

				return measures;
			}
		}
	}
}
