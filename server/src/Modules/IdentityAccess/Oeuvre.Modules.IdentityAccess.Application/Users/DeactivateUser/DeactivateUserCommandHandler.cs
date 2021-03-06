﻿using Domaina.CQRS;
using Domaina.CQRS.Command;
using Oeuvre.Modules.IdentityAccess.Application.Users.DeactivateUser;
using Oeuvre.Modules.IdentityAccess.Domain.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Oeuvre.Modules.IdentityAccess.Application.Users.AactivateUser
{
    public class DeActivateUserCommandHandler : ICommandHandler<DeActivateUserCommand, Guid>
    {

        private readonly IUserRepository userRepository;

        public DeActivateUserCommandHandler(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<Guid> Handle(DeActivateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await userRepository.GetByIdAsync(new UserId(request.UserId));

            user.DeActivate();

            await userRepository.UpdateAsync(user);

            return user.Id.Value;
        }

    }
}
