using System;
using System.Xml;

namespace MusicXml.Domain
{
	public class MeasureAttributes
	{
		private readonly XmlNode _measureAttributesNode;

		internal MeasureAttributes(XmlNode measureAttributesNode)
		{
			_measureAttributesNode = measureAttributesNode;
		}

		public int Divisions
		{
			get
			{
				var divisionsNode = _measureAttributesNode.SelectSingleNode("divisions");
				return divisionsNode == null ? 0 : Convert.ToInt32(divisionsNode.InnerText);
			}
		}
		public Key Key
		{
			get
			{
				var keyNode = _measureAttributesNode.SelectSingleNode("key");

				return keyNode == null ? null : new Key(keyNode);
			}
		}
		public Time Time
		{
			get
			{
				var timeNode = _measureAttributesNode.SelectSingleNode("time");

				return timeNode == null ? null : new Time(timeNode);
			}
		}
		public Clef Clef
		{
			get
			{
				var clefNode = _measureAttributesNode.SelectSingleNode("clef");

				return clefNode == null ? null : new Clef(clefNode);
			}
		}
	}
}
