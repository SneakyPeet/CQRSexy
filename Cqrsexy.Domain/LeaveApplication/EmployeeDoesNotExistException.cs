using System;
using System.Runtime.Serialization;

namespace Cqrsexy.Domain.LeaveApplication
{
    [Serializable]
    public class EmployeeDoesNotExistException : Exception
    {
        public EmployeeDoesNotExistException(Guid id)
            : base(string.Format("Employee with id {0} not found", id))
        {
            
        }

        public EmployeeDoesNotExistException(string message) : base(message) {}

        public EmployeeDoesNotExistException(string message, Exception inner) : base(message, inner) {}

        protected EmployeeDoesNotExistException(
            SerializationInfo info,
            StreamingContext context) : base(info, context) {}
    }
}