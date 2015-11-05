using System;
using System.Runtime.Serialization;

namespace Cqrsexy.Domain.LeaveApplication
{
    [Serializable]
    public class OverlappingLeaveException : Exception
    {
        //
        // For guidelines regarding the creation of new exception types, see
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
        // and
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
        //

        public OverlappingLeaveException() {}

        public OverlappingLeaveException(string message) : base(message) {}

        public OverlappingLeaveException(string message, Exception inner) : base(message, inner) {}

        protected OverlappingLeaveException(
            SerializationInfo info,
            StreamingContext context) : base(info, context) {}
    }
}