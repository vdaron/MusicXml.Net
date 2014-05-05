using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using MusicXml.Domain;
using Encoding = MusicXml.Domain.Encoding;

namespace MusicXml
{
	public static class MusicXmlParser
	{
		public static Score GetScore(string filename)
		{
			var document = GetXmlDocument(filename);

			var score = new Score();

			var movementTitleNode = document.SelectSingleNode("score-partwise/movement-title");
			if (movementTitleNode != null)
				score.MovementTitle = movementTitleNode.InnerText;

			score.Identification = GetIdentification(document);
			
			var partNodes = document.SelectNodes("score-partwise/part-list/score-part");
			
			if (partNodes != null)
			{
				foreach (XmlNode partNode in partNodes)
				{
					var part = new Part();
					score.Parts.Add(part);

					if (partNode.Attributes != null)
						part.Id = partNode.Attributes["id"].InnerText;
					
					var partNameNode = partNode.SelectSingleNode("part-name");
					
					if (partNameNode != null)
						part.Name = partNameNode.InnerText;

					var measuresXpath = string.Format("//part[@id='{0}']/measure", part.Id);

					var measureNodes = partNode.SelectNodes(measuresXpath);

					if (measureNodes != null)
					{
						foreach (XmlNode measureNode in measureNodes)
						{
							var measure = new Measure();

							if (measureNode.Attributes != null)
							{
								var measureWidthAttribute = measureNode.Attributes["width"];
								if (measureWidthAttribute != null)
									measure.Width = Convert.ToInt32(measureWidthAttribute.InnerText);
							}

							var attributesNode = measureNode.SelectSingleNode("attributes");

							if (attributesNode != null)
							{
								measure.Attributes = new MeasureAttributes();

								var divisionsNode = attributesNode.SelectSingleNode("divisions");
								if (divisionsNode != null)
									measure.Attributes.Divisions = Convert.ToInt32(divisionsNode.InnerText);

								var keyNode = attributesNode.SelectSingleNode("key");

								if (keyNode != null)
								{
									measure.Attributes.Key = new Key();

									var fifthsNode = keyNode.SelectSingleNode("fifths");
									if (fifthsNode != null)
										measure.Attributes.Key.Fifths = Convert.ToInt32(fifthsNode.InnerText);

									var modeNode = keyNode.SelectSingleNode("mode");
									if (modeNode != null)
										measure.Attributes.Key.Mode = modeNode.InnerText;
								}
								
								measure.Attributes.Time = GetTime(attributesNode);

								measure.Attributes.Clef = GetClef(attributesNode);
							}

							var childNodes = measureNode.ChildNodes;

							var postion = 0;

							foreach (XmlNode node in childNodes)
							{
								if (node.Name == "note")
								{
									var newNote = GetNote(node);
									
									measure.Notes.Add(newNote);

									if (newNote.Staff == 1 || newNote.IsRest)
									{
										
										if (measure.UpperStaffNotesInOrderOfTime.ContainsKey(postion))
										{
											var notesAtPosition = measure.UpperStaffNotesInOrderOfTime[postion];

											var indexToInsert = 0;

											for (var i = 0; i < notesAtPosition.Count; i++)
											{
												var note = notesAtPosition[i];
												if (note.Pitch.Octave < newNote.Pitch.Octave)
												{
													indexToInsert = i;
												}
											}

											notesAtPosition.Insert(indexToInsert, newNote);
										}
										else
										{
											measure.UpperStaffNotesInOrderOfTime.Add(postion, 
												new List<Note>
												{
													newNote
												});
										}
									}

									postion += newNote.Duration;
								}

								if (node.Name == "backup")
								{
									postion -= GetDuration(node);
								}
								if (node.Name == "forward")
								{
									postion += GetDuration(node);
								}
							}

							part.Measures.Add(measure);
						}
					}
				}
			}

			return score;
		}

		private static int GetDuration(XmlNode node)
		{
			var durationNode = node.SelectSingleNode("duration");
			if (durationNode != null)
				return Convert.ToInt32(durationNode.InnerText);

			return 0;
		}

		private static Note GetNote(XmlNode noteNode)
		{
			var note = new Note();

			var typeNode = noteNode.SelectSingleNode("type");
			if (typeNode != null)
				note.Type = typeNode.InnerText;

			var voiceNode = noteNode.SelectSingleNode("voice");
			if (voiceNode != null)
				note.Voice = Convert.ToInt32(voiceNode.InnerText);

			var durationNode = noteNode.SelectSingleNode("duration");
			if (durationNode != null)
				note.Duration = Convert.ToInt32(durationNode.InnerText);

			note.Lyric = GetLyric(noteNode);

			note.Pitch = GetPitch(noteNode);

			var staffNode = noteNode.SelectSingleNode("staff");
			if (staffNode != null)
				note.Staff = Convert.ToInt32(staffNode.InnerText);

			var chordNode = noteNode.SelectSingleNode("chord");
			if (chordNode != null)
				note.IsChordTone = true;
			
			var restNode = noteNode.SelectSingleNode("rest");
			if (restNode != null)
				note.IsRest = true;

			return note;
		}

