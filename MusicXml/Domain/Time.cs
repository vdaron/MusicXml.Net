using System;
using System.Xml;

namespace MusicXml.Domain
{
	public enum TimeSymbol
	{
		Normal, Common, Cut, SingleNumber
	}

	public class Time
	{
		private readonly XmlNode _timeNode;

		internal Time(XmlNode timeNode)
		{
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
			get
			{
				var beatTypeNode = _timeNode.SelectSingleNode("beat-type");
				return beatTypeNode == null ? string.Empty : beatTypeNode.InnerText;
			}
		}

		public TimeSymbol Symbol
		{
			get
			{
				var symbol = TimeSymbol.Normal;

				if (_timeNode.Attributes != null)
				{
					var symbolAttribute = _timeNode.Attributes["symbol"];

					if (symbolAttribute != null)
					{
						switch (symbolAttribute.InnerText)
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
					}
				}
				
				return symbol;
			}
		}
	}
}
