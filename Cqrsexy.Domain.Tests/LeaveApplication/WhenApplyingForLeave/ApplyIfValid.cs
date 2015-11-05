using System;
using System.Collections.Generic;
using Cqrsexy.Domain.LeaveApplication;
using Cqrsexy.DomainMessages;

namespace Cqrsexy.Domain.Tests.LeaveApplication.WhenApplyingForLeave
{
    public class ApplyIfValid : EventSpesification
    {
        private readonly Guid employeeId = new Guid("809b71b5-1fc5-4039-b7fe-5d23aa58c5b4");
        private readonly Guid leaveId = new Guid("dfewb7b5-1fc5-4039-b7fe-5d23aa58c5b4");
        private readonly DateTime from = new DateTime(2012, 05, 05);
        private readonly DateTime to = new DateTime(2012, 05, 06);

        public override List<ICommand> Given()
        {
            return History.With(new HireEmployee(this.employeeId, "Pieter"));
        }

        public override ICommand When()
        {
            return new ApplyForLeave(this.leaveId, this.employeeId, this.@from, this.to);
        }

        public override List<IEvent> Then()
        {
            return Expected.Event(new AppliedForLeave(this.leaveId, this.@from, this.to));
        }
    }

    
}
