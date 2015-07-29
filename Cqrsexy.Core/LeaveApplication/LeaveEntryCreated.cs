using System;
using Cqrsexy.Core.Infrastructure;

namespace Cqrsexy.Core.LeaveApplication
{
    public class LeaveEntryCreated : Event
    {
        public readonly Guid Id;
        public readonly Employee Employee;
        public readonly DateTime StartDate;
        public readonly DateTime EndDate;
        public readonly LeaveType LeaveType;

        public LeaveEntryCreated(Guid id, Employee employee, DateTime startDate, DateTime endDate, LeaveType leaveType)
        {
            Id = id;
            Employee = employee;
            StartDate = startDate;
            EndDate = endDate;
            LeaveType = leaveType;
        }
    }
}