using Microsoft.AspNetCore.Mvc;
using DapperLab.Models;

namespace DapperLab.Controllers
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
            if(person.First_Name == null || person.First_Name.Length <1)
            {
                TempData["FirstNameError"] = "*First name Required";
                isValid = false;
            }
            if (person.Last_Name == null || person.Last_Name.Length < 1)
            {
                TempData["LastNameError"] = "*Last name Required";
                isValid = false;
            }
            if (person.Email == null || !person.Email.Contains('@'))
            {
                TempData["EmailError"] = "*Email Required";
                isValid = false;
            }
            if(isValid == true)
            {
                DAL.InsertPerson(person);
                return Redirect("/Person");
            }
            else
            {
                return Redirect("/Person/AddForm");
            }
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
