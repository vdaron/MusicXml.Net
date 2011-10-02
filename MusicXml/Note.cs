using System;
using MindTouch.Dream;
using MindTouch.Xml;

namespace MusicXml
{
	public class Note
	{
		private readonly XDoc theDocument;

		internal Note(XDoc aDocument)
		{
			theDocument = aDocument;
		}

		public string Type
		{
			get { return theDocument["type"].AsText ?? String.Empty; }
		}
		public int Voice
		{
			get { return theDocument["voice"].AsInt ?? -1; }
		}
		public int Duration
		{
			get { return theDocument["duration"].AsInt ?? -1; }
		}
		public Lyric Lyric
		{
			get
			{
				XDoc lyric = theDocument["lyric"];
				return lyric.IsEmpty ? null : new Lyric(lyric);
			}
		}
		public Pitch Pitch
		{
			get
			{
				XDoc pitch = theDocument["pitch"];
				return pitch.IsEmpty ? null : new Pitch(pitch);
			}
		}
	}
}
