using System;
using System.Runtime.Serialization;

namespace Cqrsexy.Core
{
    [Serializable]
    public class OnEventHandlerNotRegisteredException : Exception
    {
        public OnEventHandlerNotRegisteredException(Type type)
            : base(type.Name) { }

        public OnEventHandlerNotRegisteredException(string message) : base(message) {}

        public OnEventHandlerNotRegisteredException(string message, Exception inner) : base(message, inner) {}

        protected OnEventHandlerNotRegisteredException(
            SerializationInfo info,
            StreamingContext context) : base(info, context) {}
    }
}