using System.ComponentModel.DataAnnotations;

namespace Demo4.Models
{
    public class Contact
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Por favor, digite o nome"), MaxLength(30)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Por favor, digite o telefone"), MaxLength(14)]
        public string Phone { get; set; }
    }
}
