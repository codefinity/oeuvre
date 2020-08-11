using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Oeuvre.Modules.IdentityAccess.Application.Configuration.Commands;
using Oeuvre.Modules.IdentityAccess.Domain.UserRegistrations;

namespace Oeuvre.Modules.IdentityAccess.Application.UserRegistrations.RegisterNewUser
{
    public class RegisterNewUserCommandHandler : ICommandHandler<RegisterNewUserCommand, Guid>
    {
        private readonly IUserRegistrationRepository userRegistrationRepository;
        private readonly IUsersCounter usersCounter;

        public RegisterNewUserCommandHandler(IUserRegistrationRepository userRegistrationRepository,
                                                IUsersCounter usersCounter)
        {
            this.userRegistrationRepository = userRegistrationRepository;
            this.usersCounter = usersCounter;

        }

        public async Task<Guid> Handle(RegisterNewUserCommand request, CancellationToken cancellationToken)
        {
            //var password = PasswordManager.HashPassword(request.Password);

            var userRegistration = Registration.RegisterNewUser(new Guid(request.TenantId),
                                                                    request.FirstName,
                                                                    request.LastName,
                                                                    request.Password, 
                                                                    request.MobileNoCountryCode,
                                                                    request.MobileNumber,
                                                                    request.Email,
                                                                    usersCounter);

            await userRegistrationRepository.AddAsync(userRegistration);

            return userRegistration.Id.Value;
        }
    }
}