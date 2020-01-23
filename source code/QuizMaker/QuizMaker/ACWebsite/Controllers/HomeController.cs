/******************************************************************
 * File Name:       HomeController.cs
 * Author:          Jaeden Mailhot
 * Team Name:       Nymbus
 * Project Name:    Anti-Corruption Website
 * Version:         0.2
 * Version Date:    2019/03/18
 * Revised By:
 * Revision Date:
 * Methods:         Index()
 *                  NewQuestion()
 *                  CreateQuestion()
 *                  ViewMyQuestions()
 *                  Register()
 *                  RegisterAndRedirect
 *                  Login()
 *                  LoginAndRedirect()
 *                  LogoutAndRedirect()
 *****************************************************************/

using ACWebsite.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;

namespace ACWebsite.Controllers
{
    public class HomeController : Controller
    {
        private QuizDataContext _dataContext;

        public HomeController(QuizDataContext context)
        {
            _dataContext = context;
        }

        public IActionResult Index()
        {
            return View("SplashPage");
        }

        public IActionResult Main()
        {
            return View("Index");
        }


        /******************************************************************
        * Method Name: NewQuestion
        * Author: Jaeden Mailhot
        * Version: 1.0
        * Version Date: 2019/03/18
        * Revised By:
        * Revision Date:
        * Methods Calls:
        * Notes: 
        *****************************************************************/
        public IActionResult NewQuestion()
        {
            if (HttpContext.Session.GetString("name") == null)
            {
                return RedirectToAction("Login");
            }

            return View();
        }

        /******************************************************************
        * Method Name: CreateQuestion
        * Author: Jaeden Mailhot
        * Version: 1.1
        * Version Date: 2019/04/06
        * Revised By:
        * Revision Date:
        * Methods Calls:
        * Notes: 
        * Modified by Kishan Sondagar
        *****************************************************************/
        public IActionResult CreateQuestion(Question newQuestion)
        {
            var date = DateTime.Now;
            newQuestion.date_created = date.Date;

            if (newQuestion.type == 2)
            {
                newQuestion.answer_1 = "True";
                newQuestion.answer_2 = "False";
                newQuestion.answer_3 = null;
                newQuestion.answer_4 = null;
            }


            newQuestion.ticketid = 1;
            string questionFilter = HttpContext.Request.Form["question"];
            questionFilter = questionFilter.ToLower();
            var censorship = (from c in _dataContext.CensoredWords select c);

            foreach (var word in censorship)
            {
                newQuestion.ticketid = 2;
                break;
            }



            _dataContext.Questions.Add(newQuestion);
            _dataContext.SaveChanges();

            return RedirectToAction("ViewMyQuestions");
        }



        /******************************************************************
        * Method Name: CreateQuestion
        * Author: Jaeden Mailhot
        * Version: 1.1
        * Version Date: 2019/04/06
        * Revised By:
        * Revision Date:
        * Methods Calls:
        * Notes: 
        *****************************************************************/
        //public IActionResult CreateQuestion(Question newQuestion)
        //{
        //    var date = DateTime.Now;
        //    newQuestion.date_created = date.Date;

        //    if (newQuestion.type == 2)
        //    {
        //        newQuestion.answer_1 = "True";
        //        newQuestion.answer_2 = "False";
        //        newQuestion.answer_3 = null;
        //        newQuestion.answer_4 = null;
        //    }

        //    _dataContext.Questions.Add(newQuestion);
        //    _dataContext.SaveChanges();

        //    return RedirectToAction("ViewMyQuestions");
        //}





