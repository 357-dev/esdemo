using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventsDemo.Framework
{
    public interface IAggregateRootRepository<T> where T : AggregateRoot
    {
        Task AppendEventAsync(IEvent @event);

        Task<T> GetAggregateRoot(Guid id);
    }
}
