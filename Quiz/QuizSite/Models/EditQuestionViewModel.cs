using System;
using System.Collections.Generic;
using MongoDB.Driver;
using QuizSite.Controllers;


namespace QuizSite.Models
{
	public class EditQuestionViewModel
	{
		public EditQuestionViewModel( Document question )
		{
			Id = ( (Oid)question[ "_id" ] ).ToStringWithoutQuotesIn();
			Question = (string)question[ "Question" ];
			QuestionType = ( (QuestionType)question[ "QuestionType" ] ).ToString();
		}



		public EditQuestionViewModel()
		{
		}



		public IEnumerable<QuestionTypeDescription> QuestionTypes
		{
			get
			{
				yield return new QuestionTypeDescription( "Multiple Choice Radio", Models.QuestionType.MultiChoiceRadio );
				yield return new QuestionTypeDescription( "Multiple Choice Drop-Down", Models.QuestionType.MultiChoiceDropDown );
				yield return new QuestionTypeDescription( "Text", Models.QuestionType.Text );
			}
		}

		public string Id { get; private set; }
		public string Question { get; private set; }
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