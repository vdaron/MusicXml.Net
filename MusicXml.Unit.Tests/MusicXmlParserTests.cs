﻿using System;
using MusicXml.Domain;
using NUnit.Framework;

namespace MusicXml.Unit.Tests
{
	[TestFixture]
    public class MusicXmlParserTests
    {
		private Score _scoreWithStaffValues;

		[TestFixtureSetUp]
		public void SetUp()
		{
			_scoreWithStaffValues = MusicXmlParser.GetScore("TestData/MusicXmlWithStaffValues.xml");
		}

		[Test]
		public void Populates_movement_title()
		{
			const string knownMovementTitle = "Im wunderschönen Monat Mai";
			Assert.That(_scoreWithStaffValues.MovementTitle, Is.EqualTo(knownMovementTitle));
		}

		[Test]
		public void Identification_is_not_null()
		{
			Assert.That(_scoreWithStaffValues.Identification, Is.Not.Null);
		}

		[Test]
		public void Populates_identification_composer()
		{
			const string knownComposer = "Robert Schumann";

			Assert.That(_scoreWithStaffValues.Identification.Composer, Is.EqualTo(knownComposer));
		}

		[Test]
		public void Populates_identification_rights()
		{
			const string knownRights = "Copyright © 2002 Recordare LLC";
			Assert.That(_scoreWithStaffValues.Identification.Rights, Is.EqualTo(knownRights));
		}

		[Test]
		public void Identification_encoding_is_not_null()
		{
			Assert.That(_scoreWithStaffValues.Identification.Encoding, Is.Not.Null);
		}

		[Test]
		public void Populates_encoding_description()
		{
			const string knownEncodingDescription = "This is a sample description\r\nacross multiple lines\r\n";

			Assert.That(_scoreWithStaffValues.Identification.Encoding.Description, Is.EqualTo(knownEncodingDescription));
		}

		[Test]
		public void Populates_encoding_date()
		{
			var knownEncodingDate = new DateTime(2011, 08, 08);

			Assert.That(_scoreWithStaffValues.Identification.Encoding.EncodingDate, Is.EqualTo(knownEncodingDate));
		}

		[Test]
		public void Populates_encoding_software()
		{
			const string knownEncodingSoftware = "Finale 2011 for Windows\r\nDolet 6.0 for Finale\r\n";

			Assert.That(_scoreWithStaffValues.Identification.Encoding.Software, Is.EqualTo(knownEncodingSoftware));
		}

		[Test]
		public void Parts_is_not_null()
		{
			Assert.That(_scoreWithStaffValues.Parts, Is.Not.Null);
		}

		[Test]
		public void Parts_contains_correct_number_of_parts()
		{
			const int knownNumberOfParts = 2;
			Assert.That(_scoreWithStaffValues.Parts.Count, Is.EqualTo(knownNumberOfParts));
		}

		[Test]
		public void Populates_part_id()
		{
			const string knownPartId = "P1";
			var part = _scoreWithStaffValues.Parts[0];

			Assert.That(part.Id, Is.EqualTo(knownPartId));
		}

		[Test]
		public void Populates_part_name()
		{
			const string knownPartName = "Voice";
			var part = _scoreWithStaffValues.Parts[0];

			Assert.That(part.Name, Is.EqualTo(knownPartName));
		}

		[Test]
		public void Part_measures_is_not_null()
		{
			var part = _scoreWithStaffValues.Parts[0];

			Assert.That(part.Measures, Is.Not.Null);
		}

		[Test]
		public void Part_contains_correct_number_of_measures()
		{
			var part = _scoreWithStaffValues.Parts[0];

			const int knownMeasuresCount = 27;

			Assert.That(part.Measures.Count, Is.EqualTo(knownMeasuresCount));
		}
		
		[Test]
		public void Populates_measure_width()
		{
			var part = _scoreWithStaffValues.Parts[0];
			var measure = part.Measures[0];

			const int knownWidth = 198;

			Assert.That(measure.Width, Is.EqualTo(knownWidth));
		}
		
