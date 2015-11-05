using System;
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
    }
}