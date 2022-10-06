using Dapper.Contrib.Extensions;

namespace DapperLab.Models
{
    [Table("presentation")]
    public class Presentation
    {
        [Key]
        public int PresentationID { get; set; }
        public int PersonID { get; set; }
        public DateTime PresentationDate { get; set; }
        public string Title {get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
    }
}
