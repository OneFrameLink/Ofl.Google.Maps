using Ofl.Google.Maps;
using System;
using System.Collections.Generic;

namespace Ofl.Google.Maps.Places
{
    public class Result
    {
        public IReadOnlyCollection<AddressComponent>? AddressComponents { get; set; }

        public string? FormattedAddress { get; set; }

        public string? FormattedPhoneNumber { get; set; }

        public string? AdrAddress { get; set; }

        public Geometry? Geometry { get; set; }

        public Uri? Icon { get; set; }

        public string? Name { get; set; }

        public string? PlaceId { get; set; }
    }
}
