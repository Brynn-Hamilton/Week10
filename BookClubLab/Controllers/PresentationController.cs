using Microsoft.AspNetCore.Mvc;
using BookClubLab.Models;

namespace BookClubLab.Controllers
{
    public class PresentationController : Controller
    {
        public IActionResult Index()
        {
            List<Presentation> presentation = DAL.GetAllPresentations();
            return View(presentation);
        }

        public IActionResult AddForm()
        {
            List<Person> person = DAL.GetAllPeople();
            return View(person);
        }

        public IActionResult Add(Presentation presentation)
        {
            bool isValid = true;
            if(presentation.PresentationDate == null || presentation.PresentationDate < new DateTime(2012, 1, 1) || presentation.PresentationDate > DateTime.Now)
            {
                TempData["DateError"] = "*Please choose a date between 1/1/2012 and today";
                isValid = false;
            }
            if(presentation.BookTitle == null || presentation.BookTitle.Length == 0)
            {
                TempData["TitleError"] = "*Book Title Required";
                isValid = false;
            }
            if(presentation.BookAuthor == null || presentation.BookAuthor.Length == 0)
            {
                TempData["AuthorError"] = "*Book Author Required";
                isValid = false;
            }
            if(presentation.Genre == null || presentation.Genre.Length == 0)
            {
                TempData["GenreError"] = "*Genre Required";
                isValid = false;
            }
            if(isValid == true)
            {
                DAL.InsertPresentation(presentation);
                return Redirect("/presentation");
            }
            else
            {
                return Redirect("/presentation/addform");
            }
            
        }

        [HttpGet("/presentation/detail/{id}")]
        public IActionResult Detail(int id)
        {
            Presentation presentation = DAL.GetOnePresentation(id);
            ViewBag.Presenter = DAL.GetOnePerson(presentation.PersonID);
            return View(presentation);
        }

        public IActionResult Delete(int id)
        {
            DAL.DeletePresentation(id);
            return Redirect("/presentation");
        }

        public IActionResult EditForm(int id)
        {
            ViewBag.Presenter = DAL.GetAllPeople();
            Presentation presentation = DAL.GetOnePresentation(id);
            return View(presentation);
        }

        public IActionResult SaveChanges(Presentation presentation)
        {
            DAL.UpdatePresentation(presentation);
            return Redirect("/presentation");
        }
    }
}
