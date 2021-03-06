﻿using System.Collections.Generic;

namespace Ofl.Google.Maps.Places
{
    public class PlaceDetails
    {
        public Status Status { get; set; }

        public Result? Result { get; set; }

        public IReadOnlyCollection<string>? HtmlAttributions { get; set; }
    }
}
