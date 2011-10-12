using System.IO;
using System.Reflection;
using System.Web;

using DotNetDev.Web.Extensions;

namespace DotNetDev.Web
{
	/// <summary>A quick and dirty embedded resource renderer that will return embedded resources
	/// to an appropriate request.</summary>
	public class EmbeddedResourceModule : IHttpModule
	{
		private Assembly assembly = null;
		private string extension = ".res";
		public EmbeddedResourceModule()
		{
			this.assembly = this.GetType().Assembly;
		}
		public EmbeddedResourceModule(Assembly assembly)
		{
			this.assembly = assembly;
		}

		public void Init(HttpApplication context)
		{
			context.BeginRequest +=new System.EventHandler(context_BeginRequest);
		}

		/// <summary>React to any request to appropriate extensions and render out an html page
		/// containing the matching embedded resource contents.</summary>
		protected void context_BeginRequest(object sender, System.EventArgs e)
		{
			var app = (HttpApplication)sender;
			var file = HttpContext.Current.Request.FilePath;
			if (file.EndsWith(extension))
			{
				file = file.Substring(0, file.Length - extension.Length).ReplaceFirst(VirtualPathUtility.ToAbsolute("~"), "");

				string[] path = file.Split(new char[]{'/'}, System.StringSplitOptions.RemoveEmptyEntries);
				var ext = file.Substring(file.LastIndexOf('.'));
				
				using (var contentStream = assembly.GetManifestResourceStream(assembly.GetName().Name + "." + string.Join(".", path))) 
				{
					if (contentStream != null)
					{
						app.Context.Response.Clear();
						app.Context.Response.ContentType = negotiateContentType(ext);

						using (var sr = new StreamReader(contentStream))
						{
							using (var sw = new StreamWriter(app.Context.Response.OutputStream))
							{
								sw.Write(sr.ReadToEnd());
							}
						}

						app.Context.Response.Flush();
						app.Context.Response.End();
					}
				}
			}
		}

		public void Dispose() {}

		private string negotiateContentType(string extension)
		{
			switch (extension.ToLower())
			{
				case ".css":
					return "text/css";
				case ".js":
					return "text/javascript";
				default:
					return "";
			}
		}
	}
}