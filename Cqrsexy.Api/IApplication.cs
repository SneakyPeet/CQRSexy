using Cqrsexy.DomainMessages;

namespace Cqrsexy.Api
{
    public interface IApplication
    {
        void Execute(ICommand command);
    }
}