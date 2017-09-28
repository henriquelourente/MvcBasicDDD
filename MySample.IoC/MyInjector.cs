using MySample.Application;
using MySample.Domain.Interfaces.Repositories;
using MySample.Infra.Data.Repositories;
using SimpleInjector;
using SimpleInjector.Integration.Web.Mvc;

namespace MySample.IoC
{
    public class MyInjector
    {
        public SimpleInjectorDependencyResolver SimpleInjectorDependencyResolver()
        {
            var container = new Container();

            container.Register<IClienteRepository, ClienteRepository>();
            container.Register<IClienteAppService, ClienteAppService>();
            container.Verify();

            return new SimpleInjectorDependencyResolver(container);
        }
    }
}
