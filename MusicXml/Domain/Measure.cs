using System.Collections.Generic;

namespace MusicXml.Domain
{
	public class Measure
	{
		internal Measure()
		{
			Width = -1;
			MeasureElements = new List<MeasureElement>();
		}

		public decimal Width { get; internal set; }
		
		// This can be any musicXML element in the measure tag, i.e. note, backup, etc
		public List<MeasureElement> MeasureElements { get; internal set; }
		
		public MeasureAttributes Attributes { get; internal set; }
	}
}
