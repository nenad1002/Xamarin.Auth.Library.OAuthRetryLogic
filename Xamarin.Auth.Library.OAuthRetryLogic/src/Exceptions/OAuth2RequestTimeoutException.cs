//------------------
// <copyrightfile="OAuth2RequestTimeoutException.cs" author="Nenad Banfic">
//  MIT Licence.
// <copyrightfile>

using System;
namespace Xamarin.Auth.Library.OAuthRetryLogic.src.Exceptions
{
    public class OAuth2RequestTimeoutException : OAuth2RequestWithRetryException
    {
        // <summary>
        // Iniatilizes a new instance of the <see href="OAuth2RequestTimeoutException/> class.
        // </summary>
        public OAuth2RequestTimeoutException()
        {
        }

        // <summary>
        // Iniatilizes a new instance of the <see href="OAuth2RequestTimeoutException/> class.
        // </summary>
        // <param name="message">The message.</param>
        public OAuth2RequestTimeoutException(string message) : base(message)
        {
        }
    }
}
