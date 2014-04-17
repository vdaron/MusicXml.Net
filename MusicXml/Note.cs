using System;
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
				var lyric = theDocument["lyric"];
				return lyric.IsEmpty ? null : new Lyric(lyric);
			}
		}
		public Pitch Pitch
		{
			get
			{
				var pitch = theDocument["pitch"];
				return pitch.IsEmpty ? null : new Pitch(pitch);
			}
		}

		public int Staff
		{
			get 
			{
				return theDocument["staff"].AsInt ?? -1;
			}
		}

		public bool IsChordTone
		{
			get
			{
				var chordTag = theDocument["chord"];
				
				if (chordTag.AsText != null)
				{
					return true;
				}
				return false;
			}
		}
	}
}
