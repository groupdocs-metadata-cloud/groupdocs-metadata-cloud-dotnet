// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Aspose Pty Ltd" file="MetadataPackage.cs">
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

namespace GroupDocs.Metadata.Cloud.Sdk.Model 
{
    using System;  
    using System.Collections;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using System.Text;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    
    /// <summary>
    /// Metadata package
    /// </summary>  
    public class MetadataPackage 
    {                       
        /// <summary>
        /// Name of the metadata package.
        /// </summary>  
        public string PackageName { get; set; }

        /// <summary>
        /// Properties of the metadata package.
        /// </summary>  
        public List<MetadataProperty> PackageProperties { get; set; }

        /// <summary>
        /// Inner packages of current metadata package.
        /// </summary>  
        public List<MetadataPackage> InnerPackages { get; set; }

        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()  
        {
          var sb = new StringBuilder();
          sb.Append("class MetadataPackage {\n");
          sb.Append("  PackageName: ").Append(this.PackageName).Append("\n");
          sb.Append("  PackageProperties: ").Append(this.PackageProperties).Append("\n");
          sb.Append("  InnerPackages: ").Append(this.InnerPackages).Append("\n");
          sb.Append("}\n");
          return sb.ToString();
        }
    }
}
