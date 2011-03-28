using System.Collections.Generic;
using MindTouch.Dream;

namespace MusicXml
{
	public class Measure
	{
		private readonly XDoc theDocument;
		private MeasureAttributes theAttributes;

		internal Measure(XDoc aDocument)
		{
			theDocument = aDocument;
		}

		public int Width
		{
			get { return theDocument["@width"].AsInt ?? -1; }
		}

		public IEnumerable<Note> Notes
		{
			get
			{
				List<Note> notes = new List<Note>();
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
					XDoc attributes = theDocument["attributes"];
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
