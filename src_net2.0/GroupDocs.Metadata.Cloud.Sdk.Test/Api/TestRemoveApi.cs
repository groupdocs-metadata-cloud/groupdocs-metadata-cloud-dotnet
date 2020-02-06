using GroupDocs.Metadata.Cloud.Sdk.Api;
using GroupDocs.Metadata.Cloud.Sdk.Client;
using GroupDocs.Metadata.Cloud.Sdk.Model;
using GroupDocs.Metadata.Cloud.Sdk.Model.Requests;
using GroupDocs.Metadata.Cloud.Sdk.Test.Api.Internal;
using NUnit.Framework;

namespace GroupDocs.Metadata.Cloud.Sdk.Test.Api
{
    [TestFixture]
    public class TestRemoveApi : BaseApiTest
    {
        [Test]
        public void RemoveApiTest()
        {
            var testFile = TestFiles.Docx;
            var options = new RemoveOptions
            {
                FileInfo = testFile.ToFileInfo(),
                SearchCriteria = new SearchCriteria
                {
                    TagOptions = new TagOptions
                    {
                        ExactTag = new Tag
                        {
                            Name = "Title",
                            Category = "Content"
                        }
                    }
                }
            };

            var request = new RemoveRequest(options);

            var result = MetadataApi.Remove(request);

            Assert.IsNotNull(result);
            Assert.Greater(result.RemovedCount, 0);
        }

        [Test]
        public void RemoveApiTest_Tag()
        {
            var options = new RemoveOptions
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

            var request = new RemoveRequest(options);

            var result = MetadataApi.Remove(request);

            Assert.IsNotNull(result);
            Assert.IsNotEmpty(result.Path);
            Assert.IsNotEmpty(result.Url);
            Assert.Greater(result.RemovedCount, 0);
        }

        [Test]
        public void RemoveApiTest_PossibleTagName()
        {
            var options = new RemoveOptions
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

            var request = new RemoveRequest(options);

            var result = MetadataApi.Remove(request);
            Assert.IsNotNull(result);
            Assert.IsNotEmpty(result.Path);
            Assert.IsNotEmpty(result.Url);
            Assert.Greater(result.RemovedCount, 0);
        }

        [Test]
        public void RemoveApiTest_PropertyName()
        {
            var options = new RemoveOptions
            {
                FileInfo = TestFiles.Doc.ToFileInfo(),
                SearchCriteria = new SearchCriteria
                {
                    NameOptions = new NameOptions
                    {
                        Value = "Application"
                    }
                }
            };

            var request = new RemoveRequest(options);

            var result = MetadataApi.Remove(request);
            Assert.IsNotNull(result);
            Assert.IsNotEmpty(result.Path);
            Assert.IsNotEmpty(result.Url);
            Assert.Greater(result.RemovedCount, 0);
        }

        [Test]
        public void RemoveApiTest_PropertyNameWholeWord()
        {
            var options = new RemoveOptions
            {
                FileInfo = TestFiles.Docx.ToFileInfo(),
                SearchCriteria = new SearchCriteria
                {
                    NameOptions = new NameOptions
                    {
                        Value = "NameOfApplication",
                        MatchOptions = new MatchOptions
                        {
                            WholeWord = true
                        }
                    }
                }
            };

            var request = new RemoveRequest(options);

            var result = MetadataApi.Remove(request);
            Assert.IsNotNull(result);
            Assert.IsNotEmpty(result.Path);
            Assert.IsNotEmpty(result.Url);
            Assert.Greater(result.RemovedCount, 0);
        }

        [Test]
        public void RemoveApiTest_PropertyNameRegex()
        {
            var options = new RemoveOptions
            {
                FileInfo = TestFiles.Docx.ToFileInfo(),
                SearchCriteria = new SearchCriteria
                {
                    NameOptions = new NameOptions
                    {
                        Value = "^[N]ame[A-Z].*",
                        MatchOptions = new MatchOptions
                        {
                            IsRegex = true
                        }
                    }
                }
            };

            var request = new RemoveRequest(options);

            var result = MetadataApi.Remove(request);
            Assert.IsNotNull(result);
            Assert.IsNotEmpty(result.Path);
            Assert.IsNotEmpty(result.Url);
            Assert.Greater(result.RemovedCount, 0);
        }

        [Test]
        public void RemoveApiTest_PropertyValue()
        {
            var options = new RemoveOptions
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

            var request = new RemoveRequest(options);

            var result = MetadataApi.Remove(request);
            Assert.IsNotNull(result);
            Assert.IsNotEmpty(result.Path);
            Assert.IsNotEmpty(result.Url);
            Assert.Greater(result.RemovedCount, 0);
        }

        [Test]
        public void RemoveApiTest_IncorrectTag()
        {
            var options = new RemoveOptions
            {
                FileInfo = TestFiles.Docx.ToFileInfo(),
                SearchCriteria = new SearchCriteria
                {
                    TagOptions = new TagOptions
                    {
                        ExactTag = new Tag
                        {
                            Name = "Wrong",
                            Category = "Wrong"
                        }
                    }
                }
            };

            var request = new RemoveRequest(options);
            var ex = Assert.Throws<ApiException>(() => { MetadataApi.Remove(request); });
            Assert.AreEqual("The specified tag was not found or has incorrect format.", ex.Message);
        }

        [Test]
        public void Remove_DocumentProtectedException()
        {
            var testFile = TestFiles.PasswordProtected;
            var options = new RemoveOptions
            {
                FileInfo = testFile.ToFileInfo(),
                SearchCriteria = new SearchCriteria
                {
                    TagOptions = new TagOptions
                    {
                        ExactTag = new Tag
                        {
                            Name = "Printed",
                            Category = "Time"
                        }
                    }
                }
            };

            var request = new RemoveRequest(options);
            var ex = Assert.Throws<ApiException>(() => { MetadataApi.Remove(request); });
            Assert.AreEqual($"The specified file '{testFile.FullName}' is protected.", ex.Message);
        }

        [Test]
        public void Remove_UnsupportedFormat()
        {
            var testFile = TestFiles.Json;
            var options = new RemoveOptions
            {
                FileInfo = testFile.ToFileInfo(),
                SearchCriteria = new SearchCriteria
                {
                    TagOptions = new TagOptions
                    {
                        ExactTag = new Tag
                        {
                            Name = "Printed",
                            Category = "Time"
                        }
                    }
                }
            };

            var request = new RemoveRequest(options);
            var ex = Assert.Throws<ApiException>(() => { MetadataApi.Remove(request); });
            Assert.AreEqual($"The specified file '{testFile.FullName}' has type which is not currently supported.", ex.Message);
        }

        [Test]
        public void Remove_FileNotFound()
        {
            var testFile = TestFiles.NotExist;
            var options = new RemoveOptions
            {
                FileInfo = testFile.ToFileInfo(),
                SearchCriteria = new SearchCriteria
                {
                    TagOptions = new TagOptions
                    {
                        PossibleName = "Empty"
                    }
                }
            };

            var request = new RemoveRequest(options);
            var ex = Assert.Throws<ApiException>(() => { MetadataApi.Remove(request); });
            Assert.AreEqual($"Can't find file located at '{testFile.FullName}'.", ex.Message);
        }
    }
}