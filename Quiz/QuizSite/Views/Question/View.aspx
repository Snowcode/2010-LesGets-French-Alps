<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<QuizSite.Controllers.ViewQuestionViewModel>" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <div>Question: <%= ViewData.Model.Question %></div>
    <div>Question Type: <%= ViewData.Model.QuestionType %></div>
</body>
</html>
