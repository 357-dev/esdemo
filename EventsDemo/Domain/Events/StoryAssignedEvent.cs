using EventsDemo.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace EventsDemo.Domain.Events
{
    public record StoryAssignedEvent(Guid Id, string AssignedTo) : IEvent;
}
