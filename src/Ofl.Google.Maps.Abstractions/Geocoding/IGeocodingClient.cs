using System.Threading;
using System.Threading.Tasks;

namespace Ofl.Google.Maps.Geocoding
{
    public interface IGeocodingClient
    {
        Task<GeocodeResponse> GeocodeAsync(GeocodeRequest request, CancellationToken cancellationToken);
    }
}
