using System;
using System.Text;
using System.Xml;

namespace MusicXml.Domain
{
	/// <summary>
	/// The encoding element contains information about who did the digital encoding,
	/// when, with what software, and in what aspects. Standard type values for the
	/// encoder element are music, words, and arrangement, but other types may be used.
	/// The type attribute is only needed when there are multiple encoder elements.
	/// </summary>
	public class Encoding
	{
		private readonly XmlNode _xmlNode;

		internal Encoding(XmlNode xmlNode)
		{
			_xmlNode = xmlNode;
		}

		public string Software
		{
			get
			{
				var result = new StringBuilder();

				var encodingSoftwareNodes = _xmlNode.SelectNodes("software");

				if (encodingSoftwareNodes != null)
				{
					foreach (XmlNode node in encodingSoftwareNodes)
					{
						result.AppendLine(node.InnerText);
					}
				}

				return result.ToString();
			}
		}

		public string Description
		{
			get
			{
				var result = new StringBuilder();
				
				var encodingDescriptionNodes = _xmlNode.SelectNodes("encoding-description");

				if (encodingDescriptionNodes != null)
				{
					foreach (XmlNode node in encodingDescriptionNodes)
					{
						result.AppendLine(node.InnerText);
					}
				}
				
				return result.ToString();
			}
		}

		public DateTime? EncodingDate
		{
			get
			{
				var encodingDate = _xmlNode.SelectSingleNode("encoding-date");

				if (encodingDate == null)
				{
					return null;
				}

				return Convert.ToDateTime(encodingDate.InnerText);
			}
		}
	}
}
