using System;
using System.ComponentModel.DataAnnotations;

namespace Service.Data.Model
{
    public class Product
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
        public string Description { get; set; }

        public string Note { get; set; }

    }
}
