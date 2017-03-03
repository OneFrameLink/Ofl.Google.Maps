using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.WebUtilities;
using Ofl.Core.Net.Http;

namespace Ofl.Google.Maps
{
    public class MapsClient : GoogleApiClient, IMapsClient
    {
        #region Constructor

        public MapsClient(IApiKeyProvider apiKeyProvider, IHttpClientFactory httpClientFactory) : 
            base(apiKeyProvider, httpClientFactory)
        { }

        #endregion

        #region Overrides

        protected override Task<string> FormatUrlAsync(string url, CancellationToken cancellationToken)
        {
            // Validate parameters.
            if (string.IsNullOrWhiteSpace(url)) throw new ArgumentNullException(nameof(url));

            // Format.
            return Task.FromResult("https://maps.googleapis.com/maps/api" + url);
        }

        #endregion

        #region Implementation of IMapsClient

        public Task<TimeZoneResponse> GetTimeZoneAsync(TimeZoneRequest request, CancellationToken cancellationToken)
        {
            // Get the latitude, longitude, key.
            string latitude = request.Latitude.ToString(CultureInfo.InvariantCulture);
            string longitude = request.Longitude.ToString(CultureInfo.InvariantCulture);
            long timestamp = new DateTimeOffset(request.Timestamp).ToUnixTimeSeconds();

            // The URI.
            string uri = "/timezone/json";

            // Add query parameters.
            uri = QueryHelpers.AddQueryString(uri, "location", $"{ latitude },{ longitude }");
            uri = QueryHelpers.AddQueryString(uri, "timestamp", timestamp.ToString(CultureInfo.InvariantCulture));

            // Return the response.
            return GetAsync<TimeZoneResponse>(uri, cancellationToken);
        }

        #endregion
    }
}
