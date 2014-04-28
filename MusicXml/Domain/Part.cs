using System.Collections.Generic;

namespace MusicXml.Domain
{
	public class Part
	{
		internal Part()
		{
			Measures = new List<Measure>();
		}

		public string Id { get; internal set; }
		
		public string Name { get; internal set; }
		
		public List<Measure> Measures { get; internal set; }
	}
}
