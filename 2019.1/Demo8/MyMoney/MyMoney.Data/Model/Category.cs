using System.ComponentModel.DataAnnotations;

namespace MyMoney.Data.Model
{
    public class Category
     {
        [Key]
        public int CategoryId { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
