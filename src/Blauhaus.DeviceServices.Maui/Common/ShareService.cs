using Blauhaus.DeviceServices.Abstractions.DeviceInfo;
using Blauhaus.DeviceServices.Abstractions.Share;
using Blauhaus.Errors;
using Blauhaus.Responses;
using Microsoft.Extensions.Logging;

namespace Blauhaus.DeviceServices.Maui.Common;

public class ShareService : IShareService
{
    private readonly ILogger<ShareService> _logger;
    private readonly IDeviceInfoService _deviceInfo;

    public ShareService(
        ILogger<ShareService> logger,
        IDeviceInfoService deviceInfo)
    {
        _logger = logger;
        _deviceInfo = deviceInfo;
    }


    public async Task<Response> ShareFileAsync(byte[] fileBytes, string filename, string title)
    {

        try
        {
            _logger.LogDebug("Processing share request for {FileName} with title {Title}", filename, title);
            
            string filePath = Path.Combine(_deviceInfo.AppDataFolder, filename);
            _logger.LogDebug("Set file path as {Path}", filePath);

            await File.WriteAllBytesAsync(filePath, fileBytes);
            string? mimeType = filename.EndsWith(".pdf") ? "application/pdf" : null;
            var fileToShare = new ShareFile(filePath, mimeType);
            _logger.LogDebug("Wrote bytes to file as content type {ContentType}", fileToShare.ContentType);

            await Share.RequestAsync(new ShareFileRequest
            {
                Title = title,
                File = fileToShare,
            });
        }
        catch (Exception e)
        {
            var error = Error.Unexpected("Failed to share file!");
            _logger.LogError(e, error.Description);
            return Response.Failure(error);
        }

        _logger.LogInformation("Successfully shared file!");
        return Response.Success();
    }
}

