using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ACWebsite.Models
{
    [Table("industries")]
    public class Industry
    {

        public int id { get; set; }


        [Required]
        [StringLength(100)]
        public string name { get; set; }


        public int active { get; set; }

        [Required]
        public int submitted_by { get; set; }


        [DataType(DataType.Date)]
        public DateTime submitted_on { get; set; }

        [Required]
        public int approved_by { get; set; }

        [DataType(DataType.Date)]
        public DateTime approved_on { get; set; }



    }
}
