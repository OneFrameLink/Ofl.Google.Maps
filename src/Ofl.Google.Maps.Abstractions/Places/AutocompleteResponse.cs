using System.Collections.Generic;

namespace Ofl.Google.Maps.Places
{
    public class AutocompleteResponse
    {
        public Status Status { get; set; }

        public IReadOnlyCollection<Prediction>? Predictions { get; set; }
    }
}
