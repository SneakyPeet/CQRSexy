using System;
using Cqrsexy.Core;
using Cqrsexy.DomainMessages;

namespace Cqrsexy.Api
{
    class SingleUnitOfWorkApplication : IApplication
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ICommandBus bus;

        public SingleUnitOfWorkApplication(IUnitOfWork unitOfWork, ICommandBus bus)
        {
            this.unitOfWork = unitOfWork;
            this.bus = bus;
        }

        public void Execute(ICommand command)
        {
            try //this can still be better but I am not yet sure how
            {
                this.bus.Submit(command);
                unitOfWork.Commit();
            }
            catch (Exception)
            {
                unitOfWork.Rollback();
                throw;
            }
        }
    }
}
