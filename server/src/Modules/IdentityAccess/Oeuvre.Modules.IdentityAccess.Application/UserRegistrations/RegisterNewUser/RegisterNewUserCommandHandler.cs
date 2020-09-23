using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Oeuvre.Modules.IdentityAccess.Application.Authentication;
using Domaina.CQRS;
using Oeuvre.Modules.IdentityAccess.Domain.UserRegistrations;
using Serilog;
using Domaina.CQRS.Command;

namespace Oeuvre.Modules.IdentityAccess.Application.UserRegistrations.RegisterNewUser
{
    public class RegisterNewUserCommandHandler : ICommandHandler<RegisterNewUserCommand, Guid>
    {
        private readonly IUserRegistrationRepository userRegistrationRepository;
        private readonly IUsersCounter usersCounter;
        private readonly ILogger logger;

        public RegisterNewUserCommandHandler(IUserRegistrationRepository userRegistrationRepository
                                                ,IUsersCounter usersCounter
                                                ,ILogger logger
                                                )
        {
            this.userRegistrationRepository = userRegistrationRepository;
            this.usersCounter = usersCounter;
            this.logger = logger;
        }

        public async Task<Guid> Handle(RegisterNewUserCommand request, CancellationToken cancellationToken)
        {
            logger.Information("Command - Register New User");

            string hashedPassword = PasswordManager.HashPassword(request.Password);

            var userRegistration = Registration.RegisterNewUser(new Guid(request.TenantId),
                                                                    request.FirstName,
                                                                    request.LastName,
                                                                    hashedPassword,
                                                                    request.MobileNoCountryCode,
                                                                    request.MobileNumber,
                                                                    request.Email,
                                                                    usersCounter);

            await userRegistrationRepository.AddAsync(userRegistration);

            return userRegistration.Id.Value;
        }
    }
}