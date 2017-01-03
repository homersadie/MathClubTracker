using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Query;
using System.Web.Http.OData.Routing;
using MathClubTracker.Domain.DomainObjects;
using Microsoft.Data.OData;
using MathClubTracker.NHibernate.Services;
using MathClubTracker.Domain.DomainTransferObjects;

namespace MathClubTracker.Controllers.WebApi
{

    public class StudentController : BaseODataController


    {
        private StudentService studentService;
        public StudentController()
        {
            studentService = new StudentService(MySession);
        }


        private static ODataValidationSettings _validationSettings = new ODataValidationSettings();

        // GET: odata/Student
        public IHttpActionResult GetStudent(ODataQueryOptions<Student> queryOptions)
        {
            // validate the query.
            try
            {
                queryOptions.Validate(_validationSettings);

                string filter = queryOptions.RawValues.Filter;
                int skip = 0;
                int top = 10;
                string orderby = queryOptions.OrderBy.RawValue;
                int count = 0;
                List<StudentDTO> studentList = StudentDTO.StudentsToDTO(studentService.GetStudents(filter, skip, top, orderby, out count));
                return Ok<IEnumerable<StudentDTO>>(studentList);
            }
            catch (ODataException ex)
            {
                return BadRequest(ex.Message);
            }

            
        }

        // GET: odata/Student(5)
        public IHttpActionResult GetStudent([FromODataUri] int key, ODataQueryOptions<Student> queryOptions)
        {
            // validate the query.
            try
            {
                queryOptions.Validate(_validationSettings);
            }
            catch (ODataException ex)
            {
                return BadRequest(ex.Message);
            }

            StudentDTO student = studentService.GetById(key);
            return Ok<StudentDTO>(student);

        }

        // PUT: odata/Student(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<Student> delta)
        {
            Validate(delta.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // TODO: Get the entity here.

            // delta.Put(student);

            // TODO: Save the patched entity.

            // return Updated(student);
            return StatusCode(HttpStatusCode.NotImplemented);
        }

        // POST: odata/Student
        public IHttpActionResult Post(Student student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // TODO: Add create logic here.

            // return Created(student);
            return StatusCode(HttpStatusCode.NotImplemented);
        }

        // PATCH: odata/Student(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<Student> delta)
        {
            Validate(delta.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // TODO: Get the entity here.

            // delta.Patch(student);

            // TODO: Save the patched entity.

            // return Updated(student);
            return StatusCode(HttpStatusCode.NotImplemented);
        }

        // DELETE: odata/Student(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            // TODO: Add delete logic here.

            // return StatusCode(HttpStatusCode.NoContent);
            return StatusCode(HttpStatusCode.NotImplemented);
        }
    }
}
