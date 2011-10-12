// Import statements to ensure access to the relevant areas of the base libraries (and our own)
using System.Web.Mvc;

using DotNetDev.Mvc.CSharp.Web.ViewModels;

namespace DotNetDev.Mvc.CSharp.Web.Controllers
{
	/// <summary>All ASP.NET MVC controllers implement IController.  In this case our
	/// MessageController inherits from the abstract base class System.Web.Mvc.Controller allowing
	/// us to focus only on our desired action methods.</summary>
	/// <remarks>This is the most basic of controllers.  ASP.NET MVC controllers have many
	/// other abilities including request pipeline events (OnExecuting, OnExecuted etc).</remarks>
    public class MessageController : Controller
    {
		/// <summary>This action method is called by the controllers ActionInvoker
		/// after the controller is successfully matched to a route</summary>
        public ActionResult Index()
        {
			// The Controller class includes a View method that can be used
			// to render a view with a particular model
			return View(new Message { Text = "Hello C# ASP.NET MVC World!" });
        }
    }
}