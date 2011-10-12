'' Import statements to ensure access to the relevant areas of the base libraries (and our own)
Imports System.Web.Mvc

Imports DotNetDev.Mvc.VisualBasic.Web.ViewModels

Namespace DotNetDev.Mvc.VisualBasic.Web.Controllers

	''' <summary>All ASP.NET MVC controllers implement IController.  In this case our
	''' MessageController inherits from the abstract base class System.Web.Mvc.Controller allowing
	''' us to focus only on our desired action methods.</summary>
	''' <remarks>This is the most basic of controllers.  ASP.NET MVC controllers have many
	''' other abilities including request pipeline events (OnExecuting, OnExecuted etc).</remarks>
	Public Class MessageController
		Inherits Controller

		''' <summary>This action method is called by the controllers ActionInvoker
		''' after the controller is successfully matched to a route</summary>
		Public Function Index() As ActionResult
			' The Controller class includes a View method that can be used
			' to render a view with a particular model
			Return View(New Message With {.Text = "Hello VB ASP.NET MVC World!"})
		End Function

	End Class
End Namespace
