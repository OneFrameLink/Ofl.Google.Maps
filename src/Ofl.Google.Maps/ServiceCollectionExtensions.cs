using System;
using Microsoft.Extensions.DependencyInjection;
using Ofl.Google.Maps.Geocoding;
using Ofl.Google.Maps.Places;
using Ofl.Google.Maps.TimeZone;

namespace Ofl.Google.Maps
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddGoogleMapsClients(this IServiceCollection serviceCollection)
        {
            // Validate parameters.
            var sc = serviceCollection ?? throw new ArgumentNullException(nameof(serviceCollection));

            // Configure the clients.
            sc = sc.AddGoogleGeocodingClient();
            sc = sc.AddGoogleTimeZoneClient();
            sc = sc.AddGooglePlacesClient();

            // Return the service collection.
            return sc;
        }
    }
}
