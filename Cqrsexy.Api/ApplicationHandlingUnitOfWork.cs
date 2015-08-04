using System;
using Cqrsexy.Core;
using Cqrsexy.DomainMessages;

namespace Cqrsexy.Api
{
    class ApplicationHandlingUnitOfWork : IApplication
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ICommandBus bus;

        public ApplicationHandlingUnitOfWork(IUnitOfWork unitOfWork, ICommandBus bus)
        {
            this.unitOfWork = unitOfWork;
            this.bus = bus;
        }

        public void Execute(ICommand command)
        {
            try //Can force unit of work to implement IDisposable and use using {} but it compiles down to what I have below anyway
            {
                this.bus.Submit(command);
                unitOfWork.Commit();
            }
            finally
            {
                unitOfWork.Rollback();
            }
        }
    }
}
