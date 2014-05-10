namespace MusicXml.Domain
{
	public class Identification
	{
		internal Identification()
		{
			Composer = string.Empty;
			Rights = string.Empty;
		}

		public string Composer { get; internal set; }
		
		public string Rights { get; internal set; }
		
		public Encoding Encoding { get; internal set; }
	}
}
