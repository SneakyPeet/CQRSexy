using System;
using Cqrsexy.Core;

namespace Cqrsexy.Domain.LeaveApplication
{
    public class Leave : Aggregate
    {
        public Leave() {}
        private Leave(Guid id, Guid employeeId, DateTime startDate, DateTime endDate, string leaveType):  this()
        {
            if(startDate >= endDate)
            {
                throw new ArgumentException("Leave Start Date should be before Leave End Date");
            }
            this.ApplyChanges(new LeaveEntryCreated(new Guid(), startDate, endDate, leaveType));
        }
        
        public static Leave CreateNew(Guid leaveId, Guid employeeId, DateTime startDate, DateTime endDate, string leaveType)
        {
            return new Leave(leaveId, employeeId, startDate, endDate, leaveType);
        }
    }
}