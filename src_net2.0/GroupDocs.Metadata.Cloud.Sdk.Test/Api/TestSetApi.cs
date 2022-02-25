using GroupDocs.Metadata.Cloud.Sdk.Api;
using GroupDocs.Metadata.Cloud.Sdk.Client;
using GroupDocs.Metadata.Cloud.Sdk.Model;
using GroupDocs.Metadata.Cloud.Sdk.Model.Requests;
using GroupDocs.Metadata.Cloud.Sdk.Test.Api.Internal;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using GroupDocs.Metadata.Cloud.Sdk.Test.Infrastructure;

namespace GroupDocs.Metadata.Cloud.Sdk.Test.Api
{
    [TestFixture]
    public class TestSetApi : BaseApiTest
    {
        [Test]
        public void SetApiTest()
        {
            var testFile = TestFiles.Docx;
            var options = new SetOptions
            {
                FileInfo = testFile.ToFileInfo(),
                Properties = new List<SetProperty>
                {
                    new SetProperty
                    {
                        NewValue = "NewAuthor",
                        SearchCriteria = new SearchCriteria
                        {
                            TagOptions = new TagOptions
                            {
                                ExactTag = new Tag
                                {
                                    Name = "Creator",
                                    Category = "Person"
                                }
                            }
                        },
                        Type = "String"
                    }
                }
            };

            var request = new SetRequest(options);

            var result = MetadataApi.Set(request);

            Assert.IsNotNull(result);
            Assert.Greater(result.SetCount, 0);
        }

        [Test]
        public void SetApiTest_Integer()
        {
            var testFile = TestFiles.Docx;
            var options = new SetOptions
            {
                FileInfo = testFile.ToFileInfo(),
                Properties = new List<SetProperty>
                {
                    new SetProperty
                    {
                        NewValue = "14",
                        SearchCriteria = new SearchCriteria
                        {
                            TagOptions = new TagOptions
                            {
                                ExactTag = new Tag
                                {
                                    Name = "SoftwareVersion",
                                    Category = "Tool"
                                }
                            }
                        },
                        Type = "integer"
                    }
                }
            };

            var request = new SetRequest(options);

            var result = MetadataApi.Set(request);

            Assert.IsNotNull(result);
            Assert.Greater(result.SetCount, 0);
        }

        [Test]
        public void SetApiTest_DateTime()
        {
            var testFile = TestFiles.Xlsx;
            var now = DateTime.Now;
            var options = new SetOptions
            {
                FileInfo = testFile.ToFileInfo(),
                Properties = new List<SetProperty>
                {
                    new SetProperty
                    {
                        NewValue = now.ToString("MM-dd-yyyy hh:mm:ss"),
                        Type = "DateTime",
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
                        },
                    }
                }
            };

            var request = new SetRequest(options);

            var result = MetadataApi.Set(request);

            Assert.IsNotNull(result);
            Assert.Greater(result.SetCount, 0);
        }

        [Test]
        public void SetApiTest_PossibleTagName()
        {
            var testFile = TestFiles.Xlsx;

            var options = new SetOptions
            {
                FileInfo = testFile.ToFileInfo(),
                Properties = new List<SetProperty>
                {
                    new SetProperty
                    {
                        NewValue = "New Creator",
                        Type = "String",
                        SearchCriteria = new SearchCriteria
                        {
                            TagOptions = new TagOptions
                            {
                                PossibleName = "creator"
                            }
                        },
                    }
                }
            };

            var request = new SetRequest(options);

            var result = MetadataApi.Set(request);
            Assert.IsNotNull(result);
            Assert.IsNotEmpty(result.Path);
            Assert.IsNotEmpty(result.Url);
            Assert.Greater(result.SetCount, 0);
        }

