#region License
// MIT License
//
// Copyright (c) 2018 Denis Ivanov
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.
#endregion

namespace Jsbeautifier
{
    using System;

    public class BeautifierFlags
    {
        public BeautifierFlags(string mode)
        {
            this.PreviousMode = "BLOCK";
            this.Mode = mode;
            this.VarLine = false;
            this.VarLineTainted = false;
            this.VarLineReindented = false;
            this.InHtmlComment = false;
            this.IfLine = false;
            this.ChainExtraIndentation = 0;
            this.InCase = false;
            this.InCaseStatement = false;
            this.CaseBody = false;
            this.EatNextSpace = false;
            this.IndentationLevel = 0;
            this.TernaryDepth = 0;
        }

        public string PreviousMode { get; set; }

        public string Mode { get; set; }

        public bool VarLine { get; set; }

        public bool VarLineTainted { get; set; }

        public bool VarLineReindented { get; set; }

        public bool InHtmlComment { get; set; }

        public bool IfLine { get; set; }

        public int ChainExtraIndentation { get; set; }

        public bool InCase { get; set; }

        public bool InCaseStatement { get; set; }

        public bool CaseBody { get; set; }

        public bool EatNextSpace { get; set; }

        public int IndentationLevel { get; set; }

        public int TernaryDepth { get; set; }
    }
}