﻿// 
// RedundantNameQualifierIssueTests.cs
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
using NUnit.Framework;
using ICSharpCode.NRefactory.CSharp.Refactoring;
using ICSharpCode.NRefactory.CSharp.CodeActions;

namespace ICSharpCode.NRefactory.CSharp.CodeIssues
{
	[TestFixture]
	public class RedundantNameQualifierIssueTests : InspectionActionTestBase
	{
		[Test]
		public void TestInspectorCase1 ()
		{
			var input = @"using System;
class Foo
{
	void Bar (string str)
	{
		System.Console.WriteLine ();
	}
}";

			TestRefactoringContext context;
			var issues = GetIssues (new RedundantNameQualifierIssue (), input, out context);
			Assert.AreEqual (1, issues.Count);
			CheckFix (context, issues, @"using System;
class Foo
{
	void Bar (string str)
	{
		Console.WriteLine ();
	}
}");
		}
		
		[Test]
		public void TestInspectorCase2 ()
		{
			var input = @"using System.Text;
class Foo
{
	void Bar (System.Text.StringBuilder b)
	{
	}
}";

			TestRefactoringContext context;
			var issues = GetIssues (new RedundantNameQualifierIssue (), input, out context);
			Assert.AreEqual (1, issues.Count);
			CheckFix (context, issues, @"using System.Text;
class Foo
{
	void Bar (StringBuilder b)
	{
	}
}");
		}
		
		[Test]
		public void UsingAlias()
		{
			var input = @"using IEnumerable = System.Collections.IEnumerable;";

			TestRefactoringContext context;
			var issues = GetIssues (new RedundantNameQualifierIssue (), input, out context);
			Assert.AreEqual (0, issues.Count);
		}

        [Test]
        public void TestDisable()
        {
            var input = @"using System;
class Foo
{
	void Bar (string str)
	{
// ReSharper disable RedundantNameQualifier
            System.Console.WriteLine();
// ReSharper restore RedundantNameQualifier
	}
}";

            TestRefactoringContext context;
            var issues = GetIssues(new RedundantNameQualifierIssue(), input, out context);
            Assert.AreEqual(0, issues.Count);
        }
	}
}
