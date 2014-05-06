namespace MusicXml.Domain
{
	public class Key
	{
		internal Key()
		{
			Fifths = 0;
			Mode = string.Empty;
		}

		public int Fifths { get; internal set; }

		public string Mode { get; internal set; }
	}
}
