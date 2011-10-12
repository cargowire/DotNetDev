using System;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.SessionState;

using IronPython.Hosting;
using Microsoft.Scripting.Hosting;

namespace DotNetDev.Mvc.IronPython.Controllers
{
	public class IronPythonControllerFactory : IControllerFactory
	{
		private ScriptEngine engine;
		private ScriptScope clrScope;

		public IronPythonControllerFactory()
		{
			this.engine = Python.CreateEngine();

			clrScope = this.engine.ImportModule("clr");

			var py = System.Reflection.Assembly
										.GetExecutingAssembly()
										.GetManifestResourceStream("DotNetDev.Mvc.IronPython.Web.Controllers.PythonControllers.py");
			
			using(var sr = new System.IO.StreamReader(py))
			{
				engine.Execute(sr.ReadToEnd(), clrScope);
			}
		}

		public IController CreateController(RequestContext requestContext, string controllerName)
		{
			var controllerType = clrScope.GetVariable(string.Concat(controllerName, "Controller"));
			var controller = engine.Operations.CreateInstance(controllerType);

			return controller;
		}

		public SessionStateBehavior GetControllerSessionBehavior(RequestContext requestContext, string controllerName)
		{
			return SessionStateBehavior.Default;
		}

		public void ReleaseController(IController controller)
		{
			if (controller is IDisposable)
				(controller as IDisposable).Dispose();
			else
				controller = null;
		}
	}
}