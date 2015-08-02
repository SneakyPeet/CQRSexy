using System;
using System.Collections.Generic;
using System.Reflection;
using Cqrsexy.Events;

namespace Cqrsexy.Core.Infrastructure
{
    public abstract class Aggregate
    {
        private readonly List<IEvent> changes;

        protected Aggregate(Guid id)
        {
            this.Id = id;
            this.changes = new List<IEvent>();
            this.Version = 0;
        }

        public Guid Id { get; protected set; }

        public string Name
        {
            get
            {
                return this.GetType().Name;
            }
        }

        public int Version { get; private set; }

        /// <summary>
        /// Version Before Uncommited Changes
        /// </summary>
        public int CommitedVersion
        {
            get
            {
                return this.Version - this.changes.Count;
            }
        }

        protected void ApplyChanges(IEvent evt)
        {
            this.Apply(evt);
            this.changes.Add(evt);
        }

        /// <summary>
        /// Applies event to the aggregate if a method on the concrete class following convention "On<EventName> can be found
        /// </summary>
        /// <param name="evt"></param>/
        private void Apply(IEvent evt)
        {
            this.Version++;
            var apply = this.GetType().GetMethod("On" + evt.GetType().Name, BindingFlags.NonPublic | BindingFlags.Instance);
            if(apply != null)
            {
                apply.Invoke(this, new object[] { evt });
            }
        }

        public IEnumerable<IEvent> GetUncommitedEvents()
        {
            return this.changes.AsReadOnly();
        }

        public void Commit()
        {
            this.changes.Clear();
        }

        public void LoadFromHistory(List<IEvent> history)
        {
            //catch load from history exception
            foreach(var evt in history)
            {
                this.Apply(evt);
            }
        }
    }
}