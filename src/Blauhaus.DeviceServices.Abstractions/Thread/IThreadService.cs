using System;
using System.Threading;
using System.Threading.Tasks;

namespace Blauhaus.DeviceServices.Abstractions.Thread
{
    public interface IThreadService
    {
        bool IsOnMainThread { get; }
        Task<T> InvokeOnMainThreadAsync<T>(Func<T> task);
        Task InvokeOnMainThreadAsync(Action action);
        Task<T> InvokeOnMainThreadAsync<T>(Func<Task<T>> task);
        Task InvokeOnMainThreadAsync(Func<Task> task);
        Task<SynchronizationContext> GetMainThreadSynchronizationContextAsync();

    }
}