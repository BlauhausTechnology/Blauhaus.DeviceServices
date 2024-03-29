﻿using Blauhaus.DeviceServices.Abstractions.Thread;

namespace Blauhaus.DeviceServices.Maui
{
    public class ThreadService : IThreadService
    {
        public bool IsOnMainThread => MainThread.IsMainThread;
        public void InvokeOnMainThread(Action action)
        {
            MainThread.BeginInvokeOnMainThread(action);
        }

        public void InvokeOnMainThread(Task task)
        {
            MainThread.BeginInvokeOnMainThread(async () => await task);
        }

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