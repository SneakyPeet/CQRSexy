using System;
using Cqrsexy.Domain.LeaveApplication;
using NUnit.Framework;

namespace Cqrsexy.Domain.Tests.LeaveApplication.WhenApplyingForLeave
{
    public class ThrowExceptionIfLeaveOverlapsExistingLeave : Spesification
    {
        private readonly Guid employeeId = new Guid("809b71b5-1fc5-4039-b7fe-5d23aa58c5b4");
        private readonly Guid leaveId = new Guid("dfeeb7b5-1fc5-4039-b7fe-5d23aa58c5b4");
        private readonly Guid existingLeaveId = new Guid("d1edb7b5-1fc5-4039-b7fe-5d23aa58c5b4");

        [Test]
        [ExpectedException(typeof(OverlappingLeaveException))]
        public void Test()
        {
            Given(new HireEmployee(this.employeeId, "Pieter", new DateTime(2012, 01, 02)));
            And(new ApplyForLeave(this.existingLeaveId, this.employeeId, new DateTime(2012, 01, 01), new DateTime(2012, 01, 02)));
            When(new ApplyForLeave(this.leaveId, this.employeeId, new DateTime(2012, 01, 02), new DateTime(2012, 05, 06)));
        }
    }
}
