using EventsDemo.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventsDemo.Domain.Events
{
    public class StoryCreatedEvent : IEvent
    {
        public StoryCreatedEvent(Guid id, string title)
        {
            Id = id;
            Title = title;
        }

        public Guid Id { get; set; }
        public string Title { get; set; }
    }
}