        [Test]
        public void SetApiTest_PropertyName()
        {
            var testFile = TestFiles.Docx;
            var now = DateTime.Now.ToString("MM-dd-yyyy hh:mm:ss");

            var options = new SetOptions
            {
                FileInfo = testFile.ToFileInfo(),
                Properties = new List<SetProperty>
                {
                    new SetProperty
                    {
                        NewValue = now,
                        Type = "DateTime",
                        SearchCriteria = new SearchCriteria
                        {
                            NameOptions = new NameOptions
                            {
                                Value = "Date"
                            }
                        },
                    }
                }
            };

            var request = new SetRequest(options);

            var result = MetadataApi.Set(request);
            Assert.IsNotNull(result);
            Assert.IsNotEmpty(result.Path);
            Assert.IsNotEmpty(result.Url);
            Assert.Greater(result.SetCount, 0);
        }

        [Test]
        public void SetApiTest_PropertyNameExactPhrase()
        {
            var testFile = TestFiles.Docx;

            var options = new SetOptions
            {
                FileInfo = testFile.ToFileInfo(),
                Properties = new List<SetProperty>
                {
                    new SetProperty
                    {
                        NewValue = "microsoft word office",
                        Type = "String",
                        SearchCriteria = new SearchCriteria
                        {
                            NameOptions = new NameOptions
                            {
                                Value = "NameOfApplication",
                                MatchOptions = new MatchOptions
                                {
                                    ExactPhrase = true
                                }
                            }
                        },
                    }
                }
            };

            var request = new SetRequest(options);

            var result = MetadataApi.Set(request);
            Assert.IsNotNull(result);
            Assert.IsNotEmpty(result.Path);
            Assert.IsNotEmpty(result.Url);
            Assert.Greater(result.SetCount, 0);
        }

        [Test]
        public void SetApiTest_PropertyNameRegex()
        {
            var testFile = TestFiles.Docx;

            var options = new SetOptions
            {
                FileInfo = testFile.ToFileInfo(),
                Properties = new List<SetProperty>
                {
                    new SetProperty
                    {
                        NewValue = "new value",
                        Type = "String",
                        SearchCriteria = new SearchCriteria
                        {
                            NameOptions = new NameOptions
                            {
                                Value = "^NameOfApp.*",
                                MatchOptions = new MatchOptions
                                {
                                    IsRegex = true
                                }
                            }
                        },
                    }
                }
            };

            var request = new SetRequest(options);

            var result = MetadataApi.Set(request);
            Assert.IsNotNull(result);
            Assert.IsNotEmpty(result.Path);
            Assert.IsNotEmpty(result.Url);
            Assert.Greater(result.SetCount, 0);
        }

        [Test]
        public void SetApiTest_PropertyValue()
        {
            var testFile = TestFiles.Docx;

            var options = new SetOptions
            {
                FileInfo = testFile.ToFileInfo(),
                Properties = new List<SetProperty>
                {
                    new SetProperty
                    {
                        NewValue = "Microsoft Office Word Application",
                        Type = "String",
                        SearchCriteria = new SearchCriteria
                        {
                            ValueOptions = new ValueOptions
                            {
                                Value = "Microsoft Office Word",
                                Type = "String"
                            }
                        },
                    }
                }
            };

            var request = new SetRequest(options);

            var result = MetadataApi.Set(request);
            Assert.IsNotNull(result);
            Assert.IsNotEmpty(result.Path);
            Assert.IsNotEmpty(result.Url);
            Assert.Greater(result.SetCount, 0);
        }

        [Test]
        public void SetApiTest_WrongTypeForTag()
        {
            var testFile = TestFiles.Pptx;
            var options = new SetOptions
            {
                FileInfo = testFile.ToFileInfo(),
                Properties = new List<SetProperty>
                {
                    new SetProperty
                    {
                        NewValue = "true",
                        Type = "Boolean",
                        SearchCriteria = new SearchCriteria
                        {
                            TagOptions = new TagOptions
                            {
                                ExactTag = new Tag
                                {
                                    Name = "Creator",
                                    Category = "Person"
                                }
                            }
                        },
                    }
                }
            };

            var request = new SetRequest(options);
            var ex = Assert.Throws<ApiException>(() => { MetadataApi.Set(request); });
            Assert.AreEqual($"There are no changes in metadata.", JsonUtils.GetErrorMessage(ex.Message));
        }

