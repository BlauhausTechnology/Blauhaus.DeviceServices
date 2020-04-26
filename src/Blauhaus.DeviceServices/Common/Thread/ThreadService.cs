using System;
using System.Threading;
using System.Threading.Tasks;
using Blauhaus.DeviceServices.Abstractions.Thread;
using Xamarin.Essentials;

namespace Blauhaus.DeviceServices.Common.Thread
{
    public class ThreadService : IThreadService
    {
        public bool IsOnMainThread => MainThread.IsMainThread;

        public Task<T> InvokeOnMainThreadAsync<T>(Func<T> task)
        {
            return MainThread.InvokeOnMainThreadAsync(task);
        }

        public Task InvokeOnMainThreadAsync(Action action)
        {
            return MainThread.InvokeOnMainThreadAsync(action);
        }

        public Task<T> InvokeOnMainThreadAsync<T>(Func<Task<T>> task)
        {
            return MainThread.InvokeOnMainThreadAsync(task);
        }

        public Task InvokeOnMainThreadAsync(Func<Task> task)
        {
            return MainThread.InvokeOnMainThreadAsync(task);
        }

        public Task<SynchronizationContext> GetMainThreadSynchronizationContextAsync()
        {
            return MainThread.GetMainThreadSynchronizationContextAsync();
        }
    }
}