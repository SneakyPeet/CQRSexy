using System;
using Cqrsexy.Core.Infrastructure;

namespace Cqrsexy.Core.LeaveApplication
{
    public class LeaveApplicationApi
    {
        private readonly IRepository<LeaveEntry> repo;
        private readonly IRepository<Employee> employeeRepo;
        private readonly ILeaveTypeFactory typeFactory;
        private readonly IIdentityFactory idFactory;

        public LeaveApplicationApi(IRepository<LeaveEntry> repo, IRepository<Employee> employeeRepo, ILeaveTypeFactory typeFactory, IIdentityFactory idFactory)
        {
            this.repo = repo;
            this.employeeRepo = employeeRepo;
            this.typeFactory = typeFactory;
            this.idFactory = idFactory;
        }

        public Guid Handle(CreateLeaveEntry cmd)
        {
            var employee = employeeRepo.GetById(cmd.EmployeeId);
            var id = idFactory.Make();
            var leaveEntry = new LeaveEntry(id, employee, cmd, typeFactory);
            repo.Save(leaveEntry);
            return leaveEntry.Id;
        }
    }
}