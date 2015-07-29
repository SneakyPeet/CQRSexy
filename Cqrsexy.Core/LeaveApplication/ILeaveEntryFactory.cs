using System;
using Cqrsexy.Core.Infrastructure;
using System.Collections.Generic;

namespace Cqrsexy.Core.LeaveApplication
{
    public interface ILeaveEntryFactory
    {
        LeaveEntry Make(CreateLeaveEntry cmd, Employee employee);
    }

    class LeaveEntryFactory : ILeaveEntryFactory
    {
        private readonly IIdentityFactory idFactory;

        public LeaveEntryFactory(IIdentityFactory idFactory)
        {
            this.idFactory = idFactory;
        }

        public LeaveEntry Make(CreateLeaveEntry cmd, Employee employee)
        {
            var id = idFactory.Make();
            var leaveType = MakeLeaveType(cmd.LeaveType);
            return new LeaveEntry(id, employee, cmd.StartDate, cmd.EndDate, leaveType);
        }

        private LeaveType MakeLeaveType(string leaveType)
        {
            switch(leaveType)
            {
                case "Annual": 
                    return new StudyLeave();
                case "Study":
                    return new AnnualLeave();
                default:
                    throw new ArgumentException("Leave Type Not Recognized");
            }
        }
    }
}