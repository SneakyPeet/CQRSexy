using System;

namespace Cqrsexy.Core.Infrastructure
{
    public interface IIdentityFactory
    {
        Guid Make();
    }

    class IdentityFactory : IIdentityFactory
    {
        public Guid Make()
        {
            return Guid.NewGuid();
        }
    }
}