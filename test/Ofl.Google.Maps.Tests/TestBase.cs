using System;
using Xunit;

namespace Ofl.Google.Maps.Tests
{
    public abstract class TestBase : IClassFixture<MapClientTestsFixture>
    {
        #region Constructor

        protected TestBase(MapClientTestsFixture fixture)
        {
            // Validate parameters.
            Fixture = fixture ?? throw new ArgumentNullException(nameof(fixture));
        }

        #endregion

        #region Instance, read-only state

        protected MapClientTestsFixture Fixture { get; }

        #endregion
    }
}
