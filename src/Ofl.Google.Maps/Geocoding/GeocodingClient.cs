using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.WebUtilities;
using Ofl.Net.Http.ApiClient.Json;
using Ofl.Text.Json;
using Ofl.Threading.Tasks;

namespace Ofl.Google.Maps.Geocoding
{
    public class GeocodingClient : JsonApiClient, IGeocodingClient
    {
        #region Constructor

        public GeocodingClient(HttpClient httpClient) : 
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
                PropertyNamingPolicy = new SnakeCaseJsonNamingPolicy(true)
            };

        #endregion

        #region Implementation of IGeocodingClient

        public Task<GeocodeResponse> GeocodeAsync(GeocodeRequest request, CancellationToken cancellationToken)
        {
            // Validate parameters.
            if (request == null) throw new ArgumentNullException(nameof(request));

            // The URI.
            string uri = "/geocode/json";

            // Add query parameters.
            uri = QueryHelpers.AddQueryString(uri, "address", request.Address);

            // Return the response.
            return GetAsync<GeocodeResponse>(uri, cancellationToken);
        }

        #endregion
    }
}
