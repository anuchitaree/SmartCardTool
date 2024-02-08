using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCardTool.Models
{
    public class ReturnError
    {
        [Required ] // TG116402-6680
        public string PartNoSubAssy { get; set; } = null;

        [Required]
        //public long LotId { get; set; }
        public string LotId { get; set; }


        [Required] // 2023-02-16T10:10:10
        public string Detail { get; set; } = null;

      
    }
}