        /******************************************************************
        * Method Name: ViewMyQuestions
        * Author: Jaeden Mailhot
        * Version: 1.0
        * Version Date: 2019/03/18
        * Revised By:
        * Revision Date:
        * Methods Calls:
        * Notes: 
        *****************************************************************/
        public async Task<IActionResult> ViewMyQuestions(string sort, string search, string currentFilter, int? page)
        {
            if (HttpContext.Session.GetString("name") == null)
            {
                return RedirectToAction("Login");
            }

            ViewData["CurrentSort"] = sort;

            //var questions = from c in _dataContext.Questions select c;
            var questions = from c in _dataContext.Questions where c.userid == HttpContext.Session.GetInt32("UserId") select c;

            if (search != null)
            {
                page = 1;
            }
            else
            {
                search = currentFilter;
            }

            ViewData["CurrentFilter"] = search;

            if (!String.IsNullOrEmpty(search))
            {
                questions = questions.Where(c => c.question.Contains(search));
            }

            foreach (var question in questions)
            {
                question.User = (from c in _dataContext.Users where c.id == question.userid select c).FirstOrDefault();
            }

            switch (sort)
            {
                case "name":
                    questions = questions.OrderBy(c => c.question);
                    break;
                case "date":
                    questions = questions.OrderBy(c => c.date_created);
                    break;
                default:
                    break;
            }

            int pageSize = 10;
            int pageNumber = (page ?? 1);

            return View(await PaginatedList<Question>.CreateAsync(questions, page ?? 1, pageSize));
        }

        /******************************************************************
        * Method Name: BrowseQuestions
        * Author: Jaeden Mailhot
        * Version: 1.1
        * Version Date: 2019/03/25
        * Revised By:
        * Revision Date:
        * Methods Calls:
        * Notes: 
        *****************************************************************/
        public async Task<IActionResult> BrowseQuestions(string sort, string search, string currentFilter, int? page)
        {
            ViewData["CurrentSort"] = sort;

            var questions = from c in _dataContext.Questions select c;

            if (search != null)
            {
                page = 1;
            }
            else
            {
                search = currentFilter;
            }

            ViewData["CurrentFilter"] = search;

            if (!String.IsNullOrEmpty(search))
            {
                questions = questions.Where(c => c.question.Contains(search));
            }

            foreach (var question in questions)
            {
                question.User = (from c in _dataContext.Users where c.id == question.userid select c).FirstOrDefault();
            }

            switch (sort)
            {
                case "name":
                    questions = questions.OrderBy(c => c.question);
                    break;
                case "date":
                    questions = questions.OrderBy(c => c.date_created);
                    break;
                default:
                    break;
            }

            int pageSize = 10;
            int pageNumber = (page ?? 1);

            return View(await PaginatedList<Question>.CreateAsync(questions, page ?? 1, pageSize));
        }

        /******************************************************************
        * Method Name: BrowseQuizzes
        * Author: Jaeden Mailhot
        * Version: 1.0
        * Version Date: 2019/03/25
        * Revised By:
        * Revision Date:
        * Methods Calls:
        * Notes: 
        *****************************************************************/
        public async Task<IActionResult> BrowseQuizzes(string sort, string search, string currentFilter, int? page)
        {
            ViewData["CurrentSort"] = sort;

            var quizzes = from c in _dataContext.Quizzes select c;

            if (search != null)
            {
                page = 1;
            }
            else
            {
                search = currentFilter;
            }

            ViewData["CurrentFilter"] = search;

            if (!String.IsNullOrEmpty(search))
            {
                quizzes = quizzes.Where(c => c.title.Contains(search));
            }

            foreach (var quiz in quizzes)
            {
                quiz.User = (from c in _dataContext.Users where c.id == quiz.userid select c).FirstOrDefault();
            }

            switch (sort)
            {
                case "name":
                    quizzes = quizzes.OrderBy(c => c.title);
                    break;
                case "date":
                    quizzes = quizzes.OrderBy(c => c.created);
                    break;
                default:
                    break;
            }

            int pageSize = 10;
            int pageNumber = (page ?? 1);

            return View(await PaginatedList<Quiz>.CreateAsync(quizzes, page ?? 1, pageSize));
        }

        /******************************************************************
        * Method Name: CreateQuiz
        * Author: Jaeden Mailhot
        * Version: 1.0
        * Version Date: 2019/03/24
        * Revised By:
        * Revision Date:
        * Methods Calls:
        * Notes: 
        *****************************************************************/
        public IActionResult CreateQuiz()
        {
            if (HttpContext.Session.GetString("name") == null)
            {
                return RedirectToAction("Login");
            }

            return View();
        }

        /******************************************************************
        * Method Name: MakeQuiz
        * Author: Jaeden Mailhot
        * Version: 1.0
        * Version Date: 2019/03/24
        * Revised By:
        * Revision Date:
        * Methods Calls:
        * Notes: 
        *****************************************************************/
        public IActionResult MakeQuiz(Quiz quiz)
        {
            _dataContext.Quizzes.Add(quiz);
            _dataContext.SaveChanges();

            return RedirectToAction("Dashboard");
        }



