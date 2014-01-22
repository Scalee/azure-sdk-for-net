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
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Common;
using Microsoft.WindowsAzure.Common.Internals;
using Microsoft.WindowsAzure.Management.Compute;
using Microsoft.WindowsAzure.Management.Compute.Models;

namespace Microsoft.WindowsAzure.Management.Compute
{
    /// <summary>
    /// Operations for managing service certificates for your subscription.
    /// (see
    /// http://msdn.microsoft.com/en-us/library/windowsazure/ee795178.aspx for
    /// more information)
    /// </summary>
    internal partial class ServiceCertificateOperations : IServiceOperations<ComputeManagementClient>, IServiceCertificateOperations
    {
        /// <summary>
        /// Initializes a new instance of the ServiceCertificateOperations
        /// class.
        /// </summary>
        /// <param name='client'>
        /// Reference to the service client.
        /// </param>
        internal ServiceCertificateOperations(ComputeManagementClient client)
        {
            this._client = client;
        }
        
        private ComputeManagementClient _client;
        
        /// <summary>
        /// Gets a reference to the
        /// Microsoft.WindowsAzure.Management.Compute.ComputeManagementClient.
        /// </summary>
        public ComputeManagementClient Client
        {
            get { return this._client; }
        }
        
        /// <summary>
        /// The Add Service Certificate operation adds a certificate to a
        /// hosted service.  The Add Service Certificate operation is an
        /// asynchronous operation. To determine whether the management
        /// service has finished processing the request, call Get Operation
        /// Status.   (see
        /// http://msdn.microsoft.com/en-us/library/windowsazure/ee460817.aspx
        /// for more information)
        /// </summary>
        /// <param name='serviceName'>
        /// The DNS prefix name of your service.
        /// </param>
        /// <param name='parameters'>
        /// Parameters supplied to the Create Service Certificate operation.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// A standard service response including an HTTP status code and
        /// request ID.
        /// </returns>
        public async Task<OperationResponse> BeginCreatingAsync(string serviceName, ServiceCertificateCreateParameters parameters, CancellationToken cancellationToken)
        {
            // Validate
            if (serviceName == null)
            {
                throw new ArgumentNullException("serviceName");
            }
            // TODO: Validate serviceName is a valid DNS name.
            if (parameters == null)
            {
                throw new ArgumentNullException("parameters");
            }
            if (parameters.Data == null)
            {
                throw new ArgumentNullException("parameters.Data");
            }
            
            // Tracing
            bool shouldTrace = CloudContext.Configuration.Tracing.IsEnabled;
            string invocationId = null;
            if (shouldTrace)
            {
                invocationId = Tracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("serviceName", serviceName);
                tracingParameters.Add("parameters", parameters);
                Tracing.Enter(invocationId, this, "BeginCreatingAsync", tracingParameters);
            }
            
            // Construct URL
            string url = this.Client.BaseUri + "/" + this.Client.Credentials.SubscriptionId + "/services/hostedservices/" + serviceName + "/certificates";
            
            // Create HTTP transport objects
            HttpRequestMessage httpRequest = null;
            try
            {
                httpRequest = new HttpRequestMessage();
                httpRequest.Method = HttpMethod.Post;
                httpRequest.RequestUri = new Uri(url);
                
                // Set Headers
                httpRequest.Headers.Add("x-ms-version", "2013-11-01");
                
                // Set Credentials
                cancellationToken.ThrowIfCancellationRequested();
                await this.Client.Credentials.ProcessHttpRequestAsync(httpRequest, cancellationToken).ConfigureAwait(false);
                
                // Serialize Request
                string requestContent = null;
                XDocument requestDoc = new XDocument();
                
                XElement certificateFileElement = new XElement(XName.Get("CertificateFile", "http://schemas.microsoft.com/windowsazure"));
                requestDoc.Add(certificateFileElement);
                
                XElement dataElement = new XElement(XName.Get("Data", "http://schemas.microsoft.com/windowsazure"));
                dataElement.Value = Convert.ToBase64String(parameters.Data);
                certificateFileElement.Add(dataElement);
                
                XElement certificateFormatElement = new XElement(XName.Get("CertificateFormat", "http://schemas.microsoft.com/windowsazure"));
                certificateFormatElement.Value = ComputeManagementClient.CertificateFormatToString(parameters.CertificateFormat);
                certificateFileElement.Add(certificateFormatElement);
                
                if (parameters.Password != null)
                {
                    XElement passwordElement = new XElement(XName.Get("Password", "http://schemas.microsoft.com/windowsazure"));
                    passwordElement.Value = parameters.Password;
                    certificateFileElement.Add(passwordElement);
                }
                
                requestContent = requestDoc.ToString();
                httpRequest.Content = new StringContent(requestContent, Encoding.UTF8);
                httpRequest.Content.Headers.ContentType = new MediaTypeHeaderValue("application/xml");
                
                // Send Request
                HttpResponseMessage httpResponse = null;
                try
                {
                    if (shouldTrace)
                    {
                        Tracing.SendRequest(invocationId, httpRequest);
                    }
                    cancellationToken.ThrowIfCancellationRequested();
                    httpResponse = await this.Client.HttpClient.SendAsync(httpRequest, cancellationToken).ConfigureAwait(false);
                    if (shouldTrace)
                    {
                        Tracing.ReceiveResponse(invocationId, httpResponse);
                    }
                    HttpStatusCode statusCode = httpResponse.StatusCode;
                    if (statusCode != HttpStatusCode.Accepted)
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                        CloudException ex = CloudException.Create(httpRequest, requestContent, httpResponse, await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false), CloudExceptionType.Xml);
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
        /// The Delete Service Certificate operation deletes a service
        /// certificate from the certificate store of a hosted service.  The
        /// Delete Service Certificate operation is an asynchronous operation.
        /// To determine whether the management service has finished
        /// processing the request, call Get Operation Status.  (see
        /// http://msdn.microsoft.com/en-us/library/windowsazure/ee460803.aspx
        /// for more information)
        /// </summary>
        /// <param name='parameters'>
        /// Parameters supplied to the Delete Service Certificate operation.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// A standard service response including an HTTP status code and
        /// request ID.
        /// </returns>
        public async Task<OperationResponse> BeginDeletingAsync(ServiceCertificateDeleteParameters parameters, CancellationToken cancellationToken)
        {
            // Validate
            if (parameters == null)
            {
                throw new ArgumentNullException("parameters");
            }
            if (parameters.ServiceName == null)
            {
                throw new ArgumentNullException("parameters.ServiceName");
            }
            // TODO: Validate parameters.ServiceName is a valid DNS name.
            if (parameters.Thumbprint == null)
            {
                throw new ArgumentNullException("parameters.Thumbprint");
            }
            if (parameters.ThumbprintAlgorithm == null)
            {
                throw new ArgumentNullException("parameters.ThumbprintAlgorithm");
            }
            
            // Tracing
            bool shouldTrace = CloudContext.Configuration.Tracing.IsEnabled;
            string invocationId = null;
            if (shouldTrace)
            {
                invocationId = Tracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("parameters", parameters);
                Tracing.Enter(invocationId, this, "BeginDeletingAsync", tracingParameters);
            }
            
            // Construct URL
            string url = this.Client.BaseUri + "/" + this.Client.Credentials.SubscriptionId + "/services/hostedservices/" + parameters.ServiceName + "/certificates/" + parameters.ThumbprintAlgorithm + "-" + parameters.Thumbprint;
            
            // Create HTTP transport objects
            HttpRequestMessage httpRequest = null;
            try
            {
                httpRequest = new HttpRequestMessage();
                httpRequest.Method = HttpMethod.Delete;
                httpRequest.RequestUri = new Uri(url);
                
                // Set Headers
                httpRequest.Headers.Add("x-ms-version", "2013-11-01");
                
                // Set Credentials
                cancellationToken.ThrowIfCancellationRequested();
                await this.Client.Credentials.ProcessHttpRequestAsync(httpRequest, cancellationToken).ConfigureAwait(false);
                
                // Send Request
                HttpResponseMessage httpResponse = null;
                try
                {
                    if (shouldTrace)
                    {
                        Tracing.SendRequest(invocationId, httpRequest);
                    }
                    cancellationToken.ThrowIfCancellationRequested();
                    httpResponse = await this.Client.HttpClient.SendAsync(httpRequest, cancellationToken).ConfigureAwait(false);
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
        /// The Add Service Certificate operation adds a certificate to a
        /// hosted service.  The Add Service Certificate operation is an
        /// asynchronous operation. To determine whether the management
        /// service has finished processing the request, call Get Operation
        /// Status.  This overload will   (see
        /// http://msdn.microsoft.com/en-us/library/windowsazure/ee460817.aspx
        /// for more information)
        /// </summary>
        /// <param name='serviceName'>
        /// The DNS prefix name of your service.
        /// </param>
        /// <param name='parameters'>
        /// Parameters supplied to the Create Service Certificate operation.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// The response body contains the status of the specified asynchronous
        /// operation, indicating whether it has succeeded, is inprogress, or
        /// has failed. Note that this status is distinct from the HTTP status
        /// code returned for the Get Operation Status operation itself.  If
        /// the asynchronous operation succeeded, the response body includes
        /// the HTTP status code for the successful request.  If the
        /// asynchronous operation failed, the response body includes the HTTP
        /// status code for the failed request, and also includes error
        /// information regarding the failure.
        /// </returns>
        public async Task<ComputeOperationStatusResponse> CreateAsync(string serviceName, ServiceCertificateCreateParameters parameters, CancellationToken cancellationToken)
        {
            ComputeManagementClient client = this.Client;
            bool shouldTrace = CloudContext.Configuration.Tracing.IsEnabled;
            string invocationId = null;
            if (shouldTrace)
            {
                invocationId = Tracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("serviceName", serviceName);
                tracingParameters.Add("parameters", parameters);
                Tracing.Enter(invocationId, this, "CreateAsync", tracingParameters);
            }
            try
            {
                if (shouldTrace)
                {
                    client = this.Client.WithHandler(new ClientRequestTrackingHandler(invocationId));
                }
                
                cancellationToken.ThrowIfCancellationRequested();
                OperationResponse response = await client.ServiceCertificates.BeginCreatingAsync(serviceName, parameters, cancellationToken).ConfigureAwait(false);
                cancellationToken.ThrowIfCancellationRequested();
                ComputeOperationStatusResponse result = await client.GetOperationStatusAsync(response.RequestId, cancellationToken).ConfigureAwait(false);
                int delayInSeconds = 30;
                while ((result.Status != OperationStatus.InProgress) == false)
                {
                    cancellationToken.ThrowIfCancellationRequested();
                    await TaskEx.Delay(delayInSeconds * 1000, cancellationToken).ConfigureAwait(false);
                    cancellationToken.ThrowIfCancellationRequested();
                    result = await client.GetOperationStatusAsync(response.RequestId, cancellationToken).ConfigureAwait(false);
                    delayInSeconds = 30;
                }
                
                if (shouldTrace)
                {
                    Tracing.Exit(invocationId, result);
                }
                
                if (result.Status != OperationStatus.Succeeded)
                {
                    if (result.Error != null)
                    {
                        CloudException ex = new CloudException(result.Error.Code + " : " + result.Error.Message);
                        ex.ErrorCode = result.Error.Code;
                        ex.ErrorMessage = result.Error.Message;
                        if (shouldTrace)
                        {
                            Tracing.Error(invocationId, ex);
                        }
                        throw ex;
                    }
                    else
                    {
                        CloudException ex = new CloudException("");
                        if (shouldTrace)
                        {
                            Tracing.Error(invocationId, ex);
                        }
                        throw ex;
                    }
                }
                
                return result;
            }
            finally
            {
                if (client != null && shouldTrace)
                {
                    client.Dispose();
                }
            }
        }
        
        /// <summary>
        /// The Delete Service Certificate operation deletes a service
        /// certificate from the certificate store of a hosted service.  The
        /// Delete Service Certificate operation is an asynchronous operation.
        /// To determine whether the management service has finished
        /// processing the request, call Get Operation Status.  (see
        /// http://msdn.microsoft.com/en-us/library/windowsazure/ee460803.aspx
        /// for more information)
        /// </summary>
        /// <param name='parameters'>
        /// Parameters supplied to the Delete Service Certificate operation.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// The response body contains the status of the specified asynchronous
        /// operation, indicating whether it has succeeded, is inprogress, or
        /// has failed. Note that this status is distinct from the HTTP status
        /// code returned for the Get Operation Status operation itself.  If
        /// the asynchronous operation succeeded, the response body includes
        /// the HTTP status code for the successful request.  If the
        /// asynchronous operation failed, the response body includes the HTTP
        /// status code for the failed request, and also includes error
        /// information regarding the failure.
        /// </returns>
        public async Task<ComputeOperationStatusResponse> DeleteAsync(ServiceCertificateDeleteParameters parameters, CancellationToken cancellationToken)
        {
            ComputeManagementClient client = this.Client;
            bool shouldTrace = CloudContext.Configuration.Tracing.IsEnabled;
            string invocationId = null;
            if (shouldTrace)
            {
                invocationId = Tracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("parameters", parameters);
                Tracing.Enter(invocationId, this, "DeleteAsync", tracingParameters);
            }
            try
            {
                if (shouldTrace)
                {
                    client = this.Client.WithHandler(new ClientRequestTrackingHandler(invocationId));
                }
                
                cancellationToken.ThrowIfCancellationRequested();
                OperationResponse response = await client.ServiceCertificates.BeginDeletingAsync(parameters, cancellationToken).ConfigureAwait(false);
                cancellationToken.ThrowIfCancellationRequested();
                ComputeOperationStatusResponse result = await client.GetOperationStatusAsync(response.RequestId, cancellationToken).ConfigureAwait(false);
                int delayInSeconds = 30;
                while ((result.Status != OperationStatus.InProgress) == false)
                {
                    cancellationToken.ThrowIfCancellationRequested();
                    await TaskEx.Delay(delayInSeconds * 1000, cancellationToken).ConfigureAwait(false);
                    cancellationToken.ThrowIfCancellationRequested();
                    result = await client.GetOperationStatusAsync(response.RequestId, cancellationToken).ConfigureAwait(false);
                    delayInSeconds = 30;
                }
                
                if (shouldTrace)
                {
                    Tracing.Exit(invocationId, result);
                }
                
                if (result.Status != OperationStatus.Succeeded)
                {
                    if (result.Error != null)
                    {
                        CloudException ex = new CloudException(result.Error.Code + " : " + result.Error.Message);
                        ex.ErrorCode = result.Error.Code;
                        ex.ErrorMessage = result.Error.Message;
                        if (shouldTrace)
                        {
                            Tracing.Error(invocationId, ex);
                        }
                        throw ex;
                    }
                    else
                    {
                        CloudException ex = new CloudException("");
                        if (shouldTrace)
                        {
                            Tracing.Error(invocationId, ex);
                        }
                        throw ex;
                    }
                }
                
                return result;
            }
            finally
            {
                if (client != null && shouldTrace)
                {
                    client.Dispose();
                }
            }
        }
        
        /// <summary>
        /// The Get Service Certificate operation returns the public data for
        /// the specified X.509 certificate associated with a hosted service.
        /// (see
        /// http://msdn.microsoft.com/en-us/library/windowsazure/ee460792.aspx
        /// for more information)
        /// </summary>
        /// <param name='parameters'>
        /// Parameters supplied to the Get Service Certificate operation.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// The Get Service Certificate operation response.
        /// </returns>
        public async Task<ServiceCertificateGetResponse> GetAsync(ServiceCertificateGetParameters parameters, CancellationToken cancellationToken)
        {
            // Validate
            if (parameters == null)
            {
                throw new ArgumentNullException("parameters");
            }
            if (parameters.ServiceName == null)
            {
                throw new ArgumentNullException("parameters.ServiceName");
            }
            // TODO: Validate parameters.ServiceName is a valid DNS name.
            if (parameters.Thumbprint == null)
            {
                throw new ArgumentNullException("parameters.Thumbprint");
            }
            if (parameters.ThumbprintAlgorithm == null)
            {
                throw new ArgumentNullException("parameters.ThumbprintAlgorithm");
            }
            
            // Tracing
            bool shouldTrace = CloudContext.Configuration.Tracing.IsEnabled;
            string invocationId = null;
            if (shouldTrace)
            {
                invocationId = Tracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("parameters", parameters);
                Tracing.Enter(invocationId, this, "GetAsync", tracingParameters);
            }
            
            // Construct URL
            string url = this.Client.BaseUri + "/" + this.Client.Credentials.SubscriptionId + "/services/hostedservices/" + parameters.ServiceName + "/certificates/" + parameters.ThumbprintAlgorithm + "-" + parameters.Thumbprint;
            
            // Create HTTP transport objects
            HttpRequestMessage httpRequest = null;
            try
            {
                httpRequest = new HttpRequestMessage();
                httpRequest.Method = HttpMethod.Get;
                httpRequest.RequestUri = new Uri(url);
                
                // Set Headers
                httpRequest.Headers.Add("x-ms-version", "2013-11-01");
                
                // Set Credentials
                cancellationToken.ThrowIfCancellationRequested();
                await this.Client.Credentials.ProcessHttpRequestAsync(httpRequest, cancellationToken).ConfigureAwait(false);
                
                // Send Request
                HttpResponseMessage httpResponse = null;
                try
                {
                    if (shouldTrace)
                    {
                        Tracing.SendRequest(invocationId, httpRequest);
                    }
                    cancellationToken.ThrowIfCancellationRequested();
                    httpResponse = await this.Client.HttpClient.SendAsync(httpRequest, cancellationToken).ConfigureAwait(false);
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
                    ServiceCertificateGetResponse result = null;
                    // Deserialize Response
                    cancellationToken.ThrowIfCancellationRequested();
                    string responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                    result = new ServiceCertificateGetResponse();
                    XDocument responseDoc = XDocument.Parse(responseContent);
                    
                    XElement certificateElement = responseDoc.Element(XName.Get("Certificate", "http://schemas.microsoft.com/windowsazure"));
                    if (certificateElement != null)
                    {
                        XElement dataElement = certificateElement.Element(XName.Get("Data", "http://schemas.microsoft.com/windowsazure"));
                        if (dataElement != null)
                        {
                            byte[] dataInstance = Convert.FromBase64String(dataElement.Value);
                            result.Data = dataInstance;
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
        /// The List Service Certificates operation lists all of the service
        /// certificates associated with the specified hosted service.  (see
        /// http://msdn.microsoft.com/en-us/library/windowsazure/jj154105.aspx
        /// for more information)
        /// </summary>
        /// <param name='serviceName'>
        /// The DNS prefix name of your hosted service.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// The List Service Certificates operation response.
        /// </returns>
        public async Task<ServiceCertificateListResponse> ListAsync(string serviceName, CancellationToken cancellationToken)
        {
            // Validate
            if (serviceName == null)
            {
                throw new ArgumentNullException("serviceName");
            }
            // TODO: Validate serviceName is a valid DNS name.
            
            // Tracing
            bool shouldTrace = CloudContext.Configuration.Tracing.IsEnabled;
            string invocationId = null;
            if (shouldTrace)
            {
                invocationId = Tracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("serviceName", serviceName);
                Tracing.Enter(invocationId, this, "ListAsync", tracingParameters);
            }
            
            // Construct URL
            string url = this.Client.BaseUri + "/" + this.Client.Credentials.SubscriptionId + "/services/hostedservices/" + serviceName + "/certificates";
            
            // Create HTTP transport objects
            HttpRequestMessage httpRequest = null;
            try
            {
                httpRequest = new HttpRequestMessage();
                httpRequest.Method = HttpMethod.Get;
                httpRequest.RequestUri = new Uri(url);
                
                // Set Headers
                httpRequest.Headers.Add("x-ms-version", "2013-11-01");
                
                // Set Credentials
                cancellationToken.ThrowIfCancellationRequested();
                await this.Client.Credentials.ProcessHttpRequestAsync(httpRequest, cancellationToken).ConfigureAwait(false);
                
                // Send Request
                HttpResponseMessage httpResponse = null;
                try
                {
                    if (shouldTrace)
                    {
                        Tracing.SendRequest(invocationId, httpRequest);
                    }
                    cancellationToken.ThrowIfCancellationRequested();
                    httpResponse = await this.Client.HttpClient.SendAsync(httpRequest, cancellationToken).ConfigureAwait(false);
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
                    ServiceCertificateListResponse result = null;
                    // Deserialize Response
                    cancellationToken.ThrowIfCancellationRequested();
                    string responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                    result = new ServiceCertificateListResponse();
                    XDocument responseDoc = XDocument.Parse(responseContent);
                    
                    XElement certificatesSequenceElement = responseDoc.Element(XName.Get("Certificates", "http://schemas.microsoft.com/windowsazure"));
                    if (certificatesSequenceElement != null)
                    {
                        foreach (XElement certificatesElement in certificatesSequenceElement.Elements(XName.Get("Certificate", "http://schemas.microsoft.com/windowsazure")))
                        {
                            ServiceCertificateListResponse.Certificate certificateInstance = new ServiceCertificateListResponse.Certificate();
                            result.Certificates.Add(certificateInstance);
                            
                            XElement certificateUrlElement = certificatesElement.Element(XName.Get("CertificateUrl", "http://schemas.microsoft.com/windowsazure"));
                            if (certificateUrlElement != null)
                            {
                                Uri certificateUrlInstance = TypeConversion.TryParseUri(certificateUrlElement.Value);
                                certificateInstance.CertificateUri = certificateUrlInstance;
                            }
                            
                            XElement thumbprintElement = certificatesElement.Element(XName.Get("Thumbprint", "http://schemas.microsoft.com/windowsazure"));
                            if (thumbprintElement != null)
                            {
                                string thumbprintInstance = thumbprintElement.Value;
                                certificateInstance.Thumbprint = thumbprintInstance;
                            }
                            
                            XElement thumbprintAlgorithmElement = certificatesElement.Element(XName.Get("ThumbprintAlgorithm", "http://schemas.microsoft.com/windowsazure"));
                            if (thumbprintAlgorithmElement != null)
                            {
                                string thumbprintAlgorithmInstance = thumbprintAlgorithmElement.Value;
                                certificateInstance.ThumbprintAlgorithm = thumbprintAlgorithmInstance;
                            }
                            
                            XElement dataElement = certificatesElement.Element(XName.Get("Data", "http://schemas.microsoft.com/windowsazure"));
                            if (dataElement != null)
                            {
                                byte[] dataInstance = Convert.FromBase64String(dataElement.Value);
                                certificateInstance.Data = dataInstance;
                            }
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
    }
}
