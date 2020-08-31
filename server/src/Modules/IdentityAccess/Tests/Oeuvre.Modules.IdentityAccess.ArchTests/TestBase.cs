using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NetArchTest.Rules;
using Oeuvre.Modules.IdentityAccess.Application.Contracts;
using Oeuvre.Modules.IdentityAccess.Infrastructure;
using Oeuvre.Modules.IdentityAccess.Domain.Users;
using Xunit;
using Domaina.CQRS;
using Domaina.CQRS.Command;

namespace Oeuvre.Modules.IdentityAccess.ArchTests
{
    public abstract class TestBase
    {
        protected static Assembly ApplicationAssembly = typeof(CommandBase).Assembly;
        protected static Assembly DomainAssembly = typeof(User).Assembly;
        protected static Assembly InfrastructureAssembly = typeof(IdentityAccessContext).Assembly;

        protected static void AssertAreImmutable(IEnumerable<Type> types)
        {
            IList<Type> failingTypes = new List<Type>();
            foreach (var type in types)
            {
                if (type.GetFields().Any(x => !x.IsInitOnly) || type.GetProperties().Any(x => x.CanWrite))
                {
                    failingTypes.Add(type);
                    break;
                }
            }

            AssertFailingTypes(failingTypes);
        }
        protected static void AssertFailingTypes(IEnumerable<Type> types)
        {
            //types.Should
            //Assert.That(types, Is.Null.Or.Empty);
            //Assert.NotNull(types)  Assert.NotEmpty(types);

            Assert.True((types == null) || types.Count() == 0);


        }

        protected static void AssertArchTestResult(TestResult result)
        {
            AssertFailingTypes(result.FailingTypes);
        }
    }
}