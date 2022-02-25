// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Aspose Pty Ltd" file="TestFiles.cs">
//  Copyright (c) 2003-2020 Aspose Pty Ltd
// </copyright>
// <summary>
//  Permission is hereby granted, free of charge, to any person obtaining a copy
//  of this software and associated documentation files (the "Software"), to deal
//  in the Software without restriction, including without limitation the rights
//  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//  copies of the Software, and to permit persons to whom the Software is
//  furnished to do so, subject to the following conditions:
// 
//  The above copyright notice and this permission notice shall be included in all
//  copies or substantial portions of the Software.
// 
//  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
//  SOFTWARE.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;

namespace GroupDocs.Metadata.Cloud.Sdk.Test.Api.Internal
{
    public static class TestFiles
    {
        public static readonly string DefaultPassword = "password";

        public static readonly TestFile PasswordProtected = new TestFile("sample-with-password.docx", "documents\\");

        public static readonly TestFile Docx = new TestFile("input.docx", "documents\\");
        public static readonly TestFile Doc = new TestFile("input.doc", "documents\\");
        public static readonly TestFile Pdf = new TestFile("input.pdf", "documents\\");
        public static readonly TestFile Pptx = new TestFile("input.pptx", "documents\\");
        public static readonly TestFile Ppt = new TestFile("input.ppt", "documents\\");
        public static readonly TestFile Xlsx = new TestFile("input.xlsx", "documents\\");
        public static readonly TestFile Xls = new TestFile("input.xls", "documents\\");
        public static readonly TestFile Jpg = new TestFile("input.jpg", "images\\");
        public static readonly TestFile Json = new TestFile("sample.json", "files\\");
        public static readonly TestFile Psd = new TestFile("iptc.psd", "files\\");
        public static readonly TestFile Mkv = new TestFile("input.mkv", "files\\");
        public static readonly TestFile NotExist = new TestFile("folder\\file-not-exist.pdf", "");

        public static IEnumerable<TestFile> TestFilesList
        {
            get
            {
                yield return PasswordProtected;
                yield return Docx;
                yield return Doc;
                yield return Pdf;
                yield return Pptx;
                yield return Ppt;
                yield return Xlsx;
                yield return Xls;
                yield return Jpg;
                yield return Json;
                yield return Psd;
                yield return Mkv;
            }
        }
    }
}