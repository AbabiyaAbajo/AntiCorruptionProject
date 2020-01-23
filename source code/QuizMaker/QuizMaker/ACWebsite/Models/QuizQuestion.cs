using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ACWebsite.Models
{
    [Table("quizzes_questions")]
    public class QuizQuestion
    {
        [ForeignKey("quizid")]
        public int quizid { get; set; }

        public Quiz quiz
        {
            get;
            set;
        }
        
        [ForeignKey("questionid")]
        public int questionid { get; set; }

        public Question question
        {
            get;
            set;
        }
    }
}
