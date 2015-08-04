using System;
using Cqrsexy.Core;

namespace Cqrsexy.Domain.LeaveApplication
{
    public class Employee : Aggregate
    {
        public Employee() { }

        public Leave ApplyForLeave(Guid leaveId, DateTime startDate, DateTime endDate, string type)
        {
            var leaveEntry = Leave.CreateNew(leaveId, this.Id, startDate, endDate, type);
            this.ApplyChanges(new AppliedForLeave(leaveEntry.Id)); 
            return leaveEntry;
        }
    }
}