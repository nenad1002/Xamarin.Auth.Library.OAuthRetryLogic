using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Xamarin.Auth.Library.OAuthRetryLogic
{
    public class OAuth2RequestWithRetry : OAuth2Request
    {
        private OAuth2RequestConfig config;

        public OAuth2RequestWithRetry(OAuth2RequestConfig config)
            : base(config.Method, config.Url, config.Parameters, config.Account)
        {
            this.config = config;
        }

        public async Task<Response> GetResponseAsync()
        {
            var mainTask = Task.Run(async () => await GetResponseAsyncHelper());
        }

        private async Task<Response> GetResponseAsync()
        {
            // Retry for the specified number of times (the first request doesn't count as a retry).
            for (int retryNumber = 0; retryNumber <= config.NumberOfRetries; retryNumber++)
            {
                var cts = new CancellationTokenSource();
                cts.CancelAfter(config.Timeout);
                var hasFailed = false;
                Response response = null;
                try
                {
                    response = await base.GetResponseAsync();
                }
                catch (Exception exception)
                {
                    hasFailed = true;

                }
            }
        }
    }
}
