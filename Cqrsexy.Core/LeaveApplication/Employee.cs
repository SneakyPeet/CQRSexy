using System;
using Cqrsexy.Core.Infrastructure;

namespace Cqrsexy.Core.LeaveApplication
{
    public class Employee : Aggregate
    {
        public Employee(Guid id) : base(id)
        {
            
        }
    }
}