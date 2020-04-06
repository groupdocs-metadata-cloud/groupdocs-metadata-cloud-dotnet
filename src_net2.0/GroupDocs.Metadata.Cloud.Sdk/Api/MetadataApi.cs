// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Aspose Pty Ltd" file="MetadataApi.cs">
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
    public class MetadataApi
    {        
        private readonly ApiInvoker apiInvoker;
        private readonly Configuration configuration;     

        /// <summary>
        /// Initializes a new instance of the <see cref="MetadataApi"/> class.
        /// </summary>
        /// <param name="appSid">Application identifier (App SID)</param>
        /// <param name="appKey">Application private key (App Key)</param>
        public MetadataApi(string appSid, string appKey)
            : this(new Configuration(appSid, appKey))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MetadataApi"/> class.
        /// </summary>    
        /// <param name="configuration">Configuration settings</param>
        public MetadataApi(Configuration configuration)
        {
            this.configuration = configuration;
            
            var requestHandlers = new List<IRequestHandler>();
            requestHandlers.Add(new AuthRequestHandler(this.configuration));
            requestHandlers.Add(new DebugLogRequestHandler(this.configuration));
            requestHandlers.Add(new ApiExceptionRequestHandler());
            this.apiInvoker = new ApiInvoker(requestHandlers, this.configuration.Timeout);
        }                            

        /// <summary>
        /// Add new metadata fields to a file. 
        /// </summary>
        /// <param name="request">Request. <see cref="AddRequest" /></param>
        /// <returns><see cref="AddResult"/></returns>
        public AddResult Add(AddRequest request)
        {
            // verify the required parameter 'options' is set
            if (request.options == null) 
            {
                throw new ApiException(400, "Missing required parameter 'options' when calling Add");
            }

            // create path and map variables
            var resourcePath = this.configuration.GetServerUrl() + "/metadata/add";
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
                return (AddResult)SerializationHelper.Deserialize(response, typeof(AddResult));
            }

            return null;
        }

        /// <summary>
        /// Retrieve document metadata. 
        /// </summary>
        /// <param name="request">Request. <see cref="ExtractRequest" /></param>
        /// <returns><see cref="ExtractResult"/></returns>
        public ExtractResult Extract(ExtractRequest request)
        {
            // verify the required parameter 'options' is set
            if (request.options == null) 
            {
                throw new ApiException(400, "Missing required parameter 'options' when calling Extract");
            }

            // create path and map variables
            var resourcePath = this.configuration.GetServerUrl() + "/metadata";
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
                return (ExtractResult)SerializationHelper.Deserialize(response, typeof(ExtractResult));
            }

            return null;
        }

        /// <summary>
        /// Remove metadata from document using search criteria. 
        /// </summary>
        /// <param name="request">Request. <see cref="RemoveRequest" /></param>
        /// <returns><see cref="RemoveResult"/></returns>
        public RemoveResult Remove(RemoveRequest request)
        {
            // verify the required parameter 'options' is set
            if (request.options == null) 
            {
                throw new ApiException(400, "Missing required parameter 'options' when calling Remove");
            }

            // create path and map variables
            var resourcePath = this.configuration.GetServerUrl() + "/metadata/remove";
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
                return (RemoveResult)SerializationHelper.Deserialize(response, typeof(RemoveResult));
            }

            return null;
        }

        /// <summary>
        /// Set existing metadata fields with new values. 
        /// </summary>
        /// <param name="request">Request. <see cref="SetRequest" /></param>
        /// <returns><see cref="SetResult"/></returns>
        public SetResult Set(SetRequest request)
        {
            // verify the required parameter 'options' is set
            if (request.options == null) 
            {
                throw new ApiException(400, "Missing required parameter 'options' when calling Set");
            }

            // create path and map variables
            var resourcePath = this.configuration.GetServerUrl() + "/metadata/set";
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
                return (SetResult)SerializationHelper.Deserialize(response, typeof(SetResult));
            }

            return null;
        }
    }
}
// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Aspose Pty Ltd" file="AddRequest.cs">
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

