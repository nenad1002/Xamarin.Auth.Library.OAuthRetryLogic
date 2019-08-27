using System;
using Xamarin.Auth;
using System.Threading.Tasks;

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
        }
    }
}
