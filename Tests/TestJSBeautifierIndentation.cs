using Jsbeautifier;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;

namespace Tests
{
    [TestClass]
    public class TestJSBeautifierIndentation
    {
        private Beautifier beautifier;

        public TestJSBeautifierIndentation()
        {
            this.beautifier = new Beautifier();
            BeautifierOptions bo = this.beautifier.Opts;
            bo.IndentWithTabs = true;
        }

        [TestMethod]
        public void TestTabs()
        {
            Assert.AreEqual<string>(this.beautifier.Beautify("{tabs()}"), "{\n\ttabs()\n}");
        }

        [TestMethod]
        public void TestFunctionIndent()
        {
            BeautifierOptions bo = this.beautifier.Opts;
            bo.IndentWithTabs = true;
            bo.KeepArrayIndentation = true;
            Assert.AreEqual<string>(this.beautifier.Beautify("var foo = function(){ bar() }();"), "var foo = function() {\n\tbar()\n}();");
        }
    }
}
