using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleOAuth;
using System.Net;
using Newtonsoft.Json.Linq;
using System.IO;

namespace planner
{
    /// <summary>
    /// Class that encapsulates the logic for querying the API.
    ///
    /// Users have to set the OAuth credentials properties
    /// in order to use this class.
    /// </summary>
    class YelpAPIClient
    {
        /// <summary>
        /// Consumer key used for OAuth authentication.
        /// This must be set by the user.
        /// </summary>
        private const string CONSUMER_KEY = "T566sL4SBt_1cRZDj_ZfUg";

        /// <summary>
        /// Consumer secret used for OAuth authentication.
        /// This must be set by the user.
        /// </summary>
        private const string CONSUMER_SECRET = "XRbHcpRK_QRpbw07hbqjbN3twPU";

        /// <summary>
        /// Token used for OAuth authentication.
        /// This must be set by the user.
        /// </summary>
        private const string TOKEN = "zWUJCKD9Psb9b9XAt7DS0UgV-WQ_OW5h";

        /// <summary>
        /// Token secret used for OAuth authentication.
        /// This must be set by the user.
        /// </summary>
        private const string TOKEN_SECRET = "KVrhTYHwXzHxzfcYpRD0fiyEgAY";

        /// <summary>
        /// Host of the API.
        /// </summary>
        private const string API_HOST = "http://api.yelp.com";

        /// <summary>
        /// Relative path for the Search API.
        /// </summary>
        private const string SEARCH_PATH = "/v2/search/";

        /// <summary>
        /// Relative path for the Business API.
        /// </summary>
        private const string BUSINESS_PATH = "/v2/business/";

        /// <summary>
        /// Search limit that dictates the number of businesses returned.
        /// </summary>
        private const int SEARCH_LIMIT = 3;

        /// <summary>
        /// Prepares OAuth authentication and sends the request to the API.
        /// </summary>
        /// <param name="baseURL">The base URL of the API.</param>
        /// <param name="queryParams">The set of query parameters.</param>
        /// <returns>The JSON response from the API.</returns>
        /// <exception>Throws WebException if there is an error from the HTTP request.</exception>
        private JObject PerformRequest(string baseURL, Dictionary<string, string> queryParams = null)
        {
            var query = System.Web.HttpUtility.ParseQueryString(String.Empty);

            if (queryParams == null)
            {
                queryParams = new Dictionary<string, string>();
            }

            foreach (var queryParam in queryParams)
            {
                query[queryParam.Key] = SimpleOAuth.Utilities.UrlHelper.Encode(queryParam.Value);
            }

            var uriBuilder = new UriBuilder(baseURL);
            uriBuilder.Query = query.ToString();

            var request = WebRequest.Create(uriBuilder.ToString());
            request.Method = "GET";

            request.SignRequest(
                new Tokens
                {
                    ConsumerKey = CONSUMER_KEY,
                    ConsumerSecret = CONSUMER_SECRET,
                    AccessToken = TOKEN,
                    AccessTokenSecret = TOKEN_SECRET
                }
            ).WithEncryption(EncryptionMethod.HMACSHA1).InHeader();

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            var stream = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
            return JObject.Parse(stream.ReadToEnd());
        }

        /// <summary>
        /// Query the Search API by a search term and location.
        /// </summary>
        /// <param name="term">The search term passed to the API.</param>
        /// <param name="location">The search location passed to the API.</param>
        /// <returns>The JSON response from the API.</returns>
        public JObject Search(string term, string location)
        {
            string baseURL = API_HOST + SEARCH_PATH;
            var queryParams = new Dictionary<string, string>()
            {
                { "term", term },
                { "location", location },
                { "limit", SEARCH_LIMIT.ToString() }
            };
            return PerformRequest(baseURL, queryParams);
        }

        /// <summary>
        /// Query the Business API by a business ID.
        /// </summary>
        /// <param name="business_id">The ID of the business to query.</param>
        /// <returns>The JSON response from the API.</returns>
        public JObject GetBusiness(string business_id)
        {
            string baseURL = API_HOST + BUSINESS_PATH + business_id;
            return PerformRequest(baseURL);
        }
    }
}
