//------------------
// <copyrightfile="OAuth2RequestWithRetry.cs" author="Nenad Banfic">
//  MIT Licence.
// <copyrightfile>

using System;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Auth.Library.OAuthRetryLogic.src.Exceptions;

namespace Xamarin.Auth.Library.OAuthRetryLogic
{
    public class OAuth2RequestWithRetry : OAuth2Request
    {
        private OAuth2RequestConfig config;

        /// <summary>
        /// Iniatilizes a new instance of OAuth2RequestWithRetry.
        /// </summary>
        /// <param name="config">The config.</param>
        public OAuth2RequestWithRetry(OAuth2RequestConfig config)
            : base(config.Method, config.Url, config.Parameters, config.Account)
        {
            if (this.CheckConfig(config))
            {
                this.config = config;
            } else
            {
                throw new OAuth2RequestInvalidConfigException();
            }
        }

        /// <summary>
        /// Send a OAuth2Request with the retry logic.
        /// </summary>
        /// <returns>The <a cref="Task"/>, representing the Response.</returns>
        public async Task<Response> GetResponseAsync()
        {
            var mainTask = Task.Run(async () => await GetResponseAsyncHelper());

            // Wait for the requests to finish, throw the exception if the time
            // exceedes maximum timeout.
            if (mainTask.Wait(config.MaximumTimeout))
            {
                return mainTask.Result;
            } else
            {
                throw new OAuth2RequestTimeoutException();
            }
        }

        private async Task<Response> GetResponseAsyncHelper()
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

                    if (retryNumber == config.NumberOfRetries)
                    {

                        throw new OAuth2RequestRetriesExceededException(exception.Message);
                    }
                }

                // Check whether this is the last retry.
                if (retryNumber != config.NumberOfRetries)
                {
                    // Call the callback function with the retry number starting from 1.
                    var waitTime = config.WaitTimeCallback(response, hasFailed, retryNumber + 1);

                    // No need to call it again.
                    if (waitTime == null)
                    {
                        return response;
                    } else
                    {
                        // Sleep time specified by the callback.
                        await Task.Delay(TimeSpan.FromMilliseconds(waitTime.Value.Milliseconds));
                    }
                } else
                {
                    return (response != null) ? response : throw new OAuth2RequestRetriesExceededException();
                }
            }

            throw new OAuth2RequestRetriesExceededException();
        }

        private bool CheckConfig(OAuth2RequestConfig config)
        {
            return config.Timeout != 0 && config.MaximumTimeout != 0 && config.NumberOfRetries != 0 && config.WaitTimeCallback != null;
        }
    }
}
