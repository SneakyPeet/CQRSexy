using System;

namespace Cqrsexy.Core.LeaveApplication
{
    public class CreateLeaveEntry
    {
        public CreateLeaveEntry(Guid employeeId, DateTime startDate, DateTime endDate, string leaveType)
        {
            this.EmployeeId = employeeId;
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.LeaveType = leaveType;
        }

        public readonly Guid EmployeeId;
        public readonly DateTime StartDate;
        public readonly DateTime EndDate;
        public readonly string LeaveType;
    }
}