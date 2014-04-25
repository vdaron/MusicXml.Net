using System;
using System.Xml;
using MindTouch.Xml;

namespace MusicXml
{
	public class Pitch
	{
		private readonly XDoc theDocument;
		private readonly XmlNode _pitchNode;

		internal Pitch(XDoc aDocument, XmlNode pitchNode)
		{
			theDocument = aDocument;
			_pitchNode = pitchNode;
		}

		public char Step
		{
			get { return theDocument["step"].AsText[0]; }
		}
		public int Alter
		{
			get
			{
				var alterNode = _pitchNode.SelectSingleNode("alter");
				return alterNode == null ? 0 : Convert.ToInt32(alterNode.InnerText);
			}
		}
		public int Octave
		{
			get
			{
				var octaveNode = _pitchNode.SelectSingleNode("octave");
				return octaveNode == null ? 0 : Convert.ToInt32(octaveNode.InnerText);
			}
		}
	}
}
