namespace MusicXml.Domain
{
	public class MeasureAttributes
	{
		internal MeasureAttributes()
		{
			Divisions = 0;
		}

		public int Divisions { get; internal set; }
		
		public Key Key { get; internal set; }
		
		public Time Time { get; internal set; }
		 
		public Clef Clef { get; internal set; }
	}
}