        public IActionResult MakeQuizModal(Dashboard dashboard)
        {
            if (HttpContext.Session.GetInt32("UserId") == null)
            {
                return View("Login");
            }

            if (dashboard.suggestedIndustry != null)
            {
                var ind = new Industry();
                ind.name = dashboard.suggestedIndustry;
                ind.submitted_by = HttpContext.Session.GetInt32("UserId").Value;
                _dataContext.Industries.Add(ind);
            }
            _dataContext.Quizzes.Add(dashboard.createQuiz);
            _dataContext.SaveChanges();

            return RedirectToAction("Dashboard");
        }

        public IActionResult AssignQuizList(string match)
        {
            if (HttpContext.Session.GetInt32("UserId") == null)
            {
                return View("Login");
            }

            var model = (from c in _dataContext.Users where c.name.Contains(match) select new { c.id, c.name, c.email }).Take(5);

            return Json(model);
        }

        [HttpPost]
        public IActionResult AssignQuiz(int quiz_id, int assignee_id)
        {
            if (HttpContext.Session.GetInt32("UserId") == null)
            {
                return View("Login");
            }

            var assignQuiz = new AssignedQuizzes();
            assignQuiz.assignee_id = assignee_id;
            assignQuiz.quiz_id = quiz_id;

            _dataContext.assigned_quizzes.Add(assignQuiz);
            _dataContext.SaveChanges();

            return View("Index");
        }

        /******************************************************************
        * Method Name: ViewMyQuizzes
        * Author: Jaeden Mailhot
        * Version: 1.0
        * Version Date: 2019/03/24
        * Revised By:
        * Revision Date:
        * Methods Calls:
        * Notes: 
        *****************************************************************/
        public async Task<IActionResult> ViewMyQuizzes(string sort, string search, string currentFilter, int? page)
        {
            if (HttpContext.Session.GetString("name") == null)
            {
                return RedirectToAction("Login");
            }

            ViewData["CurrentSort"] = sort;

            var quizzes = from c in _dataContext.Quizzes where c.userid == HttpContext.Session.GetInt32("UserId") select c;

            if (search != null)
            {
                page = 1;
            }
            else
            {
                search = currentFilter;
            }

            ViewData["CurrentFilter"] = search;

            if (!String.IsNullOrEmpty(search))
            {
                quizzes = quizzes.Where(c => c.title.Contains(search));
            }
/*
            foreach (var quiz in quizzes)
            {
                quiz.User = (from c in _dataContext.Users where c.id == quiz.userid select c).FirstOrDefault();
            }
*/
            switch (sort)
            {
                case "name":
                    quizzes = quizzes.OrderBy(c => c.title);
                    break;
                case "date":
                    quizzes = quizzes.OrderBy(c => c.created);
                    break;
                default:
                    break;
            }

            int pageSize = 10;
            int pageNumber = (page ?? 1);

            return View(await PaginatedList<Quiz>.CreateAsync(quizzes, page ?? 1, pageSize));
        }



        public IActionResult Dashboard()
        {

            if (HttpContext.Session.GetString("UserId") == null)
            {
                return RedirectToAction("Login");
            }

            var dashboard = new Dashboard();
            dashboard.quizzes = (from c in _dataContext.Quizzes where c.userid == HttpContext.Session.GetInt32("UserId") select c).ToList();
            dashboard.quizIndustries = (from c in _dataContext.Industries where c.active == 1 select c).OrderBy(c=>c.name).ToList();

            return View(dashboard);
        }



