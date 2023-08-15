using Blauhaus.DeviceServices.Abstractions.Share;
using Blauhaus.Errors;
using Blauhaus.Responses;
using Blauhaus.TestHelpers.MockBuilders;
using Moq;

namespace Blauhaus.DeviceServices.TestHelpers.MockBuilders;

public class ShareServiceMockBuilder : BaseMockBuilder<ShareServiceMockBuilder, IShareService>
{

    public ShareServiceMockBuilder()
    {
        Where_ShareFileAsync_succeeds();
    }

    public ShareServiceMockBuilder Where_ShareFileAsync_succeeds()
    {
        Mock.Setup(x => x.ShareFileAsync(It.IsAny<byte[]>(), It.IsAny<string>(), It.IsAny<string>()))
            .ReturnsAsync(Response.Success);
        return this;
    }

    public Error Where_ShareFileAsync_fails(Error? err = null)
    {
        err??=Error.Create(nameof(Where_ShareFileAsync_fails));
        Mock.Setup(x => x.ShareFileAsync(It.IsAny<byte[]>(), It.IsAny<string>(), It.IsAny<string>()))
            .ReturnsAsync(Response.Failure(err.Value));
        return err.Value;
    }
}