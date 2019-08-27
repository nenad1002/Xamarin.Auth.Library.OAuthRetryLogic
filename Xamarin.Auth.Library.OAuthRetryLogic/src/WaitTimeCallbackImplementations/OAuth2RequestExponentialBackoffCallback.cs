//------------------
// <copyrightfile="OAuth2RequestExponentialBackoffCallback.cs" author="Nenad Banfic">
//  MIT Licence.
// <copyrightfile>

using System;
namespace Xamarin.Auth.Library.OAuthRetryLogic.src.WaitTimeCallbackImplementations
{
    public class OAuth2RequestExponentialBackoffCallback
    {
        /// <summary>
        /// The provided callback method that does exponential backoff with a random constant to avoid network congestion.
        /// </summary>
        /// <param name="response">The response.</param>
        /// <param name="hasFailed">A boolean denoting whether the previous request failed.</param>
        /// <param name="retryNumber">The retry numbr.</param>
        /// <returns>The <see cref="TimeSpan">, specifying the wait time, or null if there is no wait time.</returns>
        public static TimeSpan? Callback(Response response, bool hasFailed, int retryNumber)
        {
            // Check whether the response has the correct status code.
            if (response != null && ((int)response.StatusCode) / 100 == 2 && !hasFailed)
            {
                return null;
            } else
            {
                Random random = new Random();

                // Wait time is calculated using exponential backoff with a random constant to avoid network congestion.
                double waitTime = random.Next(1 << retryNumber) * 500;
                return TimeSpan.FromMilliseconds(waitTime);
            }
        }
    }
}
