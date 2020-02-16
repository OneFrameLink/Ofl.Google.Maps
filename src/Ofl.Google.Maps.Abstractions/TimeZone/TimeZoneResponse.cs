using System;
using System.Text.Json.Serialization;
using Ofl.Google.Maps.Serialization.Newtonsoft;

namespace Ofl.Google.Maps.TimeZone
{
    public class TimeZoneResponse
    {
        [JsonConverter(typeof(SecondsToTimeSpanJsonConverter))]
        public TimeSpan DstOffset { get; set; }

        [JsonConverter(typeof(SecondsToTimeSpanJsonConverter))]
        public TimeSpan RawOffset { get; set; }

        public string? TimeZoneId { get; set; }

        public string? TimeZoneName { get; set; }

        public Status Status { get; set; }
    }
}
