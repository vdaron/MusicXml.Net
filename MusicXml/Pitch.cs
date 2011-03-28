using MindTouch.Dream;

namespace MusicXml
{
	/// <summary>
		  //<pitch>
		  //  <step>C</step>
		  //  <alter>1</alter>
		  //  <octave>4</octave>
		  //</pitch>
	/// </summary>
	public class Pitch
	{
		private readonly XDoc theDocument;

		internal Pitch(XDoc aDocument)
		{
			theDocument = aDocument;
		}

		public char Step
		{
			get { return theDocument["step"].AsText[0]; }
		}
		public int Alter
		{
			get { return theDocument["alter"].AsInt ?? 0; }
		}
		public int Octave
		{
			get { return theDocument["octave"].AsInt ?? 0; }
		}
	}
}
