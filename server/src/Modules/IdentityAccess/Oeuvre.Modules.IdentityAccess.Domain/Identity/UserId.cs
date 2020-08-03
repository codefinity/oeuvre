using System;
using Domania.Domain;

namespace Oeuvre.Modules.IdentityAccess.Domain.Identity
{
    public class UserId : Value<UserId>
    {
        public Guid Value { get; internal set; }

        protected UserId() { }

        public UserId(Guid value)
        {
            if (value == default)
                throw new ArgumentNullException(nameof(value), "Classified Ad id cannot be empty");

            Value = value;
        }

        public static implicit operator Guid(UserId self) => self.Value;

        public static implicit operator UserId(string value)
            => new UserId(Guid.Parse(value));

        public override string ToString() => Value.ToString();
    }
}
