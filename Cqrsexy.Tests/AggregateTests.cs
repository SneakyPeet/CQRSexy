using System.Collections.Generic;
using System.Linq;
using Cqrsexy.Core;
using NUnit.Framework;

namespace Cqrsexy.Tests
{
    [TestFixture]
    public class AggregateTests
    {
        private TestAggregate aggregate;

        [SetUp]
        public void SetUp()
        {
            aggregate = new TestAggregate();
        }

        [Test]
        public void AggregateNameShouldEqualTheConcreteImplementationClassName()
        {
            Assert.AreEqual("TestAggregate", aggregate.Name);
        }

        [Test]
        public void ApplyingAnEventShouldAddItToUncommitedEvents()
        {
            aggregate.ApplyTestEvent();
            var evt =  aggregate.GetUncommitedEvents().Single();
            Assert.IsInstanceOf(typeof(TestEventApplied), evt);
        }

        [Test]
        public void MarkingEventsAsCommitedShouldClearUncommitedEvents()
        {
            aggregate.ApplyTestEvent();
            aggregate.ApplyTestEvent();
            aggregate.Commit();
            Assert.IsEmpty(aggregate.GetUncommitedEvents());
        }

        [Test]
        public void AggregateVersionShouldBeTheTotalOfAppliedEvents()
        {
            aggregate.ApplyTestEvent();
            aggregate.ApplyTestEvent();
            aggregate.Commit();
            aggregate.ApplyTestEvent();
            Assert.AreEqual(3, aggregate.Version);
        }

        [Test]
        public void AggregateCommitedVersionShouldBeTheTotalOfCommitedEvents()
        {
            aggregate.ApplyTestEvent();
            aggregate.ApplyTestEvent();
            aggregate.Commit();
            aggregate.ApplyTestEvent();
            Assert.AreEqual(2, aggregate.CommitedVersion);
        }

        [Test]
        public void LoadingEventsFromHistoryShouldSetTheCorrectVersionNumber()
        {
            var history = MakeHistory();
            aggregate.LoadFromHistory(history);
            Assert.AreEqual(3, aggregate.CommitedVersion);
        }

        [Test]
        public void ChangesShouldHaveTheCorrectVersion()
        {
            aggregate.LoadFromHistory(MakeHistory());
            aggregate.ApplyTestEvent();
            var change = aggregate.GetUncommitedEvents().Single();
            Assert.AreEqual(4, change.Version);
        }

        [Test]
        public void EventsShouldBeAppliedInOrder()
        {
            aggregate.LoadFromHistory(MakeHistory());
            aggregate.ApplyTestEvent("D");
            Assert.AreEqual("ABCD", aggregate.Foo);
        }

        [Test]
        public void EventsWithNoApplyMethodShouldNotThrowException()
        {
            aggregate.LoadFromHistory(MakeHistory());
            aggregate.ApplyNonStateChangeEvent();
        }

        private List<Event> MakeHistory()
        {
            return new List<Event>
                          {
                              new TestEventApplied("A") { Version = 1 },
                              new TestEventApplied("C") { Version = 3 },
                              new TestEventApplied("B") { Version = 2 }
                          };
        }

        class TestAggregate : Aggregate
        {
            public string Foo { get; private set; }

            public void ApplyTestEvent()
            {
                ApplyTestEvent("A");
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
                Foo = Foo + evt.Prop;
            }
        }

        class TestEventApplied : Event
        {
            public readonly string Prop;

            public TestEventApplied(string s)
            {
                this.Prop = s;
            }
        }

        class NonStateChangeEventApplied : Event
        {
            
        }
    }
}