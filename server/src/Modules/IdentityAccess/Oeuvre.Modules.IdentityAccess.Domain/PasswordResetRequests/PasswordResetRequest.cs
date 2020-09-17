using Domania.Domain;
using Oeuvre.Modules.IdentityAccess.Domain.PasswordResetRequests.Events;
using Oeuvre.Modules.IdentityAccess.Domain.Users;
using System;
using System.Runtime.CompilerServices;

namespace Oeuvre.Modules.IdentityAccess.Domain.PasswordResetRequests
{
    public class PasswordResetRequest : Entity, IAggregateRoot
    {
        public PasswordResetRequestId Id { get; private set; }

        private UserId userId;

        private DateTime requestedOn;

        private PasswordRequestStatus status;

        private PasswordResetRequest()
        {

        }

        private PasswordResetRequest(UserId userId)
        {
            this.Id = new PasswordResetRequestId(Guid.NewGuid());
            this.userId = userId;
            this.requestedOn = SystemClock.Now;
            this.status = PasswordRequestStatus.ResetPending;

            AddDomainEvent(new PasswordResetRequested(userId));
        }

        internal static PasswordResetRequest CreateFromUser(UserId userId)
        {
            return new PasswordResetRequest(userId);
        }
    }
}
