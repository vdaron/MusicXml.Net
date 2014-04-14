using System.Collections.Generic;
using MindTouch.Xml;

namespace MusicXml
{
	public class Part
	{
		private readonly XDoc theDocument;

		internal Part(XDoc aDocument)
		{
			theDocument = aDocument;
		}

		public string Id
		{
			get { return theDocument["@id"].AsText; }
		}

		public string Name
		{
			get { return theDocument["part-name"].AsText; }
		}

		public IEnumerable<Measure> Measures
		{
			get
			{
				var measures = new List<Measure>();
				foreach (XDoc measure in theDocument["//part[@id='" + Id + "']/measure"])
				{
					measures.Add(new Measure(measure));
				}
				return measures;
			}
		}
	}
}
