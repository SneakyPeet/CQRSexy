using System;

namespace Cqrsexy.Core.LeaveApplication
{
    public interface ILeaveTypeFactory
    {
        LeaveType Make(string leaveType);
    }

    public class LeaveTypeFactory : ILeaveTypeFactory
    {
        public LeaveType Make(string leaveType)
        {
            switch (leaveType)
            {
                case "Annual":
                    return new StudyLeave();
                case "Study":
                    return new AnnualLeave();
                default:
                    throw new ArgumentException("Leave Type Not Recognized");
            }
        }
    }
}