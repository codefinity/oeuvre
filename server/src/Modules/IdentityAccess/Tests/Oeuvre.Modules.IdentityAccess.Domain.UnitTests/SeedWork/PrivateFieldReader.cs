using Domania.Domain;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Oeuvre.Modules.IdentityAccess.Domain.UnitTests.SeedWork
{
    internal static class PrivateFieldReader
    {
        internal static object GetProperty(this Entity instance, string fieldName)
        {
            BindingFlags bindFlags = BindingFlags.Instance 
                                        //| BindingFlags.Public 
                                        | BindingFlags.NonPublic
                                        | BindingFlags.Static;
            FieldInfo field = instance
                                .GetType()
                                .GetField(fieldName, bindFlags);

            return field.GetValue(instance);
        }
    }
}
