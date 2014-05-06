using System;

namespace MusicXml.Domain
{
	/// <summary>
	/// The encoding element contains information about who did the digital encoding,
	/// when, with what software, and in what aspects. Standard type values for the
	/// encoder element are music, words, and arrangement, but other types may be used.
	/// The type attribute is only needed when there are multiple encoder elements.
	/// </summary>
	public class Encoding
	{
		internal Encoding()
		{
			Software = string.Empty;
			Description = string.Empty;
			EncodingDate = new DateTime();
		}

		public string Software { get; internal set; }
	
		public string Description { get; internal set; }
		
		public DateTime EncodingDate { get; internal set; }
		
	}
}
