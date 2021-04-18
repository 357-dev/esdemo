using EventsDemo.Domain;
using EventsDemo.Domain.Commands;
using EventsDemo.Framework;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EventsDemo.Handlers
{
    public class AssignStoryCommandHandler : AsyncRequestHandler<AssignStoryCommand>
    {
        private readonly IAggregateRootRepository<StoryAggregateRoot> _aggregateRootRepository;

        public AssignStoryCommandHandler(IAggregateRootRepository<StoryAggregateRoot> aggregateRootRepository)
        {
            _aggregateRootRepository = aggregateRootRepository;
        }

        protected override async Task Handle(AssignStoryCommand request, CancellationToken cancellationToken)
        {
            var story = await _aggregateRootRepository.GetAggregateRoot(request.Id);
            var @event = story.Process(request);

            await _aggregateRootRepository.AppendEventAsync(@event);

        }
    }
}
