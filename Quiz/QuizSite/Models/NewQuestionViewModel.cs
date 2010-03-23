using System.Collections.Generic;


namespace QuizSite.Models
{
	public class NewQuestionViewModel
	{
		public IEnumerable<QuestionTypeDescription> QuestionTypes
		{
			get
			{
				yield return new QuestionTypeDescription( "Multiple Choice Radio", Models.QuestionType.MultiChoiceRadio );
				yield return new QuestionTypeDescription( "Multiple Choice Drop-Down", Models.QuestionType.MultiChoiceDropDown );
				yield return new QuestionTypeDescription( "Text", Models.QuestionType.Text );
			}
		}

		public string QuestionType { get; set; }
	}



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



	public enum QuestionType
	{
		MultiChoiceRadio,
		MultiChoiceDropDown,
		Text
	}
}