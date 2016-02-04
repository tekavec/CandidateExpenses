﻿using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using CandidateExpenses.Infrastructure;
using CandidateExpenses.Installers;
using Castle.Windsor;
using Castle.Windsor.Installer;

namespace CandidateExpenses
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private static IWindsorContainer _container;

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            BootstrapContainer();
        }
        protected void Application_End()
        {
            _container.Dispose();
        }

        private static void BootstrapContainer()
        {
            _container = new WindsorContainer()
                .Install(FromAssembly.This());
            var controllerFactory = new CastleControllerFactory(_container.Kernel);
            ControllerBuilder.Current.SetControllerFactory(controllerFactory);
        }
    }
}
