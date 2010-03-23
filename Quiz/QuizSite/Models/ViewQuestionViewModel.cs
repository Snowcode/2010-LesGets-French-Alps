using MongoDB.Driver;
using QuizSite.Controllers;


namespace QuizSite.Models
{
	public class ViewQuestionViewModel
	{
		public ViewQuestionViewModel( Document question )
		{
			Id = ( (Oid)question[ "_id" ] ).ToStringWithoutQuotesIn();
			Question = (string)question[ "Question" ];
			QuestionType = (QuestionType)question[ "QuestionType" ];
		}



		public string Id { get; private set; }
		public string Question { get; private set; }
		public QuestionType QuestionType { get; private set; }
	}
}