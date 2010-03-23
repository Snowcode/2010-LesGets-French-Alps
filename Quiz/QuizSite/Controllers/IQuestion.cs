using QuizSite.Models;


namespace QuizSite.Controllers
{
	public interface IQuestion
	{
		QuestionType QuestionType { get; }
		string Question { get; }
		string Id { get; }
	}
}