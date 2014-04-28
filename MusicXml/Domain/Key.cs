using System;
using System.Xml;

namespace MusicXml.Domain
{
	public class Key
	{
		private readonly XmlNode _keyNode;

		internal Key(XmlNode keyNode)
		{
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
			get
			{
				var modeNode = _keyNode.SelectSingleNode("mode");
				if (modeNode == null)
					return string.Empty;

				return modeNode.InnerText;
			}
		}
	}
}
