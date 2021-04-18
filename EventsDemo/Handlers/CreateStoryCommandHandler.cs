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
    public class CreateStoryCommandHandler : AsyncRequestHandler<CreateStoryCommand>
    {
        private readonly IAggregateRootRepository<StoryAggregateRoot> _aggregateRootRepository;

        public CreateStoryCommandHandler(IAggregateRootRepository<StoryAggregateRoot> aggregateRootRepository)
        {
            _aggregateRootRepository = aggregateRootRepository;
        }

        protected override async Task Handle(CreateStoryCommand request, CancellationToken cancellationToken)
        {
            var aggregate = new StoryAggregateRoot();
            var @event = aggregate.Process(request);

            await _aggregateRootRepository.AppendEventAsync(@event);

            // could broadcast after
        }
    }
}
