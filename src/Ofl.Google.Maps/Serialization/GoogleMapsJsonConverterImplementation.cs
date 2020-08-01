using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Ofl.Google.Maps.Serialization.Newtonsoft
{
    internal class GoogleMapsJsonConverterImplementation<T> : JsonConverter<T>
    {
        #region Constructor

        public GoogleMapsJsonConverterImplementation(JsonSerializerOptions options)
        {
            // Assign values.
            _options = options;
        }

        #endregion

        #region Instance, read-only state

        private readonly JsonSerializerOptions _options;

        #endregion

        #region Overrides of JsonConverter

        public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) =>
            JsonSerializer.Deserialize<T>(ref reader, _options);

        public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options) =>
            JsonSerializer.Serialize(writer, value, _options);

        #endregion
    }
}
