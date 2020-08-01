using Ofl.Google.Maps.Serialization.Newtonsoft;

namespace Ofl.Google.Maps.Places
{
    public class PlacesClientJsonConverter : GoogleMapsJsonConverter
    {
        public PlacesClientJsonConverter() : base(SerializationExtensions.PlacesClientJsonSerializerOptions)
        { }
    }
}
