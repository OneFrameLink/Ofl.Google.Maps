using Ofl.Text.Json;
using System.Text.Json;

namespace Ofl.Google.Maps.Geocoding
{
    public static class SerializationExtensions
    {
        public static readonly JsonSerializerOptions GeocodingClientJsonSerializerOptions = new JsonSerializerOptions {
            PropertyNamingPolicy = new SnakeCaseJsonNamingPolicy(true)
        };
    }
}
