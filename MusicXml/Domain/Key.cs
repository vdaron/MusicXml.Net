namespace MusicXml.Domain
{
	public class Key
	{
		internal Key()
		{
			Fifths = 0;
		}

		public int Fifths { get; internal set; }

		public string Mode { get; internal set; }
	}
}
