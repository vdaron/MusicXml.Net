using System.Collections.Generic;

namespace MusicXml.Domain
{
	public class Note
	{
		internal Note()
		{
			Type = string.Empty;
			Duration = -1;
			Voice = -1;
			Staff = -1;
			IsChordTone = false;
			Lyric = new Lyric();
			Pitch = new Pitch();
			CounterPoints = new List<Note>();
		}

		public string Type { get; internal set; }
		
		public int Voice { get; internal set; }

		public int Duration { get; internal set; }

		public Lyric Lyric { get; internal set; }
		
		public Pitch Pitch { get; internal set; }

		public int Staff { get; internal set; }

		public bool IsChordTone { get; internal set; }

		// CounterPoints are notes that appear at the exact same time as other notes. 
		// Using the term counterpoint may not be accurate from a Music Theory standpoint in all cases; I needed something to call such notes.
		public List<Note> CounterPoints { get; internal set; }
	}
}
