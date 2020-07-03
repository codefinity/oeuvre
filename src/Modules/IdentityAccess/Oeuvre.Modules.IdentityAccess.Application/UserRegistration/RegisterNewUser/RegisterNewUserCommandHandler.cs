using System;
using System.Threading.Tasks;
using Oeuvre.Modules.IdentityAccess.Application.CQRS;
using Oeuvre.Modules.IdentityAccess.Domain.Identity;

namespace Oeuvre.Modules.IdentityAccess.Application.UserRegistration.RegisterNewUser
{

    public class RegisterNewUserCommandHandler : ICommandHandler
    {
        private readonly IUserRepository userRepository;

        public RegisterNewUserCommandHandler(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }


        public Task Handle(RegisterNewUserCommand request)
        {
            var user = User.RegisterNewUser(request.Password,
                                            request.Email,
                                            request.FirstName,
                                            request.LastName);

            userRepository.AddAsync(user);

            return null;
        }

    }
}
