using System.Web.Mvc;
using System.Web.Routing;

namespace DotNetDev.Mvc.CSharp.Web
{
	/// <summary>This application class provides us access to the global events.  Allowing us to ask the framework to
	/// do something on ApplicationStart or BeginRequest etc</summary>
	public class MvcApplication : System.Web.HttpApplication
	{
		public static void RegisterGlobalFilters(GlobalFilterCollection filters)
		{
			filters.Add(new HandleErrorAttribute());
		}

		/// <summary>Routes are registered to the RouteTable.Routes collection.  Simple patterns are matched
		/// to controller classes to instantiate and action methods to call with varying parameters.</summary>
		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			routes.MapRoute(
				"Default", // Route name
				"{controller}/{action}/{id}", // URL with parameters
				new { controller = "Message", action = "Index", id = UrlParameter.Optional } // Parameter defaults
			);

		}

		/// <summary>The code to run when the application is started.  In this case register any areas that exist ('sub sites' within the
		/// project with their own controllers, views etc- in this case none), Register filters (code that run for each action)
		/// and most importantly register the routes that the application will respond to.</summary>
		protected void Application_Start()
		{
			AreaRegistration.RegisterAllAreas();
			
			RegisterGlobalFilters(GlobalFilters.Filters);
			RegisterRoutes(RouteTable.Routes);
		}
	}
}