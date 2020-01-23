using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ACWebsite.Models
{
    [Table("assigned_quizzes")]
    public class AssignedQuizzes
    {
        [Column("id")]
        public int id { get; set; }


        [Column("quiz_id")]
        public int quiz_id { get; set; }


        [Column("assignee_id")]
        public int assignee_id { get; set; }

        [ForeignKey("assignee_id")]
        public User User
        {
            get;
            set;
        }

        [Column("submitted")]
        public int submitted { get; set; }


        [Column("assigned_on")]
        [DataType(DataType.Date)]
        public DateTime assigned_on { get; set; }


        [Column("submitted_on")]
        [DataType(DataType.Date)]
        public DateTime submitted_on { get; set; }
        /*
        [Required]
        public int userid { get; set; }

        [ForeignKey("userid")]
        public User User
        {
            get;
            set;
        }
        */

    }
}
