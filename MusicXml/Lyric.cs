using System;
using MindTouch.Xml;

namespace MusicXml
{
	public enum Syllabic
	{
		None,
		Begin,
		Single,
		End,
		Middle
	}

	public class Lyric
	{
		private readonly XDoc theDocument;

		internal Lyric(XDoc aDocument)
		{
			theDocument = aDocument;
		}

		public Syllabic Syllabic
		{
			get
			{
				switch (theDocument["syllabic"].AsText ?? String.Empty)
				{
					case "":
						return Syllabic.None;
					case "begin":
						return Syllabic.Begin;
					case "single":
						return Syllabic.Single;
					case "end":
						return Syllabic.End;
					case "middle":
						return Syllabic.Middle;
					default:
						throw new Exception("Unknown syllabic type");
				}
			}
		}
		public string Text
		{
			get { return theDocument["text"].AsText ?? String.Empty; }
		}
	}
}
