using EventsDemo.Domain.Events;
using EventStore.Client;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsDemo.Framework
{
    public class AggregateRootRepository<T> : IAggregateRootRepository<T> where T : AggregateRoot
    {
        private readonly EventStoreClient _eventStoreClient;

        public AggregateRootRepository(EventStoreClient eventStoreClient)
        {
            _eventStoreClient = eventStoreClient;
        }

        public async Task AppendEventAsync(IEvent @event)
        {
            var eventData = new EventData(
                Uuid.NewUuid(),
                @event.GetType().AssemblyQualifiedName,
                Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(@event))
            );

            await _eventStoreClient.AppendToStreamAsync(
                GetStreamName(@event.Id),
                StreamState.Any,
                new List<EventData> {
                    eventData
                });
        }
        public async Task<T> GetAggregateRoot(Guid id)
        {
            var events = new List<IEvent>();
            var stream = _eventStoreClient.ReadStreamAsync(
                Direction.Forwards,
                GetStreamName(id),
                StreamPosition.Start);

            var streamEvents = await stream.ToListAsync();

            foreach (var @event in streamEvents)
            {
                events.Add(JsonConvert.DeserializeObject(Encoding.UTF8.GetString(@event.Event.Data.ToArray()), Type.GetType(@event.Event.EventType)) as IEvent);
            }

            var aggregateRoot = Activator.CreateInstance(typeof(T)) as T;
            aggregateRoot.Load(events);
            return aggregateRoot;
        }

        private string GetStreamName(Guid Id) => $"{typeof(T)}-{Id}";
    }
}
