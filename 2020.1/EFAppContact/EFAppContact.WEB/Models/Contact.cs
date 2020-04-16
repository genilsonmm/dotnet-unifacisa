using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFAppContact.WEB.Models
{
    public class Contact
    {
        public int Id { get; set; }
        [Column(TypeName ="varchar(60)")]
        [Required]
        public string Name { get; set; }
        public string Phone { get; set; }
    }
}
