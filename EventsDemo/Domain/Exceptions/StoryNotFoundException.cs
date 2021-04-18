using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventsDemo.Domain.Exceptions
{
    public class StoryNotFoundException : Exception
    {
        public StoryNotFoundException() : base("Story not found.") { }
    }
}
