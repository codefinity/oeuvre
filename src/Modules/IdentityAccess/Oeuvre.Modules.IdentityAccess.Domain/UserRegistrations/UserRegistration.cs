using System;
using System.Runtime.CompilerServices;
using Domania.Domain;

namespace Oeuvre.Modules.IdentityAccess.Domain.UserRegistrations
{
    public class UserRegistration : Entity, IAggregateRoot
    {
        public long Id { get; private set; }

        //public UserRegistrationId userRegistrationId;

        private string login;

        private string password;

        private string email;

        private string firstName;

        private string lastName;

        private string name;

        private DateTime registerDate;

        //private UserRegistrationStatus status;

        private int status;

        private DateTime? confirmedDate;

        private UserRegistration()
        {
            // Only EF.
        }

        public static UserRegistration RegisterNewUser(
            string login, 
            string password, 
            string email, 
            string firstName,
            string lastName)
        {
            return new UserRegistration(login, password, email, firstName, lastName);
        }

        private UserRegistration(
            string login, 
            string password, 
            string email, 
            string firstName, 
            string lastName)
        {
            //this.CheckRule(new UserLoginMustBeUniqueRule(usersCounter, login));

            //this.Id = new UserRegistrationId(Guid.NewGuid());
            this.login = login;
            this.password = password;
            this.email = email;
            this.firstName = firstName;
            this.lastName = lastName;
            name = $"{firstName} {lastName}";
            registerDate = DateTime.UtcNow;
            this.status = 1;
            //status = UserRegistrationStatus.WaitingForConfirmation;

            //this.AddDomainEvent(new NewUserRegisteredDomainEvent(this.Id, _login, _email, _firstName, _lastName, _name, _registerDate));
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