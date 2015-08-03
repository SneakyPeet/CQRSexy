using System;
using Cqrsexy.Core.Infrastructure;
using Cqrsexy.Events;
using Cqrsexy.Commands;

namespace Cqrsexy.Core.LeaveApplication
{
    public class LeaveEntry : Aggregate
    {
        public LeaveEntry()
        {
            
        }
        private LeaveEntry(Guid id, Guid employeeId, DateTime startDate, DateTime endDate, string leaveType):  this()
        {
            if(startDate >= endDate)
            {
                throw new ArgumentException("Leave Start Date should be before Leave End Date");
            }
            //this.employee = employee;
            //this.typeFactory = typeFactory;
            //ApplyChanges(new LeaveEntryCreated(new Guid(), cmd.StartDate, cmd.EndDate, cmd.LeaveType));
        }

        //public void OnLeaveEntryCreated(LeaveEntryCreated evt)
        //{
        //    leaveType = typeFactory.Make(evt.LeaveType);
        //}

        public static LeaveEntry CreateNew(Guid employeeId, DateTime startDate, DateTime endDate, string leaveType)
        {
            var id = IdentityFactory.Make();
            return new LeaveEntry(id, employeeId, startDate, endDate, leaveType);
        }
    }
}