        [Test]
        public void SetApiTest_ValueFormatException()
        {
            var testFile = TestFiles.Jpg;
            var options = new SetOptions
            {
                FileInfo = testFile.ToFileInfo(),
                Properties = new List<SetProperty>
                {
                    new SetProperty
                    {
                        NewValue = "NewAuthor",
                        Type = "Boolean",
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
                        },
                    }
                }
            };

            var request = new SetRequest(options);
            var ex = Assert.Throws<ApiException>(() => { MetadataApi.Set(request); });
            Assert.AreEqual("Request parameters missing or have incorrect format", JsonUtils.GetErrorMessage(ex.Message));
        }

        [Test]
        public void SetApiTest_DocumentProtectedException()
        {
            var testFile = TestFiles.PasswordProtected;
            var options = new SetOptions
            {
                FileInfo = testFile.ToFileInfo(),
                Properties = new List<SetProperty>
                {
                    new SetProperty
                    {
                        NewValue = "NewAuthor",
                        SearchCriteria = new SearchCriteria
                        {
                            TagOptions = new TagOptions
                            {
                                ExactTag = new Tag
                                {
                                    Name = "Creator",
                                    Category = "Person"
                                }
                            }
                        },
                        Type = "String"
                    }
                }
            };

            var request = new SetRequest(options);
            var ex = Assert.Throws<ApiException>(() => { MetadataApi.Set(request); });
            Assert.AreEqual($"The specified file '{testFile.FullName}' is protected.", JsonUtils.GetErrorMessage(ex.Message));
        }

        [Test]
        public void SetApiTest_UnsupportedFormat()
        {
            var testFile = TestFiles.Json;
            var options = new SetOptions
            {
                FileInfo = testFile.ToFileInfo(),
                Properties = new List<SetProperty>
                {
                    new SetProperty
                    {
                        NewValue = "NewAuthor",
                        SearchCriteria = new SearchCriteria
                        {
                            TagOptions = new TagOptions
                            {
                                ExactTag = new Tag
                                {
                                    Name = "Creator",
                                    Category = "Person"
                                }
                            }
                        },
                        Type = "String"
                    }
                }
            };

            var request = new SetRequest(options);
            var ex = Assert.Throws<ApiException>(() => { MetadataApi.Set(request); });
            Assert.AreEqual($"The specified file '{testFile.FullName}' has type which is not currently supported.", JsonUtils.GetErrorMessage(ex.Message));
        }

        [Test]
        public void SetApiTest_FileNotFound()
        {
            var testFile = TestFiles.NotExist;
            var options = new SetOptions
            {
                FileInfo = testFile.ToFileInfo(),
                Properties = new List<SetProperty>
                {
                    new SetProperty
                    {
                        NewValue = "NewAuthor",
                        Type = "Boolean",
                        SearchCriteria = new SearchCriteria
                        {
                            TagOptions = new TagOptions
                            {
                                ExactTag = new Tag
                                {
                                    Name = "Creator",
                                    Category = "Person"
                                }
                            }
                        },
                    }
                }
            };

            var request = new SetRequest(options);
            var ex = Assert.Throws<ApiException>(() => { MetadataApi.Set(request); });
            Assert.AreEqual($"Can't find file located at '{testFile.FullName}'.", JsonUtils.GetErrorMessage(ex.Message));
        }

        [Test]
        public void SetApiTest_NoChanges()
        {
            var testFile = TestFiles.Psd;
            var options = new SetOptions
            {
                FileInfo = testFile.ToFileInfo(),
                Properties = new List<SetProperty>
                {
                    new SetProperty
                    {
                        NewValue = "NewAuthor",
                        Type = "String",
                        SearchCriteria = new SearchCriteria
                        {
                            TagOptions = new TagOptions
                            {
                                ExactTag = new Tag
                                {
                                    Name = "Owner",
                                    Category = "Legal"
                                }
                            }
                        },
                    }
                }
            };

            var request = new SetRequest(options);
            var ex = Assert.Throws<ApiException>(() => { MetadataApi.Set(request); });
            Assert.AreEqual($"There are no changes in metadata.", JsonUtils.GetErrorMessage(ex.Message));
        }
    }
}