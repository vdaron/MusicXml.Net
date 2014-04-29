namespace MusicXml.Domain
{
	public class Identification
	{
		internal Identification()
		{
		}

		public string Composer { get; internal set; }
		
		public string Rights { get; internal set; }
		
		public Encoding Encoding { get; internal set; }
	}
}
