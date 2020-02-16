using System.Threading;
using System.Threading.Tasks;

namespace Ofl.Google.Maps.Places
{
    public interface IPlacesClient
    {
        Task<PlaceDetails> GetDetailsAsync(string placeId, CancellationToken cancellationToken);
    }
}
