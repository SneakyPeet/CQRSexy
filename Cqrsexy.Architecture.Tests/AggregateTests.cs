using System.Collections.Generic;
using System.Linq;
using Cqrsexy.Core;
using Cqrsexy.DomainMessages;
using NUnit.Framework;

namespace Cqrsexy.Architecture.Tests
{
    [TestFixture]
    public class AggregateTests
    {
        private TestAggregate aggregate;

        [SetUp]
        public void SetUp()
        {
            this.aggregate = new TestAggregate();
        }

        [Test]
        public void AggregateNameShouldEqualTheConcreteImplementationClassName()
        {
            Assert.AreEqual("TestAggregate", this.aggregate.Name);
        }

        [Test]
        public void ApplyingAnEventShouldAddItToUncommitedEvents()
        {
            this.aggregate.ApplyTestEvent();
            var evt =  this.aggregate.GetUncommitedChanges().Single();
            Assert.IsInstanceOf(typeof(TestEventApplied), evt);
        }

        [Test]
        public void MarkingEventsAsCommitedShouldClearUncommitedEvents()
        {
            this.aggregate.ApplyTestEvent();
            this.aggregate.ApplyTestEvent();
            this.aggregate.Commit();
            Assert.IsEmpty(this.aggregate.GetUncommitedChanges());
        }

        [Test]
        public void AggregateVersionShouldBeTheTotalOfAppliedEvents()
        {
            this.aggregate.ApplyTestEvent();
            this.aggregate.ApplyTestEvent();
            this.aggregate.Commit();
            this.aggregate.ApplyTestEvent();
            Assert.AreEqual(3, this.aggregate.Version);
        }

        [Test]
        public void AggregateCommitedVersionShouldBeTheTotalOfCommitedEvents()
        {
            this.aggregate.ApplyTestEvent();
            this.aggregate.ApplyTestEvent();
            this.aggregate.Commit();
            this.aggregate.ApplyTestEvent();
            Assert.AreEqual(2, this.aggregate.CommitedVersion);
        }

        [Test]
        public void LoadingEventsFromHistoryShouldSetTheCorrectVersionNumber()
        {
            var history = this.MakeHistory();
            this.aggregate.LoadFromHistory(history);
            Assert.AreEqual(3, this.aggregate.CommitedVersion);
        }

        [Test]
        public void EventsWithNoApplyMethodShouldNotThrowException()
        {
            this.aggregate.LoadFromHistory(this.MakeHistory());
            this.aggregate.ApplyNonStateChangeEvent();
        }

        private List<IEvent> MakeHistory()
        {
            return new List<IEvent>
                          {
                              new TestEventApplied("A"),
                              new TestEventApplied("C"),
                              new TestEventApplied("B")
                          };
        }

        class TestAggregate : Aggregate
        {
            public string Foo { get; private set; }

            public void ApplyTestEvent()
            {
                this.ApplyTestEvent("A");
            }
            
            public void ApplyTestEvent(string prop)
            {
                ApplyChanges(new TestEventApplied(prop));
            }

            public void ApplyNonStateChangeEvent()
            {
                ApplyChanges(new NonStateChangeEventApplied());
            }

            private void OnTestEventApplied(TestEventApplied evt)
            {
                this.Foo = this.Foo + evt.Prop;
            }

            public TestAggregate() {}
        }

        class TestEventApplied : IEvent
        {
            public readonly string Prop;

            public TestEventApplied(string s)
            {
                this.Prop = s;
            }
        }

        class NonStateChangeEventApplied : IEvent
        {
            
        }
    }
}