using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ACWebsite.Models
{
    public class Ticket
    {
        [Column("id")]
        public int Ticketid
        {
            get;
            set;
        }

        [Column("name")]
        public string Name
        {
            get;
            set;
        }
    }
}
