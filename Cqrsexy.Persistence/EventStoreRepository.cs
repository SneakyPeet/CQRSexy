﻿using System;
using Cqrsexy.Core;

namespace Cqrsexy.Persistence
{
    public class EventStoreRepository : IRepository
    {
        public EventStoreRepository(IEventStoreLoader eventStore)
        {
            this.eventStore = eventStore;
        }

        private readonly IEventStoreUnitOfWork unitOfWork;
        private readonly IEventStoreLoader eventStore;

        public EventStoreRepository(IEventStoreUnitOfWork unitOfWork, IEventStoreLoader eventStore)
        {
            this.unitOfWork = unitOfWork;
            this.eventStore = eventStore;
        }

        public T GetById<T>(Guid id) where T : Aggregate, new()
        {
            if (unitOfWork.Contains(id))
            {
                return this.unitOfWork.GetById<T>(id);
            }

            var aggregate = eventStore.Load<T>(id);
            this.unitOfWork.RegisterForTracking(aggregate);
            return aggregate;
        }

        public void Add(Aggregate aggregate)
        {
            this.unitOfWork.RegisterForTracking(aggregate);
        }
    }
}