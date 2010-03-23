<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<System.Collections.Generic.IEnumerable<QuizSite.Models.ViewQuestionViewModel>>" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
<% foreach (var question in ViewData.Model) { %>
    <div><%= Html.ActionLink(question.Question, "Show", new { id=question.Id } ) %> <%= Html.ActionLink("Edit", "Edit", new { id=question.Id } ) %></div>
<% } %>
</body>
</html>
