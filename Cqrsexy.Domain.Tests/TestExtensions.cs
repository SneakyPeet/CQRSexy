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

    public static class History
    {
        public static List<ICommand> With(ICommand command)
        {
            return new List<ICommand> { command };
        }
    }

    public static class No
    {
        public static List<ICommand> History()
        {
            return new List<ICommand>();
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