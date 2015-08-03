using System;
using Cqrsexy.Core.LeaveApplication;
using SharpTestsEx;

namespace Cqrsexy.Tests.LeaveEntryTests
{
    public class WhenCreatingLeaveEntryWithInvalidDates : AggregateSpesificationBase<LeaveEntry>
    {
        protected override void When()
        {
            var startDate = DateTime.UtcNow;
            LeaveEntry.CreateNew(Guid.NewGuid(), startDate, startDate.AddDays(-1), "Annual");
        }

        [Then]
        public void ThrowArgumentException()
        {
            this.expectedException.Should().Be.InstanceOf<ArgumentException>();
        }

        [Then]
        public void ExceptionMessageShouldBeCorrect()
        {
            this.expectedException.Message.Should().Be.EqualTo("Leave Start Date should be before Leave End Date");
        }
    }
}