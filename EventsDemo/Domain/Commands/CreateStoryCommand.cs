using EventsDemo.Framework;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventsDemo.Domain.Commands
{
    public record CreateStoryCommand(string Title) : IRequest, ICommand;
}
