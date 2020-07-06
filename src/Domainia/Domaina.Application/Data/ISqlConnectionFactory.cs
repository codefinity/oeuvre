using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Domaina.Application.Data
{
    public interface ISqlConnectionFactory
    {
        IDbConnection GetOpenConnection();
    }
}
