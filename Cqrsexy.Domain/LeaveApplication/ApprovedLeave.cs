using System;

namespace Cqrsexy.Domain.LeaveApplication
{
    public class ApprovedLeave : Leave
    {
        public readonly Guid ApproverId;

        public ApprovedLeave(Guid approverId, Leave pendingLeave) 
            :base(pendingLeave.Id, pendingLeave.From, pendingLeave.To)
        {
            this.ApproverId = approverId;
        }
    }
}