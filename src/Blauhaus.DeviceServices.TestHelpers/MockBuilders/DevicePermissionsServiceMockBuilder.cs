using Blauhaus.DeviceServices.Abstractions.Permissions;
using Blauhaus.Responses;
using Blauhaus.TestHelpers.MockBuilders;
using Moq;

namespace Blauhaus.DeviceServices.TestHelpers.MockBuilders
{
    public class DevicePermissionsServiceMockBuilder : BaseMockBuilder<DevicePermissionsServiceMockBuilder, IDevicePermissionsService>
    {
        public DevicePermissionsServiceMockBuilder()
        {
            Where_RequestPermissionAsync_returns(Response.Success());
            Where_EnsurePermissionGrantedAsync_returns(Response.Success());
        }
        public DevicePermissionsServiceMockBuilder Where_EnsurePermissionGrantedAsync_returns(Response result, DevicePermission permission)
        {
            Mock.Setup(x => x.EnsurePermissionGrantedAsync(permission))
                .ReturnsAsync(result);
            return this;
        }
        public DevicePermissionsServiceMockBuilder Where_EnsurePermissionGrantedAsync_returns(Response result)
        {
            Mock.Setup(x => x.EnsurePermissionGrantedAsync(It.IsAny<DevicePermission>()))
                .ReturnsAsync(result);
            return this;
        }
        public DevicePermissionsServiceMockBuilder Where_CheckPermissionAsync_returns(Response result)
        {
            Mock.Setup(x => x.CheckPermissionAsync(It.IsAny<DevicePermission>()))
                .ReturnsAsync(result);
            return this;
        }

        public DevicePermissionsServiceMockBuilder Where_CheckPermissionAsync_returns(Response result, DevicePermission requestedPermission)
        {
            Mock.Setup(x => x.CheckPermissionAsync(requestedPermission))
                .ReturnsAsync(result);
            return this;
        }

        public DevicePermissionsServiceMockBuilder Where_RequestPermissionAsync_returns(Response result)
        {
            Mock.Setup(x => x.RequestPermissionAsync(It.IsAny<DevicePermission>()))
                .ReturnsAsync(result);
            return this;
        }

        public DevicePermissionsServiceMockBuilder Where_RequestPermissionAsync_returns(Response result, DevicePermission requestedPermission)
        {
            Mock.Setup(x => x.RequestPermissionAsync(requestedPermission))
                .ReturnsAsync(result);
            return this;
        }
    }
}