// 
// Copyright (c) Microsoft and contributors.  All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// 
// See the License for the specific language governing permissions and
// limitations under the License.
// 

// Warning: This code was generated by a tool.
// 
// Changes to this file may cause incorrect behavior and will be lost if the
// code is regenerated.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Common;
using Microsoft.WindowsAzure.Common.Internals;
using Microsoft.WindowsAzure.Management.WebSites;
using Microsoft.WindowsAzure.Management.WebSites.Models;

namespace Microsoft.WindowsAzure.Management.WebSites
{
    /// <summary>
    /// The Web Sites Management API provides a RESTful set of web services
    /// that interact with the Windows Azure Web Sites service to manage your
    /// web sites. The API has entities that capture the relationship between
    /// an end user and Windows Azure Web Sites service.  (see
    /// http://msdn.microsoft.com/en-us/library/windowsazure/dn166981.aspx for
    /// more information)
    /// </summary>
    public partial class WebSiteManagementClient : ServiceClient<WebSiteManagementClient>, Microsoft.WindowsAzure.Management.WebSites.IWebSiteManagementClient
    {
        private Uri _baseUri;
        
        /// <summary>
        /// The URI used as the base for all Service Management requests.
        /// </summary>
        public Uri BaseUri
        {
            get { return this._baseUri; }
        }
        
        private SubscriptionCloudCredentials _credentials;
        
        /// <summary>
        /// When you create an Azure subscription, it is uniquely identified by
        /// a subscription ID. The subscription ID forms part of the URI for
        /// every call that you make to the Service Management API. The Azure
        /// Service Management API uses mutual authentication of management
        /// certificates over SSL to ensure that a request made to the service
        /// is secure. No anonymous requests are allowed.
        /// </summary>
        public SubscriptionCloudCredentials Credentials
        {
            get { return this._credentials; }
        }
        
        private IServerFarmOperations _serverFarms;
        
        /// <summary>
        /// Operations for managing the server farm in a web space.  (see
        /// http://msdn.microsoft.com/en-us/library/windowsazure/dn194277.aspx
        /// for more information)
        /// </summary>
        public virtual IServerFarmOperations ServerFarms
        {
            get { return this._serverFarms; }
        }
        
        private IWebSiteOperations _webSites;
        
        /// <summary>
        /// Operations for managing the web sites in a web space.  (see
        /// http://msdn.microsoft.com/en-us/library/windowsazure/dn166981.aspx
        /// for more information)
        /// </summary>
        public virtual IWebSiteOperations WebSites
        {
            get { return this._webSites; }
        }
        
        private IWebSpaceOperations _webSpaces;
        
        /// <summary>
        /// Operations for managing web spaces beneath your subscription.
        /// </summary>
        public virtual IWebSpaceOperations WebSpaces
        {
            get { return this._webSpaces; }
        }
        
        /// <summary>
        /// Initializes a new instance of the WebSiteManagementClient class.
        /// </summary>
        private WebSiteManagementClient()
            : base()
        {
            this._serverFarms = new ServerFarmOperations(this);
            this._webSites = new WebSiteOperations(this);
            this._webSpaces = new WebSpaceOperations(this);
            this.HttpClient.Timeout = TimeSpan.FromSeconds(300);
        }
        
        /// <summary>
        /// Initializes a new instance of the WebSiteManagementClient class.
        /// </summary>
        /// <param name='credentials'>
        /// Required. When you create an Azure subscription, it is uniquely
        /// identified by a subscription ID. The subscription ID forms part of
        /// the URI for every call that you make to the Service Management
        /// API. The Azure Service Management API uses mutual authentication
        /// of management certificates over SSL to ensure that a request made
        /// to the service is secure. No anonymous requests are allowed.
        /// </param>
        /// <param name='baseUri'>
        /// Required. The URI used as the base for all Service Management
        /// requests.
        /// </param>
        public WebSiteManagementClient(SubscriptionCloudCredentials credentials, Uri baseUri)
            : this()
        {
            if (credentials == null)
            {
                throw new ArgumentNullException("credentials");
            }
            if (baseUri == null)
            {
                throw new ArgumentNullException("baseUri");
            }
            this._credentials = credentials;
            this._baseUri = baseUri;
            
            this.Credentials.InitializeServiceClient(this);
        }
        
