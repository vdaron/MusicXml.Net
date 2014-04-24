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
		private MeasureAttributes theAttributes;

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
				if (theAttributes == null)
				{
					var attributes = theDocument["attributes"];
					if (!attributes.IsEmpty)
					{
						theAttributes = new MeasureAttributes(attributes);
					}
				}
				return theAttributes;
			}
		}
	}
}
