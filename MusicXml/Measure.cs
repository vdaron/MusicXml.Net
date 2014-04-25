using System;
using System.Collections.Generic;
using System.Xml;
using MindTouch.Xml;

namespace MusicXml
{
	public class Measure
	{
		private readonly XDoc theDocument;
		private readonly XmlNode _measureNode;

		internal Measure(XDoc aDocument, XmlNode measureNode)
		{
			theDocument = aDocument;
			_measureNode = measureNode;
		}

		public int Width
		{
			get
			{
				if (_measureNode.Attributes == null)
					return -1;

				return Convert.ToInt32(_measureNode.Attributes["width"].InnerText);
			}
		}

		public List<Note> Notes
		{
			get
			{
				var notes = new List<Note>();
				foreach (XDoc note in theDocument["note"])
				{
					notes.Add(new Note(note));
				}
				return notes;
			}
		}

		public MeasureAttributes Attributes
		{
			get
			{
				var attributesNode = _measureNode.SelectSingleNode("attributes");

				return attributesNode == null ? null : new MeasureAttributes(attributesNode);
			}
		}
	}
}
