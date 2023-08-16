using System;
using System.IO;
using System.Threading.Tasks;
using Blauhaus.Analytics.Abstractions;
using Blauhaus.Analytics.Abstractions.Extensions;
using Blauhaus.DeviceServices.Abstractions.Share;
using Blauhaus.Errors;
using Blauhaus.Responses;
using Microsoft.Extensions.Logging;
using Xamarin.Essentials;

namespace Blauhaus.DeviceServices.Common.Share;

public class ShareService : IShareService
{
    private readonly IAnalyticsLogger<ShareService> _logger;

    public ShareService(IAnalyticsLogger<ShareService> logger)
    {
        _logger = logger;
    }


    public async Task<Response> ShareFileAsync(byte[] fileBytes, string filename, string title)
    {

        try
        {
            _logger.LogDebug("Processing share request for {FileName} with title {Title}", filename, title);
            
            string filePath = Path.Combine(FileSystem.CacheDirectory, filename);
            _logger.LogDebug("Set file path as {Path}", filePath);

            File.WriteAllBytes(filePath, fileBytes);
            string? mimeType = filename.EndsWith(".pdf") ? "" : null;
            var fileToShare = new ShareFile(filePath,  "application/pdf");
            _logger.LogDebug("Wrote bytes to file as content type {ContentType}", fileToShare.ContentType);

            await Xamarin.Essentials.Share.RequestAsync(new ShareFileRequest
            {
                Title = title,
                File = fileToShare,
            });
        }
        catch (Exception e)
        {
            var error = Error.Unexpected("Failed to share file!");
            _logger.LogError(error, e);
            return Response.Failure(error);
        }

        _logger.LogInformation("Successfully shared file!");
        return Response.Success();
    }
}

