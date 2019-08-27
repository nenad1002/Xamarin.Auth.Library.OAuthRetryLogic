//------------------
// <copyrightfile="OAuth2RequestRetriesExceededException.cs" author="Nenad Banfic">
//  MIT Licence.
// <copyrightfile>

using System;
namespace Xamarin.Auth.Library.OAuthRetryLogic.src.Exceptions
{
    public class OAuth2RequestRetriesExceededException : OAuth2RequestWithRetryException
    {
        // <summary>
        // Iniatilizes a new instance of the <see href="OAuth2RequestRetriesExceededException/> class.
        // </summary>
        public OAuth2RequestRetriesExceededException()
        {
        }

        // <summary>
        // Iniatilizes a new instance of the <see href="OAuth2RequestRetriesExceededException/> class.
        // </summary>
        // <param name="message">The message.</param>
        public OAuth2RequestRetriesExceededException(string message) : base(message)
        {
        }
    }
}
