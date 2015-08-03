using System;

namespace Cqrsexy.Core.Infrastructure
{
    public interface IIdentityFactory
    {
        Guid Make();
    }

    public class IdentityFactory : IIdentityFactory
    {
        public Guid Make()
        {
            return Guid.NewGuid();
        }
    }
}