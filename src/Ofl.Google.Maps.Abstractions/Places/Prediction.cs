using System.Collections.Generic;

namespace Ofl.Google.Maps.Places
{
    public class Prediction
    {
        public string? Description { get; set; }

        public string? Id { get; set; }

        public IReadOnlyCollection<MatchedSubstring>? MatchedSubstrings { get; set; }

        public string? PlaceId { get; set; }

        public string? Reference { get; set; }

        public IReadOnlyCollection<Term>? Terms { get; set; }

        public IReadOnlyCollection<string>? Types { get; set; }
    }
}
