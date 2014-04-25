using System;
using System.Xml;
using MindTouch.Xml;

namespace MusicXml
{
	public class MeasureAttributes
	{
		private readonly XDoc theDocument;
		private readonly XmlNode _measureAttributesNode;

		internal MeasureAttributes(XDoc aDocument, XmlNode measureAttributesNode)
		{
			theDocument = aDocument;
			_measureAttributesNode = measureAttributesNode;
		}

		public int Divisions
		{
			get
			{
				var divisionsNode = _measureAttributesNode.SelectSingleNode("divisions");
				if (divisionsNode == null)
					return 0;

				return Convert.ToInt32(divisionsNode.InnerText);
			}
		}
		public Key Key
		{
			get
			{
				var keyNode = _measureAttributesNode.SelectSingleNode("key");

				if (keyNode == null)
					return null;

				return new Key(keyNode);
			}
		}
		public Time Time
		{
			get
			{
				var time = theDocument["time"];
				var timeNode = _measureAttributesNode.SelectSingleNode("time");
				return time.IsEmpty ? null : new Time(time, timeNode);
			}
		}
		public Clef Clef
		{
			get
			{
				var clefNode = _measureAttributesNode.SelectSingleNode("clef");

				if (clefNode == null)
					return null;

				return new Clef(clefNode);
			}
		}
	}
}
