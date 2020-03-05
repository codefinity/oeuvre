using System;
namespace Domania.Domain
{
    public interface IInternalEventHandler
    {
        void Handle(object @event);
    }
}
