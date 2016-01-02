using Newtonsoft.Json.Linq;
using Skybrud.Social.Json.Extensions.JObject;

namespace Skybrud.Social.Facebook.Objects.Likes {

    public class FacebookLikes : FacebookObject {

        // TODO: Check whether this class is still used...

        #region Properties

        /// <summary>
        /// Gets the total amounbt of comments. This value might not always be present in the API response - in such
        /// cases the count will be zero.
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// An array of likes. For a post, photo or similar with many likes, this array will only be a subset of all
        /// likes.
        /// </summary>
        public FacebookEntity[] Data { get; private set; }

        /// <summary>
        /// Gets a summary of the likes of the parent object, or <code>null</code> if not present.
        /// </summary>
        public FacebookLikesSummary Summary { get; private set; }

        /// <summary>
        /// Gets whether a summary is present.
        /// </summary>
        public bool HasSummary {
            get { return Summary != null; }
        }

        #endregion

        #region Constructors

        private FacebookLikes(JObject obj) : base(obj) {
            Count = obj.GetInt32("count");
            Data = obj.GetArray("data", FacebookEntity.Parse) ?? new FacebookEntity[0];
            Summary = obj.GetObject("summary", FacebookLikesSummary.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Gets an instance of <code>FacebookLikes</code> from the specified <code>obj</code>.
        /// </summary>
        /// <param name="obj">The instance of <code>JObject</code> to parse.</param>
        /// <returns>Returns an instance of <code>FacebookLikes</code>.</returns>
        public static FacebookLikes Parse(JObject obj) {
            return obj == null ? null : new FacebookLikes(obj);
        }

        #endregion

    }

}