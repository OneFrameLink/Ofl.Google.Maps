using Ofl.Google.Maps.Serialization.Newtonsoft;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Ofl.Google.Maps.Places
{
    public class Result
    {
        public IReadOnlyCollection<AddressComponent>? AddressComponents { get; set; }

        public string? FormattedAddress { get; set; }

        public string? FormattedPhoneNumber { get; set; }

        public string? AdrAddress { get; set; }

        public Geometry? Geometry { get; set; }

        public PlusCode? PlusCode { get; set; }

        public Uri? Icon { get; set; }

        public string? InternationalPhoneNumber { get; set; }

        public string? Name { get; set; }

        // TODO: opening_hours https://developers.google.com/places/web-service/details#fields

        public bool PermanentlyClosed { get; set; }

        public IReadOnlyCollection<Photo>? Photos { get; set; }

        public string? PlaceId { get; set; }

        public int PriceLevel { get; set; }

        public decimal Rating { get; set; }

        // TODO: Not mentioned in documentation, but returned.
        // public string? Reference { get; set; }

        public IReadOnlyCollection<Review>? Reviews { get; set; }

        public IReadOnlyCollection<string>? Types { get; set; }

        public Uri? Url { get; set; }

        [JsonConverter(typeof(MinutesToTimeSpanJsonConverter))]
        public TimeSpan UtcOffset { get; set; }

        public string? Vicinity { get; set; }

        public Uri? Website { get; set; }
    }
}
