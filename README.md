![](https://img.shields.io/badge/api-v2.0-lightgrey) ![Nuget](https://img.shields.io/nuget/v/GroupDocs.Metadata-Cloud) ![Nuget](https://img.shields.io/nuget/dt/GroupDocs.Metadata-Cloud) [![GitHub license](https://img.shields.io/github/license/groupdocs-metadata-cloud/groupdocs-metadata-cloud-dotnet)](https://github.com/groupdocs-metadata-cloud/groupdocs-metadata-cloud-dotnet/blob/master/LICENSE)

# .NET SDK to Manage Documents Metadata in the Cloud

[GroupDocs.Metadata Cloud SDK for .NET](https://products.groupdocs.cloud/metadata/net) wraps GroupDocs.Metadata RESTful APIs so you may integrate **Document Metadata** features in your own apps with zero initial cost.

GroupDocs.Metadata Cloud API allows the developers to perform metadata manipulation operations on documents, images and other popular file formats using cURL commands or independent SDKs for .NET and Java platforms.

## Document Metadata REST API

- Extract metadata from the documents.
- Add metadata properties.
- Set metadata properties.
- Remove metadata properties.
- Obtain all supported metadata formats list.
- Integrated storage API.

Check out the [Developer's Guide](https://docs.groupdocs.cloud/metadata/developer-guide/) to know more about GroupDocs.Metadata REST API.

## Microsoft File Formats

**Microsoft Word:** DOC, DOCX, DOT, DOTX, DOCM\
**Excel:** XLS, XLSX, XLSM, XLTM\
**PowerPoint:** PPT, PPTX, POTM, POTX, PPTM, PPS, PPSX‎, PPSM‎\
**Outlook:** MSG, EML\
**OneNote:** ONE\
**Visio:** VSD, VDX, VSDX, VSS, VSX\
**Project:** MPP\

## Other Formats

**OpenDocument:** ODT, ODS\
**Portable:** PDF\
**Photoshop:** PSD\
**AutoCAD:** DWG, DXF\
**Audio:** MP3, WAV\
**Video:** AVI, MOV, QT, FLV\
**Metafiles:** EMF, WMF\
**vCard:** VCF‎, VCR\
**Image:** JPG, JPEG, JPE, JP2, PNG, GIF, TIFF, WebP, BMP, DJVU, DJV, DICOM‎\
**OpenType Fonts:** OTF, OTC, TTF, TTC\‎
**Others:** EPUB, ZIP, TORRENT, ASF\

## Get Started with GroupDocs.Metadata Cloud SDK for .NET

First create an account at [GroupDocs for Cloud](https://dashboard.groupdocs.cloud/) and get your application information. Next,  execute `Install-Package GroupDocs.Metadata-Cloud` from Package Manager Console in Visual Studio to fetch & reference the SDK in your project. If you already have the package and wish to upgrade it, please execute `Update-Package GroupDocs.Metadata-Cloud` to get the latest version.

### Dependencies

- [Json.NET](https://www.nuget.org/packages/Newtonsoft.Json)

## Get Supported File Formats for Metadata

```csharp
// Get Client Id and Client Secret from https://dashboard.groupdocs.cloud
string MyClientId = "";
string MyClientSecret = "";

// Create instance of the API
var configuration = new Configuration(MyClientId, MyClientSecret);
var api = new InfoApi(configuration);

// Get supported file formats
var response = api.GetSupportedFileFormats();

foreach (var format in response.Formats)
{
	Debug.Print(format.ToString());
}
```

## GroupDocs.Metadata Cloud SDKs in Popular Languages

| .NET | Java | PHP | Python | Ruby | Node.js | Android |
|---|---|---|---|---|---|---|
| [GitHub](https://github.com/groupdocs-metadata-cloud/groupdocs-metadata-cloud-dotnet) | [GitHub](https://github.com/groupdocs-metadata-cloud/groupdocs-metadata-cloud-java) | [GitHub](https://github.com/groupdocs-metadata-cloud/groupdocs-metadata-cloud-php) | [GitHub](https://github.com/groupdocs-metadata-cloud/groupdocs-metadata-cloud-python) | [GitHub](https://github.com/groupdocs-metadata-cloud/groupdocs-metadata-cloud-ruby)  | [GitHub](https://github.com/groupdocs-metadata-cloud/groupdocs-metadata-cloud-node) | [GitHub](https://github.com/groupdocs-metadata-cloud/groupdocs-metadata-cloud-android) |
| [NuGet](https://www.nuget.org/packages/GroupDocs.Metadata-Cloud/) | [Maven](https://repository.groupdocs.cloud/webapp/#/artifacts/browse/tree/General/repo/com/groupdocs/groupdocs-metadata-cloud) |  |  |   |  |  |

[Home](https://www.groupdocs.cloud/) | [Product Page](https://products.groupdocs.cloud/metadata/net) | [Documentation](https://docs.groupdocs.cloud/metadata/) | [Live Demo](https://products.groupdocs.app/metadata/total) | [API Reference](https://apireference.groupdocs.cloud/metadata/) | [Code Samples](https://github.com/groupdocs-metadata-cloud/groupdocs-metadata-cloud-dotnet-samples) | [Blog](https://blog.groupdocs.cloud/category/metadata/) | [Free Support](https://forum.groupdocs.cloud/c/metadata) | [Free Trial](https://dashboard.groupdocs.cloud)
