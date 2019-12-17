using System;
using System.ComponentModel.DataAnnotations;

namespace AgendaApp.MODEL
{
    public class Contact
    {
        public Guid Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage ="Campo obrigatório!")]
        [Display(Name="Nome do contato")]
        public string Name { get; set; }

        public Contact()
        {
            this.Id = Guid.NewGuid();
        }
    }
}
