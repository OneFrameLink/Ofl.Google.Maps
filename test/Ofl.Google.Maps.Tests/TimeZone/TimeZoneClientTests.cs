using Ofl.Google.Maps.TimeZone;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Ofl.Google.Maps.Tests.TimeZone
{
    public class TimeZoneClientTests : TestBase
    {
        #region Constructor

        public TimeZoneClientTests(MapClientTestsFixture fixture)
            : base(fixture)
        { }

        #endregion

        #region Tests

        [Fact]
        public async Task Test_GetTimeZoneAsync()
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
            TimeZoneResponse actual = await client
                .GetTimeZoneAsync(request, default)
                .ConfigureAwait(false);

            // Assert.
            Assert.Equal(Status.OK, actual.Status);
            Assert.Null(actual.ErrorMessage);
            Assert.Equal(TimeSpan.FromHours(1), actual.DstOffset);
            Assert.Equal(TimeSpan.FromHours(-5), actual.RawOffset);
            Assert.Equal("America/New_York", actual.TimeZoneId);
            Assert.Equal("Eastern Daylight Time", actual.TimeZoneName);
        }

        #endregion
    }
}
