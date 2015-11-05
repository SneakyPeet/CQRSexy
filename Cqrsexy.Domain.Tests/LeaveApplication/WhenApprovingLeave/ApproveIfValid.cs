using System;
using System.Collections.Generic;
using Cqrsexy.Domain.LeaveApplication;
using Cqrsexy.DomainMessages;

namespace Cqrsexy.Domain.Tests.LeaveApplication.WhenApprovingLeave
{
    public class ApproveIfValid : EventSpesification
    {
        private readonly Guid employeeId = new Guid("809b71b5-1fc5-4039-b7fe-5d23aa58c5b4");
        private readonly Guid approverId = new Guid("809de1b5-1fc5-4039-b7fe-5d23aa58c5b4");
        private readonly Guid leaveId = new Guid("dfewb7b5-1fc5-4039-b7fe-5d23aa58c5b4");
        private readonly DateTime from = new DateTime(2012, 05, 05);
        private readonly DateTime to = new DateTime(2012, 05, 06);

        public override List<ICommand> Given()
        {
            return History.With(new HireEmployee(this.employeeId, "Pieter"))
                .And(new ApplyForLeave(this.leaveId, this.employeeId, this.@from, this.to));
        }

        public override ICommand When()
        {
            return new ApproveLeave(this.leaveId, this.approverId);
        }

        public override List<IEvent> Then()
        {
            return Expected.Event(new LeaveApproved(this.leaveId, this.approverId));
        }
    }
}
