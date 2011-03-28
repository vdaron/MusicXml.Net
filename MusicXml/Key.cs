using System;
using MindTouch.Dream;

namespace MusicXml
{
	public class Key
	{
		private readonly XDoc theDocument;

		internal Key(XDoc aDocument)
		{
			theDocument = aDocument;
		}
		public int Fifths
		{
			get { return theDocument["fifths"].AsInt ?? 0; }
		}
		public string Mode
		{
			get{ return theDocument["mode"].AsText ?? String.Empty; }
		}
	}
}
