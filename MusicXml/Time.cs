using System;
using System.Xml;
using MindTouch.Xml;

namespace MusicXml
{
	public enum TimeSymbol
	{
		Normal,Common, Cut, SingleNumber
	}

	public class Time
	{
		private readonly XDoc theDocument;
		private readonly XmlNode _timeNode;

		internal Time(XDoc aDocument, XmlNode timeNode)
		{
			theDocument = aDocument;
			_timeNode = timeNode;
		}

		public int Beats
		{
			get
			{
				var beatsNode = _timeNode.SelectSingleNode("beats");
				return beatsNode == null ? 0 : Convert.ToInt32(beatsNode.InnerText);
			}
		}
		public string Mode
		{
			get { return theDocument["beat-type"].AsText ?? String.Empty; }
		}

		public TimeSymbol Symbol
		{
			get
			{
				var symbol = TimeSymbol.Normal;
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
