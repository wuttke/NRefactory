﻿// 
using System.Diagnostics.CodeAnalysis;


// IssueAttribute.cs
//  
// Author:
//       Mike Krüger <mkrueger@xamarin.com>
// 
// Copyright (c) 2012 Xamarin Inc. (http://xamarin.com)
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
using System;
using ICSharpCode.NRefactory.Refactoring;

namespace ICSharpCode.NRefactory.CSharp
{
	[AttributeUsage(AttributeTargets.Class)]
	public class IssueDescriptionAttribute : System.Attribute
	{
		public string Title { get; private set;}
		
		public string Description { get; set; }
		
		public string Category { get; set; }

		public string ResharperDisableKeyword { get; set; }
		public string SuppressMessageCategory { get; set; }
		public string SuppressMessageCheckId { get; set; }
        public int PragmaWarning { get; set; }

		public Severity Severity { get; set; }

		public IssueMarker IssueMarker { get; set; }

		public IssueDescriptionAttribute (string title)
		{
			Title = title;
			Severity = Severity.Suggestion;
			IssueMarker = IssueMarker.Underline;
		}
	}
}

