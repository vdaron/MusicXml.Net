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
			UpperStaffNotesInOrderOfTime = new Dictionary<int, List<Note>>();
		}

		public int Width { get; internal set; }
		
		public List<Note> Notes { get; internal set; }
		
		public MeasureAttributes Attributes { get; internal set; }

		/*
		 * This structure contains the notes in the order they will appear in the rendered staff from highest to lowest in pitch.
		 * 
		 * Each key is the absolute postion of the note in the measure. The absolute position is caculated by summing the durations of notes as they are
		 * parsed. If a backup or forward tag is encountered the current position is moved and the next insertion checks to see if there is
		 * already a note at that position and performs and ordered insert.
		 */
		public Dictionary <int, List<Note>> UpperStaffNotesInOrderOfTime { get; internal set; }
	}
}
