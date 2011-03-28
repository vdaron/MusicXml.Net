using System;
using MindTouch.Dream;

namespace MusicXml
{
	public enum TimeSymbol
	{
		Normal,Common, Cut, SingleNumber
	}

	public class Time
	{
		private readonly XDoc theDocument;

		internal Time(XDoc aDocument)
		{
			theDocument = aDocument;
		}
		public int Beats
		{
			get { return theDocument["beats"].AsInt ?? 0; }
		}
		public string Mode
		{
			get { return theDocument["beat-type"].AsText ?? String.Empty; }
		}
		public TimeSymbol Symbol
		{
			get
			{
				TimeSymbol symbol = TimeSymbol.Normal;
				switch(theDocument["@symbol"].AsText)
				{
					case "common":
						symbol = TimeSymbol.Common;
						break;
					case "cut":
						symbol = TimeSymbol.Cut;
						break;
					case "single-number":
						symbol = TimeSymbol.SingleNumber;
						break;
				}
				return symbol;
			}
		}
	}
}
