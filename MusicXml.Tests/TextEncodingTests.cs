using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using MusicXml.Domain;
using NUnit.Framework;

namespace MusicXml.Unit.Tests {

    [TestFixture]
    public class TextEncodingTests 
    {
        [SetUp]
        public void SetUp() 
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        }

        public void TestLyric(Score score, string[] lyricFact) {
            var part = score.Parts[0];
            var lyric = part.Measures.SelectMany(measure => measure.MeasureElements)
                .Where(me => me.Type == MeasureElementType.Note)
                .Select(me => ((Note)(me.Element)).Lyric.Text)
                .Where(str => str != null)
                .Take(lyricFact.Length).ToArray();
            Assert.That(lyric, Is.EquivalentTo(lyricFact));
        }

        [Test]
        public void Text_encoding_zh_cn() {
            var lyricFact = "明山涌水郁郁葱葱钟灵毓秀海天东".Select(x=>x.ToString()).ToArray();
            //UTF-8
            TestLyric(MusicXmlParser.GetScore("TestData/TextEncodingTest/zh-CN_UTF8.xml"), lyricFact);
            TestLyric(
                MusicXmlParser.GetScore("TestData/TextEncodingTest/zh-CN_UTF8.xml", System.Text.Encoding.UTF8), 
                lyricFact);
            //GBK
            TestLyric(
                MusicXmlParser.GetScore("TestData/TextEncodingTest/zh-CN_GBK.xml", System.Text.Encoding.GetEncoding("gbk")),
                lyricFact);
        }

        [Test]
        public void Text_encoding_ja_jp() {
            var lyricFact = "さかえにみちたるかみのみやこわ".Select(x => x.ToString()).ToArray();
            //UTF-8
            TestLyric(MusicXmlParser.GetScore("TestData/TextEncodingTest/ja-JP_UTF8.xml"), lyricFact);
            TestLyric(
                MusicXmlParser.GetScore("TestData/TextEncodingTest/ja-JP_UTF8.xml", System.Text.Encoding.UTF8),
                lyricFact);
            //Shift-JIS
            TestLyric(
                MusicXmlParser.GetScore("TestData/TextEncodingTest/ja-JP_ShiftJIS.xml", System.Text.Encoding.GetEncoding("shift_jis")),
                lyricFact);
        }
    }
}
