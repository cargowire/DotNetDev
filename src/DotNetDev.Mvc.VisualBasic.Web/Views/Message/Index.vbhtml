@ModelType Message

@Code
	ViewData("Title") = "Index"
End Code

<h2>Index</h2>

@Model.Text

@Html.Partial("Notes")