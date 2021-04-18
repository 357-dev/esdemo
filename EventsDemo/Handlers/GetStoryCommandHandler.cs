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
    public class GetStoryCommandHandler : IRequestHandler<GetStoryCommand, StoryDto>
    {
        private readonly IAggregateRootRepository<StoryAggregateRoot> _aggregateRootRepository;

        public GetStoryCommandHandler(IAggregateRootRepository<StoryAggregateRoot> aggregateRootRepository)
        {
            _aggregateRootRepository = aggregateRootRepository;
        }

        public async Task<StoryDto> Handle(GetStoryCommand request, CancellationToken cancellationToken)
        {
            var story = await _aggregateRootRepository.GetAggregateRoot(request.Id);
            return new StoryDto(story.Id, story.Title, story.Status, story.AssignedTo, story.IsCompleted);
        }
    }
}
