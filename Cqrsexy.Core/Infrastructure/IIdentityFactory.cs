using System;

namespace Cqrsexy.Core.Infrastructure
{
    public class IdentityFactory
    {
        public static Guid Make()
        {
            return Guid.NewGuid();
        }
    }
}