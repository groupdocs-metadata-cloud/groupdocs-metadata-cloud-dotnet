// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Aspose Pty Ltd" file="InfoApi.cs">
//  Copyright (c) 2003-2019 Aspose Pty Ltd
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

namespace GroupDocs.Metadata.Cloud.Sdk.Api
{
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using GroupDocs.Metadata.Cloud.Sdk.Client;
    using GroupDocs.Metadata.Cloud.Sdk.Client.RequestHandlers;
    using GroupDocs.Metadata.Cloud.Sdk.Model;
    using GroupDocs.Metadata.Cloud.Sdk.Model.Requests;
    
    /// <summary>
    /// GroupDocs.Metadata Cloud API.
    /// </summary>
    public class InfoApi
    {        
        private readonly ApiInvoker apiInvoker;
        private readonly Configuration configuration;     

        /// <summary>
        /// Initializes a new instance of the <see cref="InfoApi"/> class.
        /// </summary>
        /// <param name="appSid">Application identifier (App SID)</param>
        /// <param name="appKey">Application private key (App Key)</param>
        public InfoApi(string appSid, string appKey)
            : this(new Configuration(appSid, appKey))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InfoApi"/> class.
        /// </summary>    
        /// <param name="configuration">Configuration settings</param>
        public InfoApi(Configuration configuration)
        {
            this.configuration = configuration;
            
            var requestHandlers = new List<IRequestHandler>();
            requestHandlers.Add(new AuthRequestHandler(this.configuration));
            requestHandlers.Add(new DebugLogRequestHandler(this.configuration));
            requestHandlers.Add(new ApiExceptionRequestHandler());
            this.apiInvoker = new ApiInvoker(requestHandlers, this.configuration.Timeout);
        }                            

        /// <summary>
        /// Retrieve information about document. 
        /// </summary>
        /// <param name="request">Request. <see cref="GetInfoRequest" /></param>
        /// <returns><see cref="InfoResult"/></returns>
        public InfoResult GetInfo(GetInfoRequest request)
        {
            // verify the required parameter 'options' is set
            if (request.options == null) 
            {
                throw new ApiException(400, "Missing required parameter 'options' when calling GetInfo");
            }

            // create path and map variables
            var resourcePath = this.configuration.GetServerUrl() + "/metadata/info";
            resourcePath = Regex
                        .Replace(resourcePath, "\\*", string.Empty)
                        .Replace("&amp;", "&")
                        .Replace("/?", "?");
            var postBody = SerializationHelper.Serialize(request.options); // http body (model) parameter
            var response = this.apiInvoker.InvokeApi(
                resourcePath, 
                "POST", 
                postBody, 
                null, 
                null);

            if (response != null)
            {
                return (InfoResult)SerializationHelper.Deserialize(response, typeof(InfoResult));
            }

            return null;
        }

        /// <summary>
        /// List supported file formats. 
        /// </summary>
        /// <returns><see cref="FormatsResult"/></returns>
        public FormatsResult GetSupportedFileFormats()
        {
            // create path and map variables
            var resourcePath = this.configuration.GetServerUrl() + "/metadata/formats";
            resourcePath = Regex
                        .Replace(resourcePath, "\\*", string.Empty)
                        .Replace("&amp;", "&")
                        .Replace("/?", "?");
            
            var response = this.apiInvoker.InvokeApi(
                resourcePath, 
                "GET", 
                null, 
                null, 
                null);

            if (response != null)
            {
                return (FormatsResult)SerializationHelper.Deserialize(response, typeof(FormatsResult));
            }

            return null;
        }

        /// <summary>
        /// Retrieve information about metadata packages, properties and tags. 
        /// </summary>
        /// <param name="request">Request. <see cref="TagsRequest" /></param>
        /// <returns><see cref="TagsResult"/></returns>
        public TagsResult Tags(TagsRequest request)
        {
            // verify the required parameter 'options' is set
            if (request.options == null) 
            {
                throw new ApiException(400, "Missing required parameter 'options' when calling Tags");
            }

            // create path and map variables
            var resourcePath = this.configuration.GetServerUrl() + "/metadata/tags";
            resourcePath = Regex
                        .Replace(resourcePath, "\\*", string.Empty)
                        .Replace("&amp;", "&")
                        .Replace("/?", "?");
            var postBody = SerializationHelper.Serialize(request.options); // http body (model) parameter
            var response = this.apiInvoker.InvokeApi(
                resourcePath, 
                "POST", 
                postBody, 
                null, 
                null);

            if (response != null)
            {
                return (TagsResult)SerializationHelper.Deserialize(response, typeof(TagsResult));
            }

            return null;
        }
    }
}
// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Aspose Pty Ltd" file="GetInfoRequest.cs">
//  Copyright (c) 2003-2019 Aspose Pty Ltd
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

namespace GroupDocs.Metadata.Cloud.Sdk.Model.Requests 
{
    using GroupDocs.Metadata.Cloud.Sdk.Model; 

    /// <summary>
    /// Request model for <see cref="GroupDocs.Metadata.Cloud.Sdk.Api.InfoApi.GetInfo" /> operation.
    /// </summary>  
    public class GetInfoRequest  
    {
          /// <summary>
          /// Initializes a new instance of the <see cref="GetInfoRequest"/> class.
          /// </summary>        
          public GetInfoRequest()
          {
          }

          /// <summary>
          /// Initializes a new instance of the <see cref="GetInfoRequest"/> class.
          /// </summary>
          /// <param name="options">Info options.</param>
          public GetInfoRequest(InfoOptions options)             
          {
              this.options = options;
          }
          
          /// <summary>
          /// Info options.
          /// </summary>  
          public InfoOptions options { get; set; }
    }
}
// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Aspose Pty Ltd" file="TagsRequest.cs">
//  Copyright (c) 2003-2019 Aspose Pty Ltd
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

namespace GroupDocs.Metadata.Cloud.Sdk.Model.Requests 
{
    using GroupDocs.Metadata.Cloud.Sdk.Model; 

    /// <summary>
    /// Request model for <see cref="GroupDocs.Metadata.Cloud.Sdk.Api.InfoApi.Tags" /> operation.
    /// </summary>  
    public class TagsRequest  
    {
          /// <summary>
          /// Initializes a new instance of the <see cref="TagsRequest"/> class.
          /// </summary>        
          public TagsRequest()
          {
          }

          /// <summary>
          /// Initializes a new instance of the <see cref="TagsRequest"/> class.
          /// </summary>
          /// <param name="options">Tags options.</param>
          public TagsRequest(TagsOptions options)             
          {
              this.options = options;
          }
          
          /// <summary>
          /// Tags options.
          /// </summary>  
          public TagsOptions options { get; set; }
    }
}
