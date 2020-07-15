using System;
using System.Threading;
using System.Threading.Tasks;
using Domaina.CQRS;
using MediatR;
using Oeuvre.Modules.IdentityAccess.Domain.UserRegistrations;

namespace Oeuvre.Modules.IdentityAccess.Application.UserRegistrations.RegisterNewUser
{
    public class RegisterNewUserCommandHandler : ICommandHandler<RegisterNewUserCommand, long>
    {
        private readonly IUserRegistrationRepository userRegistrationRepository;

        public RegisterNewUserCommandHandler(
            IUserRegistrationRepository userRegistrationRepository)
        {
            this.userRegistrationRepository = userRegistrationRepository;

        }

        public async Task<long> Handle(RegisterNewUserCommand request, CancellationToken cancellationToken)
        {
            //var password = PasswordManager.HashPassword(request.Password);

            var userRegistration = UserRegistration.RegisterNewUser(
                request.Login,
                request.Password, 
                request.Email, 
                request.FirstName,
                request.LastName);

            await userRegistrationRepository.AddAsync(userRegistration);

            return userRegistration.Id;
        }
    }
}