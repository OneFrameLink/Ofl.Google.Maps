using System.Threading;
using System.Threading.Tasks;
using Ofl.Google.Maps.TimeZone;

namespace Ofl.Google.Maps.TimeZone
{
    public interface ITimeZoneClient
    {
        Task<TimeZoneResponse> GetTimeZoneAsync(TimeZoneRequest request, CancellationToken cancellationToken);
    }
}
