using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventsDemo.Domain.Exceptions
{
    public class StoryCompletedException : Exception
    {
        public StoryCompletedException() : base("Story is completed.") { }
    }
}
