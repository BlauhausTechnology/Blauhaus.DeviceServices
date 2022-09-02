using Blauhaus.DeviceServices.Abstractions.Thread;
using System.Threading.Tasks;

namespace Blauhaus.DeviceServices.Blazor.Services;

public class BlazorThreadService : IThreadService
{
    public bool IsOnMainThread { get; } = true;

    public void InvokeOnMainThread(Action action)
    {
        action.Invoke();
    }

    public void InvokeOnMainThread(Task task)
    {
        Task.Run(()=> task);
    }

    public async Task<T> InvokeOnMainThreadAsync<T>(Func<T> task)
    {
        return task.Invoke();
    }

    public async Task InvokeOnMainThreadAsync(Action action)
    {
        await Task.Run(action.Invoke);
    }

    public async Task<T> InvokeOnMainThreadAsync<T>(Func<Task<T>> task)
    {
        return await Task.Run(task.Invoke);
    }

    public async Task InvokeOnMainThreadAsync(Func<Task> task)
    {
        await Task.Run(task);
    }

    public async Task<SynchronizationContext> GetMainThreadSynchronizationContextAsync()
    {
        return null;
    }
}