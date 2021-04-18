using EventsDemo.Domain;
using EventsDemo.Domain.Commands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventsDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StoryController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpGet("{id}")]
        public async Task<StoryDto> CreateStory([FromRoute] Guid id)
        {
            return await _mediator.Send(new GetStoryCommand(id));
        }

        [HttpPost]
        public async Task CreateStory([FromBody] CreateStoryCommand createStoryCommand)
        {
            await _mediator.Send(createStoryCommand);
        }

        [HttpPatch("assign")]
        public async Task AssignStory([FromBody] AssignStoryCommand assignStoryCommand)
        {
            await _mediator.Send(assignStoryCommand);
        }

        [HttpPatch("complete")]
        public async Task CompleteStory([FromBody] CompleteStoryCommand completeStoryCommand)
        {
            await _mediator.Send(completeStoryCommand);
        }
    }
}
