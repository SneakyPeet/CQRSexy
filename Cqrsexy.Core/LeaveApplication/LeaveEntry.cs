using System;
using Cqrsexy.Core.Infrastructure;

namespace Cqrsexy.Core.LeaveApplication
{
    public class LeaveEntry : Aggregate
    {
        private LeaveType leaveType;

        public LeaveEntry(Guid id, Employee employee, DateTime startDate, DateTime endDate, LeaveType leaveType)
        {
            if(startDate >= endDate)
            {
                throw new ArgumentException("Leave Start Date should be before Leave End Date");
            }
            ApplyChanges(new LeaveEntryCreated(id, employee, startDate, endDate, leaveType));
        }

        public void OnLeaveEntryCreated(LeaveEntryCreated evt)
        {
            Id = evt.Id;
            leaveType = evt.LeaveType;
        }
    }
}