using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domania.Domain
{
    public interface IDomainEvent : INotification
    {
        Guid Id { get; }
        DateTime OccurredOn { get; }
    }
}
