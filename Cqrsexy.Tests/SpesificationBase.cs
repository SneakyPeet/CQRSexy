using System;
using System.Linq;
using Cqrsexy.Core;
using NUnit.Framework;

namespace Cqrsexy.Tests
{
    [TestFixture]
    public abstract class SpesificationBase
    {
        [SetUp]
        public void SetUp()
        {
            Given();
            When();
        }

        protected virtual void Given() { }
        protected virtual void When() { }
    }
}
