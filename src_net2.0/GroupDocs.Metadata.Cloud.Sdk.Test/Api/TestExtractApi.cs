using GroupDocs.Metadata.Cloud.Sdk.Api;
using GroupDocs.Metadata.Cloud.Sdk.Client;
using GroupDocs.Metadata.Cloud.Sdk.Model;
using GroupDocs.Metadata.Cloud.Sdk.Model.Requests;
using GroupDocs.Metadata.Cloud.Sdk.Test.Api.Internal;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GroupDocs.Metadata.Cloud.Sdk.Test.Api
{
    [TestFixture]
    public class TestExtractApi : BaseApiTest
    {
        [Test]
        public void ExtractApiTest()
        {
            var options = new ExtractOptions
            {
                FileInfo = TestFiles.Docx.ToFileInfo()
            };

            var request = new ExtractRequest(options);

            var result = MetadataApi.Extract(request);

            Assert.IsNotNull(result.MetadataTree);
            Assert.IsNotEmpty(result.MetadataTree.InnerPackages);
            Assert.IsTrue(result.MetadataTree.InnerPackages.Any(x => string.Equals(x.PackageName, "FileFormat")));
        }

        [Test]
        public void ExtractApiTest_Tag()
        {
            var options = new ExtractOptions
            {
                FileInfo = TestFiles.Docx.ToFileInfo(),
                SearchCriteria = new SearchCriteria
                {
                    TagOptions = new TagOptions
                    {
                        ExactTag = new Tag
                        {
                            Name = "Created",
                            Category = "Time"
                        }
                    }
                }
            };

            var request = new ExtractRequest(options);

            var result = MetadataApi.Extract(request);

            Assert.IsNotNull(result);
            Assert.IsNotEmpty(result.Properties);
            Assert.IsTrue(result.Properties.Any(x => string.Equals(x.Name, "CreateTime")));
        }

        [Test]
        public void ExtractApiTest_PossibleTagName()
        {
            var options = new ExtractOptions
            {
                FileInfo = TestFiles.Docx.ToFileInfo(),
                SearchCriteria = new SearchCriteria
                {
                    TagOptions = new TagOptions
                    {
                        PossibleName = "creator"
                    }
                }
            };

            var request = new ExtractRequest(options);

            var result = MetadataApi.Extract(request);
            Assert.IsNotNull(result);
            Assert.IsNotEmpty(result.Properties);
            Assert.IsTrue(result.Properties.Any(x => x.Tags.Any(t => t.Name.Contains("Creator"))));
        }

        [Test]
        public void ExtractApiTest_PropertyName()
        {
            var options = new ExtractOptions
            {
                FileInfo = TestFiles.Docx.ToFileInfo(),
                SearchCriteria = new SearchCriteria
                {
                    NameOptions = new NameOptions
                    {
                        Value = "Date"
                    }
                }
            };

            var request = new ExtractRequest(options);

            var result = MetadataApi.Extract(request);
            Assert.IsNotNull(result);
            Assert.IsNotEmpty(result.Properties);
            Assert.IsTrue(result.Properties.Any(x => x.Name.Contains("Date")));
        }

        [Test]
        public void ExtractApiTest_PropertyNameExactPhrase()
        {
            var options = new ExtractOptions
            {
                FileInfo = TestFiles.Docx.ToFileInfo(),
                SearchCriteria = new SearchCriteria
                {
                    NameOptions = new NameOptions
                    {
                        Value = "MimeType",
                        MatchOptions = new MatchOptions
                        {
                            ExactPhrase = true
                        }
                    }
                }
            };

            var request = new ExtractRequest(options);

            var result = MetadataApi.Extract(request);
            Assert.IsNotNull(result);
            Assert.IsNotEmpty(result.Properties);
            Assert.IsTrue(result.Properties.Any(x => x.Name.Equals("MimeType", StringComparison.OrdinalIgnoreCase)));
        }

        [Test]
        public void ExtractApiTest_PropertyNameRegex()
        {
            var options = new ExtractOptions
            {
                FileInfo = TestFiles.Docx.ToFileInfo(),
                SearchCriteria = new SearchCriteria
                {
                    NameOptions = new NameOptions
                    {
                        Value = "^dc:.*",
                        MatchOptions = new MatchOptions
                        {
                            IsRegex = true
                        }
                    }
                }
            };

            var request = new ExtractRequest(options);

            var result = MetadataApi.Extract(request);
            Assert.IsNotNull(result);
            Assert.IsNotEmpty(result.Properties);
            Assert.IsTrue(result.Properties.Any(x => x.Name.StartsWith("dc:", StringComparison.OrdinalIgnoreCase)));
        }

        [Test]
        public void ExtractApiTest_PropertyValue()
        {
            var options = new ExtractOptions
            {
                FileInfo = TestFiles.Docx.ToFileInfo(),
                SearchCriteria = new SearchCriteria
                {
                    ValueOptions = new ValueOptions
                    {
                        Value = "Microsoft Office Word",
                        Type = "String"
                    }
                }
            };

            var request = new ExtractRequest(options);

            var result = MetadataApi.Extract(request);
            Assert.IsNotNull(result);
            Assert.IsNotEmpty(result.Properties);
            Assert.IsTrue(result.Properties.Any(x => x.Name.StartsWith("NameOfApplication", StringComparison.OrdinalIgnoreCase)));
        }

        [Test]
        public void ExtractApiTest_IncorrectTag()
        {
            var options = new ExtractOptions
            {
                FileInfo = TestFiles.Docx.ToFileInfo(),
                SearchCriteria = new SearchCriteria
                {
                    TagOptions = new TagOptions
                    {
                        ExactTag = new Tag
                        {
                            Name = "wrong",
                            Category = "Wrong"
                        }
                    }
                }
            };

            var request = new ExtractRequest(options);

            var ex = Assert.Throws<ApiException>(() => { MetadataApi.Extract(request); });
            Assert.AreEqual("The specified tag was not found or has incorrect format.", ex.Message);
        }

        [Test]
        public void ExtractApiTest_DocumentProtectedException()
        {
            var testFile = TestFiles.PasswordProtected;
            var options = new ExtractOptions
            {
                FileInfo = testFile.ToFileInfo(),
            };

            var request = new ExtractRequest(options);

            var ex = Assert.Throws<ApiException>(() => { MetadataApi.Extract(request); });
            Assert.AreEqual($"The specified file '{testFile.FullName}' is protected.", ex.Message);
        }

        [Test]
        public void ExtractApiTest_UnsupportedFormat()
        {
            var testFile = TestFiles.Json;
            var options = new ExtractOptions
            {
                FileInfo = testFile.ToFileInfo(),
                SearchCriteria = new SearchCriteria
                {
                    TagOptions = new TagOptions
                    {
                        PossibleName = "Tag"
                    }
                }
            };

            var request = new ExtractRequest(options);

            var ex = Assert.Throws<ApiException>(() => { MetadataApi.Extract(request); });
            Assert.AreEqual($"The specified file '{testFile.FullName}' has type which is not currently supported.", ex.Message);
        }

        [Test]
        public void ExtractApiTest_FileNotFound()
        {
            var testFile = TestFiles.NotExist;
            var options = new ExtractOptions
            {
                FileInfo = testFile.ToFileInfo(),
            };

            var request = new ExtractRequest(options);

            var ex = Assert.Throws<ApiException>(() => { MetadataApi.Extract(request); });
            Assert.AreEqual($"Can't find file located at '{testFile.FullName}'.", ex.Message);
        }
    }
}