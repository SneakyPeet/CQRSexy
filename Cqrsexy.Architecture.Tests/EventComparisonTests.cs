using System;
using Cqrsexy.Domain.LeaveApplication;
using NUnit.Framework;

namespace Cqrsexy.Architecture.Tests
{
    //Test F# structural equality
    [TestFixture]
    public class EventComparisonTests
    {
        [Test]
        public void Given()
        {
            var id = Guid.NewGuid();
            var employeeId = Guid.NewGuid();
            var startDate = DateTime.UtcNow;
            var event1 = new LeaveEntryCreated(employeeId, startDate, startDate.AddDays(1),  "foo");
            var event2 = new LeaveEntryCreated(employeeId, startDate, startDate.AddDays(1), "foo");
            Assert.AreEqual(event1, event2);
        }
        
    }
}