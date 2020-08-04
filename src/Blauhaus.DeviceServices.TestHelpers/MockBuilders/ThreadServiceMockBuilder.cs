using System;
using System.Threading.Tasks;
using Blauhaus.DeviceServices.Abstractions.Thread;
using Blauhaus.TestHelpers.MockBuilders;
using Moq;

namespace Blauhaus.DeviceServices.TestHelpers.MockBuilders
{
    public class ThreadServiceMockBuilder : BaseMockBuilder<ThreadServiceMockBuilder, IThreadService>
    {
        public ThreadServiceMockBuilder()
        {
            Mock.Setup(x => x.InvokeOnMainThreadAsync(It.IsAny<Action>()))
                .Callback((Action act) => act.Invoke());
            
            Mock.Setup(x => x.InvokeOnMainThreadAsync(It.IsAny<Func<Task>>()))
                .Callback((Func<Task> act) => act.Invoke());

        }

        public ThreadServiceMockBuilder Setup<T>()
        {
            Mock.Setup(x => x.InvokeOnMainThreadAsync<T>(It.IsAny<Func<T>>()))
                .Callback((Func<T> act) => act.Invoke());
            
            Mock.Setup(x => x.InvokeOnMainThreadAsync(It.IsAny<Func<Task<T>>>()))
                .Callback((Func<Task<T>> act) => act.Invoke());

            return this;
        }
    }
}