		[Test]
		public void Measure_attributes_is_not_null()
		{
			var part = _scoreWithStaffValues.Parts[0];

			var measure = part.Measures[0];

			Assert.That(measure.Attributes, Is.Not.Null);
		}

		[Test]
		public void Populates_measure_divisions()
		{
			var part = _scoreWithStaffValues.Parts[0];

			var measure = part.Measures[0];

			const int knownMeasureDivisions = 8;

			Assert.That(measure.Attributes.Divisions, Is.EqualTo(knownMeasureDivisions));
		}

		[Test]
		public void Measure_clef_is_not_null()
		{
			var part = _scoreWithStaffValues.Parts[0];

			var measure = part.Measures[0];

			Assert.That(measure.Attributes.Clef, Is.Not.Null);
		}

		[Test]
		public void Populates_measure_clef_line()
		{
			var part = _scoreWithStaffValues.Parts[0];

			var measure = part.Measures[0];

			var clef = measure.Attributes.Clef;

			const int knownClefLine = 2;

			Assert.That(clef.Line, Is.EqualTo(knownClefLine));
		}

		[Test]
		public void Populates_measure_clef_sign()
		{
			var part = _scoreWithStaffValues.Parts[0];

			var measure = part.Measures[0];

			var clef = measure.Attributes.Clef;

			const string knownClefSign = "G";

			Assert.That(clef.Sign, Is.EqualTo(knownClefSign));
		}

		[Test]
		public void Key_is_not_null()
		{
			var part = _scoreWithStaffValues.Parts[0];

			var measure = part.Measures[0];

			var key = measure.Attributes.Key;

			Assert.That(key, Is.Not.Null);
		}

		[Test]
		public void Populates_key_fifths()
		{
			var part = _scoreWithStaffValues.Parts[0];

			var measure = part.Measures[0];

			var key = measure.Attributes.Key;

			const int knownFifths = 3;

			Assert.That(key.Fifths, Is.EqualTo(knownFifths));
		}
		
		[Test]
		public void Populates_key_mode()
		{
			var part = _scoreWithStaffValues.Parts[0];

			var measure = part.Measures[0];

			var key = measure.Attributes.Key;

			const string knownMode = "major";

			Assert.That(key.Mode, Is.EqualTo(knownMode));
		}

		[Test]
		public void Measure_time_is_not_null()
		{
			var part = _scoreWithStaffValues.Parts[0];

			var measure = part.Measures[0];

			var time = measure.Attributes.Time;

			Assert.That(time, Is.Not.Null);
		}

		[Test]
		public void Populates_time_beats()
		{
			var part = _scoreWithStaffValues.Parts[0];

			var measure = part.Measures[0];

			var time = measure.Attributes.Time;

			const int knownBeats = 2;

			Assert.That(time.Beats, Is.EqualTo(knownBeats));
		}

		[Test]
		public void Populates_time_mode()
		{
			var part = _scoreWithStaffValues.Parts[0];

			var measure = part.Measures[0];

			var time = measure.Attributes.Time;

			const string knownTimeMode = "4";

			Assert.That(time.Mode, Is.EqualTo(knownTimeMode));
		}

		[Test]
		public void Populates_time_symbol()
		{
			var part = _scoreWithStaffValues.Parts[0];

			var measure = part.Measures[0];
			var time = measure.Attributes.Time;

			Assert.That(time.Symbol, Is.EqualTo(TimeSymbol.Normal));
		}
		
		[Test]
		public void Measure_without_width_attribute_returns_negative_one()
		{
			var scoreWithoutMeasureWidthAttribute = MusicXmlParser.GetScore(@"TestData\MusicXmlWithoutMeasureWidthAttribute.xml");

			var part = scoreWithoutMeasureWidthAttribute.Parts[0];

			var measure = part.Measures[0];

			Assert.That(measure.Width, Is.EqualTo(-1));
		}
		
		[Test]
		public void Note_is_not_null()
		{
			var part = _scoreWithStaffValues.Parts[0];

			var measure = part.Measures[0];
			var note = measure.MeasureElements[0];

			Assert.That(note, Is.Not.Null);
		}

