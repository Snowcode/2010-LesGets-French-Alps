using System.Linq;
using System.Web.Mvc;
using MongoDB.Driver;
using MongoDB.Linq;
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
			return View( new EditQuestionViewModel() );
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
			return RedirectToAction( "Show", new { id = idWithoutQuotes } );
		}



		public ActionResult Show( string id )
		{
			var question = questions.FindOne( new Document { { "_id", new Oid( id ) } } );
			return View( new ViewQuestionViewModel( question ) );
		}



		public ActionResult List( string id )
		{
			return View( from question in questions.AsQueryable().ToList()
			             select new ViewQuestionViewModel( question ) );
		}



		public ActionResult Edit( string id )
		{
			var question = questions.FindOne( new Document { { "_id", new Oid( id ) } } );
			return View( new EditQuestionViewModel( question ) );
		}



		public ActionResult Save( string id, string question, QuestionType questionType )
		{
			Document oldQuestion = questions.FindOne( new Document { { "_id", new Oid( id ) } } );
			oldQuestion[ "Question" ] = question;
			oldQuestion[ "QuestionType" ] = questionType;

			questions.Update( oldQuestion );

			return RedirectToAction( "List" );
		}
	}
}