        /// <summary>
        /// Initializes a new instance of the WebSiteManagementClient class.
        /// </summary>
        /// <param name='credentials'>
        /// Required. When you create an Azure subscription, it is uniquely
        /// identified by a subscription ID. The subscription ID forms part of
        /// the URI for every call that you make to the Service Management
        /// API. The Azure Service Management API uses mutual authentication
        /// of management certificates over SSL to ensure that a request made
        /// to the service is secure. No anonymous requests are allowed.
        /// </param>
        public WebSiteManagementClient(SubscriptionCloudCredentials credentials)
            : this()
        {
            if (credentials == null)
            {
                throw new ArgumentNullException("credentials");
            }
            this._credentials = credentials;
            this._baseUri = new Uri("https://management.core.windows.net");
            
            this.Credentials.InitializeServiceClient(this);
        }
        
        /// <summary>
        /// The Get Operation Status operation returns the status of the
        /// specified operation. After calling a long-running operation, you
        /// can call Get Operation Status to determine whether the operation
        /// has succeeded, failed, timed out, or is still in progress.  (see
        /// http://msdn.microsoft.com/en-us/library/windowsazure/ee460783.aspx
        /// for more information)
        /// </summary>
        /// <param name='webSpaceName'>
        /// Required. The name of the webspace for the website where the
        /// operation was targeted.
        /// </param>
        /// <param name='siteName'>
        /// Required. The name of the site where the operation was targeted.
        /// </param>
        /// <param name='operationId'>
        /// Required. The operation ID for the operation you wish to track. The
        /// operation ID is returned in the ID field in the body of the
        /// response for long-running operations.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// The response body contains the status of the specified long-running
        /// operation, indicating whether it has succeeded, is inprogress, has
        /// timed out, or has failed. Note that this status is distinct from
        /// the HTTP status code returned for the Get Operation Status
        /// operation itself. If the long-running operation failed, the
        /// response body includes error information regarding the failure.
        /// </returns>
        public async System.Threading.Tasks.Task<Microsoft.WindowsAzure.Management.WebSites.Models.WebSiteOperationStatusResponse> GetOperationStatusAsync(string webSpaceName, string siteName, string operationId, CancellationToken cancellationToken)
        {
            // Validate
            if (webSpaceName == null)
            {
                throw new ArgumentNullException("webSpaceName");
            }
            if (siteName == null)
            {
                throw new ArgumentNullException("siteName");
            }
            if (operationId == null)
            {
                throw new ArgumentNullException("operationId");
            }
            
            // Tracing
            bool shouldTrace = CloudContext.Configuration.Tracing.IsEnabled;
            string invocationId = null;
            if (shouldTrace)
            {
                invocationId = Tracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("webSpaceName", webSpaceName);
                tracingParameters.Add("siteName", siteName);
                tracingParameters.Add("operationId", operationId);
                Tracing.Enter(invocationId, this, "GetOperationStatusAsync", tracingParameters);
            }
            
            // Construct URL
            string baseUrl = this.BaseUri.AbsoluteUri;
            string url = "/" + this.Credentials.SubscriptionId.Trim() + "/services/WebSpaces/" + webSpaceName.Trim() + "/sites/" + siteName.Trim() + "/operations/" + operationId.Trim();
            // Trim '/' character from the end of baseUrl and beginning of url.
            if (baseUrl[baseUrl.Length - 1] == '/')
            {
                baseUrl = baseUrl.Substring(0, baseUrl.Length - 1);
            }
            if (url[0] == '/')
            {
                url = url.Substring(1);
            }
            url = baseUrl + "/" + url;
            
            // Create HTTP transport objects
            HttpRequestMessage httpRequest = null;
            try
            {
                httpRequest = new HttpRequestMessage();
                httpRequest.Method = HttpMethod.Get;
                httpRequest.RequestUri = new Uri(url);
                
                // Set Headers
                httpRequest.Headers.Add("x-ms-version", "2013-08-01");
                
                // Set Credentials
                cancellationToken.ThrowIfCancellationRequested();
                await this.Credentials.ProcessHttpRequestAsync(httpRequest, cancellationToken).ConfigureAwait(false);
                
                // Send Request
                HttpResponseMessage httpResponse = null;
                try
                {
                    if (shouldTrace)
                    {
                        Tracing.SendRequest(invocationId, httpRequest);
                    }
                    cancellationToken.ThrowIfCancellationRequested();
                    httpResponse = await this.HttpClient.SendAsync(httpRequest, cancellationToken).ConfigureAwait(false);
                    if (shouldTrace)
                    {
                        Tracing.ReceiveResponse(invocationId, httpResponse);
                    }
                    HttpStatusCode statusCode = httpResponse.StatusCode;
                    if (statusCode != HttpStatusCode.OK)
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                        CloudException ex = CloudException.Create(httpRequest, null, httpResponse, await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false), CloudExceptionType.Xml);
                        if (shouldTrace)
                        {
                            Tracing.Error(invocationId, ex);
                        }
                        throw ex;
                    }
                    
                    // Create Result
                    WebSiteOperationStatusResponse result = null;
                    // Deserialize Response
                    cancellationToken.ThrowIfCancellationRequested();
                    string responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                    result = new WebSiteOperationStatusResponse();
                    XDocument responseDoc = XDocument.Parse(responseContent);
                    
                    XElement operationElement = responseDoc.Element(XName.Get("Operation", "http://schemas.microsoft.com/windowsazure"));
                    if (operationElement != null && operationElement.IsEmpty == false)
                    {
                        XElement createdTimeElement = operationElement.Element(XName.Get("CreatedTime", "http://schemas.microsoft.com/windowsazure"));
                        if (createdTimeElement != null && createdTimeElement.IsEmpty == false)
                        {
                            DateTime createdTimeInstance = DateTime.Parse(createdTimeElement.Value, CultureInfo.InvariantCulture);
                            result.CreatedTime = createdTimeInstance;
                        }
                        
                        XElement errorsSequenceElement = operationElement.Element(XName.Get("Errors", "http://schemas.microsoft.com/windowsazure"));
                        if (errorsSequenceElement != null && errorsSequenceElement.IsEmpty == false)
                        {
                            bool isNil = false;
                            XAttribute nilAttribute = errorsSequenceElement.Attribute(XName.Get("nil", "http://www.w3.org/2001/XMLSchema-instance"));
                            if (nilAttribute != null)
                            {
                                isNil = nilAttribute.Value == "true";
                            }
                            if (isNil == false)
                            {
                                foreach (XElement errorsElement in errorsSequenceElement.Elements(XName.Get("Error", "http://schemas.microsoft.com/windowsazure")))
                                {
                                    WebSiteOperationStatusResponse.Error errorInstance = new WebSiteOperationStatusResponse.Error();
                                    result.Errors.Add(errorInstance);
                                    
                                    XElement codeElement = errorsElement.Element(XName.Get("Code", "http://schemas.microsoft.com/windowsazure"));
                                    if (codeElement != null && codeElement.IsEmpty == false)
                                    {
                                        bool isNil2 = false;
                                        XAttribute nilAttribute2 = codeElement.Attribute(XName.Get("nil", "http://www.w3.org/2001/XMLSchema-instance"));
                                        if (nilAttribute2 != null)
                                        {
                                            isNil2 = nilAttribute2.Value == "true";
                                        }
                                        if (isNil2 == false)
                                        {
                                            string codeInstance = codeElement.Value;
                                            errorInstance.Code = codeInstance;
                                        }
                                    }
                                    
                                    XElement messageElement = errorsElement.Element(XName.Get("Message", "http://schemas.microsoft.com/windowsazure"));
                                    if (messageElement != null && messageElement.IsEmpty == false)
                                    {
                                        bool isNil3 = false;
                                        XAttribute nilAttribute3 = messageElement.Attribute(XName.Get("nil", "http://www.w3.org/2001/XMLSchema-instance"));
                                        if (nilAttribute3 != null)
                                        {
                                            isNil3 = nilAttribute3.Value == "true";
                                        }
                                        if (isNil3 == false)
                                        {
                                            string messageInstance = messageElement.Value;
                                            errorInstance.Message = messageInstance;
                                        }
                                    }
                                    
                                    XElement extendedCodeElement = errorsElement.Element(XName.Get("ExtendedCode", "http://schemas.microsoft.com/windowsazure"));
                                    if (extendedCodeElement != null && extendedCodeElement.IsEmpty == false)
                                    {
                                        bool isNil4 = false;
                                        XAttribute nilAttribute4 = extendedCodeElement.Attribute(XName.Get("nil", "http://www.w3.org/2001/XMLSchema-instance"));
                                        if (nilAttribute4 != null)
                                        {
                                            isNil4 = nilAttribute4.Value == "true";
                                        }
                                        if (isNil4 == false)
                                        {
                                            string extendedCodeInstance = extendedCodeElement.Value;
                                            errorInstance.ExtendedCode = extendedCodeInstance;
                                        }
                                    }
                                    
                                    XElement messageTemplateElement = errorsElement.Element(XName.Get("MessageTemplate", "http://schemas.microsoft.com/windowsazure"));
                                    if (messageTemplateElement != null && messageTemplateElement.IsEmpty == false)
                                    {
                                        bool isNil5 = false;
                                        XAttribute nilAttribute5 = messageTemplateElement.Attribute(XName.Get("nil", "http://www.w3.org/2001/XMLSchema-instance"));
                                        if (nilAttribute5 != null)
                                        {
                                            isNil5 = nilAttribute5.Value == "true";
                                        }
                                        if (isNil5 == false)
                                        {
                                            string messageTemplateInstance = messageTemplateElement.Value;
                                            errorInstance.MessageTemplate = messageTemplateInstance;
                                        }
                                    }
                                    
                                    XElement parametersSequenceElement = errorsElement.Element(XName.Get("Parameters", "http://schemas.microsoft.com/windowsazure"));
                                    if (parametersSequenceElement != null && parametersSequenceElement.IsEmpty == false)
                                    {
                                        bool isNil6 = false;
                                        XAttribute nilAttribute6 = parametersSequenceElement.Attribute(XName.Get("nil", "http://www.w3.org/2001/XMLSchema-instance"));
                                        if (nilAttribute6 != null)
                                        {
                                            isNil6 = nilAttribute6.Value == "true";
                                        }
                                        if (isNil6 == false)
                                        {
                                            foreach (XElement parametersElement in parametersSequenceElement.Elements(XName.Get("string", "http://schemas.microsoft.com/2003/10/Serialization/Arrays")))
                                            {
                                                errorInstance.Parameters.Add(parametersElement.Value);
                                            }
                                        }
                                    }
                                    
                                    XElement innerErrorsElement = errorsElement.Element(XName.Get("InnerErrors", "http://schemas.microsoft.com/windowsazure"));
                                    if (innerErrorsElement != null && innerErrorsElement.IsEmpty == false)
                                    {
                                        bool isNil7 = false;
                                        XAttribute nilAttribute7 = innerErrorsElement.Attribute(XName.Get("nil", "http://www.w3.org/2001/XMLSchema-instance"));
                                        if (nilAttribute7 != null)
                                        {
                                            isNil7 = nilAttribute7.Value == "true";
                                        }
                                        if (isNil7 == false)
                                        {
                                            string innerErrorsInstance = innerErrorsElement.Value;
                                            errorInstance.InnerErrors = innerErrorsInstance;
                                        }
                                    }
                                }
                            }
                        }
                        
                        XElement expirationTimeElement = operationElement.Element(XName.Get("ExpirationTime", "http://schemas.microsoft.com/windowsazure"));
                        if (expirationTimeElement != null && expirationTimeElement.IsEmpty == false)
                        {
                            DateTime expirationTimeInstance = DateTime.Parse(expirationTimeElement.Value, CultureInfo.InvariantCulture);
                            result.ExpirationTime = expirationTimeInstance;
                        }
                        
                        XElement geoMasterOperationIdElement = operationElement.Element(XName.Get("GeoMasterOperationId", "http://schemas.microsoft.com/windowsazure"));
                        if (geoMasterOperationIdElement != null && geoMasterOperationIdElement.IsEmpty == false)
                        {
                            bool isNil8 = false;
                            XAttribute nilAttribute8 = geoMasterOperationIdElement.Attribute(XName.Get("nil", "http://www.w3.org/2001/XMLSchema-instance"));
                            if (nilAttribute8 != null)
                            {
                                isNil8 = nilAttribute8.Value == "true";
                            }
                            if (isNil8 == false)
                            {
                                string geoMasterOperationIdInstance = geoMasterOperationIdElement.Value;
                                result.GeoMasterOperationId = geoMasterOperationIdInstance;
                            }
                        }
                        
                        XElement idElement = operationElement.Element(XName.Get("Id", "http://schemas.microsoft.com/windowsazure"));
                        if (idElement != null && idElement.IsEmpty == false)
                        {
                            bool isNil9 = false;
                            XAttribute nilAttribute9 = idElement.Attribute(XName.Get("nil", "http://www.w3.org/2001/XMLSchema-instance"));
                            if (nilAttribute9 != null)
                            {
                                isNil9 = nilAttribute9.Value == "true";
                            }
                            if (isNil9 == false)
                            {
                                string idInstance = idElement.Value;
                                result.OperationId = idInstance;
                            }
                        }
                        
                        XElement modifiedTimeElement = operationElement.Element(XName.Get("ModifiedTime", "http://schemas.microsoft.com/windowsazure"));
                        if (modifiedTimeElement != null && modifiedTimeElement.IsEmpty == false)
                        {
                            DateTime modifiedTimeInstance = DateTime.Parse(modifiedTimeElement.Value, CultureInfo.InvariantCulture);
                            result.ModifiedTime = modifiedTimeInstance;
                        }
                        
                        XElement nameElement = operationElement.Element(XName.Get("Name", "http://schemas.microsoft.com/windowsazure"));
                        if (nameElement != null && nameElement.IsEmpty == false)
                        {
                            bool isNil10 = false;
                            XAttribute nilAttribute10 = nameElement.Attribute(XName.Get("nil", "http://www.w3.org/2001/XMLSchema-instance"));
                            if (nilAttribute10 != null)
                            {
                                isNil10 = nilAttribute10.Value == "true";
                            }
                            if (isNil10 == false)
                            {
                                string nameInstance = nameElement.Value;
                                result.Name = nameInstance;
                            }
                        }
                        
                        XElement statusElement = operationElement.Element(XName.Get("Status", "http://schemas.microsoft.com/windowsazure"));
                        if (statusElement != null && statusElement.IsEmpty == false)
                        {
                            WebSiteOperationStatus statusInstance = ((WebSiteOperationStatus)Enum.Parse(typeof(WebSiteOperationStatus), statusElement.Value, true));
                            result.Status = statusInstance;
                        }
                    }
                    
                    result.StatusCode = statusCode;
                    if (httpResponse.Headers.Contains("x-ms-request-id"))
                    {
                        result.RequestId = httpResponse.Headers.GetValues("x-ms-request-id").FirstOrDefault();
                    }
                    
                    if (shouldTrace)
                    {
                        Tracing.Exit(invocationId, result);
                    }
                    return result;
                }
                finally
                {
                    if (httpResponse != null)
                    {
                        httpResponse.Dispose();
                    }
                }
            }
            finally
            {
                if (httpRequest != null)
                {
                    httpRequest.Dispose();
                }
            }
        }
        
        /// <summary>
        /// Register your subscription to use Azure Web Sites.
        /// </summary>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// A standard service response including an HTTP status code and
        /// request ID.
        /// </returns>
        public async System.Threading.Tasks.Task<OperationResponse> RegisterSubscriptionAsync(CancellationToken cancellationToken)
        {
            // Validate
            
            // Tracing
            bool shouldTrace = CloudContext.Configuration.Tracing.IsEnabled;
            string invocationId = null;
            if (shouldTrace)
            {
                invocationId = Tracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                Tracing.Enter(invocationId, this, "RegisterSubscriptionAsync", tracingParameters);
            }
            
            // Construct URL
            string baseUrl = this.BaseUri.AbsoluteUri;
            string url = "/" + this.Credentials.SubscriptionId.Trim() + "/services?";
            url = url + "service=website";
            url = url + "&action=register";
            // Trim '/' character from the end of baseUrl and beginning of url.
            if (baseUrl[baseUrl.Length - 1] == '/')
            {
                baseUrl = baseUrl.Substring(0, baseUrl.Length - 1);
            }
            if (url[0] == '/')
            {
                url = url.Substring(1);
            }
            url = baseUrl + "/" + url;
            
            // Create HTTP transport objects
            HttpRequestMessage httpRequest = null;
            try
            {
                httpRequest = new HttpRequestMessage();
                httpRequest.Method = HttpMethod.Put;
                httpRequest.RequestUri = new Uri(url);
                
                // Set Headers
                httpRequest.Headers.Add("x-ms-version", "2013-08-01");
                
                // Set Credentials
                cancellationToken.ThrowIfCancellationRequested();
                await this.Credentials.ProcessHttpRequestAsync(httpRequest, cancellationToken).ConfigureAwait(false);
                
                // Send Request
                HttpResponseMessage httpResponse = null;
                try
                {
                    if (shouldTrace)
                    {
                        Tracing.SendRequest(invocationId, httpRequest);
                    }
                    cancellationToken.ThrowIfCancellationRequested();
                    httpResponse = await this.HttpClient.SendAsync(httpRequest, cancellationToken).ConfigureAwait(false);
                    if (shouldTrace)
                    {
                        Tracing.ReceiveResponse(invocationId, httpResponse);
                    }
                    HttpStatusCode statusCode = httpResponse.StatusCode;
                    if (statusCode != HttpStatusCode.Accepted)
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                        CloudException ex = CloudException.Create(httpRequest, null, httpResponse, await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false), CloudExceptionType.Xml);
                        if (shouldTrace)
                        {
                            Tracing.Error(invocationId, ex);
                        }
                        throw ex;
                    }
                    
                    // Create Result
                    OperationResponse result = null;
                    result = new OperationResponse();
                    result.StatusCode = statusCode;
                    if (httpResponse.Headers.Contains("x-ms-request-id"))
                    {
                        result.RequestId = httpResponse.Headers.GetValues("x-ms-request-id").FirstOrDefault();
                    }
                    
                    if (shouldTrace)
                    {
                        Tracing.Exit(invocationId, result);
                    }
                    return result;
                }
                finally
                {
                    if (httpResponse != null)
                    {
                        httpResponse.Dispose();
                    }
                }
            }
            finally
            {
                if (httpRequest != null)
                {
                    httpRequest.Dispose();
                }
            }
        }
        
        /// <summary>
        /// Unregister your subscription to use Azure Web Sites.
        /// </summary>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// A standard service response including an HTTP status code and
        /// request ID.
        /// </returns>
        public async System.Threading.Tasks.Task<OperationResponse> UnregisterSubscriptionAsync(CancellationToken cancellationToken)
        {
            // Validate
            
            // Tracing
            bool shouldTrace = CloudContext.Configuration.Tracing.IsEnabled;
            string invocationId = null;
            if (shouldTrace)
            {
                invocationId = Tracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                Tracing.Enter(invocationId, this, "UnregisterSubscriptionAsync", tracingParameters);
            }
            
            // Construct URL
            string baseUrl = this.BaseUri.AbsoluteUri;
            string url = "/" + this.Credentials.SubscriptionId.Trim() + "/services?";
            url = url + "service=website";
            url = url + "&action=unregister";
            // Trim '/' character from the end of baseUrl and beginning of url.
            if (baseUrl[baseUrl.Length - 1] == '/')
            {
                baseUrl = baseUrl.Substring(0, baseUrl.Length - 1);
            }
            if (url[0] == '/')
            {
                url = url.Substring(1);
            }
            url = baseUrl + "/" + url;
            
            // Create HTTP transport objects
            HttpRequestMessage httpRequest = null;
            try
            {
                httpRequest = new HttpRequestMessage();
                httpRequest.Method = HttpMethod.Put;
                httpRequest.RequestUri = new Uri(url);
                
                // Set Headers
                httpRequest.Headers.Add("x-ms-version", "2013-08-01");
                
                // Set Credentials
                cancellationToken.ThrowIfCancellationRequested();
                await this.Credentials.ProcessHttpRequestAsync(httpRequest, cancellationToken).ConfigureAwait(false);
                
                // Send Request
                HttpResponseMessage httpResponse = null;
                try
                {
                    if (shouldTrace)
                    {
                        Tracing.SendRequest(invocationId, httpRequest);
                    }
                    cancellationToken.ThrowIfCancellationRequested();
                    httpResponse = await this.HttpClient.SendAsync(httpRequest, cancellationToken).ConfigureAwait(false);
                    if (shouldTrace)
                    {
                        Tracing.ReceiveResponse(invocationId, httpResponse);
                    }
                    HttpStatusCode statusCode = httpResponse.StatusCode;
                    if (statusCode != HttpStatusCode.Accepted)
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                        CloudException ex = CloudException.Create(httpRequest, null, httpResponse, await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false), CloudExceptionType.Xml);
                        if (shouldTrace)
                        {
                            Tracing.Error(invocationId, ex);
                        }
                        throw ex;
                    }
                    
                    // Create Result
                    OperationResponse result = null;
                    result = new OperationResponse();
                    result.StatusCode = statusCode;
                    if (httpResponse.Headers.Contains("x-ms-request-id"))
                    {
                        result.RequestId = httpResponse.Headers.GetValues("x-ms-request-id").FirstOrDefault();
                    }
                    
                    if (shouldTrace)
                    {
                        Tracing.Exit(invocationId, result);
                    }
                    return result;
                }
                finally
                {
                    if (httpResponse != null)
                    {
                        httpResponse.Dispose();
                    }
                }
            }
            finally
            {
                if (httpRequest != null)
                {
                    httpRequest.Dispose();
                }
            }
        }
    }
}
