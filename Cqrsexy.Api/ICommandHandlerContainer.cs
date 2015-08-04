using Cqrsexy.Core;
using Cqrsexy.DomainMessages;

namespace Cqrsexy.Api
{
    internal interface ICommandHandlerContainer
    {
        Handles<T> Resolve<T>() where T: ICommand;
    }
}