using System;
using System.Xml;

namespace MusicXml.Domain
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
		private readonly XmlNode _lyricNode;

		internal Lyric(XmlNode lyricNode)
		{
			_lyricNode = lyricNode;
		}

		public Syllabic Syllabic
		{
			get
			{
				var syllabicNode = _lyricNode.SelectSingleNode("syllabic");

				var syllabicText = string.Empty;
				if (syllabicNode != null)
					syllabicText = syllabicNode.InnerText;

				switch (syllabicText)
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
			get
			{
				var textNode = _lyricNode.SelectSingleNode("text");

				return textNode == null ? string.Empty : textNode.InnerText;
			}
		}
	}
}