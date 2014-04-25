using System;
using System.Xml;

namespace MusicXml
{
	public class Clef
	{
		private readonly XmlNode _clefNode;

		internal Clef(XmlNode clefNode)
		{
			_clefNode = clefNode;
		}

		public int Line
		{
			get
			{
				var lineNode = _clefNode.SelectSingleNode("line");
				if (lineNode == null)
					return 0;

				return Convert.ToInt32(lineNode.InnerText);
			}
		}
		public string Sign
		{
			get
			{
				var signNode = _clefNode.SelectSingleNode("sign");
				if (signNode == null)
					return string.Empty;

				return signNode.InnerText;
			}
		}
	}
}
