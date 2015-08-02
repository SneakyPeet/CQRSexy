using System;
using Cqrsexy.Core.Infrastructure;
using Cqrsexy.Events;

namespace Cqrsexy.Core.LeaveApplication
{
    public class LeaveEntry : Aggregate
    {
        private LeaveType leaveType;
        private Employee employee;
        private readonly ILeaveTypeFactory typeFactory;

        public LeaveEntry(Guid id, Employee employee, CreateLeaveEntry cmd, ILeaveTypeFactory typeFactory) : base(id)
        {
            if(cmd.StartDate >= cmd.EndDate)
            {
                throw new ArgumentException("Leave Start Date should be before Leave End Date");
            }
            this.employee = employee;
            this.typeFactory = typeFactory;
            ApplyChanges(new LeaveEntryCreated(employee.Id, cmd.StartDate, cmd.EndDate, cmd.LeaveType));
        }
        

        public void OnLeaveEntryCreated(LeaveEntryCreated evt)
        {
            leaveType = typeFactory.Make(evt.LeaveType);
        }
    }
}