using System;
using System.Collections.Generic;
using System.Text;

namespace Domania.Domain
{
    public interface IBusinessRule
    {
        bool IsBroken();

        string Message { get; }
    }
}
