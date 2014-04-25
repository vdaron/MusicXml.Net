using System;
using System.Xml;
using MindTouch.Xml;

namespace MusicXml
{
	public class Key
	{
		private readonly XDoc theDocument;
		private readonly XmlNode _keyNode;

		internal Key(XDoc aDocument, XmlNode keyNode)
		{
			theDocument = aDocument;
			_keyNode = keyNode;
		}

		public int Fifths
		{
			get
			{
				var fifthsNode = _keyNode.SelectSingleNode("fifths");
				if (fifthsNode == null)
					return 0;

				return Convert.ToInt32(fifthsNode.InnerText);
			}
		}
		public string Mode
		{
			get{ return theDocument["mode"].AsText ?? String.Empty; }
		}
	}
}
