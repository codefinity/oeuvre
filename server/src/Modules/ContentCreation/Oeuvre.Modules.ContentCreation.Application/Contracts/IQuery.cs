using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Oeuvre.Modules.ContentCreation.Application.Contracts
{
    public interface IQuery<out TResult> : IRequest<TResult>
    {

    }
}
