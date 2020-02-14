using System;
using Microsoft.Extensions.DependencyInjection;

namespace Ofl.Google.Maps.Geocoding
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddGoogleGeocodingClient(this IServiceCollection serviceCollection)
        {
            // Validate parameters.
            var sc = serviceCollection ?? throw new ArgumentNullException(nameof(serviceCollection));

            // Configure the client.
            sc.AddHttpClient<IGeocodingClient, GeocodingClient>()
                .ConfigureGoogleApiKeyProvider();

            // Return the service collection.
            return sc;
        }
    }
}
