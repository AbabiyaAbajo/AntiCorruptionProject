using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ACWebsite.Models
{
    [Table("quizzes")]
    public class Quiz
    {
        [Key]
        [Column("id")]
        public int id { get; set; }
        /*
        public Quiz()
        {
            this.quizQuestions = new List<QuizQuestion>();
        }*/

        [Required]
        public int userid { get; set; }

        [ForeignKey("userid")]
        public User User
        {
            get;
            set;
        }

        [Column("title")]
        [Required]
        [StringLength(500)]
        public string title { get; set; }

        [Column("description")]
        [StringLength(255)]
        public string description { get; set; }


        [Required]
        public int industry_Id { get; set; }


        [Column("created")]
        [Required]
        [DataType(DataType.Date)]
        public DateTime created { get; set; } = DateTime.Now;

        [Column("edited_on")]
        [DataType(DataType.Date)]
        public DateTime edited_on { get; set; }

        public ICollection<QuizQuestion> quizQuestions { get; set; }
    }
}
