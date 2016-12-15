using MathClubTracker.Domain;
using MathClubTracker.Domain.Models;
using MathClubTracker.NHibernate.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace MathClubWebApi.Controllers
{
    public class StudentController : BaseController
    {
        //
        // GET: /Student/




        public IEnumerable<Student> GetAllStudents()
        {

            StudentService studentService = new StudentService(MySession);
            List<Student> students = studentService.GetStudents();
            return students;
        }

        public Student GetStudentById(int id)
        {
            StudentService studentService = new StudentService(MySession);

            Student student = studentService.GetById(id);
            if (student == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return student;
        }

        public HttpResponseMessage PostStudent(Student student)
        {
            StudentService studentService = new StudentService(MySession);
            studentService.InsertStudent(student);
            var response = Request.CreateResponse<Student>(HttpStatusCode.Created, student);

            string uri = Url.Link("DefaultApi", new { id = student.Id });
            response.Headers.Location = new Uri(uri);
            return response;
        }

        public void PutStudent(int id, StudentModel studentModel)
        {
            StudentService studentService = new StudentService(MySession);
            Student student = studentService.GetById(id);
            if (!studentService.UpdateStudent(student, studentModel))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        public void DeleteStudent(int id)
        {
            StudentService studentService = new StudentService(MySession);
            studentService.DeleteStudent(id);
        }

    }
}
