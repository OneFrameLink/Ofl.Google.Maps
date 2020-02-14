using System.Collections.Generic;

namespace Ofl.Google.Maps.Geocoding
{
    public class Result
    {
        public IReadOnlyCollection<AddressComponent>? AddressComponents { get; set; }

        public string? FormattedAddress { get; set; }

        public Geometry? Geomoetry { get; set; }
        
        public string? PlaceId { get; set; }
        
        public IReadOnlyCollection<string>? Types { get; set; }
    }
}
