﻿using System.Collections.Generic;
using Cqrsexy.DomainMessages;
using SharpTestsEx;

namespace Cqrsexy.Domain.Tests
{
    public abstract class EventSpesification : SpesificationBase
    {
        public abstract List<IEvent> Then();

        public override void Test()
        {
            this.Execute();
            this.AssertEventsAreAsExpected();
        }

        private void AssertEventsAreAsExpected()
        {
            this.eventStore.NewEvents().Should()
                      .Not.Be.Empty()
                      .And.Not.Have.SameSequenceAs(this.Then())
                      .And.Have.UniqueValues();
        }
    }
}