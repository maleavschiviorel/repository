using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using AutoMapper;
using Castle.Windsor;
using Castle.Windsor.Installer;
using Factory.IoC;
using FirstMVC.AutoMapper;
using Presentation.MVC.Windsor_Utils;


namespace FirstMVC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var container = new WindsorContainer().Install(FromAssembly.This());

            ServiceLocator.RegisterAll(container.Kernel);
            ControllerBuilder.Current.SetControllerFactory(new WindsorControllerFactory(container.Kernel));

            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<OrderProfile >( );
                cfg.AddProfile<ClientProfile>();
                // Configuration code
            });

        }
    }
}
