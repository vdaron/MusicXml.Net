using System;
using System.Collections.Generic;
using System.Xml;

namespace MusicXml.Domain
{
	public class Measure
	{
		private readonly XmlNode _measureNode;

		internal Measure(XmlNode measureNode)
		{
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
				var noteNodes = _measureNode.SelectNodes("note");

				if (noteNodes == null)
					return notes;

				foreach (XmlNode note in noteNodes)
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
