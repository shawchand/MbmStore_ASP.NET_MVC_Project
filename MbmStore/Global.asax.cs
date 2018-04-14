using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using MbmStore.Models;
using MbmStore.ViewModels;
using MbmStore.Infrastructure.Binders;


namespace MbmStore
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

			// Add custom model binder
			ModelBinders.Binders.Add(typeof(Cart), new CartModelBinder());
		}
	}
}
