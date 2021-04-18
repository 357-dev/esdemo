using EventsDemo.Domain.Commands;
using EventsDemo.Domain.Events;
using EventsDemo.Domain.Exceptions;
using EventsDemo.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventsDemo.Domain
{
    public class StoryAggregateRoot : AggregateRoot
    {
        public string Title { get; private set; }
        public Statuses Status { get; private set; }
        public string AssignedTo { get; private set; }
        public bool IsCompleted { get; private set; }

        protected override void When(IEvent @event)
        {
            switch (@event)
            {
                case StoryCreatedEvent x: OnCreated(x); break;
                case StoryAssignedEvent x: OnAssigned(x); break;
                case StoryCompletedEvent x: OnCompleted(); break;
            }
        }

        public override IEvent Process(ICommand command)
        {
            switch (command)
            {
                case CreateStoryCommand x: return CreateStory(x);
                case AssignStoryCommand x: return AssignStory(x);
                case CompleteStoryCommand x: return CompleteStory(x);
            }

            throw new EntryPointNotFoundException($"{command.GetType().Name} not found!");
        }

        #region Commands

        private IEvent CreateStory(CreateStoryCommand command)
        {
            //if (Version >= 0)
            //{
            //    throw new StoryAlreadyCreatedException();
            //}

            return Apply(new StoryCreatedEvent(Guid.NewGuid(), command.Title));
        }

        private IEvent CompleteStory(CompleteStoryCommand command)
        {
            //if (Version == -1)
            //{
            //    throw new StoryNotFoundException();
            //}

            if (IsCompleted)
            {
                throw new StoryCompletedException();
            }

            return Apply(new StoryCompletedEvent(Id));
        }

        private IEvent AssignStory(AssignStoryCommand command)
        {
            //if (Version == -1)
            //{
            //    throw new StoryNotFoundException();
            //}

            if (IsCompleted)
            {
                throw new StoryCompletedException();
            }

            return Apply(new StoryAssignedEvent(Id, command.AssignedTo));
        }

        #endregion

        #region Event Handlers

        private void OnCreated(StoryCreatedEvent @event)
        {
            Id = @event.Id;
            Title = @event.Title;
            Status = Statuses.Open;
        }

        private void OnAssigned(StoryAssignedEvent @event)
        {
            Status = Statuses.InProgress;
            AssignedTo = @event.AssignedTo;
        }

        private void OnCompleted()
        {
            IsCompleted = true;
            Status = Statuses.Done;
        }

        #endregion
    }
}
