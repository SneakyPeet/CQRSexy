using System.Collections.Generic;
using System.Linq;
using System.Reflection;

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
            Version++;
            evt.Version = Version;
        }

        /// <summary>
        /// Applies event to the aggregate if a method on the concrete class following convention "On<EventName> can be found
        /// </summary>
        /// <param name="evt"></param>/
        private void Apply(Event evt)
        {
            var apply = this.GetType().GetMethod("On" + evt.GetType().Name, BindingFlags.NonPublic | BindingFlags.Instance);
            if(apply != null)
            {
                apply.Invoke(this, new object[] { evt });
            }
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
            foreach(var evt in history.OrderBy(e => e.Version))
            {
                Apply(evt);
            }
        }
    }
}