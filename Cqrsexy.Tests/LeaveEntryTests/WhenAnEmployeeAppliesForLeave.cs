using System;
using System.Linq;
using Cqrsexy.Core.LeaveApplication;
using Cqrsexy.Events;
using SharpTestsEx;

namespace Cqrsexy.Tests.LeaveEntryTests
{
    public class WhenAnEmployeeAppliesForLeave : AggregateSpesificationBase<Employee>
    {
        private LeaveEntry output;
        protected override void When()
        {
            var startDate = DateTime.UtcNow;
            output = aggregate.ApplyForLeave(startDate, startDate.AddDays(1), "Annual");
        }

        [Then]
        public void AppliedForLeaveEventShouldBeInChangeList()
        {
            this.changes.Single().Should().Be.InstanceOf<AppliedForLeave>();
        }

        [Then]
        public void EmployeeShouldReturnNewLeaveEntry()
        {
            output.Should().Not.Be.Null();
        }
    }
}