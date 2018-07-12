using System;
using Microsoft.Extensions.DependencyInjection;

namespace Ofl.Google.Maps
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddGoogleMapsClient(this IServiceCollection serviceCollection)
        {
            // Validate parameters.
            var sc = serviceCollection ?? throw new ArgumentNullException(nameof(serviceCollection));

            // Configure the client.
            sc.AddHttpClient<IMapsClient, MapsClient>()
                .ConfigureGoogleApiKeyProvider();

            // Return the service collection.
            return sc;
        }
    }
}
