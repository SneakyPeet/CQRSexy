using Cqrsexy.Core;

namespace Cqrsexy.Domain.LeaveApplication
{
    public class ApplyForLeaveCommandHandler : Handles<ApplyForLeave>
    {
        private readonly IRepository repo;

        public ApplyForLeaveCommandHandler(IRepository repo)
        {
            this.repo = repo;
        }

        public void Handle(ApplyForLeave cmd)
        {
            var employee = this.repo.GetById<Employee>(cmd.EmployeeId);
            var leaveEntry = employee.ApplyForLeave(cmd.LeaveId, cmd.StartDate, cmd.EndDate, cmd.LeaveType);
            this.repo.Add(leaveEntry);
        }
    }
}