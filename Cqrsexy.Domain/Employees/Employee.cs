using System;
using System.Linq;
using System.Collections.Generic;
using Cqrsexy.Core;
using Cqrsexy.Domain.LeaveApplication;
using Cqrsexy.DomainMessages;

namespace Cqrsexy.Domain.Employees
{
    public class Employee : Aggregate
    {

        public Employee()
        {
            
        }

        private readonly List<Leave> leave;

        private Employee(Guid id, string name, DateTime hireDate)
        {
            this.leave = new List<Leave>();
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
            this.leave.Add(new PendingLeave(evt.LeaveEntryId, evt.From, evt.To));
        }

        public void On(LeaveApproved evt)
        {
            var pendingLeave = GetLeave<PendingLeave>(evt.LeaveId);
            this.leave.Remove(pendingLeave);
            var approvedLeave = pendingLeave.Approve(evt.ApproverId);
            this.leave.Add(approvedLeave);
        }

        private T GetLeave<T>(Guid id) where T : Leave
        {
            return this.leave.OfType<T>().Single(x => x.Id == id);
        }

        
    }
}