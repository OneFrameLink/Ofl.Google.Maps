using Ofl.Google.Maps.Places;
using System.Threading.Tasks;
using Xunit;

namespace Ofl.Google.Maps.Tests.Places
{
    public class PlacesClientTests : TestBase
    {
        #region Constructor

        public PlacesClientTests(MapClientTestsFixture fixture)
            : base(fixture)
        { }

        #endregion

        #region Tests

        [Fact]
        public async Task Test_GetDetailsAsync()
        {
            // Get the client.
            IPlacesClient client = Fixture.GetRequiredService<IPlacesClient>();

            // The place ID.
            // The White House, US.
            string placeId = "ChIJ37HL3ry3t4kRv3YLbdhpWXE";

            // Execute.
            PlaceDetails actual = await client
                .GetDetailsAsync(placeId, default)
                .ConfigureAwait(false);

            // Assert.
            Assert.Equal(Status.OK, actual.Status);
            Assert.Equal(placeId, actual.Result.PlaceId);
        }

        [Fact]
        public async Task Test_GetDetails2Async()
        {
            // Get the client.
            IPlacesClient client = Fixture.GetRequiredService<IPlacesClient>();

            // The place ID.
            // The White House, US.
            string placeId = "ChIJdY8J6x3IBZERR5k0LHRrmBU";

            // Execute.
            PlaceDetails actual = await client
                .GetDetailsAsync(placeId, default)
                .ConfigureAwait(false);

            // Assert.
            Assert.Equal(Status.OK, actual.Status);
            Assert.Equal(placeId, actual.Result.PlaceId);
        }

        #endregion
    }
}
