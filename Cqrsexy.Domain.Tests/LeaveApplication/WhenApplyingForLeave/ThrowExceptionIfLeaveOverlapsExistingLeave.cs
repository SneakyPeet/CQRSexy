using System;
using System.Collections.Generic;
using Cqrsexy.Domain.LeaveApplication;
using Cqrsexy.DomainMessages;

namespace Cqrsexy.Domain.Tests.WhenApplyingForLeave
{
    public class ThrowExceptionIfLeaveOverlapsExistingLeave : ExceptionSpesification
    {
        private readonly Guid employeeId = new Guid("809b71b5-1fc5-4039-b7fe-5d23aa58c5b4");
        private readonly Guid leaveId = new Guid("dfewb7b5-1fc5-4039-b7fe-5d23aa58c5b4");
        private readonly Guid existingLeaveId = new Guid("dtewb7b5-1fc5-4039-b7fe-5d23aa58c5b4");

        public override List<ICommand> Given()
        {
            return History
                .With(new HireEmployee(employeeId, "Pieter"))
                .And(new ApplyForLeave(existingLeaveId, employeeId, new DateTime(2012,01,01),new DateTime(2012,01,02)));
        }

        public override ICommand When()
        {
            return new ApplyForLeave(this.leaveId, this.employeeId, new DateTime(2012, 01, 02), new DateTime(2012, 05, 06));
        }

        public override Exception Then()
        {
            return new OverlappingLeaveException();
        }
    }
}
