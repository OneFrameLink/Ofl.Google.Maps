using Ofl.Google.Maps.Geocoding;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Xunit;

namespace Ofl.Google.Maps.Tests.Geocoding
{
    public class GeocodingClientJsonConverterTests : TestBase
    {
        #region Constructor

        public GeocodingClientJsonConverterTests(MapClientTestsFixture fixture)
            : base(fixture)
        { }

        #endregion

        #region Helpers

        private class Container<T> { 
            [JsonConverter(typeof(GeocodingClientJsonConverter))]
            public T Value { get; set; }
        }

        #endregion

        #region Tests

        [Fact]
        public async Task Test_SerializationAsync()
        {
            // Get the client.
            IGeocodingClient client = Fixture.GetRequiredService<IGeocodingClient>();

            // Set up the request.
            var request = new GeocodeRequest(
                "1600 Pennsylvania Avenue, Washington D.C., United States"
            );

            // Make the request.
            var results = await client
                .GeocodeAsync(request, default)
                .ConfigureAwait(false);

            // Create the container.
            var expected = new Container<GeocodeResponse> { Value = results };

            // Serialize to a string.
            string json = JsonSerializer.Serialize(expected);

            // Serialize again.
            var actual = JsonSerializer.Deserialize<Container<GeocodeResponse>>(json);

            // Compare.
            Assert.Equal(expected.Value.Status, actual.Value.Status);
            Assert.Equal(expected.Value.Results.Count, actual.Value.Results.Count);
        }

        #endregion
    }
}
