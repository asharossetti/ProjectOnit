using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Data.Model
{
    public class Cart
    {
        public Cart()
        {
            Rows = new List<Row>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string SerialNumber { get; set; }
        public List<Row> Rows { get; set; }

        public DateTimeOffset CreatedDate {  get; set; } 

        public string StokPosition { get; set; }

        public string Location { get; set; } 

        [NotMapped]
        public string Arrive { get { return  CreatedDate.ToString("YYYY")+"//"+Id ; } }
    }
}
