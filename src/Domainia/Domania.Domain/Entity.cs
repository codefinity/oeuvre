using System;
namespace Domania.Domain
{
    public abstract class Entity : IInternalEventHandler
        
    {
        private readonly Action<object> _applier;

        public Guid Id { get; protected set; }

        protected Entity(Action<object> applier) => _applier = applier;

        protected Entity() { }

        protected abstract void When(object @event);

        protected void Apply(object @event)
        {
            When(@event);
            _applier(@event);
        }

        void IInternalEventHandler.Handle(object @event) => When(@event);
    }

}
