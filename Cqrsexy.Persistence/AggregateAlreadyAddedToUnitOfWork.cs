using System;
using System.Runtime.Serialization;

namespace Cqrsexy.Persistence
{
    [Serializable]
    public class AggregateAlreadyAddedToUnitOfWork : Exception
    {
        public AggregateAlreadyAddedToUnitOfWork() {}

        protected AggregateAlreadyAddedToUnitOfWork(
            SerializationInfo info,
            StreamingContext context) : base(info, context) {}
    }
}
