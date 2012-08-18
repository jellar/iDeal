using System;
using System.Web.Mvc;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using UIT.iDeal.Common.Configuration;

namespace UIT.iDeal.Infrastructure.Bootstrapper.Installers
{
    public class ControllersInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
               AllTypes
                   .FromAssemblyNamed(ConfigSettings.WebAssemblyName)
                   .BasedOn<IController>()
                   .If(type => type.Name.EndsWith("Controller", StringComparison.Ordinal))
                   .LifestyleTransient());
        }
    }
}