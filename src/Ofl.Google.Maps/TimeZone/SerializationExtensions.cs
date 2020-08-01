using System.Text.Json;
using System.Text.Json.Serialization;

namespace Ofl.Google.Maps.TimeZone
{
    public static class SerializationExtensions
    {
        public static readonly JsonSerializerOptions TimeZoneClientJsonSerializerOptions = new JsonSerializerOptions {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            Converters = { new JsonStringEnumConverter() }
        };
    }
}
