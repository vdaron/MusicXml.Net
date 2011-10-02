using System;
using System.Collections.Generic;
using System.Text;
using MindTouch.Dream;
using MindTouch.Xml;

namespace MusicXml
{
	/// <summary>
	/// The encoding element contains information about who did the digital encoding,
	/// when, with what software, and in what aspects. Standard type values for the
	/// encoder element are music, words, and arrangement, but other types may be used.
	/// The type attribute is only needed when there are multiple encoder elements.
	/// </summary>
	public class Encoding
	{
		private readonly XDoc theDocument;

		internal Encoding(XDoc doc)
		{
			theDocument = doc;
		}

		public string Software
		{
			get
			{
				StringBuilder result = new StringBuilder();
				theDocument["software"].ForEach(x => result.AppendLine(x.AsText));
				return result.ToString();
			}
		}

		public string Description
		{
			get
			{
				StringBuilder result = new StringBuilder();
				theDocument["encoding-description"].ForEach(x => result.AppendLine(x.AsText));
				return result.ToString();
			}
		}

		public DateTime? EncodingDate
		{
			get { return theDocument["encoding-date"].AsDate; }
		}
	}
}
