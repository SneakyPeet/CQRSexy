using System;
using Cqrsexy.Domain.LeaveApplication;
using NUnit.Framework;

namespace Cqrsexy.Domain.Tests.LeaveApplication.WhenApplyingForLeave
{
    public class ApplyIfValid : Spesification
    {
        private readonly Guid employeeId = new Guid("809b71b5-1fc5-4039-b7fe-5d23aa58c5b4");
        private readonly Guid leaveId = new Guid("dfeab7b5-1fc5-4039-b7fe-5d23aa58c5b4");
        private readonly DateTime from = new DateTime(2012, 05, 05);
        private readonly DateTime to = new DateTime(2012, 05, 06);

        [Test]
        public void Test()
        {
            Given(new HireEmployee(this.employeeId, "Pieter", new DateTime(2012, 01, 02)));
            When(new ApplyForLeave(this.leaveId, this.employeeId, this.@from, this.to));
            Then(Expected.Event(new AppliedForLeave(this.leaveId, this.@from, this.to)));
        }
    }
}
