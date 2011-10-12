namespace DotNetDev.Mvc.FSharp.Controllers

open System
open System.Web.Mvc

open DotNetDev.Mvc.FSharp.ViewModels

// All ASP.NET MVC controllers implement IController.  In this case our
// MessageController inherits from the abstract base class System.Web.Mvc.Controller allowing
// us to focus only on our desired action methods.
[<HandleError>]
type MessageController() =
  inherit Controller()

  // This action method is called by the controllers ActionInvoker
  // after the controller is successfully matched to a route
  member x.Index() =
    x.ViewData.Model <- new Message "Hello F# ASP.NET MVC World!"
    // The Controller class includes a View method that can be used
    // to render a view with a particular model
    x.View() 