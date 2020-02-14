using System;
using System.Globalization;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.WebUtilities;
using Ofl.Net.Http.ApiClient.Json;
using Ofl.Threading.Tasks;

namespace Ofl.Google.Maps.TimeZone
{
    public class TimeZoneClient : JsonApiClient, ITimeZoneClient
    {
        #region Constructor

        public TimeZoneClient(HttpClient httpClient) : 
            base(httpClient)
        { }

        #endregion

        #region Overrides

        protected override ValueTask<string> FormatUrlAsync(string url, CancellationToken cancellationToken)
        {
            // Validate parameters.
            if (string.IsNullOrWhiteSpace(url)) throw new ArgumentNullException(nameof(url));

            // Format.
            return ValueTaskExtensions.FromResult("https://maps.googleapis.com/maps/api" + url);
        }

        protected override JsonSerializerOptions CreateJsonSerializerOptions() =>
            new JsonSerializerOptions {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

        #endregion

        #region Implementation of ITimeZoneClient

        public Task<TimeZoneResponse> GetTimeZoneAsync(TimeZoneRequest request, CancellationToken cancellationToken)
        {
            // Validate parameters.
            if (request == null) throw new ArgumentNullException(nameof(request));

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