        /******************************************************************
        * Method Name: ViewQuiz
        * Author: Jaeden Mailhot
        * Version: 1.0
        * Version Date: 2019/03/25
        * Revised By:
        * Revision Date:
        * Methods Calls:
        * Notes: 
        *****************************************************************/
        public async Task<IActionResult> ViewQuiz(int id, string sort, string search, string currentFilter, int? page)
        {
            var viewModel = new QuizViewModel();

            ViewData["CurrentSort"] = sort;
            ViewData["CurrentId"] = id;

            viewModel.Quiz = (from c in _dataContext.Quizzes where c.id == id select c).FirstOrDefault();
            viewModel.User = (from c in _dataContext.Users where c.id == viewModel.Quiz.userid select c).FirstOrDefault();
            viewModel.Questions = (from c in _dataContext.Junction where c.quizid == id select c.question).ToList();
            var candidates = from c in _dataContext.Questions select c;

            if (search != null)
            {
                page = 1;
            }
            else
            {
                search = currentFilter;
            }

            ViewData["CurrentFilter"] = search;

            if (!String.IsNullOrEmpty(search))
            {
                candidates = candidates.Where(c => c.question.Contains(search));
            }

            foreach (var question in candidates)
            {
                question.User = (from c in _dataContext.Users where c.id == question.userid select c).FirstOrDefault();
            }

            switch (sort)
            {
                case "name":
                    candidates = candidates.OrderBy(c => c.question);
                    break;
                case "date":
                    candidates = candidates.OrderBy(c => c.date_created);
                    break;
                default:
                    break;
            }

            int pageSize = 10;
            int pageNumber = (page ?? 1);

            viewModel.CandidateQuestions = await (PaginatedList<Question>.CreateAsync(candidates, page ?? 1, pageSize));
            return View(viewModel);
        }

        /******************************************************************
        * Method Name: QuizDetails
        * Author: Jaeden Mailhot
        * Version: 1.0
        * Version Date: 2019/03/25
        * Revised By:
        * Revision Date:
        * Methods Calls:
        * Notes: 
        *****************************************************************/
        public IActionResult QuizDetails(int id)
        {
            var viewModel = new QuizViewModel();

            viewModel.Quiz = (from c in _dataContext.Quizzes where c.id == id select c).FirstOrDefault();
            viewModel.User = (from c in _dataContext.Users where c.id == viewModel.Quiz.userid select c).FirstOrDefault();
            viewModel.Questions = (from c in _dataContext.Junction where c.quizid == id select c.question).ToList();

            return View(viewModel);
        }


        public IActionResult TakeQuiz(int id)
        { 
            if (HttpContext.Session.GetInt32("UserId") == null)
            {
                return View("Login");
            }

            var quizTake = new QuizTakeModel();

            quizTake.Quiz = (from c in _dataContext.Quizzes where c.id == id select c).FirstOrDefault();
//            quizTake.User = (from c in _dataContext.Users where c.id == quizTake.Quiz.userid select c).FirstOrDefault();
            quizTake.User = null;
 //           quizTake.Questions = null;
            quizTake.Questions = (from c in _dataContext.Junction where c.quizid == id select c.question).ToList();

            return View(quizTake);
        }


        [HttpPost]
        public IActionResult saveAnswer(int quiz_id, int question_id, String answr)
        {
            // Redirect user to Register page if not logged in
            if (HttpContext.Session.GetInt32("UserId") == null)
            {
                return View("Login");
            }

            var usrId = HttpContext.Session.GetInt32("UserId").Value;
            if (quiz_id==0 || question_id==0 || answr == null || usrId == 0)
            {
                return View("Error");
            }
            // Update already existing answer to the question
            if (_dataContext.SubmittedAnswers.Any(submition => submition.quiz_id == quiz_id && submition.question_id == question_id && submition.user_id == usrId))
            {
                var updateAnswer = (from e in _dataContext.SubmittedAnswers where e.quiz_id == quiz_id && e.question_id == question_id && e.user_id == usrId select e).FirstOrDefault();
                updateAnswer.answer = answr;
                var timestamp = DateTime.Now;
                updateAnswer.submitted_on = timestamp;
            }
            else
            // Save new answer to the question
            {
                var answer = new SubmittedAnswers();
                answer.quiz_id = quiz_id;
                answer.question_id = question_id;
                answer.user_id = usrId;
                answer.answer = answr;
                var timestamp = DateTime.Now;
                answer.submitted_on = timestamp;
                _dataContext.SubmittedAnswers.Add(answer);
            }
            _dataContext.SaveChanges();
            
            return View("Index");
        }
        // RUN FOR YOUR LIFE
        public IActionResult SubmitQuiz(int quizId)
        {
            // Redirect user to Register page if not logged in
            if (HttpContext.Session.GetInt32("UserId") == null)
            {
                return View("Login");
            }
            /*
            var submitQuiz = (from c in _dataContext.assigned_quizzes where c.quiz_id == quizId && c.assignee_id == HttpContext.Session.GetInt32("UserId").Value select c).First();
            if (submitQuiz.submitted == 1)
            {
                return View("Error");
            }
            submitQuiz.submitted = 1;
            submitQuiz.submitted_on = DateTime.Now;

            _dataContext.SaveChanges();
            */
            return View("Score");
        }

