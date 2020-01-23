using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ACWebsite.Models
{
    public class QuizViewModel
    {
        public User User { get; set; }
        public Quiz Quiz { get; set; }
        public List<Question> Questions { get; set; }
        //public List<Question> CandidateQuestions { get; set; }

        public List<AssignedQuizzes> assignedQuizzes { get; set; }
        public PaginatedList<Question> CandidateQuestions { get; set; }
    }
}
