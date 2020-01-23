using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ACWebsite.Models
{
    [Table("submitted_answers")]
    public class SubmittedAnswers
    {

        [Key]
        [Column("id")]
        public int id { get; set; }

        [Column("quiz_id")]
        [Required]
        public int quiz_id { get; set; }

        [Column("question_id")]
        [Required]
        public int question_id { get; set; }

        [Column("user_id")]
        [Required]
        public int user_id { get; set; }

        [Column("answer")]
        [Required]
        [StringLength(500)]
        public string answer { get; set; }

        [Column("submitted_on")]
        [DataType(DataType.Date)]
        public DateTime submitted_on { get; set; }

    }
}
