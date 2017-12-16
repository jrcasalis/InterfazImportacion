using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc5;
using ExportarLista.Business.Interfaces;
using ExportarLista.Business;
using ExportarLista.Services;
using ExportarLista.Data.Repositories;
using Microsoft.Practices.Unity.Configuration;

namespace ExportarLista.UI
{
    public static class UnityConfig
    {
        public static UnityContainer RegisterComponents()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            //container.RegisterType<INavbarBusiness, NavbarBusiness>();
            //container.RegisterType<INavbarRepository, NavbarRepository>();
            container.LoadConfiguration();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
            return container;
        }
    }
}