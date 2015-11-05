using System;

namespace Cqrsexy.Domain.Tests
{
    internal class TestException : Exception
    {
        public TestException(string message)
            : base(message)
        {
        }
    }
}