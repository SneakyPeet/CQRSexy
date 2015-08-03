using System;
using Cqrsexy.Commands;

namespace Cqrsexy.Core.Infrastructure
{
    public class CqrsexyApi
    {
        private readonly IUnitOfWorkFactory uowFactory;
        private readonly ICommandBus bus;

        public CqrsexyApi(IUnitOfWorkFactory uowFactory, ICommandBus bus)
        {
            this.uowFactory = uowFactory;
            this.bus = bus;
        }

        public void Handle(ICommand command)
        {
            var uow = uowFactory.Make();
            try
            {
                this.bus.Submit(command);
                uow.Commit();
            }
            catch(Exception)
            {
                uow.Rollback();
                throw;
            }
        }
    }
}