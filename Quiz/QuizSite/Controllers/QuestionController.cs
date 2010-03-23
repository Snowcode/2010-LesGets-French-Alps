using System.Web.Mvc;
using MongoDB.Driver;
using QuizSite.Models;


namespace QuizSite.Controllers
{
	public class QuestionController : Controller
	{
		private readonly IMongoCollection questions;



		public QuestionController()
		{
			var mongoConnectionStringBuilder = new MongoConnectionStringBuilder();
			mongoConnectionStringBuilder.AddServer( "localhost" );

			var mongo = new Mongo( mongoConnectionStringBuilder.ToString() );
			mongo.Connect();

			var myDb = mongo.GetDatabase( "mydb" );

			questions = myDb[ "questions" ];
		}



		public ActionResult Index()
		{
			return View();
		}



		public ActionResult New()
		{
			return View( new NewQuestionViewModel() );
		}



		public ActionResult Create( string question, QuestionType questionType )
		{
			var document = new Document
			               {
			               	{ "Question", question },
			               	{ "QuestionType", questionType }
			               };
			questions.Insert( document );


			var id = (Oid)document[ "_id" ];
			var idWithoutQuotes = id.ToStringWithoutQuotesIn();
			return RedirectToAction( "View", new { id = idWithoutQuotes } );
		}



		public ActionResult View( string id )
		{
			var question = questions.FindOne( new Document { { "_id", new Oid( id ) } } );
			return View( new ViewQuestionViewModel( question ) );
		}
	}
}