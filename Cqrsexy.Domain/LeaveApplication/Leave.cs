using System;

namespace Cqrsexy.Domain.LeaveApplication
{
    public abstract class Leave
    {
        public readonly Guid Id;
        public readonly DateTime To;
        public readonly DateTime From;

        protected Leave(Guid id, DateTime from, DateTime to)
        {
            Id = id;
            To = to;
            From = from;
        }
    }
}