        /******************************************************************
        * Method Name: AddQuestion
        * Author: Jaeden Mailhot
        * Version: 1.0
        * Version Date: 2019/03/25
        * Revised By:
        * Revision Date:
        * Methods Calls:
        * Notes: 
        *****************************************************************/
        public IActionResult AddQuestion(int questionId, int quizId)
        {
            var count = _dataContext.Junction.Count(c => c.quizid == quizId && c.questionid == questionId);
            if (count == 0)
            {
                var qq = new QuizQuestion
                {
                    quizid = quizId,
                    questionid = questionId
                };

                _dataContext.Junction.Add(qq);
                _dataContext.SaveChanges();
            }

            return RedirectToAction("ViewQuiz", new { id = quizId });
        }

        /******************************************************************
        * Method Name: RemoveQuestion
        * Author: Jaeden Mailhot
        * Version: 1.0
        * Version Date: 2019/03/25
        * Revised By:
        * Revision Date:
        * Methods Calls:
        * Notes: 
        *****************************************************************/
        public IActionResult RemoveQuestion(int questionId, int quizId)
        {
            var qq = new QuizQuestion
            {
                quizid = quizId,
                questionid = questionId
            };

            _dataContext.Junction.Remove(qq);
            _dataContext.SaveChanges();

            return RedirectToAction("ViewQuiz", new { id = quizId });
        }

        public IActionResult Register()
        {
            if (HttpContext.Session.GetString("First") != null)
            {
                return RedirectToAction("Main");
            }

            return View();
        }

        /******************************************************************
        * Method Name: RegisterAndRedirect
        * Author:
        * Version: 1.0
        * Version Date: 2019/04/15
        * Revised By:
        * Revision Date:
        * Methods Calls:
        * Notes: 
        * Midified by Kishan Sondagar
        *****************************************************************/
        public IActionResult RegisterAndRedirect(User user, bool adminrequest = false)
        {
            if (_dataContext.Users.Any(info => info.email == user.email))
            {
                ViewBag.ErrorMessage = "Email Address already taken.";
                return View("Register");
            }

            if (adminrequest == true)
            {
                user.ticketid = 4;
            }
            else
            {
                user.ticketid = 3;
            }

            user.roleid = 1;

            _dataContext.Users.Add(user);
            _dataContext.SaveChanges();

            return RedirectToAction("Main");
        }





        /******************************************************************
        * Method Name: RemoveQuestion
        * Author: Jaeden Mailhot
        * Version: 1.0
        * Version Date: 2019/03/25
        * Revised By:
        * Revision Date:
        * Methods Calls:
        * Notes: 
        *****************************************************************/
        //public IActionResult RegisterAndRedirect(User user)
        //{
        //    if (_dataContext.Users.Any(info => info.email == user.email))
        //    {
        //        ViewBag.ErrorMessage = "Email Adress already taken.";
        //        return View("Register");
        //    }

        //    _dataContext.Users.Add(user);
        //    _dataContext.SaveChanges();

        //    return RedirectToAction("Main");
        //}






        public IActionResult Login()
        {
            return View();
        }

        public IActionResult LoginAndRedirect(User user)
        {
            if (_dataContext.Users.Any(info => info.email == user.email && info.password == user.password))
            {
                User dataUser = _dataContext.Users.Single(data => data.email == user.email);

                HttpContext.Session.SetString("name", dataUser.name);
                HttpContext.Session.SetString("Email", dataUser.email);
                HttpContext.Session.SetInt32("UserId", dataUser.id);
                HttpContext.Session.SetInt32("RoleId", dataUser.roleid);

                return RedirectToAction("Dashboard");
            }
            else
            {
                ViewBag.ErrorMessage = "Wrong Email Adress or Password.";
                return View("Login");
            }
        }

