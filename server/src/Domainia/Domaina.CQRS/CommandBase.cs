using System;
using System.Collections.Generic;
using System.Text;

namespace Domaina.CQRS
{
    public abstract class CommandBase : ICommand
    {
        public long Id { get; }

        protected CommandBase()
        {
            //this.Id = Guid.NewGuid();
        }

        protected CommandBase(long id)
        {
            this.Id = id;
        }
    }

    public abstract class CommandBase<TResult> : ICommand<TResult>
    {
        public long Id { get; }

        protected CommandBase()
        {
            //this.Id = Guid.NewGuid();
        }

        protected CommandBase(long id)
        {
            this.Id = id;
        }
    }
}
