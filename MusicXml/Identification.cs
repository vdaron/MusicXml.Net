using MindTouch.Dream;
using System;
using MindTouch.Xml;

namespace MusicXml
{
	public class Identification
	{
		private readonly XDoc theDocument;

		internal Identification(XDoc aDocument)
		{
			theDocument = aDocument;
		}

		public string Composer
		{
			get
			{
				return theDocument["creator[@type='composer']"].AsText ?? String.Empty;
			}
		}

		public string Rights
		{
			get
			{
				return theDocument["rights"].AsText ?? String.Empty;
			}
		}

		public Encoding Encoding
		{
			get
			{
				return new Encoding(theDocument["encoding"]);
			}
		}
	}
}
