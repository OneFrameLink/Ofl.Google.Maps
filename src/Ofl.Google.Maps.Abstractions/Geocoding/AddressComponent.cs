using System.Collections.Generic;

namespace Ofl.Google.Maps.Geocoding
{
    public class AddressComponent
    {
        public string? LongName { get; set; }

        public string? ShortName { get; set; }

        public IReadOnlyCollection<string>? Types { get; set; }
    }
}
