using System;
using System.ComponentModel.DataAnnotations;

namespace MyMoney.Data.Model
{
    public class Purchase
    {
        [Key]
        public int PurchaseId { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public Decimal Value { get; set; }
        public string Description { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public Category Category { get; set; }
    }
}
