using Blauhaus.DeviceServices.Abstractions.Permissions;
using Blauhaus.TestHelpers.MockBuilders;
using CSharpFunctionalExtensions;
using Moq;

namespace Blauhaus.DeviceServices.TestHelpers.MockBuilders
{
    public class DevicePermissionsServiceMockBuilder : BaseMockBuilder<DevicePermissionsServiceMockBuilder, IDevicePermissionsService>
    {
        public DevicePermissionsServiceMockBuilder()
        {
            Where_RequestPermissionAsync_returns(Result.Success());
        }

        public DevicePermissionsServiceMockBuilder Where_CheckPermissionAsync_returns(Result result)
        {
            Mock.Setup(x => x.CheckPermissionAsync(It.IsAny<DevicePermission>()))
                .ReturnsAsync(result);
            return this;
        }

        public DevicePermissionsServiceMockBuilder Where_CheckPermissionAsync_returns(Result result, DevicePermission requestedPermission)
        {
            Mock.Setup(x => x.CheckPermissionAsync(requestedPermission))
                .ReturnsAsync(result);
            return this;
        }

        public DevicePermissionsServiceMockBuilder Where_RequestPermissionAsync_returns(Result result)
        {
            Mock.Setup(x => x.RequestPermissionAsync(It.IsAny<DevicePermission>()))
                .ReturnsAsync(result);
            return this;
        }

        public DevicePermissionsServiceMockBuilder Where_RequestPermissionAsync_returns(Result result, DevicePermission requestedPermission)
        {
            Mock.Setup(x => x.RequestPermissionAsync(requestedPermission))
                .ReturnsAsync(result);
            return this;
        }
    }
}