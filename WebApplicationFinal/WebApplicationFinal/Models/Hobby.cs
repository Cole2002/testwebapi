namespace WebApplicationFinal.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Hobby
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string DifficultyLevel { get; set; }
        public string PreferredTimeOfDay { get; set; }
    }

}
