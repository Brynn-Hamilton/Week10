using MySql.Data.MySqlClient;
using Dapper;
using Dapper.Contrib.Extensions;

namespace DapperLab.Models
{
    public class DAL
    {
        public static MySqlConnection DB = new MySqlConnection("Server=127.0.0.1;Database=bookclub;Uid=root;Pwd=ReasonsILoveYou;");

        // CRUD operations for person table
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
            Person person = new Person();
            person.Person_ID = id;
            DB.Delete<Person>(person);
        }

        public static void UpdatePerson(Person person)
        {
            DB.Update<Person>(person);
        }

        // CRUD operations for presentation table

        public static List<Presentation> GetAllPresentation()
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
            presentation.PresentationID = id;
            DB.Delete<Presentation>(presentation);
        }

        public static void UpdatePresentation(Presentation presentation)
        {
            DB.Update<Presentation>(presentation);
        }
    }


}
