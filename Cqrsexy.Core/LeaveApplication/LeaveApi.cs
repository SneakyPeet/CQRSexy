using System;
using Cqrsexy.Core.Infrastructure;

namespace Cqrsexy.Core.LeaveApplication
{
    public class LeaveApplicationApi
    {
        private readonly IRepository<LeaveEntry> repo;
        private readonly IRepository<Employee> employeeRepo;
        private readonly ILeaveEntryFactory factory;

        public LeaveApplicationApi(IRepository<LeaveEntry> repo, IRepository<Employee> employeeRepo, ILeaveEntryFactory factory)
        {
            this.repo = repo;
            this.employeeRepo = employeeRepo;
            this.factory = factory;
        }

        public Guid Handle(CreateLeaveEntry cmd)
        {
            var employee = employeeRepo.GetById(cmd.EmployeeId);
            var leaveEntry = factory.Make(cmd, employee);
            repo.Save(leaveEntry);
            return leaveEntry.Id;
        }
    }
}