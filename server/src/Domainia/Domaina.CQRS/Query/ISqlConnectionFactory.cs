﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Domaina.CQRS.Query
{
    public interface ISqlConnectionFactory
    {
        IDbConnection GetOpenConnection();
    }
}
