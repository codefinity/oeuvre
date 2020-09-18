using Domania.Domain;
using Oeuvre.Modules.IdentityAccess.Domain.PasswordResetRequests.Events;
using Oeuvre.Modules.IdentityAccess.Domain.PasswordResetRequests.Rules;
using Oeuvre.Modules.IdentityAccess.Domain.Users;
using System;
using System.Runtime.CompilerServices;

namespace Oeuvre.Modules.IdentityAccess.Domain.PasswordResetRequests
{
    public class PasswordResetRequest : Entity, IAggregateRoot
    {
        public PasswordResetRequestId Id { get; private set; }

        private string eMailId;

        private DateTime requestedOn;

        private PasswordRequestStatus status;

        private PasswordResetRequest()
        {

        }

        private PasswordResetRequest(string eMailId, IUserFinder finder)
        {
            //Rules
            CheckRule(new UserLoginEMailIdMustExistRule(eMailId, finder));
            CheckRule(new UserMustBeActiveRule(eMailId, finder));

            this.Id = new PasswordResetRequestId(Guid.NewGuid());
            this.eMailId = eMailId;
            this.requestedOn = SystemClock.Now;
            this.status = PasswordRequestStatus.ResetPending;

            AddDomainEvent(new PasswordResetRequestedDomainEvent(eMailId));
        }

        public static PasswordResetRequest RequestPasswordReset(string eMailId, IUserFinder finder)
        {
            return new PasswordResetRequest(eMailId, finder);
        }

        public void SendNewPassword(string newPassword, 
            IPasswordResetExpirationCalculator calculator, 
            IUserFinder finder)
        {
            CheckRule(new UserMustBeActiveRule(eMailId, finder));
            CheckRule(new PasswordCannotBeResetMoreThanOnceRule(status));
            CheckRule(new PasswordCannotBeResetAfterRequestExpirationRule(calculator, requestedOn));

            status = PasswordRequestStatus.NewPasswordReveived;

            AddDomainEvent(new NewPasswordReceivedDomainEvent(eMailId, newPassword));
        }
    }
}
