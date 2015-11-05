using System;

namespace Cqrsexy.Domain.LeaveApplication
{
    public class PendingLeave : Leave
    {
        

        public PendingLeave(Guid id, DateTime from, DateTime to)
            :base(id, from, to)
        {
            
        }

        public ApprovedLeave Approve(Guid approverId)
        {
            return new ApprovedLeave(approverId, this);
        }
    }
}