		[Test]
		public void Populates_note_duration()
		{
			var part = _scoreWithStaffValues.Parts[0];

			var measure = part.Measures[0];
			var note = measure.MeasureElements[0].Element as Note;

			const int knownDuration = 2;

			Assert.That(note.Duration, Is.EqualTo(knownDuration));
		}

		[Test]
		public void Populates_note_type()
		{
			var part = _scoreWithStaffValues.Parts[0];

			var measure = part.Measures[0];
			var note = measure.MeasureElements[0].Element as Note;

			const string knownNoteType = "16th";

			Assert.That(note.Type, Is.EqualTo(knownNoteType));
		}

		[Test]
		public void Populates_note_voice()
		{
			var part = _scoreWithStaffValues.Parts[0];

			var measure = part.Measures[0];

			var note = measure.MeasureElements[0].Element as Note;

			const int knownNoteVoice = 1;

			Assert.That(note.Voice, Is.EqualTo(knownNoteVoice));
		}

		[Test]
		public void Populates_note_staff()
		{
			const int knownStaffValue = 1;
			const int knownPartWithStaffTags = 1;
			const int knownMeasureWithStaffTags = 0;
			const int firstNoteIndex = 0;

			var part = _scoreWithStaffValues.Parts[knownPartWithStaffTags];
			var measure = part.Measures[knownMeasureWithStaffTags];
			var note = measure.MeasureElements[firstNoteIndex].Element as Note;

			Assert.That(note.Staff, Is.EqualTo(knownStaffValue));
		}

		[Test]
		public void Is_chord_tone_true_for_note_with_chord_tag()
		{
			const int knownChordToneIndex = 1;
			const int knownPartWithChord = 1;

			var score = MusicXmlParser.GetScore("TestData/MusicXmlWithChords.xml");

			var part = score.Parts[knownPartWithChord];
			var measure = part.Measures[0];
			var note = measure.MeasureElements[knownChordToneIndex].Element as Note;

			Assert.That(note.IsChordTone, Is.True);
		}

		[Test]
		public void Is_chord_tone_false_for_note_without_chord_tag()
		{
			var score = MusicXmlParser.GetScore("TestData/MusicXmlWithChords.xml");

			var part = score.Parts[0];
			var measure = part.Measures[0];
			var note = measure.MeasureElements[0].Element as Note;

			Assert.That(note.IsChordTone, Is.False);
		}

		[Test]
		public void Note_pitch_is_not_null()
		{
			const int measureContainingNotesWithPitches = 4;
			const int noteWithPitchTag = 3;

			var part = _scoreWithStaffValues.Parts[0];
			var measure = part.Measures[measureContainingNotesWithPitches];
			var note = measure.MeasureElements[noteWithPitchTag].Element as Note;

			Assert.That(note.Pitch, Is.Not.Null);
		}

		[Test]
		public void Populates_pitch_alter()
		{
			const int measureContainingNotesWithPitches = 4;
			const int noteWithPitchTag = 3;

			var part = _scoreWithStaffValues.Parts[0];
			var measure = part.Measures[measureContainingNotesWithPitches];
			var note = measure.MeasureElements[noteWithPitchTag].Element as Note;
			var pitch = note.Pitch;

			const int knownAlter = 1;

			Assert.That(pitch.Alter, Is.EqualTo(knownAlter));
		}

		[Test]
		public void Populates_pitch_octave()
		{
			const int measureContainingNotesWithPitches = 4;
			const int noteWithPitchTag = 3;

			var part = _scoreWithStaffValues.Parts[0];
			var measure = part.Measures[measureContainingNotesWithPitches];
			var note = measure.MeasureElements[noteWithPitchTag].Element as Note;
			var pitch = note.Pitch;

			const int knownOctave = 5;

			Assert.That(pitch.Octave, Is.EqualTo(knownOctave));
		}

		[Test]
		public void Populates_pitch_step()
		{
			const int measureContainingNotesWithPitches = 4;
			const int noteWithPitchTag = 3;

			var part = _scoreWithStaffValues.Parts[0];
			var measure = part.Measures[measureContainingNotesWithPitches];
			var note = measure.MeasureElements[noteWithPitchTag].Element as Note;
			var pitch = note.Pitch;

			const char knownStep = 'C';

			Assert.That(pitch.Step, Is.EqualTo(knownStep));
		}

