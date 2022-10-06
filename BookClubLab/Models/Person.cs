using Dapper.Contrib.Extensions;

namespace BookClubLab.Models
{
    [Table("person")]
    public class Person
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

    }
}