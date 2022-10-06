using Dapper.Contrib.Extensions;

namespace DapperLab.Models
{
    [Table("person")]
    public class Person
    {
        [Key]
        public int Person_ID { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Email { get; set; }

    }
}
