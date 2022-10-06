using Microsoft.AspNetCore.Mvc;
using BookClubLab.Models;

namespace BookClubLab.Controllers
{
    public class PersonController : Controller
    {
        public IActionResult Index()
        {
            List<Person> people = DAL.GetAllPeople();
            return View(people);
        }

        public IActionResult AddForm()
        {
            return View();
        }

        public IActionResult Add(Person person)
        {
            bool isValid = true;
            if(person.FirstName == null || person.FirstName.Length == 0)
            {
                TempData["FirstNameError"] = "*First Name Required";
                isValid = false;
            }
            if(person.LastName == null || person.LastName.Length == 0)
            {
                TempData["LastNameError"] = "Last Name Required";
                isValid = false;
            }
            if(person.Email == null || person.Email.Length == 0 || !person.Email.Contains('@'))
            {
                TempData["EmailError"] = "*Email Required";
                isValid = false;
            }
            if(isValid == true)
            {
                DAL.InsertPerson(person);
                return Redirect("/person");
            }
            else
            {
                return Redirect("/person/addform");
            }
        }

        [HttpGet("/person/detail/{id}")]
        public IActionResult Detail(int id)
        {
            ViewBag.presentationCount = DAL.GetPersonPresentations(id).Count();
            Person person = DAL.GetOnePerson(id);
            return View(person);
        }

        public IActionResult ConfirmDelete(int id)
        {
            ViewBag.presentationCount = DAL.GetPersonPresentations(id).Count();
            Person person = DAL.GetOnePerson(id);
            return View(person);
        }

        public IActionResult Delete(int id)
        {
            DAL.DeletePerson(id);
            return Redirect("/person");
        }

        public IActionResult EditForm(int id)
        {
            Person person = DAL.GetOnePerson(id);
            return View(person);
        }

        public IActionResult SaveChanges(Person person)
        {
            DAL.UpdatePerson(person);
            return Redirect("/person");
        }
    }
}
