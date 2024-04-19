namespace WebApplicationFinal.Models
{
    using System.ComponentModel.DataAnnotations;

    public class BreakfastFood
    {
        [Key]
        public int Id { get; set; }
        public string FoodName { get; set; }
        public int Calories { get; set; }
        public bool IsVegan { get; set; }
    }

}
