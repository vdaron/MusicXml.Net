using System;

namespace MusicXml.Domain
{
	public class Pitch
	{
		internal Pitch()
		{
			Alter = 0;
			Octave = 0;
			Step = new Char();
		}

		public int Alter { get; internal set; }

		public int Octave { get; internal set; }

		public char Step { get; internal set; }
	}
}