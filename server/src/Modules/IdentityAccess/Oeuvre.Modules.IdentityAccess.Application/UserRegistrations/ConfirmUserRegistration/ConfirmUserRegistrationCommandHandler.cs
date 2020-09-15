using System.Threading;
using System.Threading.Tasks;
using Domaina.CQRS.Command;
using MediatR;
using Oeuvre.Modules.IdentityAccess.Domain.UserRegistrations;

namespace Oeuvre.Modules.IdentityAccess.Application.UserRegistrations.ConfirmUserRegistration
{
    internal class ConfirmUserRegistrationCommandHandler : ICommandHandler<ConfirmUserRegistrationCommand>
    {
        private readonly IUserRegistrationRepository userRegistrationRepository;
        private readonly IUserRegistrationConfirmationExpirationCalculator expirationCounter;
        public ConfirmUserRegistrationCommandHandler(IUserRegistrationRepository userRegistrationRepository,
                                                        IUserRegistrationConfirmationExpirationCalculator expirationCounter)
        {
            this.userRegistrationRepository = userRegistrationRepository;
            this.expirationCounter = expirationCounter;
        }

        public async Task<Unit> Handle(ConfirmUserRegistrationCommand request, CancellationToken cancellationToken)
        {
            var userRegistration =
                await userRegistrationRepository.GetByIdAsync(new UserRegistrationId(request.UserRegistrationId));

            userRegistration.Confirm(expirationCounter);

            await userRegistrationRepository.AddAsync(userRegistration);

            return Unit.Value;
        }
    }
}