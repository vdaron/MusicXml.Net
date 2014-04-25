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
				var key = theDocument["key"];
				return key.IsEmpty ? null : new Key(key);
			}
		}
		public Time Time
		{
			get
			{
				var time = theDocument["time"];
				return time.IsEmpty ? null : new Time(time);
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
