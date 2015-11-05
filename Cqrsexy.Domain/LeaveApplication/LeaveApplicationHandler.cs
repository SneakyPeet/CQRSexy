using Cqrsexy.Core;
using Cqrsexy.Domain.Employees;

namespace Cqrsexy.Domain.LeaveApplication
{
    public class LeaveApplicationHandler 
        : ICommandHandler<ApplyForLeave>,
        ICommandHandler<ApproveLeave>
    {
        private readonly IRepository repo;

        public LeaveApplicationHandler(IRepository repo)
        {
            this.repo = repo;
        }

        public void Handle(ApplyForLeave cmd)
        {
            var employee = this.repo.GetById<Employee>(cmd.EmployeeId);
            employee.ApplyForLeave(cmd.LeaveId, cmd.From, cmd.To);
        }

        public void Handle(ApproveLeave cmd)
        {
            var employee = this.repo.GetById<Employee>(cmd.EmployeeId);
            employee.ApproveLeave(cmd.LeaveId, cmd.ApproverId);
        }
    }
}