using MindTouch.Dream;
using MindTouch.Xml;

namespace MusicXml
{
	public class MeasureAttributes
	{
		private readonly XDoc theDocument;

		internal MeasureAttributes(XDoc aDocument)
		{
			theDocument = aDocument;
		}
		public int Divisions
		{
			get { return theDocument["divisions"].AsInt ?? 0; }
		}
		public Key Key
		{
			get
			{
				XDoc key = theDocument["key"];
				return key.IsEmpty ? null : new Key(key);
			}
		}
		public Time Time
		{
			get
			{
				XDoc time = theDocument["time"];
				return time.IsEmpty ? null : new Time(time);
			}
		}
		public Clef Clef
		{
			get
			{
				XDoc clef = theDocument["clef"];
				return clef.IsEmpty ? null : new Clef(clef);
			}
		}
	}
}
