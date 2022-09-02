using System;
using Blauhaus.Common.TestHelpers.MockBuilders;
using Blauhaus.DeviceServices.Abstractions.SecureStorage;
using Blauhaus.TestHelpers.MockBuilders;
using Moq;

namespace Blauhaus.DeviceServices.TestHelpers.MockBuilders
{
    public class SecureStorageServiceMockBuilder : BaseKeyValueProviderMockBuilder<SecureStorageServiceMockBuilder, ISecureStorageService>
    {
        public SecureStorageServiceMockBuilder()
        {
            Where_GetAsync_returns(Guid.NewGuid().ToString());
        }
         
    }
}