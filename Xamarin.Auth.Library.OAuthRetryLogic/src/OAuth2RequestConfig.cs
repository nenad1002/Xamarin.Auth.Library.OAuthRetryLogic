//------------------
// <copyrightfile="OAuth2RequestConfig.cs" author="Nenad Banfic">
//  MIT Licence.
// <copyrightfile>
using System;
using System.Collections.Generic;

namespace Xamarin.Auth.Library.OAuthRetryLogic
{
    public class OAuth2RequestConfig
    {
        /// <summary>
        /// The HTTP method, corresponding to the method parameter of OAuth2Request.
        /// </summary>
        public string Method { get; set; }

        /// <summary>
        /// The URI, corresponding to the method parameter of OAuth2Request.
        /// </summary>
        public Uri Url { get; set; }

        /// <summary>
        /// The parameters, corresponding to the method parameter of OAuth2Request.
        /// </summary>
        public IDictionary<string, string> Parameters { get; set; }

        /// <summary>
        /// The account, corresponding to the method parameter of OAuth2Request.
        /// </summary>
        public Account Account;

        /// <summary>
        /// The maximum allowed number of retries.
        /// </summary>
        public int NumberOfRetries { get; set; }

        /// <summary>
        /// The allowed timeout for a single request in milliseconds.
        /// </summary>
        public int Timeout { get; set; }

        /// <summary>
        /// The allowed timeout for all the requests in milliseconds.
        /// </summary>
        public int MaximumTimeout { get; set; }

        /// <summary>
        /// The callback specified by a user that gets called after the requests is executed.
        /// </summary>
        public Callback WaitTimeCallback { get; set; }

        /// <summary>
        /// The wait time callback.
        /// </summary>
        public delegate TimeSpan? Callback(Response response, bool hasFailed, int retryNumber);
    }
}
