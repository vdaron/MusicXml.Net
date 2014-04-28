using System;
using System.Xml;

namespace MusicXml.Domain
{
	public class Note
	{
		private readonly XmlNode _noteNode;

		internal Note(XmlNode noteNode)
		{
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
				var lyricNode = _noteNode.SelectSingleNode("lyric");
				return lyricNode == null ? null : new Lyric(lyricNode);
			}
		}
		public Pitch Pitch
		{
			get
			{
				var pitchNode = _noteNode.SelectSingleNode("pitch");
				return pitchNode == null ? null : new Pitch(pitchNode);
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
				var chordNode = _noteNode.SelectSingleNode("chord");
				return chordNode != null;
			}
		}
	}
}
