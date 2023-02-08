using System.ComponentModel.DataAnnotations;

namespace food.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
    }
}
