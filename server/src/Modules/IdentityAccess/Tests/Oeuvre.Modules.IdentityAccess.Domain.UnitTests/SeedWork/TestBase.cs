using System;
using System.Linq;
using Domania.Domain;

namespace Oeuvre.Modules.IdentityAccess.Domain.UnitTests.SeedWork
{
    public abstract class TestBase
    {
        public static T AssertPublishedDomainEvent<T>(Entity aggregate) where T : IDomainEvent
        {
            var domainEvent = DomainEventsTestHelper.GetAllDomainEvents(aggregate).OfType<T>().SingleOrDefault();

            if (domainEvent == null)
            {
                throw new Exception($"{typeof(T).Name} event not published");
            }

            return domainEvent;
        }
    }
}