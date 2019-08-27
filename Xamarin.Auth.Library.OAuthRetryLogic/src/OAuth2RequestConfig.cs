using System;
using System.Collections.Generic;

namespace Xamarin.Auth.Library.OAuthRetryLogic
{
    public class OAuth2RequestConfig
    {
        public string Method { get; set; }

        public Uri Url { get; set; }

        public IDictionary<string, string> Parameters { get; set; }

        public Account Account;

        public int NumberOfRetries { get; set; }

        public int Timeout { get; set; }

        public int MaximumTimeout { get; set; }

        public Callback WaitTimeCallback { get; set; }

        public delegate TimeSpan? Callback(Response response, bool hasFailed, int retryNumber);
    }
}
