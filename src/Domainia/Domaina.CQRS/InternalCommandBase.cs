using System;
using System.Collections.Generic;
using System.Text;

namespace Domaina.CQRS
{
    public abstract class InternalCommandBase : ICommand
    {
        public long Id { get; }

        protected InternalCommandBase(long id)
        {
            this.Id = id;
        }
    }

    public abstract class InternalCommandBase<TResult> : ICommand<TResult>
    {
        public long Id { get; }

        protected InternalCommandBase()
        {
            //this.Id = Guid.NewGuid();
        }

        protected InternalCommandBase(long id)
        {
            this.Id = id;
        }
    }
}
