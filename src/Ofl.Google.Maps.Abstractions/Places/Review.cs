using Ofl.Text.Json;
using System;
using System.Text.Json.Serialization;

namespace Ofl.Google.Maps.Places
{
    public class Review
    {
        public string? AuthorName { get; set; }

        public Uri? AuthorUrl { get; set; }

        public Uri? ProfilePhotoUrl { get; set; }

        public string? Language { get; set; }

        public int Rating { get; set; }

        public string? RelativeTimeDescription { get; set; }

        public string? Text { get; set; }

        [JsonConverter(typeof(UnixTimestampDateTimeOffsetJsonConverter))]
        public DateTimeOffset Time { get; set; }
    }
}
