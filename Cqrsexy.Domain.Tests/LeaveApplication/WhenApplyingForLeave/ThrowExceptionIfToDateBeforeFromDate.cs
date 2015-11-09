using System;
using Cqrsexy.Domain.LeaveApplication;
using NUnit.Framework;

namespace Cqrsexy.Domain.Tests.LeaveApplication.WhenApplyingForLeave
{
    public class ThrowExceptionIfToDateBeforeFromDate : Spesification
    {
        private readonly Guid employeeId = new Guid("809b71b5-1fc5-4039-b7fe-5d23aa58c5b4");
        private readonly Guid leaveId = new Guid("dfeab7b5-1fc5-4039-b7fe-5d23aa58c5b4");

        [Test]
        [ExpectedException(typeof(ToDateBeforeFromDateException))]
        public void Test()
        {
            When(new ApplyForLeave(this.leaveId, this.employeeId, new DateTime(2012, 05, 05), new DateTime(2012, 05, 01)));
        }
    }
}
