using System;
using System.Collections.Generic;
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

        public int Id { get; set; }
        public Product Product { get; set; }

        public Cart Cart { get; set; }
    }
}