		[Test]
		public void Lyric_is_not_null()
		{
			const int knownMeasureWithLyric = 4;
			const int knownNoteWithLyric = 3;

			var part = _scoreWithStaffValues.Parts[0];
			var measure = part.Measures[knownMeasureWithLyric];
			var note = measure.MeasureElements[knownNoteWithLyric].Element as Note;
			var lyric = note.Lyric;

			Assert.That(lyric, Is.Not.Null);
		}

		[Test]
		public void Populates_lyric_syllabic()
		{
			const int knownMeasureWithLyric = 4;
			const int knownNoteWithLyric = 3;

			var part = _scoreWithStaffValues.Parts[0];
			var measure = part.Measures[knownMeasureWithLyric];
			var note = measure.MeasureElements[knownNoteWithLyric].Element as Note;
			var lyric = note.Lyric;

			const Syllabic knownSyllabic = Syllabic.Single;

			Assert.That(lyric.Syllabic, Is.EqualTo(knownSyllabic));
		}

		[Test]
		public void Populates_lyric_text()
		{
			const int knownMeasureWithLyric = 4;
			const int knownNoteWithLyric = 3;

			var part = _scoreWithStaffValues.Parts[0];
			var measure = part.Measures[knownMeasureWithLyric];
			var note = measure.MeasureElements[knownNoteWithLyric].Element as Note;
			var lyric = note.Lyric;

			const string knownLyricText = "Im";

			Assert.That(lyric.Text, Is.EqualTo(knownLyricText));
		}

		[Test]
		public void Populates_is_rest()
		{
			const int knownMeasureContainingRest = 0;
			var part = _scoreWithStaffValues.Parts[0];
			var measure = part.Measures[knownMeasureContainingRest];
			var note = measure.MeasureElements[0].Element as Note;

			Assert.That(note.IsRest, Is.True);
		}
		
		[Test]
		public void Pitch_is_null_note_with_rest()
		{
			const int knownMeasureContainingRest = 0;
			var part = _scoreWithStaffValues.Parts[0];
			var measure = part.Measures[knownMeasureContainingRest];
			var note = measure.MeasureElements[0].Element as Note;

			Assert.That(note.Pitch, Is.Null);
		}

		[Test]
		public void Backup_element_is_not_null()
		{
			const int knownBackupElement = 1;
			const int knownPartWithBackup = 1;
			var part = _scoreWithStaffValues.Parts[knownPartWithBackup];
			var measure = part.Measures[0];
			var element = measure.MeasureElements[knownBackupElement].Element;

			Assert.That(element, Is.Not.Null);
		}

		[Test]
		public void Populates_backup_duration()
		{
			const int knownBackupElement = 1;
			const int knownPartWithBackup = 1;
			var part = _scoreWithStaffValues.Parts[knownPartWithBackup];
			var measure = part.Measures[0];
			var backup = measure.MeasureElements[knownBackupElement].Element as Backup;

			const int knownBackupDuration = 2;

			Assert.That(backup.Duration, Is.EqualTo(knownBackupDuration));
		}
		
		[Test]
		public void Forward_is_not_null()
		{
			const int partWithForward = 1;
			const int measureWithForward = 1;
			const int forwardMeasureElement = 6;
			var part = _scoreWithStaffValues.Parts[partWithForward];
			var measure = part.Measures[measureWithForward];
			
			var forward = measure.MeasureElements[forwardMeasureElement].Element;

			Assert.That(forward, Is.Not.Null);
		}

		[Test]
		public void Populates_forward_duration()
		{
			const int partWithForward = 1;
			const int measureWithForward = 1;
			const int forwardMeasureElement = 6;

			var part = _scoreWithStaffValues.Parts[partWithForward];
			var measure = part.Measures[measureWithForward];
			var forward = measure.MeasureElements[forwardMeasureElement].Element as Forward;

			Assert.That(forward.Duration, Is.EqualTo(8));
		}
	}
}