namespace GroupDocs.Metadata.Cloud.Sdk.Model.Requests 
{
    using GroupDocs.Metadata.Cloud.Sdk.Model; 

    /// <summary>
    /// Request model for <see cref="GroupDocs.Metadata.Cloud.Sdk.Api.MetadataApi.Add" /> operation.
    /// </summary>  
    public class AddRequest  
    {
          /// <summary>
          /// Initializes a new instance of the <see cref="AddRequest"/> class.
          /// </summary>        
          public AddRequest()
          {
          }

          /// <summary>
          /// Initializes a new instance of the <see cref="AddRequest"/> class.
          /// </summary>
          /// <param name="options">Add options.</param>
          public AddRequest(AddOptions options)             
          {
              this.options = options;
          }
          
          /// <summary>
          /// Add options.
          /// </summary>  
          public AddOptions options { get; set; }
    }
}
// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Aspose Pty Ltd" file="ExtractRequest.cs">
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

namespace GroupDocs.Metadata.Cloud.Sdk.Model.Requests 
{
    using GroupDocs.Metadata.Cloud.Sdk.Model; 

    /// <summary>
    /// Request model for <see cref="GroupDocs.Metadata.Cloud.Sdk.Api.MetadataApi.Extract" /> operation.
    /// </summary>  
    public class ExtractRequest  
    {
          /// <summary>
          /// Initializes a new instance of the <see cref="ExtractRequest"/> class.
          /// </summary>        
          public ExtractRequest()
          {
          }

          /// <summary>
          /// Initializes a new instance of the <see cref="ExtractRequest"/> class.
          /// </summary>
          /// <param name="options">Extract options.</param>
          public ExtractRequest(ExtractOptions options)             
          {
              this.options = options;
          }
          
          /// <summary>
          /// Extract options.
          /// </summary>  
          public ExtractOptions options { get; set; }
    }
}
// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Aspose Pty Ltd" file="RemoveRequest.cs">
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

namespace GroupDocs.Metadata.Cloud.Sdk.Model.Requests 
{
    using GroupDocs.Metadata.Cloud.Sdk.Model; 

    /// <summary>
    /// Request model for <see cref="GroupDocs.Metadata.Cloud.Sdk.Api.MetadataApi.Remove" /> operation.
    /// </summary>  
    public class RemoveRequest  
    {
          /// <summary>
          /// Initializes a new instance of the <see cref="RemoveRequest"/> class.
          /// </summary>        
          public RemoveRequest()
          {
          }

          /// <summary>
          /// Initializes a new instance of the <see cref="RemoveRequest"/> class.
          /// </summary>
          /// <param name="options">Remove options.</param>
          public RemoveRequest(RemoveOptions options)             
          {
              this.options = options;
          }
          
          /// <summary>
          /// Remove options.
          /// </summary>  
          public RemoveOptions options { get; set; }
    }
}
// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Aspose Pty Ltd" file="SetRequest.cs">
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

namespace GroupDocs.Metadata.Cloud.Sdk.Model.Requests 
{
    using GroupDocs.Metadata.Cloud.Sdk.Model; 

    /// <summary>
    /// Request model for <see cref="GroupDocs.Metadata.Cloud.Sdk.Api.MetadataApi.Set" /> operation.
    /// </summary>  
    public class SetRequest  
    {
          /// <summary>
          /// Initializes a new instance of the <see cref="SetRequest"/> class.
          /// </summary>        
          public SetRequest()
          {
          }

          /// <summary>
          /// Initializes a new instance of the <see cref="SetRequest"/> class.
          /// </summary>
          /// <param name="options">Set options.</param>
          public SetRequest(SetOptions options)             
          {
              this.options = options;
          }
          
          /// <summary>
          /// Set options.
          /// </summary>  
          public SetOptions options { get; set; }
    }
}
