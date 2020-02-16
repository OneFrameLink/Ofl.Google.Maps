using System;
using Microsoft.Extensions.DependencyInjection;

namespace Ofl.Google.Maps.Places
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddGooglePlacesClient(this IServiceCollection serviceCollection)
        {
            // Validate parameters.
            var sc = serviceCollection ?? throw new ArgumentNullException(nameof(serviceCollection));

            // Add the http client.
            sc.AddHttpClient<IPlacesClient, PlacesClient>()
                .ConfigureGoogleApiKeyProvider();

            // Return.
            return sc;
        }
    }
}
