using System;
using Domaina.CQRS.Command;
using Newtonsoft.Json;

namespace Oeuvre.Modules.ContentCreation.Application.Members.CreateMember
{
    internal class CreateMemberCommand : InternalCommandBase
    {
        internal CreateMemberCommand(
            Guid id,
            Guid memberId,
            Guid tenantId,
            string eMailId,
            string firstName,
            string lastName)
            : base(id)
        {
            MemberId = memberId;
            TenantId = tenantId;
            EMailId = eMailId;
            FirstName = firstName;
            LastName = lastName;
        }

        internal Guid MemberId { get; }
        internal Guid TenantId { get; }
        internal string EMailId { get; }
        internal string FirstName { get; }
        internal string LastName { get; }

    }
}