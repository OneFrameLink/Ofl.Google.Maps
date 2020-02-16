using Ofl.Google.Maps.Geocoding;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Ofl.Google.Maps.Tests.Geocoding
{
    public class GeocodingClientTests : TestBase
    {
        #region Constructor

        public GeocodingClientTests(MapClientTestsFixture fixture)
            : base(fixture)
        { }

        #endregion

        #region Tests

        [Fact]
        public async Task Test_GeocodeAsync()
        {
            // Get the client.
            IGeocodingClient client = Fixture.GetRequiredService<IGeocodingClient>();

            // Set up the request.
            var request = new GeocodeRequest(
                "1600 Pennsylvania Avenue, Washington D.C., United States"
            );

            // Make the request.
            var actual = await client
                .GeocodeAsync(request, default)
                .ConfigureAwait(false);

            // Validate response.
            Assert.Equal("OK", actual.Status);
            Assert.Single(actual.Results);
            Assert.Contains(actual.Results.Single().AddressComponents, c => c.LongName == "1600");
        }

        #endregion
    }
}
