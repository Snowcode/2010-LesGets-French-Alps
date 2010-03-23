namespace QuizSite.Models
{
	public class QuestionTypeDescription
	{
		public string Name { get; private set; }
		public QuestionType QuestionType { get; private set; }



		public QuestionTypeDescription( string name, QuestionType questionType )
		{
			Name = name;
			QuestionType = questionType;
		}
	}
}