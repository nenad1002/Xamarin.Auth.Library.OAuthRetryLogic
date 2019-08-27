//------------------
// <copyrightfile="OAuth2RequestWithRetryException.cs" author="Nenad Banfic">
//  MIT Licence.
// <copyrightfile>

using System;
namespace Xamarin.Auth.Library.OAuthRetryLogic.src.Exceptions
{
    public abstract class OAuth2RequestWithRetryException : Exception
    {
        // <summary>
        // Iniatilizes a new instance of the <see href="OAuth2RequestWithRetryException/> class.
        // </summary>
        public OAuth2RequestWithRetryException()
        {
        }

        // <summary>
        // Iniatilizes a new instance of the <see href="OAuth2RequestWithRetryException/> class.
        // </summary>
        // <param name="message">The message.</param>
        public OAuth2RequestWithRetryException(string message) : base(message)
        {
        }
    }
}
