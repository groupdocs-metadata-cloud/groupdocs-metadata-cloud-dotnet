using GroupDocs.Metadata.Cloud.Sdk.Client;
using GroupDocs.Metadata.Cloud.Sdk.Model;
using GroupDocs.Metadata.Cloud.Sdk.Model.Requests;
using GroupDocs.Metadata.Cloud.Sdk.Test.Api.Internal;
using NUnit.Framework;

namespace GroupDocs.Metadata.Cloud.Sdk.Test.Api
{
    [TestFixture]
    public class TestInfoApi : BaseApiTest
    {
        [Test]
        public void InfoHandlerTest_Slides()
        {
            var options = new InfoOptions { FileInfo = TestFiles.Pptx.ToFileInfo()};
            var request = new GetInfoRequest(options);

            var result = InfoApi.GetInfo(request);
            Assert.IsNotNull(result);
            Assert.AreEqual("PRESENTATION", result.FileType.FileFormat.ToUpper());
            Assert.AreEqual(1, result.PageCount);
        }

        [Test]
        public void InfoHandlerTest_Docx()
        {
            var options = new InfoOptions { FileInfo = TestFiles.Docx.ToFileInfo() };
            var request = new GetInfoRequest(options);

            var result = InfoApi.GetInfo(request);
            Assert.IsNotNull(result);
            Assert.AreEqual("APPLICATION/VND.OPENXMLFORMATS-OFFICEDOCUMENT.WORDPROCESSINGML.DOCUMENT", result.FileType.MimeType.ToUpper());
            Assert.AreEqual(1, result.PageCount);
        }

        [Test]
        public void InfoHandlerTest_Xlsx()
        {
            var options = new InfoOptions { FileInfo = TestFiles.Xlsx.ToFileInfo() };
            var request = new GetInfoRequest(options);

            var result = InfoApi.GetInfo(request);
            Assert.IsNotNull(result);
            Assert.AreEqual("APPLICATION/VND.OPENXMLFORMATS-OFFICEDOCUMENT.SPREADSHEETML.SHEET", result.FileType.MimeType.ToUpper());
            Assert.AreEqual(3, result.PageCount);
        }

        [Test]
        public void InfoHandlerTest_Jpeg()
        {
            var options = new InfoOptions { FileInfo = TestFiles.Jpg.ToFileInfo() };
            var request = new GetInfoRequest(options);

            var result = InfoApi.GetInfo(request);
            Assert.IsNotNull(result);
            Assert.AreEqual("IMAGE/JPEG", result.FileType.MimeType.ToUpper());
            Assert.AreEqual(1, result.PageCount);
        }

        [Test]
        public void InfoApiTest_FileNotFoundResult()
        {
            var options = new InfoOptions { FileInfo = TestFiles.NotExist.ToFileInfo() };
            var request = new GetInfoRequest(options);

            var ex = Assert.Throws<ApiException>(() => { InfoApi.GetInfo(request); });
            Assert.AreEqual($"Can't find file located at '{TestFiles.NotExist.FullName}'.", ex.Message);
        }

        [Test]
        public void InfoApiTest_Not_Supported()
        {
            var testFile = TestFiles.Json;
            var options = new InfoOptions { FileInfo = testFile.ToFileInfo() };
            var request = new GetInfoRequest(options);

            var ex = Assert.Throws<ApiException>(() => { InfoApi.GetInfo(request); });
            Assert.AreEqual($"The file format is not supported at the moment. Basic operations are not implemented for the loaded file", ex.Message);
        }
    }
}