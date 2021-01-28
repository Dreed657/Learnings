using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace P03_SalesDatabase.Data.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        public double Quantity { get; set; }

        public decimal Price { get; set; }

        [MaxLength(250)]
        public string Description { get; set; }

        public ICollection<Sale> Sales { get; set; }
    }
}
