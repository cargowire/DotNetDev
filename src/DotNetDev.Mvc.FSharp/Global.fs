namespace DotNetDev.Mvc.FSharp

open System
open System.Web.Mvc
open System.Web.Routing

type Route = { 
  controller : string
  action : string
  id : UrlParameter }

/// This application class provides us access to the global events.  Allowing us to ask the framework to
/// do something on ApplicationStart or BeginRequest etc
type Global() =
  inherit System.Web.HttpApplication() 

  static member RegisterRoutes(routes:RouteCollection) =
    routes.IgnoreRoute("{resource}.axd/{*pathInfo}")
    routes.MapRoute(
        "Default", // Route name
        "{controller}/{action}/{id}", // URL with parameters
        { controller = "Message"; action = "Index"; id = UrlParameter.Optional } // Parameter defaults
      )

  // The Start event called within the C# sub classes Application_Start event handler
  member x.Start() =
    AreaRegistration.RegisterAllAreas()
    Global.RegisterRoutes(RouteTable.Routes)