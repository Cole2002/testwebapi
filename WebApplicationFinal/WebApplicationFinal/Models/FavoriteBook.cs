namespace WebApplicationFinal.Models
{
    using System.ComponentModel.DataAnnotations;

    public class FavoriteBook
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int PublicationYear { get; set; }
        public string Genre { get; set; }
    }

}
