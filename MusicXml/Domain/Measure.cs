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
			Width = -1;
		}

		public int Width { get; internal set; }
		
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

		public MeasureAttributes Attributes { get; internal set; }
	}
}
