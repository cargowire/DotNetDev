using System;

using DotNetDev.WebForms.CSharp.Web.ViewModels;

namespace DotNetDev.WebForms.CSharp.Web
{
	public partial class _Default : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			this.Title = "Index";

			var model = new Message { Text = "Hello C# WebForms World!" };
			message.Text = model.Text;
		}
	}
}
