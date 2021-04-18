using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventsDemo.Framework
{
    public abstract class AggregateRoot
    {
        // private readonly IList<IEvent> Events = new List<IEvent>();

        public Guid Id { get; protected set; }

        public long Version { get; protected set; } = -1;

        protected abstract void When(IEvent @event);

        public abstract IEvent Process(ICommand command);

        public IEvent Apply(IEvent @event)
        {
            When(@event);

            // Events.Add(@event);

            return @event;
        }

        public void Load(IEnumerable<IEvent> history)
        {
            foreach (var e in history)
            {
                When(e);
            }
        }

    }
}
