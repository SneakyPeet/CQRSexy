using System;
using NUnit.Framework;

namespace Cqrsexy.Domain.Tests
{
    public abstract class ExceptionSpesification : SpesificationBase
    {
        public abstract Exception Then();

        public override void Test()
        {
            var expectedException = this.Then();
            AssertExpectedExceptionSet(expectedException);
            
            var exception = this.TryTest();
            
            this.AssertExceptionThrown(expectedException, exception);
            this.AssertExceptionType(expectedException, exception);
            this.AssertExceptionMessage(expectedException, exception);
            this.AssertNoEventsCommitted();
        }

        private Exception TryTest()
        {
            Exception exception = null;
            try
            {
                this.Execute();
            }
            catch(Exception e)
            {
                exception = e;
            }
            return exception;
        }

        private static void AssertExpectedExceptionSet(Exception expectedException)
        {
            Assert.IsNotNull(expectedException, "Then Cannot Return a null Exception");
        }

        private void AssertExceptionThrown(Exception expected, Exception exception)
        {
            Assert.IsNotNull(exception, string.Format("Exception of Type {0} was expected.", expected.GetType()));
        }

        private void AssertExceptionType(Exception expected, Exception exception)
        {
            var expectedType = expected.GetType();
            var actualType = exception.GetType();
            Assert.AreEqual(expectedType, actualType, string.Format("Exception of Type {0} was expected. But Was {1}", expectedType, actualType));
        }

        private void AssertExceptionMessage(Exception expected, Exception exception)
        {
            var expectedMessage = expected.Message;
            var actualMessage = exception.Message;
            Assert.AreEqual(expectedMessage, actualMessage, string.Format("Expected Message {0} was expected. But Was {1}", expectedMessage, actualMessage));
        }

        private void AssertNoEventsCommitted()
        {
            Assert.IsEmpty(this.eventStore.NewEvents(), "Events Where Commited Eventhough Exception Was Thrown");
        }
    }
}