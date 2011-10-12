Namespace DotNetDev.Mvc.VisualBasic.Web

	''' <summary>This application class provides us access to the global events.  Allowing us to ask the framework to
	''' do something on ApplicationStart or BeginRequest etc</summary>
	Public Class MvcApplication
		Inherits System.Web.HttpApplication

		Shared Sub RegisterGlobalFilters(ByVal filters As GlobalFilterCollection)
			filters.Add(New HandleErrorAttribute())
		End Sub

		''' <summary>Routes are registered to the RouteTable.Routes collection.  Simple patterns are matched
		''' to controller classes to instantiate and action methods to call with varying parameters.</summary>
		Shared Sub RegisterRoutes(ByVal routes As RouteCollection)
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}")

			' MapRoute takes the following parameters, in order:
			' (1) Route name
			' (2) URL with parameters
			' (3) Parameter defaults
			routes.MapRoute( _
			 "Default", _
			 "{controller}/{action}/{id}", _
			 New With {.controller = "Message", .action = "Index", .id = UrlParameter.Optional} _
			)

		End Sub

		''' <summary>The code to run when the application is started.  In this case register any areas that exist ('sub sites' within the
		''' project with their own controllers, views etc- in this case none), Register filters (code that run for each action)
		''' and most importantly register the routes that the application will respond to.</summary>
		Sub Application_Start()
			AreaRegistration.RegisterAllAreas()

			RegisterGlobalFilters(GlobalFilters.Filters)
			RegisterRoutes(RouteTable.Routes)
		End Sub
	End Class

End Namespace