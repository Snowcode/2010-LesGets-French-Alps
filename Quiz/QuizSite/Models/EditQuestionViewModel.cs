﻿using System.Collections.Generic;
using QuizSite.Controllers;


namespace QuizSite.Models
{
	public class EditQuestionViewModel
	{
		public EditQuestionViewModel( IQuestion question )
		{
			Id = question.Id;
			Question = question.Question;
			QuestionType = question.QuestionType.ToString();
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
}