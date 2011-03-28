using System;
using MindTouch.Dream;

namespace MusicXml
{
	public class Clef
	{
		private readonly XDoc theDocument;

		internal Clef(XDoc aDocument)
		{
			theDocument = aDocument;
		}
		public int Line
		{
			get { return theDocument["line"].AsInt ?? 0; }
		}
		public string Sign
		{
			get { return theDocument["sign"].AsText ?? String.Empty; }
		}
	}
}
