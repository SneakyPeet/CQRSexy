using System;
using System.Linq;
using System.Collections.Generic;
using Cqrsexy.Core;
using Cqrsexy.Domain.LeaveApplication;

namespace Cqrsexy.Domain.Employees
{
    public class Employee : Aggregate
    {
        public Employee()
        {
            this.leave = new List<Leave>();
        }

        private readonly List<Leave> leave;

        public void ApplyForLeave(Guid leaveId, DateTime startDate, DateTime endDate)
        {
            this.ApplyChanges(new AppliedForLeave(leaveId, startDate, endDate));
        }

        public void OnAppliedForLeave(AppliedForLeave evt)
        {
            this.leave.Add(new PendingLeave(evt.LeaveEntryId, evt.From, evt.To));
        }

        public void ApproveLeave(Guid leaveId, Guid approverId)
        {
            this.ApplyChanges(new LeaveApproved(leaveId, approverId));
        }

        public void OnLeaveApproved(LeaveApproved evt)
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