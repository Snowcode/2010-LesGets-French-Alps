using QuizSite.Models;


namespace QuizSite.Controllers
{
	public class SimpleQuestion : IQuestion
	{
		public string Id { get; private set; }
		public QuestionType QuestionType { get; private set; }
		public string Question { get; private set; }



		public SimpleQuestion( string Id,  QuestionType questionType, string question )
		{
			this.Id = Id;
			QuestionType = questionType;
			Question = question;
		}
	}
}