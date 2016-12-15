using MathClubTracker.Domain;
using MathClubTracker.Domain.DomainObjects;
using MathClubTracker.Domain.Search;
using MathClubTracker.NHibernate.Services;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Newtonsoft.Json;
using MathClubTracker.Domain.DomainTransferObjects;
using System.Web;
using System.IO;

namespace MathClubTracker.Controllers
{
    public class StudentController : BaseController

    {
        private StudentService _studentService;
        //
        // GET: /Student/
        public StudentController()
        {
            _studentService =  new StudentService(MySession);
        }

        public ActionResult Index()
        {

            StudentService studentService = new StudentService(MySession);
            List<Student> students = studentService.GetStudents();
            return View();
        }

        public ActionResult Detail(int id)
        {
            StudentDTO student = _studentService.GetById(id);
            return View(student);
        }

        public bool GetAttended(int sessionId = 0)
        {
            if (sessionId == 0)
            {
                return false;
            }
            
            return true;
        }

        public IList<ClassSession> GetAllAttended(int id)
        {
            StudentDTO student = _studentService.GetById(id);
            return null;
        }

        [System.Web.Http.AcceptVerbs("GET", "POST")]
        public JsonResult GetAllStudents()
        {
            List<Student> students = _studentService.GetStudents();
            List<StudentDTO> dtos = BaseDomainObject.CopyList<StudentDTO, Student>(students);
            return Json(new { result = dtos, count = dtos.Count }, JsonRequestBehavior.AllowGet);
        }

        [System.Web.Http.AcceptVerbs("GET", "POST")]
        public JsonResult PagingGetStudents()
        {
            int skip = int.Parse(Request.QueryString["$skip"]);
            int top = int.Parse(Request.QueryString["$top"]);
            string orderby = Request.QueryString["$orderby"];
            int count = 0;
            List<Student> students = _studentService.GetStudents(skip, top, orderby, out count);
            List<StudentDTO> dtos = BaseDomainObject.CopyList<StudentDTO, Student>(students);
            return Json(new { result = dtos, count = count }, JsonRequestBehavior.AllowGet);
        }

        [System.Web.Http.AcceptVerbs("GET", "POST")]
        public JsonResult AddStudent(int? MathGeniusId, string LastName, string FirstName, string Sex, int? GraduationYear)
        {
            string sex = Sex == "Male" ? "M" : "F";
            ServiceResult result = FinalizeResult(_studentService.AddStudent(MathGeniusId, LastName, FirstName, sex , GraduationYear));
            return Json(new { result = result }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult UploadStudents()
        {
            ServiceResult result = new ServiceResult();
            foreach (string file in Request.Files)
            {
                MemoryStream target = new MemoryStream();
                Request.Files[file].InputStream.CopyTo(target);
                byte[] data = target.ToArray();
                string txt = System.Text.Encoding.UTF8.GetString(data);
                result.Merge(_studentService.ProcessUploadedStudentFile(txt));
            }
            return Json(FinalizeResult(result), JsonRequestBehavior.AllowGet);
        }

    }
}
