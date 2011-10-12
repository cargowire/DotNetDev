<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Notes.ascx.cs" Inherits="DotNetDev.WebForms.CSharp.Web.Notes" %>

<h2>Notes</h2>
<p>ASP.NET WebForms projects are made up of:</p>
<dl>
	<dt>Pages</dt>
	<dd>Instantiated by the ASP.NET pipeline based upon a url directly matching the filename (although Url rewriting can be achieved
	via IIS modules or by writing handlers/modules).  In this case we have one <a class="popup" href="Default.aspx.view">Default.aspx</a>
	with an associated <a class="popup" href="Site.Master.view">Site.Master</a> master page.  With ASP.NET WebForms pages the code is
	separated from the markup into a codebehind <a class="popup" href="Default.aspx.cs.view">Default.aspx.cs</a> file.
	</dd>

	<dt>Controls</dt>
	<dd>In this example the default page contains a child control - <a class="popup" href="Notes.ascx.view">Notes.ascx</a>
	this allows more granular reuse of web page content and functionality.  For this to work child controls must be registered
	with the <a class="popup" href="Default.aspx.view?lines=3">page</a> that is using it.
	</dd>
	
	<dt><strong>M</strong>odels</dt>
	<dd>
		There isn't so much a ViewModel in the WebForms case but the page codebehind can certainly control dynamic values.  In this
		case <a class="popup" href="Default.aspx.cs.view?lines=13,14">Default.aspx.cs</a> sets the <a class="popup" href="Default.aspx.view?lines=10">label</a>
		value in its Page_Load event handler.
	</dd>
</dl>