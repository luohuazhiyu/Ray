﻿using System.Threading.Tasks;
using Ray.Core.EventSourcing;
using Ray.IGrains;
using Ray.Postgresql;

namespace Ray.Grain
{
    public abstract class DbGrain<K, S> : SqlAsyncGrain<K, S, MessageInfo>
          where S : class, IState<K>, new()
    {
        protected override Task Handle(IEventBase<K> @event)
        {
            return Process(@event).ContinueWith(t =>
            {
                if (t.Exception != null)
                {
                    if (!(t.Exception.InnerException is Npgsql.PostgresException e && e.SqlState == "23505"))
                    {
                        throw t.Exception;
                    }
                }
            });
        }
        protected abstract Task Process(IEventBase<K> @event);
    }
}
