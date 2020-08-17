using System;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using Domania.Domain;
using Oeuvre.Modules.IdentityAccess.Domain.Tenants;
using Oeuvre.Modules.IdentityAccess.Domain.UserRegistrations.Events;
using Oeuvre.Modules.IdentityAccess.Domain.UserRegistrations.Rules;
using Oeuvre.Modules.IdentityAccess.Domain.Users;

namespace Oeuvre.Modules.IdentityAccess.Domain.UserRegistrations
{
    public class Registration : Entity, IAggregateRoot
    {
        public UserRegistrationId Id { get; private set; }

        private TenantId tenantId;

        private FullName fullName;

        private string password;

        private MobileNumber mobileNumber;

        private string eMailId;

        private DateTime registrationDate;

        private UserRegistrationStatus status;

        private DateTime? confirmedDate;

        private Registration()
        {
            // Only EF.
        }

        private Registration(TenantId tenantId, 
                                FullName fullName,
                                string password,
                                MobileNumber mobileNumber,
                                string eMailId,
                                IUsersCounter usersCounter)
        {
            this.CheckRule(new UserLoginMustBeUniqueRule(usersCounter, eMailId));

            this.Id = new UserRegistrationId(Guid.NewGuid());

            this.tenantId = tenantId;
            this.fullName = fullName;
            this.password = password;
            this.mobileNumber = mobileNumber;
            this.eMailId = eMailId;

            registrationDate = DateTime.UtcNow;

            //this.status = 1;
            status = UserRegistrationStatus.WaitingForConfirmation;

            this.AddDomainEvent(new NewUserRegisteredDomainEvent(this.Id,
                                                                    fullName.FirstName,
                                                                    fullName.LastName,
                                                                    mobileNumber.MobileNo,
                                                                    eMailId, 
                                                                    registrationDate));
        }

        public static Registration RegisterNewUser(Guid tenantId,
                                                    string firstName,
                                                     string lastName,
                                                     string password,
                                                     string mobileNoCountryCode,
                                                     string mobileNumber,
                                                     string emailId,
                                                     IUsersCounter usersCounter)
        {
            return new Registration(new TenantId(tenantId), 
                                        new FullName(firstName, lastName),
                                        password,
                                        new MobileNumber(mobileNoCountryCode, mobileNumber),
                                        emailId,
                                        usersCounter);
        }

        public User CreateUser()
        {

           //this.CheckRule(new UserCannotBeCreatedWhenRegistrationIsNotConfirmedRule(status));

           return User.CreateFromUserRegistration(this.Id,
                                                    this.tenantId,
                                                    this.fullName.FirstName,
                                                    this.fullName.LastName,
                                                    this.mobileNumber.CountryCode,
                                                    this.mobileNumber.MobileNo,
                                                    this.eMailId,
                                                    this.password);
        }

        public void Confirm()
        {
            this.CheckRule(new UserRegistrationCannotBeConfirmedMoreThanOnceRule(status));
            this.CheckRule(new UserRegistrationCannotBeConfirmedAfterExpirationRule(status));

            //this.fullName = new FullName("X", "Y");
            this.status = UserRegistrationStatus.Confirmed;
            this.confirmedDate = DateTime.UtcNow;

            this.AddDomainEvent(new UserRegistrationConfirmedDomainEvent(this.Id));
        }

        public void Expire()
        {
            //this.CheckRule(new UserRegistrationCannotBeExpiredMoreThanOnceRule(_status));

            //status = UserRegistrationStatus.Expired;

            //this.AddDomainEvent(new UserRegistrationExpiredDomainEvent(this.Id));
        }
    }
}