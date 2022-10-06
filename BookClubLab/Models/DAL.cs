using Dapper.Contrib.Extensions;
using Dapper;
using MySql.Data.MySqlClient;

namespace BookClubLab.Models
{
    public class DAL
    {
        public static MySqlConnection DB = new MySqlConnection("Server=127.0.0.1;Database=bookclub;Uid=root;Pwd=ReasonsILoveYou;");

        public static List<Person> GetAllPeople()
        {
            return DB.GetAll<Person>().ToList();
        }

        public static Person GetOnePerson(int id)
        {
            return DB.Get<Person>(id);
        }

        public static Person InsertPerson(Person person)
        {
            DB.Insert<Person>(person);
            return person;
        }

        public static void DeletePerson(int id)
        {
            DB.Execute("delete from presentation where PersonId=@Id", new { Id = id });
            Person person = new Person();
            person.Id = id;
            DB.Delete<Person>(person);
        }

        public static void UpdatePerson(Person person)
        {
            DB.Update<Person>(person);
        }

        public static List<Presentation> GetPersonPresentations(int id)
        {
            return DB.GetAll<Presentation>().Where(x => x.PersonID == id).ToList();
        }

        // Presentation
        public static List<Presentation> GetAllPresentations()
        {
            return DB.GetAll<Presentation>().ToList();
        }

        public static Presentation GetOnePresentation(int id)
        {
            return DB.Get<Presentation>(id);
        }

        public static Presentation InsertPresentation(Presentation presentation)
        {
            DB.Insert<Presentation>(presentation);
            return presentation;
        }

        public static void DeletePresentation(int id)
        {
            Presentation presentation = new Presentation();
            presentation.Id = id;
            DB.Delete<Presentation>(presentation);
        }

        public static void UpdatePresentation(Presentation presentation)
        {
            DB.Update<Presentation>(presentation);
        }
    }
}
