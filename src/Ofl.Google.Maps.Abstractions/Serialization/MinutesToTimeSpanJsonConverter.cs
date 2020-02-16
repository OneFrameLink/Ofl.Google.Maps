using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Ofl.Google.Maps.Serialization.Newtonsoft
{
    internal class MinutesToTimeSpanJsonConverter : JsonConverter<TimeSpan>
    {
        #region Overrides of JsonConverter

        public override TimeSpan Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            // Token type must be an integer.
            if (reader.TokenType != JsonTokenType.Number)
                throw new JsonException($"Unexpected token parsing date. Expected {nameof(JsonTokenType.Number)}, got {reader.TokenType}.");

            // Convert.
            return TimeSpan.FromMinutes(reader.GetInt64());
        }

        public override void Write(Utf8JsonWriter writer, TimeSpan value, JsonSerializerOptions options) =>
            throw new NotImplementedException();

        #endregion
    }
}
