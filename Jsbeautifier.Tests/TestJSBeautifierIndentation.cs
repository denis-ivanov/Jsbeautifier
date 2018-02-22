using Jsbeautifier;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class TestJSBeautifierIndentation
    {
        private Beautifier beautifier;

        public TestJSBeautifierIndentation()
        {
            beautifier = new Beautifier();
            BeautifierOptions bo = beautifier.Opts;
            bo.IndentWithTabs = true;
        }

        [Test]
        public void TestTabs()
        {
            Assert.AreEqual(beautifier.Beautify("{tabs()}"), "{\n\ttabs()\n}");
        }

        [Test]
        public void TestFunctionIndent()
        {
            BeautifierOptions bo = beautifier.Opts;
            bo.IndentWithTabs = true;
            bo.KeepArrayIndentation = true;
            Assert.AreEqual(beautifier.Beautify("var foo = function(){ bar() }();"), "var foo = function() {\n\tbar()\n}();");
        }
    }
}
