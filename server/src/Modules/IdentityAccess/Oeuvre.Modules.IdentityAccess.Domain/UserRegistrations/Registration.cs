using System;
using System.Runtime.CompilerServices;
using Domania.Domain;

namespace Oeuvre.Modules.IdentityAccess.Domain.UserRegistrations
{
    public class Registration : Entity, IAggregateRoot
    {
        public long Id { get; private set; }

        //public UserRegistrationId userRegistrationId;

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

        private Registration(FullName fullName,
                                string password,
                                MobileNumber mobileNumber,
                                string eMailId)
        {
            //this.CheckRule(new UserLoginMustBeUniqueRule(usersCounter, login));

            //this.Id = new UserRegistrationId(Guid.NewGuid());

            this.fullName = fullName;
            this.password = password;
            this.mobileNumber = mobileNumber;
            this.eMailId = eMailId;

            //this.status = 1;
            status = UserRegistrationStatus.WaitingForConfirmation;

            //this.AddDomainEvent(new NewUserRegisteredDomainEvent(this.Id, _login, _email, _firstName, _lastName, _name, _registerDate));
        }

        public static Registration RegisterNewUser(string firstName,
                                                     string lastName,
                                                     string password,
                                                     string mobileNoCountryCode,
                                                     string mobileNumber,
                                                     string emailId)
        {
            return new Registration(new FullName(firstName, lastName),
                                        password,
                                        new MobileNumber(mobileNoCountryCode, mobileNumber),
                                        emailId);
        }

        //public User CreateUser()
        //{
        //this.CheckRule(new UserCannotBeCreatedWhenRegistrationIsNotConfirmedRule(_status));

        //   return User.CreateFromUserRegistration(this.Id, this._login, this._password, this._email, this._firstName,
        //       this._lastName, this._name);
        //}

        public void Confirm()
        {
            //this.CheckRule(new UserRegistrationCannotBeConfirmedMoreThanOnceRule(_status));
            //this.CheckRule(new UserRegistrationCannotBeConfirmedAfterExpirationRule(_status));

            //status = UserRegistrationStatus.Confirmed;
            confirmedDate = DateTime.UtcNow;

            //this.AddDomainEvent(new UserRegistrationConfirmedDomainEvent(this.Id));
        }

        public void Expire()
        {
            //this.CheckRule(new UserRegistrationCannotBeExpiredMoreThanOnceRule(_status));

            //status = UserRegistrationStatus.Expired;

            //this.AddDomainEvent(new UserRegistrationExpiredDomainEvent(this.Id));
        }
    }
}