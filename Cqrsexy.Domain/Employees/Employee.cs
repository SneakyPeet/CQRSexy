using System;
using System.Collections.Generic;
using Cqrsexy.Core;
using Cqrsexy.Domain.LeaveApplication;

namespace Cqrsexy.Domain.Employees
{
    public class Employee : Aggregate
    {
        private readonly Dictionary<Guid, PendingLeave> pendingLeave = new Dictionary<Guid, PendingLeave>();
        private readonly Dictionary<Guid, ApprovedLeave> approvedLeave = new Dictionary<Guid, ApprovedLeave>();

        public Employee() {}

        private Employee(Guid id, string name, DateTime hireDate)
        {
            this.ApplyChanges(new EmployeeHired(id, name, hireDate));
        }

        public static Employee HireEmployee(Guid id, string name, DateTime hireDate)
        {
            return new Employee(id, name, hireDate);
        }

        public void ApplyForLeave(Guid leaveId, DateTime startDate, DateTime endDate)
        {
            this.ApplyChanges(new AppliedForLeave(leaveId, startDate, endDate));
        }

        public void ApproveLeave(Guid leaveId, Guid approverId)
        {
            this.ApplyChanges(new LeaveApproved(leaveId, approverId));
        }

        public void On(EmployeeHired evt)
        {
            this.Id = evt.EmployeeId;
        }

        public void On(AppliedForLeave evt)
        {
            this.pendingLeave.Add(evt.LeaveEntryId, new PendingLeave(evt.LeaveEntryId, evt.From, evt.To));
        }

        public void On(LeaveApproved evt)
        {
            var leave = pendingLeave[evt.LeaveId];
            this.pendingLeave.Remove(evt.LeaveId);
            this.approvedLeave.Add(evt.LeaveId, leave.Approve(evt.ApproverId));
        }
    }
}