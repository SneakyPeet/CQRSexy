using Cqrsexy.DomainMessages;

namespace Cqrsexy.Api
{
    public interface IApplication
    {
        void Execute<T>(T command) where T : ICommand;
    }
}