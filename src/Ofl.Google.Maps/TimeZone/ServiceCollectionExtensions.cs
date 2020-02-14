using System;
using Microsoft.Extensions.DependencyInjection;

namespace Ofl.Google.Maps.TimeZone
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddGoogleTimeZoneClient(this IServiceCollection serviceCollection)
        {
            // Validate parameters.
            var sc = serviceCollection ?? throw new ArgumentNullException(nameof(serviceCollection));

            // Configure the client.
            sc.AddHttpClient<ITimeZoneClient, TimeZoneClient>()
                .ConfigureGoogleApiKeyProvider();

            // Return the service collection.
            return sc;
        }
    }
}
