using System;
using System.Runtime.Serialization;

namespace Cqrsexy.Domain.LeaveApplication
{
    [Serializable]
    public class ToDateBeforeFromDateException : Exception
    {
        //
        // For guidelines regarding the creation of new exception types, see
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
        // and
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
        //

        public ToDateBeforeFromDateException() {}

        public ToDateBeforeFromDateException(string message) : base(message) {}

        public ToDateBeforeFromDateException(string message, Exception inner) : base(message, inner) {}

        protected ToDateBeforeFromDateException(
            SerializationInfo info,
            StreamingContext context) : base(info, context) {}
    }
}