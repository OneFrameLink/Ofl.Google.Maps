using Ofl.Text.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Ofl.Google.Maps.Places
{
    public static class SerializationExtensions
    {
        public static readonly JsonSerializerOptions PlacesClientJsonSerializerOptions = new JsonSerializerOptions {
            PropertyNamingPolicy = new SnakeCaseJsonNamingPolicy(true),
            Converters = { new JsonStringEnumConverter() }
        };
    }
}
