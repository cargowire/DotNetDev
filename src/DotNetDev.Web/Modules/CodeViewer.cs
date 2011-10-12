using System;
using System.IO;
using System.Linq;
using System.Web;

using DotNetDev.Web.Extensions;

namespace DotNetDev.Web
{
	/// <summary>A quick and dirty code viewer that will open a normally inaccessible source code file
	/// and render it within an HTML page using Alex Gorbatchev's Syntax Highlighter 
	/// (https://github.com/alexgorbatchev/SyntaxHighlighter). Contains an EmbeddedResourceModule
	/// to allow the SyntaxHighlighter client code to be stored within the dll.</summary>
	public class CodeViewer : IHttpModule
	{
		public static IHttpModule Module = new EmbeddedResourceModule();
		private string extension = ".view";
		private string[] relativeRootFolders;
		private string[] rootFolders;

		public CodeViewer()	{ }
		public CodeViewer(params string[] relativeRootFolders) 
		{
			this.relativeRootFolders = relativeRootFolders; 
		}

		/// <summary>Wire up an event lister on the applications 'BeginRequest' event (fired at the beginning
		/// of all requests to this app on the server</summary>
		public void Init(HttpApplication context)
		{
			context.BeginRequest +=new System.EventHandler(context_BeginRequest);
			Module.Init(context);
		}

		/// <summary>React to any request to appropriate extensions and render out an html page
		/// containing the source file contents.  Include an html header and use the 'lines'
		/// querystring property to identify lines to highlight.</summary>
		protected void context_BeginRequest(object sender, EventArgs e)
		{
			var app = (HttpApplication)sender;
			
			if (rootFolders == null)
			{
				if (relativeRootFolders == null)
					rootFolders = new string[] { app.Context.Server.MapPath("~/") };
				else
					rootFolders = relativeRootFolders.Select(f => Path.Combine(app.Context.Server.MapPath("~/"), f)).ToArray();
			}

			var file = HttpContext.Current.Request.FilePath.ReplaceFirst(VirtualPathUtility.ToAbsolute("~/"), "");
			if (file.EndsWith(extension))
			{
				file = file.Substring(0, file.Length - extension.Length);

				foreach(var rootFolder in rootFolders){
					var filePath = string.Concat(rootFolder,"/", file);
					if (System.IO.File.Exists(filePath))
					{
						var ext = file.Substring(file.LastIndexOf('.'));
						var fileName = filePath.Substring(filePath.LastIndexOf('/'));

						app.Context.Response.Clear();
						app.Context.Response.ContentType = "text/html";
						app.Context.Response.Write("<!DOCTYPE html>\n<html>\n<head><meta charset=\"utf-8\" /><title>"+fileName+"</title>\n");
						app.Context.Response.Write("<link rel=\"stylesheet\" href=\""+VirtualPathUtility.ToAbsolute("~/Content/styles/SyntaxHighlighter.css.res")+"\" type=\"text/css\" media=\"all\">\n");
						app.Context.Response.Write("<script type=\"text/javascript\" src=\""+VirtualPathUtility.ToAbsolute("~/Content/scripts/shCore.js.res")+"\"></script>\n");
						app.Context.Response.Write(getStyles(ext));
						app.Context.Response.Write("</head>\n<body>\n");
						app.Context.Response.Write("<h1>"+fileName+"</h1>\n");
						app.Context.Response.Write("<pre id=\"code\" style=\"overflow:auto;\" class=\"brush: "+ negotiateBrush(ext));
						if(app.Context.Request.QueryString["lines"] != null){
							app.Context.Response.Write(" highlight: [" + string.Join(",", app.Context.Request.QueryString.GetValues("lines")) + "];");
						}
						app.Context.Response.Write("\">");
						app.Context.Response.Write(System.Web.HttpUtility.HtmlEncode(File.ReadAllText(filePath)));
						app.Context.Response.Write("</pre>\n</body>\n");
						app.Context.Response.Write("<script type=\"text/javascript\">");
						app.Context.Response.Write(@"var cv = function(){
													SyntaxHighlighter.defaults['toolbar'] = false;
													SyntaxHighlighter.all();
													function attachEvent(obj, type, func, scope)
													{
														function handler(e)
														{
															e = e || window.event;
															if (!e.target)
															{
																e.target = e.srcElement;
																e.preventDefault = function() {	this.returnValue = false; };
															}
															func.call(scope || window, e);
														};
														if (obj.attachEvent) 
															obj.attachEvent('on' + type, handler);
														else 
															obj.addEventListener(type, handler, false);
													};
													// Ensure that the code div is sized to be full scroll width (enables
													// tighter embedding in an iFrame)
													attachEvent(window,'load', function() {
														var width = ((document.getElementsByTagName(""div"")[1].scrollWidth)+20) + 'px';
														document.getElementById(""code"").style.width = width;
													});
													}();</script>");
						app.Context.Response.Write("</html>\n");
						app.Context.Response.Flush();
						app.Context.Response.End();
						
						break;
					}
				}
			}
		}

		public void Dispose() { Module.Dispose(); }

		/// <summary>Returns a brush name appropriate for the requested code file for use with the Syntax Highlighter</summary>
		private string negotiateBrush(string extension)
		{
			switch (extension.ToLower())
			{
				case ".cs":
				case ".js":
				case ".fs":
					return "csharp";
				case ".py":
					return "python";
				case ".cshtml":
				case ".vbhtml":
				case ".master":
				case ".aspx":
				case ".ascx":
				case ".html":
				case ".xml":
				case ".config":
					return "xml";
				case ".css":
					return "css";
				case ".vb":
					return "vb";
				default:
					return "";
			}
		}
		
		/// <summary>Returns a style link to the appropriate Syntax Highlighter brush</summary>
		private string getStyles(string extension)
		{
			switch (extension.ToLower())
			{
				case ".cs":
				case ".fs":
				case ".js":
					return "<script type=\"text/javascript\" src=\"" + VirtualPathUtility.ToAbsolute("~/Content/scripts/shBrushCSharp.js.res")+"\"></script>\n";
				case ".py":
					return "<script type=\"text/javascript\" src=\"" + VirtualPathUtility.ToAbsolute("~/Content/scripts/shBrushPython.js.res") + "\"></script>\n";
				case ".cshtml":
				case ".vbhtml":
				case ".master":
				case ".aspx":
				case ".ascx":
				case ".html":
				case ".xml":
				case ".config":
					return "<script type=\"text/javascript\" src=\"" + VirtualPathUtility.ToAbsolute("~/Content/scripts/shBrushXml.js.res")+"\"></script>\n";
				case ".css":
					return "<script type=\"text/javascript\" src=\"" + VirtualPathUtility.ToAbsolute("~/Content/scripts/shBrushCss.js.res")+"\"></script>\n";
				case ".vb":
					return "<script type=\"text/javascript\" src=\"" + VirtualPathUtility.ToAbsolute("~/Content/scripts/shBrushVb.js.res")+"\"></script>\n";
				default:
					return "";
			}
		}
	}
}