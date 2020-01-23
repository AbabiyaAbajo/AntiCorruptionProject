using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ACWebsite.Models
{
    [Table("CensoredWords")]
    public class CensoredWord
    {
        [Column("id")]
        public int id { get; set; }

        [Column("word")]
        public string Word
        {
            get;
            set;
        }
    }
}
