﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Presentation.MVC
{
   using Castle.Windsor;
   using Castle.Windsor.Installer;
   using Factory.IoC;
   using Windsor_Utils;

   public class MvcApplication : System.Web.HttpApplication
    {
      protected void Application_Start()
      {
         AreaRegistration.RegisterAllAreas();
         RouteConfig.RegisterRoutes(RouteTable.Routes);

         var container = new WindsorContainer().Install(FromAssembly.This());

         ServiceLocator.RegisterAll(container.Kernel);
         ControllerBuilder.Current.SetControllerFactory(new WindsorControllerFactory(container.Kernel));
      }
    }
}
