﻿using System;
using System.Threading;
using System.Threading.Tasks;
using Blauhaus.DeviceServices.Abstractions.Thread;

namespace Blauhaus.DeviceServices.TestHelpers.Dummies
{
    public class DummyThreadService : IThreadService
    {
        public void InvokeOnMainThread(Action action)
        {
            action.Invoke();
        }

        public void InvokeOnMainThread(Task task)
        {
            task.Wait();
        }

        public Task<T> InvokeOnMainThreadAsync<T>(Func<T> task)
        {
            return Task.FromResult(task.Invoke());
        }

        public Task InvokeOnMainThreadAsync(Action action)
        {
            action.Invoke();
            return Task.CompletedTask;
        }

        public async Task<T> InvokeOnMainThreadAsync<T>(Func<Task<T>> task)
        {
            return await task.Invoke();
        }

        public Task InvokeOnMainThreadAsync(Func<Task> task)
        {
            return task.Invoke();
        }

        public Task<SynchronizationContext> GetMainThreadSynchronizationContextAsync()
        {
            return Task.FromResult(new SynchronizationContext());
        }

        public bool IsOnMainThread { get; } = true;
    }
}