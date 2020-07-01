using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Data.Model
{
    [DebuggerDisplay("{Product.Code} - {Qantity}")]
    public class Row
    {

        [Required]
        public int Id { get; set; }

        [Required]
        public int Qantity { get; set; }

        [Required]
        
        public virtual Product Product { get; set; }

        [Required]
        public virtual Cart Cart { get; set; }


        [Required]
        public DateTimeOffset CreatedDate { get; set; }

        //[Required]
        //public DateTimeOffset LastModifiedDate { get; set; }
    }
}