		private static Pitch GetPitch(XmlNode noteNode)
		{
			var pitch = new Pitch();
			var pitchNode = noteNode.SelectSingleNode("pitch");
			if (pitchNode != null)
			{
				var stepNode = pitchNode.SelectSingleNode("step");
				if (stepNode != null)
					pitch.Step = stepNode.InnerText[0];

				var alterNode = pitchNode.SelectSingleNode("alter");
				if (alterNode != null)
					pitch.Alter = Convert.ToInt32(alterNode.InnerText);

				var octaveNode = pitchNode.SelectSingleNode("octave");
				if (octaveNode != null)
					pitch.Octave = Convert.ToInt32(octaveNode.InnerText);
			}
			return pitch;
		}

		private static Lyric GetLyric(XmlNode noteNode)
		{
			var lyric = new Lyric();

			var lyricNode = noteNode.SelectSingleNode("lyric");
			if (lyricNode != null)
			{
				var syllabicNode = lyricNode.SelectSingleNode("syllabic");

				var syllabicText = string.Empty;

				if (syllabicNode != null)
					syllabicText = syllabicNode.InnerText;

				switch (syllabicText)
				{
					case "":
						lyric.Syllabic = Syllabic.None;
						break;
					case "begin":
						lyric.Syllabic = Syllabic.Begin;
						break;
					case "single":
						lyric.Syllabic = Syllabic.Single;
						break;
					case "end":
						lyric.Syllabic = Syllabic.End;
						break;
					case "middle":
						lyric.Syllabic = Syllabic.Middle;
						break;
				}

				var textNode = lyricNode.SelectSingleNode("text");
				if (textNode != null)
					lyric.Text = textNode.InnerText;
			}
			return lyric;
		}

		private static Clef GetClef(XmlNode attributesNode)
		{
			var clef = new Clef();

			var clefNode = attributesNode.SelectSingleNode("clef");

			if (clefNode != null)
			{
				var lineNode = clefNode.SelectSingleNode("line");
				if (lineNode != null)
					clef.Line = Convert.ToInt32(lineNode.InnerText);

				var signNode = clefNode.SelectSingleNode("sign");
				if (signNode != null)
					clef.Sign = signNode.InnerText;
			}
			return clef;
		}

		private static Time GetTime(XmlNode attributesNode)
		{
			var time = new Time();

			var timeNode = attributesNode.SelectSingleNode("time");
			if (timeNode != null)
			{
				var beatsNode = timeNode.SelectSingleNode("beats");

				if (beatsNode != null)
					time.Beats = Convert.ToInt32(beatsNode.InnerText);

				var beatTypeNode = timeNode.SelectSingleNode("beat-type");

				if (beatTypeNode != null)
					time.Mode = beatTypeNode.InnerText;

				var symbol = TimeSymbol.Normal;

				if (timeNode.Attributes != null)
				{
					var symbolAttribute = timeNode.Attributes["symbol"];

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

				time.Symbol = symbol;
			}
			return time;
		}

		private static Identification GetIdentification(XmlNode document)
		{
			var identificationNode = document.SelectSingleNode("score-partwise/identification");

			if (identificationNode != null)
			{
				var identification = new Identification();

				var composerNode = identificationNode.SelectSingleNode("creator[@type='composer']");
				identification.Composer = composerNode != null ? composerNode.InnerText : string.Empty;

				var rightsNode = identificationNode.SelectSingleNode("rights");
				identification.Rights = rightsNode != null ? rightsNode.InnerText : string.Empty;

				identification.Encoding = GetEncoding(identificationNode);

				return identification;
			}

			return null;
		}

		private static Encoding GetEncoding(XmlNode identificationNode)
		{
			var encodingNode = identificationNode.SelectSingleNode("encoding");

			var encoding = new Encoding();

			if (encodingNode != null)
			{
				encoding.Software = GetInnerTextOfChildTag(encodingNode, "software");

				encoding.Description = GetInnerTextOfChildTag(encodingNode, "encoding-description");

				var encodingDate = encodingNode.SelectSingleNode("encoding-date");
				if (encodingDate != null)
					encoding.EncodingDate = Convert.ToDateTime(encodingDate.InnerText);
			}

			return encoding;
		}

		private static string GetInnerTextOfChildTag(XmlNode encodingNode, string tagName)
		{
			var softwareStringBuilder = new StringBuilder();
			
			var encodingSoftwareNodes = encodingNode.SelectNodes(tagName);

			if (encodingSoftwareNodes != null)
			{
				foreach (XmlNode node in encodingSoftwareNodes)
				{
					softwareStringBuilder.AppendLine(node.InnerText);
				}
			}

			return softwareStringBuilder.ToString();
		}

		private static XmlDocument GetXmlDocument(string filename)
		{
			var document = new XmlDocument();

			var xml = GetFileContents(filename);
			document.XmlResolver = null;
			document.LoadXml(xml);

			return document;
		}

		private static string GetFileContents(string filename)
		{
			using (var fileStream = new FileStream(filename, FileMode.Open))
			using (var streamReader = new StreamReader(fileStream))
			{
				return streamReader.ReadToEnd();
			}
		}
	}
}
