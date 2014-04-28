using System;
using System.Xml;

namespace MusicXml.Domain
{
	public class Pitch
	{
		private readonly XmlNode _pitchNode;

		internal Pitch(XmlNode pitchNode)
		{
			_pitchNode = pitchNode;
		}

		public char? Step
		{
			get
			{
				var stepNode = _pitchNode.SelectSingleNode("step");
				return stepNode != null ? (char?) stepNode.InnerText[0] : null;
			}
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
