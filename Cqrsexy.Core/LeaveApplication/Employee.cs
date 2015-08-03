using System;
using System.Collections.Generic;
using Cqrsexy.Core.Infrastructure;
using Cqrsexy.Events;

namespace Cqrsexy.Core.LeaveApplication
{
    public class Employee : Aggregate
    {
        public Employee()
        {
            
        }

        public LeaveEntry ApplyForLeave(DateTime startDate, DateTime endDate, string type)
        {
            var leaveEntry = LeaveEntry.CreateNew(this.Id, startDate, endDate, type);
            ApplyChanges(new AppliedForLeave(leaveEntry.Id)); //is this really required?
            return leaveEntry;
        }
    }
}