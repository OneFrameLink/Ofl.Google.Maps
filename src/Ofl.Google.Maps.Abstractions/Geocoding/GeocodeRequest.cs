using System;

namespace Ofl.Google.Maps.Geocoding
{
    public class GeocodeRequest
    {
        #region Constructor

        public GeocodeRequest(
            string address
        )
        {
            // Validate parameters.
            Address = string.IsNullOrWhiteSpace(address)
                ? throw new ArgumentNullException(nameof(address))
                : address;
        }

        #endregion

        public string Address { get; set; }
    }
}
