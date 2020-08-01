using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Ofl.Google.Maps.Serialization.Newtonsoft
{
    public abstract class GoogleMapsJsonConverter : JsonConverterFactory
    {
        #region Constructor

        public GoogleMapsJsonConverter(JsonSerializerOptions options)
        {
            // Assign values.
            _options = options;
        }

        #endregion

        #region Instance, read-only state

        private readonly JsonSerializerOptions _options;

        #endregion

        #region Overrides of JsonConverterFactory

        public override bool CanConvert(Type typeToConvert) => true;

        public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options)
        {
            // Create the converter type.
            Type type = typeof(GoogleMapsJsonConverterImplementation<>).MakeGenericType(typeToConvert);

            // Create the instance and return.
            return (JsonConverter) Activator.CreateInstance(type, _options);
        }

        #endregion
    }
}
