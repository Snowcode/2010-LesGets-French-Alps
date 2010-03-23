using System.Linq;
using System.Web.Mvc;
using MongoDB.Driver;
using QuizSite.Models;


namespace QuizSite.Controllers
{
	public class QuestionController : Controller
	{
		public QuestionController()
		{
			questions = new QuestionRepository();
		}



		public QuestionRepository questions { get; private set; }



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
			var newQuestion = questions.Insert( questionType, question );
			var id = newQuestion.Id;

			return RedirectToAction( "Show", new { id } );
		}



		public ActionResult Show( string id )
		{
			return View( new ViewQuestionViewModel( questions.GetById( id ) ) );
		}



		public ActionResult List( string id )
		{
			return View( from question in questions.GetAll()
			             select new ViewQuestionViewModel( question ) );
		}



		public ActionResult Edit( string id )
		{
			return View( new EditQuestionViewModel( questions.GetById( id ) ) );
		}



		public ActionResult Save( string id, string question, QuestionType questionType )
		{
			questions.Update( id, questionType, question );
			return RedirectToAction( "List" );
		}
	}
}