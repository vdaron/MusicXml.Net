using NUnit.Framework;

namespace MusicXml.Unit.Tests
{
	[TestFixture]
    public class XScoreTests
    {
		[Test]
		public void Populates_staff()
		{
			const int knownStaffValue = 1;
			const int knownPartWithStaffTags = 1;
			const int knownMeasureWithStaffTags = 0;
			const int firstNoteIndex = 0;

			var score = new XScore("TestData/MusicXmlWithStaffValues.xml");
			
			var firstPart = score.Parts[knownPartWithStaffTags];
			var fifthMeasure = firstPart.Measures[knownMeasureWithStaffTags];
			var firstNote = fifthMeasure.Notes[firstNoteIndex];

			Assert.That(firstNote.Staff, Is.EqualTo(knownStaffValue));
		}
    }
}
