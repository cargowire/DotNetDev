<h2>Notes</h2>
<p>ASP.NET MVC Visual Basic:</p>
<dl>
	<dt>Routes</dt>
	<dd>The entry point of the system.  Defined within 
		<a class="popup" href="@Url.Content("~/Global.asax.vb.view?lines=21,22,23,24,25,36")">Global.asax.vb</a>
		Application_Start event.  Routes are defined with a pattern that matches to a controller, action
		and any number of parameters (optional or otherwise).
	</dd>
	
	<dt><strong>C</strong>ontrollers</dt>
	<dd>Instantiated by a controller factory based upon the defined routes.
	</dd>

	<dt>Actions</dt>
	<dd>In this example the <a class="popup" href="@Url.Content("~/Controllers/MessageController.vb.view?lines=18,19,20,21,22")">MessageController.vb</a> index
		action is called by default.
	</dd>
	
	<dt><strong>M</strong>odels</dt>
	<dd>Within the message controller a <a class="popup" href="@Url.Content("~/ViewModels/Message.vb.view")">Message.vb</a> view model is created.  This is not a model in the
		database sense.  In fact these do not exist in this particular project.  A View Model encapsulates the set of data required
		by a particular view, some of which may come from persistant storage models.
	</dd>
	
	<dt><strong>V</strong>iews</dt>
	<dd>
		In this example we are using the Razor view engine (provided by Microsoft).  We could just as easily be using Spark, webforms
		or many others.  With razor code is denoted by @@ symbols.  We can see this in <a class="popup" href="@Url.Content("~/Views/Message/Index.vbhtml.view?lines=9")">Index.vbhtml</a>
		where the view model is accessed and the Text property is output.
	</dd>
</dl>