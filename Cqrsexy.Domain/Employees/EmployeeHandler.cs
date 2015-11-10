using Cqrsexy.Core;
using Cqrsexy.Domain.LeaveApplication;

namespace Cqrsexy.Domain.Employees
{
    public class EmployeeHandler 
        : ICommandHandler<HireEmployee>
    {
        private readonly IRepository repo;

        public EmployeeHandler(IRepository repo)
        {
            this.repo = repo;
        }

        public void Handle(HireEmployee cmd)
        {
            var employee = Employee.HireEmployee(cmd.EmployeeId, cmd.Name, cmd.HireDate);
            repo.Add(employee);
        }
    }
}