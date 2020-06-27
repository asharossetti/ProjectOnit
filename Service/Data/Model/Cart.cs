using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Service.Data.Model
{
    public class Cart
    {
        public Cart()
        {
            Rows = new List<Row>();
        }

        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public string SerialNumber { get; set; }

        public List<Row> Rows { get; set; }

        [Required]
        public DateTimeOffset CreatedDate {  get; set; }

        [Required]
        public StokPosition StokPosition { get; set; }

        [Required]
        public Location Location { get; set; }

        [NotMapped]
        public string Arrive { get { return  CreatedDate.ToString("YYYY")+"//"+Id ; } }
    }
}
