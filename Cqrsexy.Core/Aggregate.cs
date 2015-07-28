using System.Collections.Generic;

namespace Cqrsexy.Core
{
    public abstract class Aggregate
    {
        private readonly List<Event> changes;

        protected Aggregate()
        {
            this.changes = new List<Event>();
            Version = 0;
        }

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
                return Version - changes.Count;
            }
        }

        protected void ApplyChanges(Event evt)
        {
            changes.Add(evt);
            Apply(evt);
        }

        private void Apply(Event evt)
        {
            Version++;
            evt.Version = Version;
        }

        public IEnumerable<Event> GetUncommitedEvents()
        {
            return changes.AsReadOnly();
        }

        public void Commit()
        {
            changes.Clear();
        }

        public void LoadFromHistory(List<Event> history)
        {
            foreach(var evt in history)
            {
                Apply(evt);
            }
        }
    }
}