using BussinessLayer.Facades;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Mvc;

namespace WebApp.Controllers
{
    [Authorize]
    public class StudentController : Controller
    {
        StudentFacade facade = new StudentFacade();
        ExamFacade exams = new ExamFacade();

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ShowExams()
        {

            return View();
        }

        public IActionResult StartExam()
        {
            return View();
        }
        
    }
}
