using System.Xml;

namespace MusicXml
{
	public class Identification
	{
		private readonly XmlNode _node;

		internal Identification(XmlNode node)
		{
			_node = node;
		}

		public string Composer
		{
			get
			{
				var composerNode = _node.SelectSingleNode("creator[@type='composer']");
				return composerNode != null ? composerNode.InnerText : string.Empty;
			}
		}

		public string Rights
		{
			get
			{
				var rightsNode = _node.SelectSingleNode("rights");
				return rightsNode != null ? rightsNode.InnerText : string.Empty;
			}
		}

		public Encoding Encoding
		{
			get
			{
				var encodingNode = _node.SelectSingleNode("encoding");
				return new Encoding(encodingNode);
			}
		}
	}
}
