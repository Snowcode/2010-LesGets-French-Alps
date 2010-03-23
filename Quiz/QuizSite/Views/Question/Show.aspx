<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<QuizSite.Models.ViewQuestionViewModel>" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <div>Question: <%= Model.Question %></div>
    <div>Question Type: <%= Model.QuestionType %></div>
    <div><%= Html.ActionLink("Edit", "Edit", new { id=Model.Id } ) %></div>
</body>
</html>
