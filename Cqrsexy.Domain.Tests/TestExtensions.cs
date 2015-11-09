using System.Collections.Generic;
using Cqrsexy.DomainMessages;

namespace Cqrsexy.Domain.Tests
{
    public static class TestExtensions
    {
        public static List<T> And<T>(this List<T> history, T message)
        {
            history.Add(message);
            return history;
        }


    }

    public static class Expected
    {
        public static List<IEvent> Event(IEvent evt)
        {
            return new List<IEvent> { evt };
        }
    }
}