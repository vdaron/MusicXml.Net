using MindTouch.Xml;

namespace MusicXml
{
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
