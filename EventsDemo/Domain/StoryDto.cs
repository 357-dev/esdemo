using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventsDemo.Domain
{
    public record StoryDto(Guid Id, string Title, Statuses Status, string AssignedTo, bool IsCompleted);
}
