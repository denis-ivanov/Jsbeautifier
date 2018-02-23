﻿#region License
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

    public class BeautifierOptions
    {
        public BeautifierOptions()
        {
            this.IndentSize = 4;
            this.IndentChar = ' ';
            this.IndentWithTabs = false;
            this.PreserveNewlines = true;
            this.MaxPreserveNewlines = 10.0f;
            this.JslintHappy = false;
            this.BraceStyle = Jsbeautifier.BraceStyle.Collapse;
            this.KeepArrayIndentation = false;
            this.KeepFunctionIndentation = false;
            this.EvalCode = false;
            //this.UnescapeStrings = false;
            this.BreakChainedMethods = false;
        }

        public uint IndentSize { get; set; }

        public char IndentChar { get; set; }

        public bool IndentWithTabs { get; set; }

        public bool PreserveNewlines { get; set; }

        public float MaxPreserveNewlines { get; set; }

        public bool JslintHappy { get; set; }

        public BraceStyle BraceStyle { get; set; }

        public bool KeepArrayIndentation { get; set; }

        public bool KeepFunctionIndentation { get; set; }

        public bool EvalCode { get; set; }

        //public bool UnescapeStrings { get; set; }

        public bool BreakChainedMethods { get; set; }

        public static BeautifierOptions DefaultOptions()
        {
            return new BeautifierOptions();
        }
    }
}