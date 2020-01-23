using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ACWebsite.Models
{
    public class Dashboard
    {

        public List<Quiz> quizzes
        {
            get;
            set;
        }

        public Quiz createQuiz
        {
            get;
            set;
        }

        [StringLength(100)]
        public string suggestedIndustry
        {
            get;
            set;
        }

        public List<Industry> quizIndustries
        {
            get;
            set;
        }

    }
}
