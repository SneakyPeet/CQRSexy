using System;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Cqrsexy.Api.Windsor
{
    public class PresistenceInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            //Unit of work needs to be installed based on the calling application
            //The same instance of the unit of work is required per application call
            throw new NotImplementedException();
        }
    }
}