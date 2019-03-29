using Skybrud.Essentials.Http;
using Skybrud.Social.Facebook.Models.Applications;

namespace Skybrud.Social.Facebook.Responses.Applications {

    /// <summary>
    /// Class representing a response of a request to get information about a <see cref="FacebookApplication"/>.
    /// </summary>
    public class FacebookGetApplicationResponse : FacebookResponse<FacebookApplication> {

        #region Constructors

        private FacebookGetApplicationResponse(IHttpResponse response) : base(response) {

            // Validate the response
            ValidateResponse(response);

            // Parse the response body
            Body = ParseJsonObject(response.Body, FacebookApplication.Parse);

        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="response"/> into an instance of <see cref="FacebookGetApplicationResponse"/>.
        /// </summary>
        /// <param name="response">The instance of <see cref="IHttpResponse"/> representing the raw response.</param>
        /// <returns>An instance of <see cref="FacebookGetApplicationResponse"/> representing the response.</returns>
        public static FacebookGetApplicationResponse ParseResponse(IHttpResponse response) {
            return response == null ? null : new FacebookGetApplicationResponse(response);
        }

        #endregion

    }

}