﻿using System;
using Blauhaus.DeviceServices.Abstractions.SecureStorage;
using Blauhaus.TestHelpers.MockBuilders;
using Moq;

namespace Blauhaus.DeviceServices.TestHelpers.MockBuilders
{
    public class SecureStorageServiceMockBuilder : BaseMockBuilder<SecureStorageServiceMockBuilder, ISecureStorageService>
    {
        public SecureStorageServiceMockBuilder()
        {
            Where_GetAsync_returns(Guid.NewGuid().ToString());
        }

        public SecureStorageServiceMockBuilder Where_GetAsync_returns(string value)
        {
            Mock.Setup(x => x.GetAsync(It.IsAny<string>())).ReturnsAsync(value);
            return this;
        }

        public SecureStorageServiceMockBuilder Where_GetAsync_returns(string key, string value)
        {
            Mock.Setup(x => x.GetAsync(key)).ReturnsAsync(value);
            return this;
        }

        public void VerifySetAsyncCalled(string key, string value)
        {
            Mock.Verify(x => x.SetAsync(key, value));
        }
        
        public void VerifyGetAsyncCalled(string key)
        {
            Mock.Verify(x => x.GetAsync(key));
        }
        
        public void VerifyRemoveCalled(string key)
        {
            Mock.Verify(x => x.Remove(key));
        }
    }
}