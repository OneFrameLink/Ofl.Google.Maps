using System.Collections.Generic;

namespace Ofl.Google.Maps.Geocoding
{
    public class Geometry
    {
        public Coordinates? Location { get; set; }

        public string? LocationType { get; set; }

        public Viewport? Viewport { get; set; }

        public string? PlaceId { get; set; }

        public IReadOnlyCollection<string>? Types { get; set; }
    }
}
