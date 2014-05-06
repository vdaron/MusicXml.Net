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
		internal Lyric()
		{
		}

		public Syllabic Syllabic { get; internal set; }
		
		public string Text { get; internal set; }
	}
}