        public IActionResult LogoutAndRedirect()
        {
            HttpContext.Session.Clear();

            return RedirectToAction("Main");
        }

        public IActionResult SplashPage()
        {
            return View();
        }

        /******************************************************************
        * Method Name: EditUser
        * Author: Harsdeep
        * Version: 1.0
        * Version Date: 2019/03/25
        * Revised By:
        * Revision Date:
        * Methods Calls:
        * Notes: 
        * Midified by Ilya Kukhtiy
        *****************************************************************/

        public IActionResult EditUser()
        {
            if (HttpContext.Session.GetInt32("UserId") == null)
            {
                return RedirectToAction("Login");
            }

            var editUser = (from e in _dataContext.Users where e.id == HttpContext.Session.GetInt32("UserId") select e).FirstOrDefault();
            if (TempData.ContainsKey("profileUpdateResult"))
            {
                ViewBag.ErrorMessage = TempData["profileUpdateResult"].ToString();
            }
            return View(editUser);
        }


        /******************************************************************
        * Method Name: QuestionDetails
        * Author: Harsdeep
        * Version: 1.0
        * Version Date: 2019/04/14
        * Revised By:
        * Revision Date:
        * Methods Calls:
        * Notes: 
        *****************************************************************/
        public IActionResult QuestionDetails(int id)
        {
            Console.WriteLine(id);
            //Question_id++;
            var ques = (from c in _dataContext.Questions where c.id == id select c).FirstOrDefault();
            return View(ques);
        }


        /******************************************************************
        * Method Name: EditUserS
        * Author: Harsdeep
        * Version: 1.0
        * Version Date: 2019/03/25
        * Revised By:
        * Revision Date:
        * Methods Calls:
        * Notes: 
        * Midified by Ilya Kukhtiy
        *****************************************************************/
        public IActionResult EditUserS(User edit)
        {

            if (HttpContext.Session.GetInt32("UserId") == null)
            {
                return RedirectToAction("Main");
            }

            var userToEdit = (from e in _dataContext.Users where e.id == HttpContext.Session.GetInt32("UserId") select e).FirstOrDefault();

            userToEdit.name = edit.name;

            _dataContext.SaveChanges();

            HttpContext.Session.SetString("name", edit.name);

            return RedirectToAction("EditUser");
        }


        /******************************************************************
        * Method Name: ChangePassword
        * Author: Harsdeep
        * Version: 1.0
        * Version Date: 2019/04/14
        * Revised By:
        * Revision Date:
        * Methods Calls:
        * Notes: Modified by Ilya Kukhtiy
        *****************************************************************/
        public IActionResult ChangePassword(User edit)
        {
            if (HttpContext.Session.GetInt32("UserId") == null)
            {
                return RedirectToAction("Main");
            }

            var userToEdit = (from e in _dataContext.Users where e.id == HttpContext.Session.GetInt32("UserId") select e).FirstOrDefault();

            if (userToEdit.password != edit.password)
            {
                TempData["profileUpdateResult"] = "Current password is not correct";
                return RedirectToAction("EditUser");
            }

            if (edit.newPassword != edit.confirmPassword)
            {
                TempData["profileUpdateResult"] = "Passwords do not match";
                return RedirectToAction("EditUser");
            }

            //byte[] salt = new byte[128 / 8];
            //using (var rng = RandomNumberGenerator.Create())
            //{
            //    rng.GetBytes(salt);
            //}
            //userToEdit.password = Convert.ToBase64String(KeyDerivation.Pbkdf2(password: edit.newPassword, salt: salt, prf: KeyDerivationPrf.HMACSHA256, iterationCount: 10000, numBytesRequested: 256 / 8));
            userToEdit.password = edit.newPassword;
            _dataContext.SaveChanges();

            return RedirectToAction("EditUser");
        }

        public IActionResult ConfirmQuestions()
        {
            return View();
        }

        /******************************************************************
         * Method:          CheckAnswers():IActionResult
         * Author:          Zachary Payne
         * Team Name:       Nymbus
         * Project Name:    Anti-Corruption Website
         * Version:         0.1
         * Version Date:    2019/04/11
         * Revised By:
         * Revision Date:
         *****************************************************************/
        //public IActionResult CheckAnswers()
        //{
        //    int mark = 0;

