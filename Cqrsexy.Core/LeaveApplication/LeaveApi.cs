using System;
using Cqrsexy.Commands;
using Cqrsexy.Core.Infrastructure;

namespace Cqrsexy.Core.LeaveApplication
{
    public class LeaveApplicationApi
    {
        private readonly IRepository<LeaveEntry> repo;
        private readonly IRepository<Employee> employeeRepo;
        private readonly ILeaveTypeFactory typeFactory;

        public LeaveApplicationApi(IRepository<LeaveEntry> repo, IRepository<Employee> employeeRepo, ILeaveTypeFactory typeFactory)
        {
            this.repo = repo;
            this.employeeRepo = employeeRepo;
            this.typeFactory = typeFactory;
        }

        public Guid Handle(CreateLeaveEntry cmd)
        {
            var employee = employeeRepo.GetById(cmd.EmployeeId);
            var leaveEntry = employee.ApplyForLeave(cmd.StartDate, cmd.EndDate, cmd.LeaveType);
            //HowToSave?
            throw new NotImplementedException();
        }
    }
}