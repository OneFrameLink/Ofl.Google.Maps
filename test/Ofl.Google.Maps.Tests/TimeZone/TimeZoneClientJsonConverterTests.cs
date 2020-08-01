using Ofl.Google.Maps.Places;
using Ofl.Google.Maps.TimeZone;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Xunit;

namespace Ofl.Google.Maps.Tests.TimeZone
{
    public class TimeZoneClientJsonConverterTests : TestBase
    {
        #region Constructor

        public TimeZoneClientJsonConverterTests(MapClientTestsFixture fixture)
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
            ITimeZoneClient client = Fixture.GetRequiredService<ITimeZoneClient>();

            // Create the request.
            var request = new TimeZoneRequest(
                // The White House
                38.8977M,
                -77.0365M,
                // 🎆🎆 July 4th, 2020 🎆🎆
                new DateTime(2020, 07, 04)
            );

            // Execute.
            TimeZoneResponse results = await client
                .GetTimeZoneAsync(request, default)
                .ConfigureAwait(false);

            // Create the container.
            var expected = new Container<TimeZoneResponse> { Value = results };

            // Serialize to a string.
            string json = JsonSerializer.Serialize(expected);

            // Serialize again.
            var actual = JsonSerializer.Deserialize<Container<TimeZoneResponse>>(json);

            // Compare.
            Assert.Equal(expected.Value.Status, actual.Value.Status);
            Assert.Equal(expected.Value.TimeZoneId, actual.Value.TimeZoneId);
            Assert.Equal(expected.Value.RawOffset, actual.Value.RawOffset);
        }

        #endregion
    }
}
