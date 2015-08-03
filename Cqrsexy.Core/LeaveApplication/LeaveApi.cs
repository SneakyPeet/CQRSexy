using System;
using Cqrsexy.Commands;
using Cqrsexy.Core.Infrastructure;

namespace Cqrsexy.Core.LeaveApplication
{
    public class LeaveApplicationApi : Handles<CreateLeaveEntry>
    {
        private readonly IRepository repo;
        private readonly ILeaveTypeFactory typeFactory;

        public LeaveApplicationApi(IRepository repo, ILeaveTypeFactory typeFactory)
        {
            this.repo = repo;
            this.typeFactory = typeFactory;
        }

        public void Handle(CreateLeaveEntry cmd)
        {
            var employee = repo.GetById<Employee>(cmd.EmployeeId);
            var leaveEntry = employee.ApplyForLeave(cmd.StartDate, cmd.EndDate, cmd.LeaveType);
            repo.Add(leaveEntry);
        }
    }
}