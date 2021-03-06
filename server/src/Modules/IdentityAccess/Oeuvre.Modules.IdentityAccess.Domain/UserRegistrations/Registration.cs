﻿using System;
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

        private bool termsAndConditionsAccepted;

        private Registration()
        {
            // Only EF.
        }

        private Registration(TenantId tenantId,
                                FullName fullName,
                                string password,
                                MobileNumber mobileNumber,
                                string eMailId,
                                bool termsAndConditionsAccepted,
                                IUsersCounter usersCounter)
        {
            //Rules
            Console.WriteLine("Business Rule Check - User EMail Id Must be Unique");

            CheckRule(new UserMustAcceptTermsAndConditions(termsAndConditionsAccepted));
            CheckRule(new UserEmailIdLoginMustBeUniqueRule(usersCounter, eMailId));

            this.Id = new UserRegistrationId(Guid.NewGuid());

            this.tenantId = tenantId;
            this.fullName = fullName;
            this.password = password;
            this.mobileNumber = mobileNumber;
            this.eMailId = eMailId;
            this.termsAndConditionsAccepted = termsAndConditionsAccepted;

            registrationDate = SystemClock.Now;

            //this.status = 1;
            status = UserRegistrationStatus.WaitingForConfirmation;

            AddDomainEvent(new NewUserRegisteredDomainEvent(this.Id,
                                                                    tenantId,
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
                                                     bool termsAndConditionsAccepted,
                                                     IUsersCounter usersCounter)
        {
            return new Registration(new TenantId(tenantId),
                                        new FullName(firstName, lastName),
                                        password,
                                        new MobileNumber(mobileNoCountryCode, mobileNumber),
                                        emailId,
                                        termsAndConditionsAccepted,
                                        usersCounter);
        }

        public User CreateUser()
        {

            this.CheckRule(new UserCannotBeCreatedWhenRegistrationIsNotConfirmedRule(status));

            return User.CreateFromUserRegistration(this.Id,
                                                     this.tenantId,
                                                     this.fullName.FirstName,
                                                     this.fullName.LastName,
                                                     this.mobileNumber.CountryCode,
                                                     this.mobileNumber.MobileNo,
                                                     this.eMailId,
                                                     this.password);
        }

        public void Confirm(IUserRegistrationConfirmationExpirationCalculator expirationCalculator)
        {
            CheckRule(new UserRegistrationCannotBeConfirmedMoreThanOnceRule(status));
            CheckRule(new UserRegistrationCannotBeConfirmedAfterExpirationRule(expirationCalculator, registrationDate));

            this.status = UserRegistrationStatus.Confirmed;
            this.confirmedDate = DateTime.UtcNow;

            this.AddDomainEvent(new UserRegistrationConfirmedDomainEvent(this.Id));
        }

    }
}