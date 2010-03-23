using QuizSite.Controllers;


namespace QuizSite.Models
{
	public class ViewQuestionViewModel
	{
		public ViewQuestionViewModel( IQuestion question )
		{
			Id = question.Id;
			Question = question.Question;
			QuestionType = question.QuestionType;
		}



		public string Id { get; private set; }
		public string Question { get; private set; }
		public QuestionType QuestionType { get; private set; }
	}
}