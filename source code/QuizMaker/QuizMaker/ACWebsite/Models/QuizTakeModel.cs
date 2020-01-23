/******************************************************************
 * File Name:       QuizTakeModel.cs
 * Author:          Zachary Payne
 * Team Name:       Nymbus
 * Project Name:    Anti-Corruption Website
 * Version:         0.1
 * Version Date:    2019/04/11
 * Revised By:
 * Revision Date:
 * Models:          Score:int
 *                  MaxScore:int
 *****************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ACWebsite.Models
{
    public class QuizTakeModel
    {
        public User User { get; set; }
        public Quiz Quiz { get; set; }
        public List<Question> Questions { get; set; }
        public List<SubmittedAnswers> SubmittedAnswers { get; set; }

    }
}
