using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventsDemo.Domain.Exceptions
{
    public class StoryAlreadyCreatedException : Exception
    {
        public StoryAlreadyCreatedException() : base("Story already created.") { }
    }
}
