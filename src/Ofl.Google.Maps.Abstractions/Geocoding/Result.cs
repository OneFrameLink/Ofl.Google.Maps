using System.Collections.Generic;

namespace Ofl.Google.Maps.Geocoding
{
    public class Result
    {
        public IReadOnlyCollection<string>? Types { get; set; }

        public string? FormattedAddress { get; set; }

        public IReadOnlyCollection<AddressComponent>? AddressComponents { get; set; }

        // TODO: Postcode localities
        // https://developers.google.com/maps/documentation/geocoding/intro#Results
        // public IReadOnlyCollection<string> PostcodeLocalities { get; set; }

        public Geometry? Geometry { get; set; }

        public PlusCode? PlusCode { get; set; }

        public bool PartialMatch { get; set; }
        
        public string? PlaceId { get; set; }        
    }
}
