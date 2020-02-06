using GroupDocs.Metadata.Cloud.Sdk.Api;
using GroupDocs.Metadata.Cloud.Sdk.Client;
using GroupDocs.Metadata.Cloud.Sdk.Model;
using GroupDocs.Metadata.Cloud.Sdk.Model.Requests;
using GroupDocs.Metadata.Cloud.Sdk.Test.Api.Internal;
using NUnit.Framework;
using System.Linq;

namespace GroupDocs.Metadata.Cloud.Sdk.Test.Api
{
    [TestFixture]
    public class TestTagsApi : BaseApiTest
    {
        [Test]
        public void TagsApiTest()
        {
            var options = new TagsOptions
            {
                FileInfo = TestFiles.Docx.ToFileInfo()
            };

            var request = new TagsRequest(options);

            var result = InfoApi.Tags(request);

            Assert.IsNotNull(result.RootPackage);
            Assert.IsNotEmpty(result.RootPackage.InnerPackages);
            Assert.IsTrue(result.RootPackage.InnerPackages.Any(x => string.Equals(x.PackageName, "FileFormat")));
            Assert.IsTrue(result.RootPackage.InnerPackages.Any(x => x.PackageProperties.First(p => p.Name == "FileFormat").Tags
                                                                     .Select(s => s.Name).Any(e => string.Equals(e, "FileFormat"))));
        }

        [Test]
        public void Tags_DocumentProtectedException()
        {
            var testFile = TestFiles.PasswordProtected;
            var options = new TagsOptions
            {
                FileInfo = testFile.ToFileInfo(),
            };

            var request = new TagsRequest(options);
            var ex = Assert.Throws<ApiException>(() => { InfoApi.Tags(request); });
            Assert.AreEqual($"The specified file '{testFile.FullName}' is protected.", ex.Message);
        }

        [Test]
        public void Tags_UnsupportedFormat()
        {
            var testFile = TestFiles.Json;
            var options = new TagsOptions
            {
                FileInfo = testFile.ToFileInfo()
            };

            var request = new TagsRequest(options);
            var ex = Assert.Throws<ApiException>(() => { InfoApi.Tags(request); });
            Assert.AreEqual($"The specified file '{testFile.FullName}' has type which is not currently supported.", ex.Message);
        }

        [Test]
        public void Tags_FileNotFound()
        {
            var testFile = TestFiles.NotExist;
            var options = new TagsOptions
            {
                FileInfo = testFile.ToFileInfo(),
            };

            var request = new TagsRequest(options);

            var ex = Assert.Throws<ApiException>(() => { InfoApi.Tags(request); });
            Assert.AreEqual($"Can't find file located at '{testFile.FullName}'.", ex.Message);
        }
    }
}