using Ofl.Google.Maps.Serialization.Newtonsoft;

namespace Ofl.Google.Maps.Geocoding
{
    public class GeocodingClientJsonConverter : GoogleMapsJsonConverter
    {
        public GeocodingClientJsonConverter() : base(SerializationExtensions.GeocodingClientJsonSerializerOptions)
        { }
    }
}
