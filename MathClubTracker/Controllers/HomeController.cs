using MathClubTracker.Domain;
using MathClubTracker.Domain.DomainObjects;
using MathClubTracker.Domain.Search;
using MathClubTracker.NHibernate;
using MathClubTracker.NHibernate.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MathClubTracker.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {

            StudentService studentService = new StudentService(MySession);
            List<Student> students = studentService.GetStudents();
            

            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        public ActionResult Scroller()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        //public ActionResult Students(string term)
        //{
        //    StudentService studentService = new StudentService(MySession);
        //    List<CodeValue> codeValueList = new List<CodeValue>();

        //    StudentSearchCriteria criteria = new StudentSearchCriteria();
        //    criteria.PartialName = term;
        //    List<Student> students = studentService.SearchStudents(criteria);

        //    List<StudentM> studentModels = MyModelFactory.CreateStudentList(students);
        //    return Json(studentModels);
        //}
    }

    public class CodeValue {

        public string item;
        public string value;
        public CodeValue(string _item, string _value) {
            item = _item;
            value = _value;

        }
    }
}

