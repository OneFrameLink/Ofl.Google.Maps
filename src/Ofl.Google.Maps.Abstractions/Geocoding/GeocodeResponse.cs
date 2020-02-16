using System.Collections.Generic;

namespace Ofl.Google.Maps.Geocoding
{
    public class GeocodeResponse
    {
        public IReadOnlyCollection<Result>? Results { get; set; }

        public string? Status { get; set; }
    }
}
