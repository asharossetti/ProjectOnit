using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Data.Model
{
    [DebuggerDisplay("{Code}")]
    public class StokPosition
    {
        public int Id { get; set; }
        public string Code { get; set; }
    }
}
