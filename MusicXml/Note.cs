using System;
using System.Xml;
using MindTouch.Xml;

namespace MusicXml
{
	public class Note
	{
		private readonly XDoc theDocument;
		private readonly XmlNode _noteNode;

		internal Note(XDoc aDocument, XmlNode noteNode)
		{
			theDocument = aDocument;
			_noteNode = noteNode;
		}

		public string Type
		{
			get
			{
				var typeNode = _noteNode.SelectSingleNode("type");
				return typeNode == null ? string.Empty : typeNode.InnerText;
			}
		}
		public int Voice
		{
			get
			{
				var voiceNode = _noteNode.SelectSingleNode("voice");
				return voiceNode == null ? -1 : Convert.ToInt32(voiceNode.InnerText);
			}
		}
		public int Duration
		{
			get
			{
				var durationNode = _noteNode.SelectSingleNode("duration");
				return durationNode == null ? -1 : Convert.ToInt32(durationNode.InnerText);
			}
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
				var staffNode = _noteNode.SelectSingleNode("staff");
				return staffNode == null ? -1 : Convert.ToInt32(staffNode.InnerText);
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
