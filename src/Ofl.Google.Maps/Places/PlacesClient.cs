using System;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.WebUtilities;
using Ofl.Net.Http.ApiClient.Json;
using Ofl.Text.Json;
using Ofl.Threading.Tasks;

namespace Ofl.Google.Maps.Places
{
    public class PlacesClient : JsonApiClient, IPlacesClient
    {
        #region Constructor

        public PlacesClient(HttpClient httpClient) : 
            base(httpClient)
        { }

        #endregion

        #region Overrides

        protected override JsonSerializerOptions CreateJsonSerializerOptions() =>
            new JsonSerializerOptions {
                PropertyNamingPolicy = new SnakeCaseJsonNamingPolicy(true),
                Converters = { new JsonStringEnumConverter() }
            };

        protected override ValueTask<string> FormatUrlAsync(string url, CancellationToken cancellationToken)
        {
            // Validate parameters.
            if (string.IsNullOrWhiteSpace(url)) throw new ArgumentNullException(nameof(url));

            // Format the url.
            return ValueTaskExtensions.FromResult($"https://maps.googleapis.com/maps/api/place/{ url }");
        }

        #endregion

        #region Implementation of IPlacesClient

        public Task<PlaceDetails> GetDetailsAsync(string placeId, CancellationToken cancellationToken)
        {
            // Validate parameters.
            if (string.IsNullOrWhiteSpace(placeId)) throw new ArgumentNullException(nameof(placeId));

            // Create the uri.
            string uri = "details/json";

            // Add the query parameter.
            uri = QueryHelpers.AddQueryString(uri, "placeid", placeId);

            // Get the place details async.
            return GetAsync<PlaceDetails>(uri, cancellationToken);
        }

        #endregion
    }
}
