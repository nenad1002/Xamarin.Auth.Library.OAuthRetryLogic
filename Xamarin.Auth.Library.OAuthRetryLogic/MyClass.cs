using System;
using Xamarin.Auth;
using System.Threading.Tasks;
using Xamarin.Auth.Library.OAuthRetryLogic.src.WaitTimeCallbackImplementations;

namespace Xamarin.Auth.Library.OAuthRetryLogic
{
    public class MyClass
    {
        public MyClass()
        {
        }

        public void f()
        {
            Account a = new Account();
            a.Properties.Add("access_token", "sdfsff");

            var request = new OAuth2Request("GET", new Uri("https://jsonplaceholder.typicodde.com/todos/"), null, a);
            var response = request.GetResponseAsync().Result;

            if (response != null)
            {
                string userJson = response.GetResponseText();
            }

            var config = new OAuth2RequestConfig()
            {
                Account = a,
                Method = "GET",
                Url = new Uri("https://jsonplaceholder.typicodde.com/todos/"),
                Parameters = null,
                Timeout = 1000,
                MaximumTimeout = 3000,
                NumberOfRetries = 2,
                WaitTimeCallback = OAuth2RequestExponentialBackoffCallback.Callback
            };

            var myRequest = new OAuth2RequestWithRetry(config);

            var response
        }
    }
}
