using GroupDocs.Metadata.Cloud.Sdk.Api;
using GroupDocs.Metadata.Cloud.Sdk.Client;
using GroupDocs.Metadata.Cloud.Sdk.Model;
using GroupDocs.Metadata.Cloud.Sdk.Model.Requests;
using GroupDocs.Metadata.Cloud.Sdk.Test.Api.Internal;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace GroupDocs.Metadata.Cloud.Sdk.Test.Api
{
    [TestFixture]
    public class TestAddApi : BaseApiTest
    {
        [Test]
        public void AddApiTest()
        {
            var now = DateTime.Now.ToString("MM-dd-yyyy hh:mm:ss");
            var testFile = TestFiles.Docx;
            var options = new AddOptions
            {
                FileInfo = testFile.ToFileInfo(),
                Properties = new List<AddProperty>
                {
                    new AddProperty
                    {
                        SearchCriteria = new SearchCriteriaWithoutValue
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
                        Value = now,
                        Type = "DateTime"
                    }
                }
            };

            var request = new AddRequest(options);

            var result = MetadataApi.Add(request);

            Assert.IsNotNull(result);
            Assert.Greater(result.AddedCount, 0);
        }

        [Test]
        public void AddApiTest_PossibleTagName()
        {
            var testFile = TestFiles.Xlsx;
            var now = DateTime.Now.ToString("MM-dd-yyyy hh:mm:ss");

            var options = new AddOptions
            {
                FileInfo = testFile.ToFileInfo(),
                Properties = new List<AddProperty>
                {
                    new AddProperty
                    {
                        Value = now,
                        Type = "DateTime",
                        SearchCriteria = new SearchCriteria
                        {
                            TagOptions = new TagOptions
                            {
                                PossibleName = "timeprinted"
                            }
                        },
                    }
                }
            };

            var request = new AddRequest(options);

            var result = MetadataApi.Add(request);
            Assert.IsNotNull(result);
            Assert.IsNotEmpty(result.Path);
            Assert.IsNotEmpty(result.Url);
            Assert.Greater(result.AddedCount, 0);
        }

        [Test]
        public void AddApiTest_PropertyName()
        {
            var testFile = TestFiles.Doc;
            var now = DateTime.Now.ToString("MM-dd-yyyy hh:mm:ss");

            var options = new AddOptions
            {
                FileInfo = testFile.ToFileInfo(),
                Properties = new List<AddProperty>
                {
                    new AddProperty
                    {
                        Value = now,
                        Type = "DateTime",
                        SearchCriteria = new SearchCriteria
                        {
                            NameOptions = new NameOptions
                            {
                                Value = "print"
                            }
                        },
                    }
                }
            };

            var request = new AddRequest(options);

            var result = MetadataApi.Add(request);
            Assert.IsNotNull(result);
            Assert.IsNotEmpty(result.Path);
            Assert.IsNotEmpty(result.Url);
            Assert.Greater(result.AddedCount, 0);
        }

        [Test]
        public void AddApiTest_PropertyNameWholeWord()
        {
            var testFile = TestFiles.Doc;
            var now = DateTime.Now.ToString("MM-dd-yyyy hh:mm:ss");

            var options = new AddOptions
            {
                FileInfo = testFile.ToFileInfo(),
                Properties = new List<AddProperty>
                {
                    new AddProperty
                    {
                        Value = now,
                        Type = "DateTime",
                        SearchCriteria = new SearchCriteria
                        {
                            NameOptions = new NameOptions
                            {
                                Value = "Lastprinted",
                                MatchOptions = new MatchOptions
                                {
                                    WholeWord = true
                                }
                            }
                        },
                    }
                }
            };

            var request = new AddRequest(options);

            var result = MetadataApi.Add(request);
            Assert.IsNotNull(result);
            Assert.IsNotEmpty(result.Path);
            Assert.IsNotEmpty(result.Url);
            Assert.Greater(result.AddedCount, 0);
        }

        [Test]
        public void AddApiTest_PropertyNameRegex()
        {
            var testFile = TestFiles.Docx;
            var now = DateTime.Now.ToString("MM-dd-yyyy hh:mm:ss");

            var options = new AddOptions
            {
                FileInfo = testFile.ToFileInfo(),
                Properties = new List<AddProperty>
                {
                    new AddProperty
                    {
                        Value = now,
                        Type = "DateTime",
                        SearchCriteria = new SearchCriteria
                        {
                            NameOptions = new NameOptions
                            {
                                Value = "^.*print.*",
                                MatchOptions = new MatchOptions
                                {
                                    IsRegex = true
                                }
                            }
                        },
                    }
                }
            };

            var request = new AddRequest(options);

            var result = MetadataApi.Add(request);
            Assert.IsNotNull(result);
            Assert.IsNotEmpty(result.Path);
            Assert.IsNotEmpty(result.Url);
            Assert.Greater(result.AddedCount, 0);
        }

        [Test]
        public void AddApiTestWrongValueTypeForTag()
        {
            var testFile = TestFiles.Docx;
            var options = new AddOptions
            {
                FileInfo = testFile.ToFileInfo(),
                Properties = new List<AddProperty>
                {
                    new AddProperty
                    {
                        SearchCriteria = new SearchCriteriaWithoutValue
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
                        Value = "New Value",
                        Type = "String"
                    }
                }
            };

            var request = new AddRequest(options);

            var ex = Assert.Throws<ApiException>(() => { MetadataApi.Add(request); });
            Assert.AreEqual($"There are no changes in metadata.", ex.Message);
        }

        [Test]
        public void AddApiTest_ValueFormatException()
        {
            var testFile = TestFiles.Jpg;
            var options = new AddOptions
            {
                FileInfo = testFile.ToFileInfo(),
                Properties = new List<AddProperty>
                {
                    new AddProperty
                    {
                        SearchCriteria = new SearchCriteriaWithoutValue
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
                        Value = "New Value",
                        Type = "DateTime"
                    }
                }
            };

            var request = new AddRequest(options);
            var ex = Assert.Throws<ApiException>(() => { MetadataApi.Add(request); });
            Assert.AreEqual(ex.Message, "Request parameters missing or have incorrect format");
        }

        [Test]
        public void AddApiTest_DocumentProtectedException()
        {
            var testFile = TestFiles.PasswordProtected;
            var options = new AddOptions
            {
                FileInfo = testFile.ToFileInfo(),
                Properties = new List<AddProperty>
                {
                    new AddProperty
                    {
                        SearchCriteria = new SearchCriteriaWithoutValue
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
                        Value = "New Value",
                        Type = "String"
                    }
                }
            };

            var request = new AddRequest(options);

            var ex = Assert.Throws<ApiException>(() => { MetadataApi.Add(request); });
            Assert.AreEqual($"The specified file '{testFile.FullName}' is protected.", ex.Message);
        }

        [Test]
        public void AddApiTest_UnsupportedFormat()
        {
            var testFile = TestFiles.Json;
            var options = new AddOptions
            {
                FileInfo = testFile.ToFileInfo(),
                Properties = new List<AddProperty>
                {
                    new AddProperty
                    {
                        SearchCriteria = new SearchCriteriaWithoutValue
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
                        Value = "New Value",
                        Type = "String"
                    }
                }
            };

            var request = new AddRequest(options);

            var ex = Assert.Throws<ApiException>(() => { MetadataApi.Add(request); });
            Assert.AreEqual($"The specified file '{testFile.FullName}' has type which is not currently supported.", ex.Message);
        }

        [Test]
        public void AddApiTest_FileNotFound()
        {
            var testFile = TestFiles.NotExist;
            var options = new AddOptions
            {
                FileInfo = testFile.ToFileInfo(),
                Properties = new List<AddProperty>
                {
                    new AddProperty
                    {
                        SearchCriteria = new SearchCriteriaWithoutValue
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
                        Value = "New Value",
                        Type = "String"
                    }
                }
            };

            var request = new AddRequest(options);

            var ex = Assert.Throws<ApiException>(() => { MetadataApi.Add(request); });
            Assert.AreEqual($"Can't find file located at '{testFile.FullName}'.", ex.Message);
        }
    }
}