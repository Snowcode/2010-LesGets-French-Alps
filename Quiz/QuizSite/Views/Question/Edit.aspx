<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<QuizSite.Models.EditQuestionViewModel>" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
	<div id="newQuestionForm">
	<% using( Html.BeginForm("Save", "Question", new { id = Model.Id }) ) { %>
		<div>Question: <%= Html.TextBoxFor(model => model.Question) %></div>
		<div>Type: <%= Html.DropDownListFor( model => model.QuestionType, from qt in ViewData.Model.QuestionTypes select new SelectListItem { Text = qt.Name, Value = qt.QuestionType.ToString() }, "--Please Select--" ) %></div>
		<input type="submit" />
    <% } %>
    </div>
</body>
</html>
