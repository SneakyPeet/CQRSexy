using Cqrsexy.Core;
using Cqrsexy.Domain.Employees;

namespace Cqrsexy.Domain.LeaveApplication
{
    public class ApplyForLeaveCommandHandler : ICommandHandler<ApplyForLeave>
    {
        private readonly IRepository repo;

        public ApplyForLeaveCommandHandler(IRepository repo)
        {
            this.repo = repo;
        }

        public void Handle(ApplyForLeave cmd)
        {
            var employee = this.repo.GetById<Employee>(cmd.EmployeeId);
            employee.ApplyForLeave(cmd.LeaveId, cmd.From, cmd.To);
        }
    }
}