﻿using System;
using Skybrud.Essentials.Http.Collections;
using Skybrud.Essentials.Http.Options;
using Skybrud.Social.Facebook.Fields;

namespace Skybrud.Social.Facebook.Options.Comments {
    
    /// <summary>
    /// Class representing the options for getting information about a single comment.
    /// </summary>
    public class FacebookGetCommentOptions : IHttpGetOptions {

        #region Properties

        /// <summary>
        /// Gets or sets the identifier (ID) of the parent object.
        /// </summary>
        public string Identifier { get; set; }

        /// <summary>
        /// Gets or sets the fields to be returned.
        /// </summary>
        public FacebookFieldsCollection Fields { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance with default options.
        /// </summary>
        public FacebookGetCommentOptions() {
            Fields = new FacebookFieldsCollection();
        }

        /// <summary>
        /// Initializes a new instance with the specified <paramref name="identifier"/>.
        /// </summary>
        /// <param name="identifier">The identifier (ID) of the comment.</param>
        public FacebookGetCommentOptions(string identifier) {
            Identifier = identifier;
            Fields = new FacebookFieldsCollection();
        }

        /// <summary>
        /// Initializes a new instance with the specified <paramref name="identifier"/> and <paramref name="fields"/>.
        /// </summary>
        /// <param name="identifier">The identifier (ID) of the user.</param>
        /// <param name="fields">A collection of the fields that should be returned by the API.</param>
        public FacebookGetCommentOptions(string identifier, FacebookFieldsCollection fields) {
            Identifier = identifier;
            Fields = fields ?? new FacebookFieldsCollection();
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets an instance of <see cref="IHttpQueryString"/> representing the GET parameters.
        /// </summary>
        public IHttpQueryString GetQueryString() {

            // Convert the collection of fields to a string
            string fields = (Fields == null ? "" : Fields.ToString()).Trim();

            // Construct the query string
            HttpQueryString query = new HttpQueryString();
            if (!String.IsNullOrWhiteSpace(fields)) query.Set("fields", fields);

            return query;

        }

        #endregion

    }

}