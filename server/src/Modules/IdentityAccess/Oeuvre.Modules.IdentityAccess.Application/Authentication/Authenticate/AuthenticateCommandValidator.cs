﻿using FluentValidation;

namespace Oeuvre.Modules.IdentityAccess.Application.Authentication.Authenticate
{
    public class AuthenticateCommandValidator : AbstractValidator<AuthenticateCommand>
    {
        public AuthenticateCommandValidator()
        {
            this.RuleFor(x => x.EMail).NotEmpty().WithMessage("Login cannot be empty");
            this.RuleFor(x => x.Password).NotEmpty().WithMessage("Password cannot be empty");
        }
    }
}