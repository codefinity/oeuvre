using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domania.Domain
{
    public interface IDomainEvent : INotification
    {
        DateTime OccurredOn { get; }
    }
}
