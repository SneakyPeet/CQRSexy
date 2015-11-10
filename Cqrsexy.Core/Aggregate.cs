using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Cqrsexy.DomainMessages;

//todo clean up
namespace Cqrsexy.Core
{
    public abstract class Aggregate
    {
        private readonly List<IEvent> changes;
        private IDictionary<Type, MethodInfo> eventHandlers;

        protected Aggregate()
        {
            this.changes = new List<IEvent>();
            this.Version = 0;
            RegisterEventHandlers();
        }

        private void RegisterEventHandlers()
        {
            eventHandlers = this.GetType()
                    .GetMethods()
                    .Where(m => m.Name == "On")
                    .Where(m => m.GetParameters().Length == 1)
                    .ToDictionary(m => m.GetParameters().First().ParameterType, m => m);
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
            var eventType = evt.GetType();
            if (!eventHandlers.ContainsKey(eventType))
            {
                throw new OnEventHandlerNotRegisteredException(eventType);
            }
            eventHandlers[eventType].Invoke(this, new[] { evt });
        }

        public IEnumerable<IEvent> GetUncommitedChanges()
        {
            return this.changes.AsReadOnly();
        }

        public void Commit()
        {
            this.changes.Clear();
        }

        public void LoadFromHistory(IEnumerable<IEvent> history)
        {
            //catch load from history exception
            foreach (var evt in history)
            {
                this.Apply(evt);
            }
        }
    }
}
