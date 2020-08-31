using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Domaina.CQRS;
using Oeuvre.Modules.IdentityAccess.Domain.UserRegistrations;
using Oeuvre.Modules.IdentityAccess.Domain.Users;
using Domaina.CQRS.Command;

namespace Oeuvre.Modules.IdentityAccess.Application.Users.CreateUser
{
    internal class CreateUserCommandHandler : ICommandHandler<CreateUserCommand, Guid>
    {
        private readonly IUserRegistrationRepository userRegistrationRepository;
        private readonly IUserRepository userRepository;

        public CreateUserCommandHandler(
            IUserRegistrationRepository userRegistrationRepository, 
            IUserRepository userRepository)
        {
            this.userRegistrationRepository = userRegistrationRepository;
            this.userRepository = userRepository;
        }

        public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var userRegistration = await userRegistrationRepository.GetByIdAsync(request.UserRegistrationId);

            var user = userRegistration.CreateUser();

            await userRepository.AddAsync(user);

            return user.Id.Value;
        }
    }
}