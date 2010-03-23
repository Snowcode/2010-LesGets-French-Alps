using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;
using MongoDB.Linq;
using QuizSite.Models;


namespace QuizSite.Controllers
{
	public class QuestionRepository
	{
		private readonly IMongoCollection questions;



		public QuestionRepository()
		{
			var mongoConnectionStringBuilder = new MongoConnectionStringBuilder();
			mongoConnectionStringBuilder.AddServer( "localhost" );

			var mongo = new Mongo( mongoConnectionStringBuilder.ToString() );
			mongo.Connect();

			var myDb = mongo.GetDatabase( "mydb" );

			questions = myDb[ "questions" ];
		}



		public IQuestion Insert( QuestionType questionType, string question )
		{
			var document = new Document
			               {
			               	{ "Question", question },
			               	{ "QuestionType", questionType }
			               };
			questions.Insert( document );
			return BuildQuestion( document );
		}



		public IQuestion GetById( string id )
		{
			return BuildQuestion( FindOne( id ) );
		}



		private Document FindOne( string id )
		{
			return questions.FindOne( new Document { { "_id", new Oid( id ) } } );
		}



		public IEnumerable<IQuestion> GetAll()
		{
			return ( from q in questions.AsQueryable().ToList()
			         select BuildQuestion( q )
			       ).Cast<IQuestion>();
		}



		public void Update( string id, QuestionType newQuestionType, string newQuestion )
		{
			Document oldQuestion = FindOne( id );
			oldQuestion[ "Question" ] = newQuestion;
			oldQuestion[ "QuestionType" ] = newQuestionType;

			questions.Update( oldQuestion );
		}



		private SimpleQuestion BuildQuestion( Document document )
		{
			return new SimpleQuestion( ( (Oid)document[ "_id" ] ).ToStringWithoutQuotesIn(), (QuestionType)document[ "QuestionType" ], (string)document[ "Question" ] );
		}
	}
}