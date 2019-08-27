//------------------
// <copyrightfile="OAuth2RequestInvalidConfigException.cs" author="Nenad Banfic">
//  MIT Licence.
// <copyrightfile>

using System;
namespace Xamarin.Auth.Library.OAuthRetryLogic.src.Exceptions
{
    public class OAuth2RequestInvalidConfigException : OAuth2RequestWithRetryException
    {
        /// <summary>
        /// Iniatilizes a new instance of the <see href="OAuth2RequestInvalidConfigException/> class.
        /// </summary>
        public OAuth2RequestInvalidConfigException()
        {
        }

        // <summary>
        // Iniatilizes a new instance of the <see href="OAuth2RequestInvalidConfigException/> class.
        // </summary>
        // <param name="message">The message.</param>
        public OAuth2RequestInvalidConfigException(string message) : base(message)
        {
        }
    }
}