        //    foreach (var item in quizviewmodel.questions)
        //    {
        //        var uanswer = convert.toint32(request.form[item.id]);
        //        if (uanswer == quizviewmodel.questions.answer) { mark++; }
        //    }

        //    var takequizmodel = new quiztakemodel();
        //    takequizmodel.score = mark;
        //    takequizmodel.maxscore = quizviewmodel.questions.count;

        //    return view("score", takequizmodel);
        //}



        public IActionResult CheckAnswers()
        {
            //int mark = 0;

            //foreach (var item in quizviewmodel.questions)
            //{
            //    var uanswer = convert.toint32(request.form[item.id]);
            //    if (uanswer == quizviewmodel.questions.answer) { mark++; }
            //}

            //var takequizmodel = new quiztakemodel();
            //takequizmodel.score = mark;
            //takequizmodel.maxscore = quizviewmodel.questions.count;

            //return view("score", takequizmodel);
            return View("Main");
        }


        /******************************************************************
        * Method Name: ViewTickets
        * Author: Kishan Sondagar
        * Version: 1.0
        * Version Date: 2019/04/15
        * Revised By:
        * Revision Date:
        * Methods Calls:
        * Notes: 
        *****************************************************************/
        public IActionResult ViewTickets()
        {

            var censorshipTickets = (from q in _dataContext.Questions where (q.ticketid == 2) select q);
            ViewData["censorshipTickets"] = censorshipTickets;

            var usertickets = (from u in _dataContext.Users where (u.ticketid == 4) select u);
            ViewData["ticketedUsers"] = usertickets;

            return View();
        }


        /******************************************************************
        * Method Name: ViewCensorshipList
        * Author: Kishan Sondagar
        * Version: 1.0
        * Version Date: 2019/04/15
        * Revised By:
        * Revision Date:
        * Methods Calls:
        * Notes: 
        *****************************************************************/
        public IActionResult ViewCensorshipList()
        {
            var censorship = (from word in _dataContext.CensoredWords select word);
            return View(censorship);

        }


        /******************************************************************
        * Method Name: AddCensorship
        * Author: Kishan Sondagar
        * Version: 1.0
        * Version Date: 2019/04/15
        * Revised By:
        * Revision Date:
        * Methods Calls:
        * Notes: 
        *****************************************************************/
        public IActionResult AddCensorship()
        {
            CensoredWord censorToAdd = new CensoredWord();
            censorToAdd.Word = HttpContext.Request.Form["censor"];

            _dataContext.CensoredWords.Add(censorToAdd);
            _dataContext.SaveChanges();

            return RedirectToAction("ViewCensorshipList");
        }


        /******************************************************************
        * Method Name: DeleteCensorship
        * Author: Kishan Sondagar
        * Version: 1.0
        * Version Date: 2019/04/15
        * Revised By:
        * Revision Date:
        * Methods Calls:
        * Notes: 
        *****************************************************************/
        public IActionResult DeleteCensorship(int id)
        {
            var censorToDelete = (from c in _dataContext.CensoredWords where c.id == id select c).FirstOrDefault();

            if (censorToDelete == null)
            {
                return RedirectToAction("ViewCensorshipList");
            }

            _dataContext.CensoredWords.Remove(censorToDelete);
            _dataContext.SaveChanges();
            return RedirectToAction("ViewCensorshipList");
        }



        /******************************************************************
        * Method Name: AdminEditUser
        * Author: Kishan Sondagar
        * Version: 1.0
        * Version Date: 2019/03/25
        * Revised By:
        * Revision Date:
        * Methods Calls:
        * Notes: 
        *****************************************************************/
        public IActionResult AdminEditUser()
        {
            if (HttpContext.Session.GetInt32("RoleId") == 1)
            {
                return RedirectToAction("Login");
            }

            var editUser = (from e in _dataContext.Users where e.id == HttpContext.Session.GetInt32("UserId") select e).FirstOrDefault();
            editUser.roleid = 2;
            editUser.ticketid = 3;

            _dataContext.SaveChanges();

            return RedirectToAction("ViewTickets");
        }



    }
}