using Dapper.Contrib.Extensions;


namespace BookClubLab.Models
{
    [Table("presentation")]
    public class Presentation
    {
        [Key]
        public int Id { get; set; }
        public int PersonID { get; set; }
        public DateTime PresentationDate {get; set; }
        public string BookTitle { get; set; }
        public string BookAuthor { get; set; }
        public string Genre { get; set; }

    }
}
