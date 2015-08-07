using System;
using Cqrsexy.Core;
using Cqrsexy.DomainMessages;

namespace Cqrsexy.Api
{
    class ApplicationHandlingUnitOfWork : IApplication
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ICommandDispatcher dispatcher;

        public ApplicationHandlingUnitOfWork(IUnitOfWork unitOfWork, ICommandDispatcher dispatcher)
        {
            this.unitOfWork = unitOfWork;
            this.dispatcher = dispatcher;
        }

        public void Execute(ICommand command)
        {
            try //Can force unit of work to implement IDisposable and use using {} but it compiles down to what I have below anyway
            {
                this.dispatcher.Send(command);
                unitOfWork.Commit();
            }
            finally
            {
                unitOfWork.Rollback();
            }
        }
    }
}
