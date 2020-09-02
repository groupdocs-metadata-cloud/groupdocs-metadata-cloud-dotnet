# GroupDocs.Metadata Cloud SDK for .NET
This repository contains GroupDocs.Metadata Cloud SDK for .NET source code. This SDK allows you to work with GroupDocs.Metadata Cloud REST APIs in your .NET applications.

## How to use the SDK?
The complete source code is available in this repository folder, you can either directly use it in your project via NuGet package manager. For more details, please visit our [documentation website](https://docs.groupdocs.cloud/metadata/available-sdks/).

## Dependencies
- [Json.NET](https://www.nuget.org/packages/Newtonsoft.Json)

## Getting Started

```csharp
using System;
using System.Diagnostics;
using GroupDocs.Metadata.Cloud.Sdk.Api;

namespace Example
{
    public class Example
    {
        public void Main()
        {
            //TODO: Get your AppSID and AppKey at https://dashboard.groupdocs.cloud (free registration is required).
            var appSid = "XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX";
            var appKey = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX";

            var api = new MetadataApi(appSid, appKey);

            try
            {
                // Get supported file formats
                var response = api.GetSupportedFileFormats();

                foreach (var format in response.Formats)
                {
                    Debug.Print(format.ToString());
                }
            }
            catch (Exception e)
            {
                Debug.Print("Something went wrong: " + e.Message);
            }
        }
    }
}
```

## Licensing
All GroupDocs.Metadata Cloud SDKs are licensed under [MIT License](LICENSE).

[Home](https://www.groupdocs.cloud/) | [Product Page](https://products.groupdocs.cloud/metadata/net) | [Docs](https://docs.groupdocs.cloud/metadata/) | [Demos](https://products.groupdocs.app/metadata/family) | [API Reference](https://apireference.groupdocs.cloud/metadata/) | [Examples](https://github.com/groupdocs-metadata-cloud/groupdocs-metadata-cloud-dotnet-samples) | [Blog](https://blog.groupdocs.cloud/category/metadata/) | [Free Support](https://forum.groupdocs.cloud/c/metadata) | [Free Trial](https://purchase.groupdocs.cloud/trial)
