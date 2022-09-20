using System;
using System.ComponentModel.DataAnnotations;

namespace NetCore.Data.Model
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(150)]
        public string Name { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [Required]
        [Range(0, 999.99)]
        public decimal Price { get; set; }
    }
}
