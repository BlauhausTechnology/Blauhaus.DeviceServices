using Blauhaus.Responses;
using System.Threading.Tasks;

namespace Blauhaus.DeviceServices.Abstractions.Share;

public interface IShareService
{
    Task<Response> ShareFileAsync(byte[] fileBytes, string filename, string title);
}