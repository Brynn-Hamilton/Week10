using Dapper.Contrib.Extensions;


namespace BusinessCrudDemo.Models
{
    [Table("employee")]
    public class Employee
    {
        public int id { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string department { get; set; }
    }
}
