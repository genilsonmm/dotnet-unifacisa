using System.ComponentModel.DataAnnotations;

namespace EFAppContact.WEB.Models
{
    public class Role
    {
        [Key]
        public int RoleId { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
