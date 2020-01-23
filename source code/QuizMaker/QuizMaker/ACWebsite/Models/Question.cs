using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ACWebsite.Models
{
    [Table("questions")]
    public class Question
    {
        [Column("id")]
        public int id { get; set; }

        [Required]
        public int userid { get; set; }

        [ForeignKey("userid")]
        public User User
        {
            get;
            set;
        }

        [Column("question")]
        [Required]
        [StringLength(500)]
        public string question { get; set; }

        [Column("answer_1")]
        [Required]
        [StringLength(500)]
        public string answer_1 { get; set; }

        [Column("answer_2")]
        [Required]
        [StringLength(500)]
        public string answer_2 { get; set; }

        [Column("answer_3")]
        [StringLength(500)]
        public string answer_3 { get; set; }

        [Column("answer_4")]
        [StringLength(500)]
        public string answer_4 { get; set; }

        [Column("answer")]
        [Required]
        public int answer { get; set; }

        [Column("type")]
        [Required]
        public int type { get; set; }

        [Column("date_created")]
        [Required]
        [DataType(DataType.Date)]
        public DateTime date_created { get; set; }

        [Column("link")]
        public string link { get; set; }

        public ICollection<QuizQuestion> quizQuestions { get; set; }

        [Column("ticketid")]
        public int ticketid
        {
            get;
            set;
        }
    }
}
