using DotNetDev.Nancy.CSharp.Web.ViewModels;

using Nancy;

namespace DotNetDev.Nancy.CSharp.Web
{
	/// <summary>All Nancy Modules inherit NancyModule.</summary>
	/// <remarks>This is the most basic of modules.</remarks>
	public class MessageModule : NancyModule
	{
		/// <summary>The module constructor sets up the urls that will be matched</summary>
		public MessageModule()
			: base("/") // The base module includes the root path for this module
		{
			/// <summary>The Get dictionary allows us to set an action by assigning
			/// a function to a url pattern.  In this case the root url matches
			/// to an inline anonymous function that renders a view.</summary>
			Get["/"] = x =>
			{
				dynamic model = new Message { Text = "Hello C# Nancy World!" };
				return View["message_index.cshtml", model];
			};
		}
	}
}