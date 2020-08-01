using Ofl.Google.Maps.Serialization.Newtonsoft;

namespace Ofl.Google.Maps.TimeZone
{
    public class TimeZoneClientJsonConverter : GoogleMapsJsonConverter
    {
        public TimeZoneClientJsonConverter() : base(SerializationExtensions.TimeZoneClientJsonSerializerOptions)
        { }
    }
}
