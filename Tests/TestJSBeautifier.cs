using Jsbeautifier;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class TestJSBeautifier
    {
        Beautifier beautifier;

        public TestJSBeautifier()
        {
            this.beautifier = new Beautifier();

            this.beautifier.Opts.IndentSize = 4;
            this.beautifier.Opts.IndentChar = ' ';
            this.beautifier.Opts.PreserveNewlines = true;
            this.beautifier.Opts.JslintHappy = false;
            this.beautifier.Opts.KeepArrayIndentation = false;
            this.beautifier.Opts.BraceStyle = BraceStyle.Collapse;
            this.beautifier.Flags.IndentationLevel = 0;
            this.beautifier.Opts.BreakChainedMethods = false;
        }

        [TestMethod]
        public void TestUnescape()
        {
            Assert.AreEqual<string>(this.beautifier.Beautify("\"\\\\s\""), "\"\\\\s\"");
            Assert.AreEqual<string>(this.beautifier.Beautify("\'\\\\s\'"), "\'\\\\s\'");
            Assert.AreEqual<string>(this.beautifier.Beautify("'\\\\\\s'"), "'\\\\\\s'");
            Assert.AreEqual<string>(this.beautifier.Beautify("'\\s'"), "'\\s'");
            Assert.AreEqual<string>(this.beautifier.Beautify("\"•\""), "\"•\"");
            Assert.AreEqual<string>(this.beautifier.Beautify("\"-\""), "\"-\"");
            Assert.AreEqual<string>(this.beautifier.Beautify("\"\\x41\\x42\\x43\\x01\""), "\"\\x41\\x42\\x43\\x01\"");
            Assert.AreEqual<string>(this.beautifier.Beautify("\"\\u2022\""), "\"\\u2022\"");
            Assert.AreEqual<string>(this.beautifier.Beautify(@"a = /\s+/"), @"a = /\s+/");
            Assert.AreEqual<string>(this.beautifier.Beautify("\"\\u2022\";a = /\\s+/;\"\\x41\\x42\\x43\\x01\".match(/\\x41/);"), "\"\\u2022\";\na = /\\s+/;\n\"\\x41\\x42\\x43\\x01\".match(/\\x41/);");
            Assert.AreEqual<string>(this.beautifier.Beautify("\"\\x22\\x27\",\'\\x22\\x27\',\"\\x5c\",\'\\x5c\',\"\\xff and \\xzz\",\"unicode \\u0000 \\u0022 \\u0027 \\u005c \\uffff \\uzzzz\""), "\"\\x22\\x27\", \'\\x22\\x27\', \"\\x5c\", \'\\x5c\', \"\\xff and \\xzz\", \"unicode \\u0000 \\u0022 \\u0027 \\u005c \\uffff \\uzzzz\"");

            //this.beautifier.Opts.UnescapeStrings = true;

            Assert.AreEqual<string>(this.beautifier.Beautify("a = /\\s+/"), "a = /\\s+/");
            // Assert.AreEqual<string>(this.beautifier.Beautify("\"\\u2022\";a = /\\s+/;\"\\x41\\x42\\x43\\x01\".match(/\\x41/);"), "\"\\u2022\";\na = /\\s+/;\\n\"ABC\\x01\".match(/\\x41/);");
        }

        [TestMethod]
        public void TestBeautifier()
        {
            Assert.AreEqual<string>(this.beautifier.Beautify(""), "");
            Assert.AreEqual<string>(this.beautifier.Beautify("return .5"), "return .5");
            Assert.AreEqual<string>(this.beautifier.Beautify("    return .5"), "    return .5");
            Assert.AreEqual<string>(this.beautifier.Beautify("a        =          1"), "a = 1");
            Assert.AreEqual<string>(this.beautifier.Beautify("a=1"), "a = 1");
            Assert.AreEqual<string>(this.beautifier.Beautify("a();\n\nb();"), "a();\n\nb();");
            Assert.AreEqual<string>(this.beautifier.Beautify("var a = 1 var b = 2"), "var a = 1\nvar b = 2");
            Assert.AreEqual<string>(this.beautifier.Beautify("var a=1, b=c[d], e=6;"), "var a = 1,\n    b = c[d],\n    e = 6;");
            Assert.AreEqual<string>(this.beautifier.Beautify("a = \" 12345 \""), "a = \" 12345 \"");
            Assert.AreEqual<string>(this.beautifier.Beautify("a = ' 12345 '"), "a = ' 12345 '");
            Assert.AreEqual<string>(this.beautifier.Beautify("if (a == 1) b = 2;"), "if (a == 1) b = 2;");
            Assert.AreEqual<string>(this.beautifier.Beautify("if(1){2}else{3}"), "if (1) {\n    2\n} else {\n    3\n}");
            Assert.AreEqual<string>(this.beautifier.Beautify("if (foo) bar();\nelse\ncar();"), "if (foo) bar();\nelse car();");
            Assert.AreEqual<string>(this.beautifier.Beautify("if(1||2);"), "if (1 || 2);");
            Assert.AreEqual<string>(this.beautifier.Beautify("(a==1)||(b==2)"), "(a == 1) || (b == 2)");
            Assert.AreEqual<string>(this.beautifier.Beautify("if(1||2);"), "if (1 || 2);");
            Assert.AreEqual<string>(this.beautifier.Beautify("(a==1)||(b==2)"), "(a == 1) || (b == 2)");
            Assert.AreEqual<string>(this.beautifier.Beautify("var a = 1 if (2) 3;"), "var a = 1\nif (2) 3;");
            Assert.AreEqual<string>(this.beautifier.Beautify("a = a + 1"), "a = a + 1");
            Assert.AreEqual<string>(this.beautifier.Beautify("a = a == 1"), "a = a == 1");
            Assert.AreEqual<string>(this.beautifier.Beautify("/12345[^678]*9+/.match(a)"), "/12345[^678]*9+/.match(a)");
            Assert.AreEqual<string>(this.beautifier.Beautify("a /= 5"), "a /= 5");
            Assert.AreEqual<string>(this.beautifier.Beautify("a = 0.5 * 3"), "a = 0.5 * 3");
            Assert.AreEqual<string>(this.beautifier.Beautify("a *= 10.55"), "a *= 10.55");
            Assert.AreEqual<string>(this.beautifier.Beautify("a < .5"), "a < .5");
            Assert.AreEqual<string>(this.beautifier.Beautify("a <= .5"), "a <= .5");
            Assert.AreEqual<string>(this.beautifier.Beautify("a<.5"), "a < .5");
            Assert.AreEqual<string>(this.beautifier.Beautify("a<=.5"), "a <= .5");
            Assert.AreEqual<string>(this.beautifier.Beautify("a = 0xff;"), "a = 0xff;");
            Assert.AreEqual<string>(this.beautifier.Beautify("a=0xff+4"), "a = 0xff + 4");
            Assert.AreEqual<string>(this.beautifier.Beautify("a = [1, 2, 3, 4]"), "a = [1, 2, 3, 4]");
            Assert.AreEqual<string>(this.beautifier.Beautify("F*(g/=f)*g+b"), "F * (g /= f) * g + b");
            Assert.AreEqual<string>(this.beautifier.Beautify("a.b({c:d})"), "a.b({\n    c: d\n})");
            Assert.AreEqual<string>(this.beautifier.Beautify("a.b\n(\n{\nc:\nd\n}\n)"), "a.b({\n    c: d\n})");
            Assert.AreEqual<string>(this.beautifier.Beautify("a=!b"), "a = !b");
            Assert.AreEqual<string>(this.beautifier.Beautify("a?b:c"), "a ? b : c");
            Assert.AreEqual<string>(this.beautifier.Beautify("a?1:2"), "a ? 1 : 2");
            Assert.AreEqual<string>(this.beautifier.Beautify("a?(b):c"), "a ? (b) : c");
            Assert.AreEqual<string>(this.beautifier.Beautify("x={a:1,b:w==\"foo\"?x:y,c:z}"), "x = {\n    a: 1,\n    b: w == \"foo\" ? x : y,\n    c: z\n}");
            Assert.AreEqual<string>(this.beautifier.Beautify("x=a?b?c?d:e:f:g;"), "x = a ? b ? c ? d : e : f : g;");
            Assert.AreEqual<string>(this.beautifier.Beautify("x=a?b?c?d:{e1:1,e2:2}:f:g;"), "x = a ? b ? c ? d : {\n    e1: 1,\n    e2: 2\n} : f : g;");
            Assert.AreEqual<string>(this.beautifier.Beautify("function void(void) {}"), "function void(void) {}");
            Assert.AreEqual<string>(this.beautifier.Beautify("if(!a)foo();"), "if (!a) foo();");
            Assert.AreEqual<string>(this.beautifier.Beautify("a=~a"), "a = ~a");
            Assert.AreEqual<string>(this.beautifier.Beautify("a;/*comment*/b;"), "a; /*comment*/\nb;");
            Assert.AreEqual<string>(this.beautifier.Beautify("a;/* comment */b;"), "a; /* comment */\nb;");
            Assert.AreEqual<string>(this.beautifier.Beautify("a;/*\ncomment\n*/b;"), "a;\n/*\ncomment\n*/\nb;");
            Assert.AreEqual<string>(this.beautifier.Beautify("a;/**\n* javadoc\n*/b;"), "a;\n/**\n * javadoc\n */\nb;");
            Assert.AreEqual<string>(this.beautifier.Beautify("a;/**\n\nno javadoc\n*/b;"), "a;\n/**\n\nno javadoc\n*/\nb;");
            Assert.AreEqual<string>(this.beautifier.Beautify("a;/*\n* javadoc\n*/b;"), "a;\n/*\n * javadoc\n */\nb;");

            Assert.AreEqual<string>(this.beautifier.Beautify("if(a)break;"), "if (a) break;");
            Assert.AreEqual<string>(this.beautifier.Beautify("if(a){break}"), "if (a) {\n    break\n}");
            Assert.AreEqual<string>(this.beautifier.Beautify("if((a))foo();"), "if ((a)) foo();");
            Assert.AreEqual<string>(this.beautifier.Beautify("for(var i=0;;)"), "for (var i = 0;;)");
            Assert.AreEqual<string>(this.beautifier.Beautify("a++;"), "a++;");
            Assert.AreEqual<string>(this.beautifier.Beautify("for(;;i++)"), "for (;; i++)");
            Assert.AreEqual<string>(this.beautifier.Beautify("for(;;++i)"), "for (;; ++i)");
            Assert.AreEqual<string>(this.beautifier.Beautify("return(1)"), "return (1)");
            Assert.AreEqual<string>(this.beautifier.Beautify("try{a();}catch(b){c();}finally{d();}"), "try {\n    a();\n} catch (b) {\n    c();\n} finally {\n    d();\n}");
            Assert.AreEqual<string>(this.beautifier.Beautify("(xx)()"), "(xx)()");
            Assert.AreEqual<string>(this.beautifier.Beautify("a[1]()"), "a[1]()");
            Assert.AreEqual<string>(this.beautifier.Beautify("if(a){b();}else if(c) foo();"), "if (a) {\n    b();\n} else if (c) foo();");
            Assert.AreEqual<string>(this.beautifier.Beautify("switch(x) {case 0: case 1: a(); break; default: break}"), "switch (x) {\n    case 0:\n    case 1:\n        a();\n        break;\n    default:\n        break\n}");
            Assert.AreEqual<string>(this.beautifier.Beautify("switch(x){case -1:break;case !y:break;}"), "switch (x) {\n    case -1:\n        break;\n    case !y:\n        break;\n}");
            Assert.AreEqual<string>(this.beautifier.Beautify("a !== b"), "a !== b");
            Assert.AreEqual<string>(this.beautifier.Beautify("if (a) b(); else c();"), "if (a) b();\nelse c();");
            Assert.AreEqual<string>(this.beautifier.Beautify("// comment\n(function something() {})"), "// comment\n(function something() {})");
            Assert.AreEqual<string>(this.beautifier.Beautify("{\n\n    x();\n\n}"), "{\n\n    x();\n\n}");
            Assert.AreEqual<string>(this.beautifier.Beautify("if (a in b) foo();"), "if (a in b) foo();");
            Assert.AreEqual<string>(this.beautifier.Beautify("var a, b"), "var a, b");
            Assert.AreEqual<string>(this.beautifier.Beautify("{a:1, b:2}"), "{\n    a: 1,\n    b: 2\n}");
            Assert.AreEqual<string>(this.beautifier.Beautify("a={1:[-1],2:[+1]}"), "a = {\n    1: [-1],\n    2: [+1]\n}");
            Assert.AreEqual<string>(this.beautifier.Beautify("var l = {\'a\':\'1\', \'b\':\'2\'}"), "var l = {\n    'a': '1',\n    'b': '2'\n}");
            Assert.AreEqual<string>(this.beautifier.Beautify("if (template.user[n] in bk) foo();"), "if (template.user[n] in bk) foo();");
            Assert.AreEqual<string>(this.beautifier.Beautify("{{}/z/}"), "{\n    {}\n    /z/\n}");
            Assert.AreEqual<string>(this.beautifier.Beautify("return 45"), "return 45");
            Assert.AreEqual<string>(this.beautifier.Beautify("If[1]"), "If[1]");
            Assert.AreEqual<string>(this.beautifier.Beautify("Then[1]"), "Then[1]");
            Assert.AreEqual<string>(this.beautifier.Beautify("a = 1e10"), "a = 1e10");
            Assert.AreEqual<string>(this.beautifier.Beautify("a = 1.3e10"), "a = 1.3e10");
            Assert.AreEqual<string>(this.beautifier.Beautify("a = 1.3e-10"), "a = 1.3e-10");
            Assert.AreEqual<string>(this.beautifier.Beautify("a = -1.3e-10"), "a = -1.3e-10");
            Assert.AreEqual<string>(this.beautifier.Beautify("a = 1e-10"), "a = 1e-10");
            Assert.AreEqual<string>(this.beautifier.Beautify("a = e - 10"), "a = e - 10");
            Assert.AreEqual<string>(this.beautifier.Beautify("a = 11-10"), "a = 11 - 10");
            Assert.AreEqual<string>(this.beautifier.Beautify("a = 1;// comment"), "a = 1; // comment");
            Assert.AreEqual<string>(this.beautifier.Beautify("a = 1; // comment"), "a = 1; // comment");
            Assert.AreEqual<string>(this.beautifier.Beautify("a = 1;\n // comment"), "a = 1;\n// comment");
            Assert.AreEqual<string>(this.beautifier.Beautify("a = [-1, -1, -1]"), "a = [-1, -1, -1]");

            Assert.AreEqual<string>(this.beautifier.Beautify("o = [{a:b},{c:d}]"), "o = [{\n    a: b\n}, {\n    c: d\n}]");

            Assert.AreEqual<string>(this.beautifier.Beautify("if (a) {\n    do();\n}"), "if (a) {\n    do();\n}");
            Assert.AreEqual<string>(this.beautifier.Beautify("if\n(a)\nb();"), "if (a) b();");
            Assert.AreEqual<string>(this.beautifier.Beautify("if (a) {\n// comment\n}else{\n// comment\n}"), "if (a) {\n    // comment\n} else {\n    // comment\n}");
            Assert.AreEqual<string>(this.beautifier.Beautify("if (a) {\n// comment\n// comment\n}"), "if (a) {\n    // comment\n    // comment\n}");
            Assert.AreEqual<string>(this.beautifier.Beautify("if (a) b() else c();"), "if (a) b()\nelse c();");
            Assert.AreEqual<string>(this.beautifier.Beautify("if (a) b() else if c() d();"), "if (a) b()\nelse if c() d();");

            Assert.AreEqual<string>(this.beautifier.Beautify("{}"), "{}");
            Assert.AreEqual<string>(this.beautifier.Beautify("{\n\n}"), "{\n\n}");
            Assert.AreEqual<string>(this.beautifier.Beautify("do { a(); } while ( 1 );"), "do {\n    a();\n} while (1);");
            Assert.AreEqual<string>(this.beautifier.Beautify("do {} while (1);"), "do {} while (1);");
            Assert.AreEqual<string>(this.beautifier.Beautify("do {\n} while (1);"), "do {} while (1);");
            Assert.AreEqual<string>(this.beautifier.Beautify("do {\n\n} while (1);"), "do {\n\n} while (1);");
            Assert.AreEqual<string>(this.beautifier.Beautify("var a = x(a, b, c)"), "var a = x(a, b, c)");
            Assert.AreEqual<string>(this.beautifier.Beautify("delete x if (a) b();"), "delete x\nif (a) b();");
            Assert.AreEqual<string>(this.beautifier.Beautify("delete x[x] if (a) b();"), "delete x[x]\nif (a) b();");
            Assert.AreEqual<string>(this.beautifier.Beautify("for(var a=1,b=2)"), "for (var a = 1, b = 2)");
            Assert.AreEqual<string>(this.beautifier.Beautify("for(var a=1,b=2,c=3)"), "for (var a = 1, b = 2, c = 3)");
            Assert.AreEqual<string>(this.beautifier.Beautify("for(var a=1,b=2,c=3;d<3;d++)"), "for (var a = 1, b = 2, c = 3; d < 3; d++)");
            Assert.AreEqual<string>(this.beautifier.Beautify("function x(){(a||b).c()}"), "function x() {\n    (a || b).c()\n}");
            Assert.AreEqual<string>(this.beautifier.Beautify("function x(){return - 1}"), "function x() {\n    return -1\n}");
            Assert.AreEqual<string>(this.beautifier.Beautify("function x(){return ! a}"), "function x() {\n    return !a\n}");

            Assert.AreEqual<string>(this.beautifier.Beautify("settings = $.extend({},defaults,settings);"), "settings = $.extend({}, defaults, settings);");
            Assert.AreEqual<string>(this.beautifier.Beautify("{xxx;}()"), "{\n    xxx;\n}()");
            Assert.AreEqual<string>(this.beautifier.Beautify("a = 'a'\nb = 'b'"), "a = 'a'\nb = 'b'");
            Assert.AreEqual<string>(this.beautifier.Beautify("a = /reg/exp"), "a = /reg/exp");
            Assert.AreEqual<string>(this.beautifier.Beautify("a = /reg/"), "a = /reg/");
            Assert.AreEqual<string>(this.beautifier.Beautify("/abc/.test()"), "/abc/.test()");
            Assert.AreEqual<string>(this.beautifier.Beautify("/abc/i.test()"), "/abc/i.test()");
            Assert.AreEqual<string>(this.beautifier.Beautify("{/abc/i.test()}"), "{\n    /abc/i.test()\n}");
            Assert.AreEqual<string>(this.beautifier.Beautify("var x=(a)/a;"), "var x = (a) / a;");

            Assert.AreEqual<string>(this.beautifier.Beautify("x != -1"), "x != -1");

            Assert.AreEqual<string>(this.beautifier.Beautify("for (; s-->0;)"), "for (; s-- > 0;)");
            Assert.AreEqual<string>(this.beautifier.Beautify("for (; s++>0;)"), "for (; s++ > 0;)");
            Assert.AreEqual<string>(this.beautifier.Beautify("a = s++>s--;"), "a = s++ > s--;");
            Assert.AreEqual<string>(this.beautifier.Beautify("a = s++>--s;"), "a = s++ > --s;");

            Assert.AreEqual<string>(this.beautifier.Beautify("{x=#1=[]}"), "{\n    x = #1=[]\n}");
            Assert.AreEqual<string>(this.beautifier.Beautify("{a:#1={}}"), "{\n    a: #1={}\n}");
            Assert.AreEqual<string>(this.beautifier.Beautify("{a:#1#}"), "{\n    a: #1#\n}");
            Assert.AreEqual<string>(this.beautifier.Beautify("{a:1},{a:2}"), "{\n    a: 1\n}, {\n    a: 2\n}");
            Assert.AreEqual<string>(this.beautifier.Beautify("var ary=[{a:1}, {a:2}];"), "var ary = [{\n    a: 1\n}, {\n    a: 2\n}];");
            Assert.AreEqual<string>(this.beautifier.Beautify("{a:#1"), "{\n    a: #1");

            Assert.AreEqual<string>(this.beautifier.Beautify("{a:#"), "{\n    a: #");
            Assert.AreEqual<string>(this.beautifier.Beautify("}}}"), "}\n}\n}");
            Assert.AreEqual<string>(this.beautifier.Beautify("<!--\nvoid();\n// -->"), "<!--\nvoid();\n// -->");
            Assert.AreEqual<string>(this.beautifier.Beautify("a=/regexp"), "a = /regexp");
            Assert.AreEqual<string>(this.beautifier.Beautify("{a:#1=[],b:#1#,c:#999999#}"), "{\n    a: #1=[],\n    b: #1#,\n    c: #999999#\n}");
            Assert.AreEqual<string>(this.beautifier.Beautify("a = 1e+2"), "a = 1e+2");
            Assert.AreEqual<string>(this.beautifier.Beautify("a = 1e-2"), "a = 1e-2");
            Assert.AreEqual<string>(this.beautifier.Beautify("do{x()}while(a>1)"), "do {\n    x()\n} while (a > 1)");
            Assert.AreEqual<string>(this.beautifier.Beautify("x(); /reg/exp.match(something)"), "x();\n/reg/exp.match(something)");
            Assert.AreEqual<string>(this.beautifier.Beautify("something();("), "something();\n(");

            Assert.AreEqual<string>(this.beautifier.Beautify("#!she/bangs, she bangs\nf=1"), "#!she/bangs, she bangs\n\nf = 1");
            Assert.AreEqual<string>(this.beautifier.Beautify("#!she/bangs, she bangs\n\nf=1"), "#!she/bangs, she bangs\n\nf = 1");
            Assert.AreEqual<string>(this.beautifier.Beautify("#!she/bangs, she bangs\n\n/* comment */"), "#!she/bangs, she bangs\n\n/* comment */");
            Assert.AreEqual<string>(this.beautifier.Beautify("#!she/bangs, she bangs\n\n\n/* comment */"), "#!she/bangs, she bangs\n\n\n/* comment */");
            Assert.AreEqual<string>(this.beautifier.Beautify("#"), "#");
            Assert.AreEqual<string>(this.beautifier.Beautify("#!"), "#!");
            Assert.AreEqual<string>(this.beautifier.Beautify("function namespace::something()"), "function namespace::something()");
            Assert.AreEqual<string>(this.beautifier.Beautify("<!--\nsomething();\n-->"), "<!--\nsomething();\n-->");
            Assert.AreEqual<string>(this.beautifier.Beautify("<!--\nif(i<0){bla();}\n-->"), "<!--\nif (i < 0) {\n    bla();\n}\n-->");
            Assert.AreEqual<string>(this.beautifier.Beautify("{foo();--bar;}"), "{\n    foo();\n    --bar;\n}");
            Assert.AreEqual<string>(this.beautifier.Beautify("{foo();++bar;}"), "{\n    foo();\n    ++bar;\n}");

            Assert.AreEqual<string>(this.beautifier.Beautify("{--bar;}"), "{\n    --bar;\n}");
            Assert.AreEqual<string>(this.beautifier.Beautify("{++bar;}"), "{\n    ++bar;\n}");
            Assert.AreEqual<string>(this.beautifier.Beautify("a(/abc\\/\\/def/);b()"), "a(/abc\\/\\/def/);\nb()");
            Assert.AreEqual<string>(this.beautifier.Beautify("a(/a[b\\[\\]c]d/);b()"), "a(/a[b\\[\\]c]d/);\nb()");
            Assert.AreEqual<string>(this.beautifier.Beautify("a(/a[b\\["), "a(/a[b\\[");
            Assert.AreEqual<string>(this.beautifier.Beautify("a(/[a/b]/);b()"), "a(/[a/b]/);\nb()");
            Assert.AreEqual<string>(this.beautifier.Beautify("a=[[1,2],[4,5],[7,8]]"), "a = [\n    [1, 2],\n    [4, 5],\n    [7, 8]\n]");
            Assert.AreEqual<string>(this.beautifier.Beautify("a=[a[1],b[4],c[d[7]]]"), "a = [a[1], b[4], c[d[7]]]");
            Assert.AreEqual<string>(this.beautifier.Beautify("[1,2,[3,4,[5,6],7],8]"), "[1, 2, [3, 4, [5, 6], 7], 8]");
            Assert.AreEqual<string>(this.beautifier.Beautify("[[[\"1\",\"2\"],[\"3\",\"4\"]],[[\"5\",\"6\",\"7\"],[\"8\",\"9\",\"0\"]],[[\"1\",\"2\",\"3\"],[\"4\",\"5\",\"6\",\"7\"],[\"8\",\"9\",\"0\"]]]"), "[\n    [\n        [\"1\", \"2\"],\n        [\"3\", \"4\"]\n    ],\n    [\n        [\"5\", \"6\", \"7\"],\n        [\"8\", \"9\", \"0\"]\n    ],\n    [\n        [\"1\", \"2\", \"3\"],\n        [\"4\", \"5\", \"6\", \"7\"],\n        [\"8\", \"9\", \"0\"]\n    ]\n]");
            Assert.AreEqual<string>(this.beautifier.Beautify("{[x()[0]];indent;}"), "{\n    [x()[0]];\n    indent;\n}");
            Assert.AreEqual<string>(this.beautifier.Beautify("return ++i"), "return ++i");
            Assert.AreEqual<string>(this.beautifier.Beautify("return !!x"), "return !!x");

            Assert.AreEqual<string>(this.beautifier.Beautify("return !x"), "return !x");
            Assert.AreEqual<string>(this.beautifier.Beautify("return [1,2]"), "return [1, 2]");
            Assert.AreEqual<string>(this.beautifier.Beautify("return;"), "return;");
            Assert.AreEqual<string>(this.beautifier.Beautify("return\nfunc"), "return\nfunc");
            Assert.AreEqual<string>(this.beautifier.Beautify("catch(e)"), "catch (e)");
            Assert.AreEqual<string>(this.beautifier.Beautify("var a=1,b={foo:2,bar:3},{baz:4,wham:5},c=4;"), "var a = 1,\n    b = {\n        foo: 2,\n        bar: 3\n    }, {\n        baz: 4,\n        wham: 5\n    }, c = 4;");
            Assert.AreEqual<string>(this.beautifier.Beautify("var a=1,b={foo:2,bar:3},{baz:4,wham:5},\nc=4;"), "var a = 1,\n    b = {\n        foo: 2,\n        bar: 3\n    }, {\n        baz: 4,\n        wham: 5\n    },\n    c = 4;");
            Assert.AreEqual<string>(this.beautifier.Beautify("function x(/*int*/ start, /*string*/ foo)"), "function x( /*int*/ start, /*string*/ foo)");
            Assert.AreEqual<string>(this.beautifier.Beautify("/**\n* foo\n*/"), "/**\n * foo\n */");
            Assert.AreEqual<string>(this.beautifier.Beautify("{\n/**\n* foo\n*/\n}"), "{\n    /**\n     * foo\n     */\n}");
            Assert.AreEqual<string>(this.beautifier.Beautify("var a,b,c=1,d,e,f=2;"), "var a, b, c = 1,\n    d, e, f = 2;");

            Assert.AreEqual<string>(this.beautifier.Beautify("var a,b,c=[],d,e,f=2;"), "var a, b, c = [],\n    d, e, f = 2;");
            Assert.AreEqual<string>(this.beautifier.Beautify("function() {\n    var a, b, c, d, e = [],\n        f;\n}"), "function() {\n    var a, b, c, d, e = [],\n        f;\n}");
            Assert.AreEqual<string>(this.beautifier.Beautify("do/regexp/;\nwhile(1);"), "do /regexp/;\nwhile (1);");
            Assert.AreEqual<string>(this.beautifier.Beautify("var a = a,\na;\nb = {\nb\n}"), "var a = a,\n    a;\nb = {\n    b\n}");
            Assert.AreEqual<string>(this.beautifier.Beautify("var a = a,\n    /* c */\n    b;"), "var a = a,\n    /* c */\n    b;");
            Assert.AreEqual<string>(this.beautifier.Beautify("var a = a,\n    // c\n    b;"), "var a = a,\n    // c\n    b;");
            Assert.AreEqual<string>(this.beautifier.Beautify("foo.(\"bar\");"), "foo.(\"bar\");");
            Assert.AreEqual<string>(this.beautifier.Beautify("if (a) a()\nelse b()\nnewline()"), "if (a) a()\nelse b()\nnewline()");
            Assert.AreEqual<string>(this.beautifier.Beautify("if (a) a()\nnewline()"), "if (a) a()\nnewline()");
            Assert.AreEqual<string>(this.beautifier.Beautify("a=typeof(x)"), "a = typeof(x)");
            Assert.AreEqual<string>(this.beautifier.Beautify("var a = function() {\n    return null;\n},\nb = false;"), "var a = function() {\n    return null;\n},\nb = false;");
            Assert.AreEqual<string>(this.beautifier.Beautify("var a = function() {\n    func1()\n}"), "var a = function() {\n    func1()\n}");
            Assert.AreEqual<string>(this.beautifier.Beautify("var a = function() {\n    func1()\n}\nvar b = function() {\n    func2()\n}"), "var a = function() {\n    func1()\n}\nvar b = function() {\n    func2()\n}");

            this.beautifier.Opts.JslintHappy = true;

            Assert.AreEqual<string>(this.beautifier.Beautify("x();\n\nfunction(){}"), "x();\n\nfunction () {}");
            Assert.AreEqual<string>(this.beautifier.Beautify("function () {\n    var a, b, c, d, e = [],\n        f;\n}"), "function () {\n    var a, b, c, d, e = [],\n        f;\n}");
            Assert.AreEqual<string>(this.beautifier.Beautify("// comment 1\n(function()"), "// comment 1\n(function ()");
            Assert.AreEqual<string>(this.beautifier.Beautify("var o1=$.extend(a);function(){alert(x);}"), "var o1 = $.extend(a);\n\nfunction () {\n    alert(x);\n}");
            Assert.AreEqual<string>(this.beautifier.Beautify("a=typeof(x)"), "a = typeof (x)");

            this.beautifier.Opts.JslintHappy = false;

            Assert.AreEqual<string>(this.beautifier.Beautify("// comment 2\n(function()"), "// comment 2\n(function()");
            Assert.AreEqual<string>(this.beautifier.Beautify("var a2, b2, c2, d2 = 0, c = function() {}, d = '';"), "var a2, b2, c2, d2 = 0,\n    c = function() {}, d = '';");
            Assert.AreEqual<string>(this.beautifier.Beautify("var a2, b2, c2, d2 = 0, c = function() {},\nd = '';"), "var a2, b2, c2, d2 = 0,\n    c = function() {},\n    d = '';");
            Assert.AreEqual<string>(this.beautifier.Beautify("var o2=$.extend(a);function(){alert(x);}"), "var o2 = $.extend(a);\n\nfunction() {\n    alert(x);\n}");
            Assert.AreEqual<string>(this.beautifier.Beautify("{\"x\":[{\"a\":1,\"b\":3},7,8,8,8,8,{\"b\":99},{\"a\":11}]}"), "{\n    \"x\": [{\n        \"a\": 1,\n        \"b\": 3\n    },\n    7, 8, 8, 8, 8, {\n        \"b\": 99\n    }, {\n        \"a\": 11\n    }]\n}");
            Assert.AreEqual<string>(this.beautifier.Beautify("{\"1\":{\"1a\":\"1b\"},\"2\"}"), "{\n    \"1\": {\n        \"1a\": \"1b\"\n    },\n    \"2\"\n}");
            Assert.AreEqual<string>(this.beautifier.Beautify("{a:{a:b},c}"), "{\n    a: {\n        a: b\n    },\n    c\n}");
            Assert.AreEqual<string>(this.beautifier.Beautify("{[y[a]];keep_indent;}"), "{\n    [y[a]];\n    keep_indent;\n}");
            Assert.AreEqual<string>(this.beautifier.Beautify("if (x) {y} else { if (x) {y}}"), "if (x) {\n    y\n} else {\n    if (x) {\n        y\n    }\n}");
            Assert.AreEqual<string>(this.beautifier.Beautify("if (foo) one()\ntwo()\nthree()"), "if (foo) one()\ntwo()\nthree()");
            Assert.AreEqual<string>(this.beautifier.Beautify("if (1 + foo() && bar(baz()) / 2) one()\ntwo()\nthree()"), "if (1 + foo() && bar(baz()) / 2) one()\ntwo()\nthree()");
            Assert.AreEqual<string>(this.beautifier.Beautify("if (1 + foo() && bar(baz()) / 2) one();\ntwo();\nthree();"), "if (1 + foo() && bar(baz()) / 2) one();\ntwo();\nthree();");

            this.beautifier.Opts.IndentSize = 1;
            this.beautifier.Opts.IndentChar = ' ';

            Assert.AreEqual<string>(this.beautifier.Beautify("{ one_char() }"), "{\n one_char()\n}");
            Assert.AreEqual<string>(this.beautifier.Beautify("var a,b=1,c=2"), "var a, b = 1,\n c = 2");

            this.beautifier.Opts.IndentSize = 4;

            Assert.AreEqual<string>(this.beautifier.Beautify("{ one_char() }"), "{\n    one_char()\n}");

            this.beautifier.Opts.IndentSize = 1;
            this.beautifier.Opts.IndentChar = '\t';

            Assert.AreEqual<string>(this.beautifier.Beautify("{ one_char() }"), "{\n\tone_char()\n}");
            Assert.AreEqual<string>(this.beautifier.Beautify("x = a ? b : c; x;"), "x = a ? b : c;\nx;");

            this.beautifier.Opts.IndentSize = 4;
            this.beautifier.Opts.IndentChar = ' ';
            this.beautifier.Opts.PreserveNewlines = false;

            Assert.AreEqual<string>(this.beautifier.Beautify("var\na=dont_preserve_newlines;"), "var a = dont_preserve_newlines;");
            Assert.AreEqual<string>(this.beautifier.Beautify("function foo() {\n    return 1;\n}\n\nfunction foo() {\n    return 1;\n}"), "function foo() {\n    return 1;\n}\n\nfunction foo() {\n    return 1;\n}");
            Assert.AreEqual<string>(this.beautifier.Beautify("function foo() {\n    return 1;\n}\nfunction foo() {\n    return 1;\n}"), "function foo() {\n    return 1;\n}\n\nfunction foo() {\n    return 1;\n}");
            Assert.AreEqual<string>(this.beautifier.Beautify("function foo() {\n    return 1;\n}\n\n\nfunction foo() {\n    return 1;\n}"), "function foo() {\n    return 1;\n}\n\nfunction foo() {\n    return 1;\n}");

            this.beautifier.Opts.PreserveNewlines = true;

            Assert.AreEqual<string>(this.beautifier.Beautify("var\na=do_preserve_newlines;"), "var\na = do_preserve_newlines;");
            Assert.AreEqual<string>(this.beautifier.Beautify("// a\n// b\n\n// c\n// d"), "// a\n// b\n\n// c\n// d");
            Assert.AreEqual<string>(this.beautifier.Beautify("if (foo) //  comment\n{\n    bar();\n}"), "if (foo) //  comment\n{\n    bar();\n}");

            this.beautifier.Opts.KeepArrayIndentation = true;

            Assert.AreEqual<string>(this.beautifier.Beautify("a = ['a', 'b', 'c',\n    'd', 'e', 'f']"), "a = ['a', 'b', 'c',\n    'd', 'e', 'f']");
            Assert.AreEqual<string>(this.beautifier.Beautify("a = ['a', 'b', 'c',\n    'd', 'e', 'f',\n        'g', 'h', 'i']"), "a = ['a', 'b', 'c',\n    'd', 'e', 'f',\n        'g', 'h', 'i']");
            Assert.AreEqual<string>(this.beautifier.Beautify("a = ['a', 'b', 'c',\n        'd', 'e', 'f',\n            'g', 'h', 'i']"), "a = ['a', 'b', 'c',\n        'd', 'e', 'f',\n            'g', 'h', 'i']");
            Assert.AreEqual<string>(this.beautifier.Beautify("var x = [{}\n]"), "var x = [{}\n]");
            Assert.AreEqual<string>(this.beautifier.Beautify("var x = [{foo:bar}\n]"), "var x = [{\n    foo: bar\n}\n]");
            Assert.AreEqual<string>(this.beautifier.Beautify("a = ['something',\n'completely',\n'different'];\nif (x);"), "a = ['something',\n'completely',\n'different'];\nif (x);");
            Assert.AreEqual<string>(this.beautifier.Beautify("a = ['a','b','c']"), "a = ['a', 'b', 'c']");
            Assert.AreEqual<string>(this.beautifier.Beautify("a = ['a',   'b','c']"), "a = ['a', 'b', 'c']");
            Assert.AreEqual<string>(this.beautifier.Beautify("x = [{'a':0}]"), "x = [{\n    'a': 0\n}]");
            Assert.AreEqual<string>(this.beautifier.Beautify("{a([[a1]], {b;});}"), "{\n    a([[a1]], {\n        b;\n    });\n}");
            Assert.AreEqual<string>(this.beautifier.Beautify("a = //comment\n/regex/;"), "a = //comment\n/regex/;");
            Assert.AreEqual<string>(this.beautifier.Beautify("/*\n * X\n */"), "/*\n * X\n */");
            Assert.AreEqual<string>(this.beautifier.Beautify("/*\r\n * X\r\n */"), "/*\n * X\n */");
            Assert.AreEqual<string>(this.beautifier.Beautify("if (a)\n{\nb;\n}\nelse\n{\nc;\n}"), "if (a) {\n    b;\n} else {\n    c;\n}");
            Assert.AreEqual<string>(this.beautifier.Beautify("var a = new function();"), "var a = new function();");
            Assert.AreEqual<string>(this.beautifier.Beautify("new function"), "new function");
            Assert.AreEqual<string>(this.beautifier.Beautify("var a =\nfoo"), "var a = foo");

            this.beautifier.Opts.BraceStyle = BraceStyle.Expand;

            Assert.AreEqual<string>(this.beautifier.Beautify("throw {}"), "throw {}");
            Assert.AreEqual<string>(this.beautifier.Beautify("throw {\n    foo;\n}"), "throw {\n    foo;\n}");
            Assert.AreEqual<string>(this.beautifier.Beautify("if (a)\n{\nb;\n}\nelse\n{\nc;\n}"), "if (a)\n{\n    b;\n}\nelse\n{\n    c;\n}");
            Assert.AreEqual<string>(this.beautifier.Beautify("if (foo) {"), "if (foo)\n{");
            Assert.AreEqual<string>(this.beautifier.Beautify("foo {"), "foo\n{");
            Assert.AreEqual<string>(this.beautifier.Beautify("return {"), "return {");
            Assert.AreEqual<string>(this.beautifier.Beautify("return;\n{"), "return;\n{");
            Assert.AreEqual<string>(this.beautifier.Beautify("if (a)\n{\nb;\n}\nelse\n{\nc;\n}"), "if (a)\n{\n    b;\n}\nelse\n{\n    c;\n}");
            Assert.AreEqual<string>(this.beautifier.Beautify("var foo = {}"), "var foo = {}");
            Assert.AreEqual<string>(this.beautifier.Beautify("if (a)\n{\nb;\n}\nelse\n{\nc;\n}"), "if (a)\n{\n    b;\n}\nelse\n{\n    c;\n}");
            Assert.AreEqual<string>(this.beautifier.Beautify("if (foo) {"), "if (foo)\n{");
            Assert.AreEqual<string>(this.beautifier.Beautify("foo {"), "foo\n{");
            Assert.AreEqual<string>(this.beautifier.Beautify("return {"), "return {");
            Assert.AreEqual<string>(this.beautifier.Beautify("return;\n{"), "return;\n{");

            this.beautifier.Opts.BraceStyle = BraceStyle.Collapse;

            Assert.AreEqual<string>(this.beautifier.Beautify("if (a)\n{\nb;\n}\nelse\n{\nc;\n}"), "if (a) {\n    b;\n} else {\n    c;\n}");
            Assert.AreEqual<string>(this.beautifier.Beautify("if (foo) {"), "if (foo) {");
            Assert.AreEqual<string>(this.beautifier.Beautify("foo {"), "foo {");
            Assert.AreEqual<string>(this.beautifier.Beautify("return {"), "return {");
            Assert.AreEqual<string>(this.beautifier.Beautify("return;\n{"), "return; {");
            Assert.AreEqual<string>(this.beautifier.Beautify("if (foo) bar();\nelse break"), "if (foo) bar();\nelse break");
            Assert.AreEqual<string>(this.beautifier.Beautify("function x() {\n    foo();\n}zzz"), "function x() {\n    foo();\n}\nzzz");
            Assert.AreEqual<string>(this.beautifier.Beautify("a: do {} while (); xxx"), "a: do {} while ();\nxxx");

            this.beautifier.Opts.BraceStyle = BraceStyle.EndExpand;

            Assert.AreEqual<string>(this.beautifier.Beautify("if(1){2}else{3}"), "if (1) {\n    2\n}\nelse {\n    3\n}");
            Assert.AreEqual<string>(this.beautifier.Beautify("try{a();}catch(b){c();}finally{d();}"), "try {\n    a();\n}\ncatch (b) {\n    c();\n}\nfinally {\n    d();\n}");
            Assert.AreEqual<string>(this.beautifier.Beautify("if(a){b();}else if(c) foo();"), "if (a) {\n    b();\n}\nelse if (c) foo();");
            Assert.AreEqual<string>(this.beautifier.Beautify("if (a) {\n// comment\n}else{\n// comment\n}"), "if (a) {\n    // comment\n}\nelse {\n    // comment\n}");
            Assert.AreEqual<string>(this.beautifier.Beautify("if (x) {y} else { if (x) {y}}"), "if (x) {\n    y\n}\nelse {\n    if (x) {\n        y\n    }\n}");
            Assert.AreEqual<string>(this.beautifier.Beautify("if (a)\n{\nb;\n}\nelse\n{\nc;\n}"), "if (a) {\n    b;\n}\nelse {\n    c;\n}");
            Assert.AreEqual<string>(this.beautifier.Beautify("if (foo) {}\nelse /regex/.test();"), "if (foo) {}\nelse /regex/.test();");
            Assert.AreEqual<string>(this.beautifier.Beautify("a = <?= external() ?> ;"), "a = <?= external() ?> ;");
            Assert.AreEqual<string>(this.beautifier.Beautify("a = <%= external() %> ;"), "a = <%= external() %> ;");
            Assert.AreEqual<string>(this.beautifier.Beautify("roo = {\n    /*\n    ****\n      FOO\n    ****\n    */\n    BAR: 0\n};"), "roo = {\n    /*\n    ****\n      FOO\n    ****\n    */\n    BAR: 0\n};");
            Assert.AreEqual<string>(this.beautifier.Beautify("if (zz) {\n    // ....\n}\n(function"), "if (zz) {\n    // ....\n}\n(function");

            this.beautifier.Opts.PreserveNewlines = true;

            Assert.AreEqual<string>(this.beautifier.Beautify("var a = 42; // foo\n\nvar b;"), "var a = 42; // foo\n\nvar b;");
            Assert.AreEqual<string>(this.beautifier.Beautify("var a = 42; // foo\n\n\nvar b;"), "var a = 42; // foo\n\n\nvar b;");
            Assert.AreEqual<string>(this.beautifier.Beautify("\"foo\"\"bar\"\"baz\""), "\"foo\"\n\"bar\"\n\"baz\"");
            Assert.AreEqual<string>(this.beautifier.Beautify("'foo''bar''baz'"), "'foo'\n'bar'\n'baz'");
            Assert.AreEqual<string>(this.beautifier.Beautify("{\n    get foo() {}\n}"), "{\n    get foo() {}\n}");
            Assert.AreEqual<string>(this.beautifier.Beautify("{\n    var a = get\n    foo();\n}"), "{\n    var a = get\n    foo();\n}");
            Assert.AreEqual<string>(this.beautifier.Beautify("{\n    set foo() {}\n}"), "{\n    set foo() {}\n}");
            Assert.AreEqual<string>(this.beautifier.Beautify("{\n    var a = set\n    foo();\n}"), "{\n    var a = set\n    foo();\n}");
            Assert.AreEqual<string>(this.beautifier.Beautify("var x = {\n    get function()\n}"), "var x = {\n    get function()\n}");
            Assert.AreEqual<string>(this.beautifier.Beautify("var x = {\n    set function()\n}"), "var x = {\n    set function()\n}");
            Assert.AreEqual<string>(this.beautifier.Beautify("var x = set\n\nfunction() {}"), "var x = set\n\nfunction() {}");
            Assert.AreEqual<string>(this.beautifier.Beautify("<!-- foo\nbar();\n-->"), "<!-- foo\nbar();\n-->");
            Assert.AreEqual<string>(this.beautifier.Beautify("<!-- dont crash"), "<!-- dont crash");
            Assert.AreEqual<string>(this.beautifier.Beautify("for () /abc/.test()"), "for () /abc/.test()");
            Assert.AreEqual<string>(this.beautifier.Beautify("if (k) /aaa/m.test(v) && l();"), "if (k) /aaa/m.test(v) && l();");
            Assert.AreEqual<string>(this.beautifier.Beautify("switch (true) {\n    case /swf/i.test(foo):\n        bar();\n}"), "switch (true) {\n    case /swf/i.test(foo):\n        bar();\n}");
            Assert.AreEqual<string>(this.beautifier.Beautify("createdAt = {\n    type: Date,\n    default: Date.now\n}"), "createdAt = {\n    type: Date,\n    default: Date.now\n}");
            Assert.AreEqual<string>(this.beautifier.Beautify("switch (createdAt) {\n    case a:\n        Date,\n    default:\n        Date.now\n}"), "switch (createdAt) {\n    case a:\n        Date,\n    default:\n        Date.now\n}");
            Assert.AreEqual<string>(this.beautifier.Beautify("foo = {\n    x: y, // #44\n    w: z // #44\n}"), "foo = {\n    x: y, // #44\n    w: z // #44\n}");
            Assert.AreEqual<string>(this.beautifier.Beautify("return function();"), "return function();");
            Assert.AreEqual<string>(this.beautifier.Beautify("var a = function();"), "var a = function();");
            Assert.AreEqual<string>(this.beautifier.Beautify("var a = 5 + function();"), "var a = 5 + function();");
            Assert.AreEqual<string>(this.beautifier.Beautify("{\n    foo // something\n    ,\n    bar // something\n    baz\n}"), "{\n    foo // something\n    ,\n    bar // something\n    baz\n}");
            Assert.AreEqual<string>(this.beautifier.Beautify("function a(a) {} function b(b) {} function c(c) {}"), "function a(a) {}\nfunction b(b) {}\nfunction c(c) {}");
            Assert.AreEqual<string>(this.beautifier.Beautify("3.*7;"), "3. * 7;");
            Assert.AreEqual<string>(this.beautifier.Beautify("import foo.*;"), "import foo.*;");
            Assert.AreEqual<string>(this.beautifier.Beautify("function f(a: a, b: b)"), "function f(a: a, b: b)");
            Assert.AreEqual<string>(this.beautifier.Beautify("foo(a, function() {})"), "foo(a, function() {})");
            Assert.AreEqual<string>(this.beautifier.Beautify("foo(a, /regex/)"), "foo(a, /regex/)");
            Assert.AreEqual<string>(this.beautifier.Beautify("if (foo) // comment\nbar();"), "if (foo) // comment\nbar();");
            Assert.AreEqual<string>(this.beautifier.Beautify("if (foo) // comment\n(bar());"), "if (foo) // comment\n(bar());");
            Assert.AreEqual<string>(this.beautifier.Beautify("if (foo) // comment\n(bar());"), "if (foo) // comment\n(bar());");
            Assert.AreEqual<string>(this.beautifier.Beautify("if (foo) // comment\n/asdf/;"), "if (foo) // comment\n/asdf/;");
            Assert.AreEqual<string>(this.beautifier.Beautify("var a = 'foo' +\n    'bar';"), "var a = 'foo' +\n    'bar';");
            Assert.AreEqual<string>(this.beautifier.Beautify("var a = \"foo\" +\n    \"bar\";"), "var a = \"foo\" +\n    \"bar\";");

            this.beautifier.Opts.BreakChainedMethods = true;

            Assert.AreEqual<string>(this.beautifier.Beautify("foo.bar().baz().cucumber(fat)"), "foo.bar()\n    .baz()\n    .cucumber(fat)");
            Assert.AreEqual<string>(this.beautifier.Beautify("foo.bar().baz().cucumber(fat); foo.bar().baz().cucumber(fat)"), "foo.bar()\n    .baz()\n    .cucumber(fat);\nfoo.bar()\n    .baz()\n    .cucumber(fat)");
            Assert.AreEqual<string>(this.beautifier.Beautify("foo.bar().baz().cucumber(fat)\n foo.bar().baz().cucumber(fat)"), "foo.bar()\n    .baz()\n    .cucumber(fat)\nfoo.bar()\n    .baz()\n    .cucumber(fat)");
            Assert.AreEqual<string>(this.beautifier.Beautify("this.something = foo.bar().baz().cucumber(fat)"), "this.something = foo.bar()\n    .baz()\n    .cucumber(fat)");
            Assert.AreEqual<string>(this.beautifier.Beautify("this.something.xxx = foo.moo.bar()"), "this.something.xxx = foo.moo.bar()");

            this.beautifier.Opts.PreserveNewlines = false;

            Assert.AreEqual<string>(this.beautifier.Beautify("var a = {\n\"a\":1,\n\"b\":2}"), "var a = {\n    \"a\": 1,\n    \"b\": 2\n}");
            Assert.AreEqual<string>(this.beautifier.Beautify("var a = {\n'a':1,\n'b':2}"), "var a = {\n    'a': 1,\n    'b': 2\n}");

            this.beautifier.Opts.PreserveNewlines = true;

            Assert.AreEqual<string>(this.beautifier.Beautify("var a = {\n\"a\":1,\n\"b\":2}"), "var a = {\n    \"a\": 1,\n    \"b\": 2\n}");
            Assert.AreEqual<string>(this.beautifier.Beautify("var a = {\n'a':1,\n'b':2}"), "var a = {\n    'a': 1,\n    'b': 2\n}");
        }

        [TestMethod]
        public void TestNewLineBug()
        {
            Assert.AreEqual<string>(this.beautifier.Beautify("function foo()\n{\n\n}\n\n\n\nfunction bar()\n{\n\n}\n"), "function foo() {\n\n}\n\n\n\nfunction bar() {\n\n}");
        }
    }
}
