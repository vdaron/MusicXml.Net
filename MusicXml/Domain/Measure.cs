using System.Collections.Generic;

namespace MusicXml.Domain
{
	public class Measure
	{
		internal Measure()
		{
			Width = -1;
			Notes = new List<Note>();
			Attributes = new MeasureAttributes();
		}

		public int Width { get; internal set; }
		
		public List<Note> Notes { get; internal set; }
		
		public MeasureAttributes Attributes { get; internal set; }
	}
}
