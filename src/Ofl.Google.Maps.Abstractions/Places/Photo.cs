using System.Collections.Generic;

namespace Ofl.Google.Maps.Places
{
    public class Photo
    {
        public int Height { get; set; }

        public IReadOnlyCollection<string>? HtmlAttributions { get; set; }

        public string? PhotoReference { get; set; }

        public int Width { get; set; }
    }
}
