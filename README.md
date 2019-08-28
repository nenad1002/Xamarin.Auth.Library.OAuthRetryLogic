# Xamarin.Auth.Library.OAuthRetryLogic
A library that extends Xamarin.Auth and provides the retry logic (in usable state, some parts of it still in development, please stay tuned, new features to be applied by 9/15/2019).

The example of usage:
```csharp
// Define a config which specifies the number of retries, the timeout of a single request, 
// the timeout of all the requests and the callback function.
var config = new OAuth2RequestConfig()
{
    Account = acc,
    Method = "GET",
    Url = new Uri("https://www.example.com"),
    Parameters = null,
    Timeout = 1000,
    MaximumTimeout = 3000,
    NumberOfRetries = 2,
    WaitTimeCallback = OAuth2RequestExponentialBackoffCallback.Callback
};

// Use it as you would use the Xamarin.Auth's OAuth2Request.
var myRequest = new OAuth2RequestWithRetry(config);

var response = await myRequest.GetResponseAsync();
```
