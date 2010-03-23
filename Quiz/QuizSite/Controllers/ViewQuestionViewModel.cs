using MongoDB.Driver;
using QuizSite.Models;


namespace QuizSite.Controllers
{
	public class ViewQuestionViewModel
	{
		public ViewQuestionViewModel( Document question )
		{
			Question = (string)question[ "Question" ];
			QuestionType = (QuestionType)question[ "QuestionType" ];
		}



		public string Question { get; private set; }
		public QuestionType QuestionType { get; private set; }
	}
}