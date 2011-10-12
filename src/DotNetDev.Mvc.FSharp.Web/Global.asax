<%@ Application Inherits="DotNetDev.Mvc.FSharp.Global" Language="C#" %>
<script Language="C#" RunAt="server">

	/// <summary>Because we need to set some constructor arguments on this module it is added by code
	/// rather than registered in the web.config</summary>
	public static IHttpModule CodeViewer = new DotNetDev.Web.CodeViewer("../DotNetDev.Mvc.FSharp/", "");
  
	/// <summary>This ApplicationStart event handler will call down into our F# code (the base class defined
	/// declaratively on line 1)</summary>
	protected void Application_Start(Object sender, EventArgs e) {
		// Delegate event handling to the F# Application class
		base.Start();
	}

	/// <summary>Ensure the codeviewer module that is added by this code rather than registered in the web.config
	/// is initialised.</summary>
	public override void Init()
	{
		base.Init();
		CodeViewer.Init(this);
	}
  
</script>