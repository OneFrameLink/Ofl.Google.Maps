using System;

namespace Ofl.Google.Maps.TimeZone
{
    public class TimeZoneRequest
    {
        #region Constructor

        public TimeZoneRequest(
            decimal latitude,
            decimal longitude,
            DateTime timestamp
        )
        {
            // Assign values.
            Latitude = latitude;
            Longitude = longitude;
            Timestamp = timestamp;
        }

        #endregion

        #region Instance, read-only state

        public decimal Latitude { get; }

        public decimal Longitude { get; }

        public DateTime Timestamp { get; }

        #endregion
    }
}
