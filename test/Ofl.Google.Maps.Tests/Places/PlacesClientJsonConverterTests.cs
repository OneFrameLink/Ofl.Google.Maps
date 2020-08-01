using Ofl.Google.Maps.Places;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Xunit;

namespace Ofl.Google.Maps.Tests.Places
{
    public class PlacesClientJsonConverterTests : TestBase
    {
        #region Constructor

        public PlacesClientJsonConverterTests(MapClientTestsFixture fixture)
            : base(fixture)
        { }

        #endregion

        #region Helpers

        private class Container<T>
        {
            [JsonConverter(typeof(PlacesClientJsonConverter))]
            public T Value { get; set; }
        }

        #endregion

        #region Tests

        [Fact]
        public async Task Test_SerializationAsync()
        {
            // Get the client.
            IPlacesClient client = Fixture.GetRequiredService<IPlacesClient>();

            // The place ID.
            // The White House, US.
            string placeId = "ChIJ37HL3ry3t4kRv3YLbdhpWXE";

            // Make the request.
            PlaceDetails results = await client
                .GetDetailsAsync(placeId, default)
                .ConfigureAwait(false);

            // Create the container.
            var expected = new Container<PlaceDetails> { Value = results };

            // Serialize to a string.
            string json = JsonSerializer.Serialize(expected);

            // Serialize again.
            var actual = JsonSerializer.Deserialize<Container<PlaceDetails>>(json);

            // Compare.
            Assert.Equal(expected.Value.Status, actual.Value.Status);
            Assert.Equal(expected.Value.Result.PlaceId, actual.Value.Result.PlaceId);
            Assert.Equal(expected.Value.Result.Geometry.Location.Lat, actual.Value.Result.Geometry.Location.Lat);
            Assert.Equal(expected.Value.Result.UtcOffset, actual.Value.Result.UtcOffset);
        }

        #endregion
    }
}
