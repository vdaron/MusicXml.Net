using NUnit.Framework;

namespace MusicXml.Unit.Tests
{
	[TestFixture]
    public class XScoreTests
    {
		[Test]
		public void Populates_movement_title()
		{
			var score = new XScore("TestData/MusicXmlWithStaffValues.xml");
			
			const string knownMovementTitle = "Im wunderschönen Monat Mai";
			Assert.That(score.MovementTitle, Is.EqualTo(knownMovementTitle));
		}

		[Test]
		public void Populates_note_staff()
		{
			const int knownStaffValue = 1;
			const int knownPartWithStaffTags = 1;
			const int knownMeasureWithStaffTags = 0;
			const int firstNoteIndex = 0;

			var score = new XScore("TestData/MusicXmlWithStaffValues.xml");
			
			var part = score.Parts[knownPartWithStaffTags];
			var measure = part.Measures[knownMeasureWithStaffTags];
			var note = measure.Notes[firstNoteIndex];

			Assert.That(note.Staff, Is.EqualTo(knownStaffValue));
		}

		[Test, Ignore]
		public void Is_chord_tone_true_for_note_with_chord_tag()
		{
			const int knownChordToneIndex = 1;

			var score = new XScore("TestData/MusicXmlWithChords.xml");

			var part = score.Parts[0];
			var measure = part.Measures[0];
			var note = measure.Notes[knownChordToneIndex];

			Assert.That(note.IsChordTone, Is.True);
		}

		[Test]
		public void Is_chord_tone_false_for_note_without_chord_tag()
		{
			var score = new XScore("TestData/MusicXmlWithChords.xml");

			var part = score.Parts[0];
			var measure = part.Measures[0];
			var note = measure.Notes[0];

			Assert.That(note.IsChordTone, Is.False);
		}
    }
}
