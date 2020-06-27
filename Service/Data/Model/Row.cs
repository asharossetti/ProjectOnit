using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Data.Model 
{ 
    public class Row
    {
        public Row()
        {
            Product = new Product();
        }

        [Required]
        public int Id { get; set; }

        [Required]
        public Product Product { get; set; }

        [Required]
        public Cart Cart { get; set; }


        [Required]
        public DateTimeOffset CreatedDate { get; set; }
    }
}
