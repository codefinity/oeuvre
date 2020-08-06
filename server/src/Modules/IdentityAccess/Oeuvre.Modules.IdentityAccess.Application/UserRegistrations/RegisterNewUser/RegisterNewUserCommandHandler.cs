using System;
using System.Threading;
using System.Threading.Tasks;
using Domaina.CQRS;
using MediatR;
using Oeuvre.Modules.IdentityAccess.Domain.UserRegistrations;

namespace Oeuvre.Modules.IdentityAccess.Application.UserRegistrations.RegisterNewUser
{
    public class RegisterNewUserCommandHandler : ICommandHandler<RegisterNewUserCommand, Guid>
    {
        private readonly IUserRegistrationRepository userRegistrationRepository;

        public RegisterNewUserCommandHandler(IUserRegistrationRepository userRegistrationRepository)
        {
            this.userRegistrationRepository = userRegistrationRepository;

        }

        public async Task<Guid> Handle(RegisterNewUserCommand request, CancellationToken cancellationToken)
        {
            //var password = PasswordManager.HashPassword(request.Password);

            var userRegistration = Registration.RegisterNewUser(request.FirstName,
                                                                                request.LastName,
                                                                                request.Password, 
                                                                                request.MobileNoCountryCode,
                                                                                request.MobileNumber,
                                                                                request.Email);

            await userRegistrationRepository.AddAsync(userRegistration);

            return userRegistration.Id.Value;
        }
    }
}