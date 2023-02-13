using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCardTool.Models
{
    public class Smartcard
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int Id { get; set; }


        [Required, StringLength(20)]
        public string Partnumber { get; set; } = null;


        [ StringLength(8)]
        public string Partname1 { get; set; } = null;

        [StringLength(8)]
        public string Partname2 { get; set; } = null;

        [StringLength(8)]
        public string Partname3 { get; set; } = null;


    }
}
