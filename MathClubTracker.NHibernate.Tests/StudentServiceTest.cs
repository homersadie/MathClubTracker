// <copyright file="StudentServiceTest.cs">Copyright ©  2013</copyright>
using System;
using System.Collections.Generic;
using MathClubTracker.Domain.DomainObjects;
using MathClubTracker.Domain.DomainTransferObjects;
using MathClubTracker.Domain.Search;
using MathClubTracker.NHibernate.Services;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NHibernate;

namespace MathClubTracker.NHibernate.Services.Tests
{
    /// <summary>This class contains parameterized unit tests for StudentService</summary>
    [PexClass(typeof(StudentService))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class StudentServiceTest
    {
        /// <summary>Test stub for AddStudent(Nullable`1&lt;Int32&gt;, String, String, String, Nullable`1&lt;Int32&gt;)</summary>
        [PexMethod]
        public ServiceResult AddStudentTest(
            [PexAssumeUnderTest]StudentService target,
            int? mathGeniusId,
            string lastName,
            string firstName,
            string gender,
            int? graduationYear
        )
        {
            ServiceResult result = 
                                  target.AddStudent(mathGeniusId, lastName, firstName, gender, graduationYear);
            return result;
            // TODO: add assertions to method StudentServiceTest.AddStudentTest(StudentService, Nullable`1<Int32>, String, String, String, Nullable`1<Int32>)
        }

        /// <summary>Test stub for .ctor(ISession)</summary>
        [PexMethod]
        public StudentService ConstructorTest(ISession session)
        {
            StudentService target = new StudentService(session);
            return target;
            // TODO: add assertions to method StudentServiceTest.ConstructorTest(ISession)
        }

        /// <summary>Test stub for DeleteStudent(Int32)</summary>
        [PexMethod]
        public void DeleteStudentTest([PexAssumeUnderTest]StudentService target, int id)
        {
            target.DeleteStudent(id);
            // TODO: add assertions to method StudentServiceTest.DeleteStudentTest(StudentService, Int32)
        }

        ///// <summary>Test stub for GetAttendeesByDate(DateTime)</summary>
        //[PexMethod]
        //public IList<Student> GetAttendeesByDateTest([PexAssumeUnderTest]StudentService target, DateTime sessionDate)
        //{
        //    IList<Student> result = target.GetAttendeesByDate(sessionDate);
        //    return result;
        //    // TODO: add assertions to method StudentServiceTest.GetAttendeesByDateTest(StudentService, DateTime)
        //}

        /// <summary>Test stub for GetById(Int32)</summary>
        [PexMethod]
        public StudentDTO GetByIdTest([PexAssumeUnderTest]StudentService target, int id)
        {
            StudentDTO result = target.GetById(id);
            return result;
            // TODO: add assertions to method StudentServiceTest.GetByIdTest(StudentService, Int32)
        }

        /// <summary>Test stub for GetStudentCount()</summary>
        [PexMethod]
        public int GetStudentCountTest([PexAssumeUnderTest]StudentService target)
        {
            int result = target.GetStudentCount();
            return result;
            // TODO: add assertions to method StudentServiceTest.GetStudentCountTest(StudentService)
        }

        /// <summary>Test stub for GetStudents()</summary>
        [PexMethod]
        public List<Student> GetStudentsTest([PexAssumeUnderTest]StudentService target)
        {
            List<Student> result = target.GetStudents();
            return result;
            // TODO: add assertions to method StudentServiceTest.GetStudentsTest(StudentService)
        }

        /// <summary>Test stub for GetStudents(Int32, Int32, String, Int32&amp;)</summary>
        [PexMethod]
        public List<Student> GetStudentsTest01(
            [PexAssumeUnderTest]StudentService target,
            int skip,
            int top,
            string orderby,
            out int count
        )
        {
            List<Student> result = target.GetStudents(skip, top, orderby, out count);
            return result;
            // TODO: add assertions to method StudentServiceTest.GetStudentsTest01(StudentService, Int32, Int32, String, Int32&)
        }

        ///// <summary>Test stub for InitializeData()</summary>
        //[PexMethod]
        //public void InitializeDataTest([PexAssumeUnderTest]StudentService target)
        //{
        //    target.InitializeData();
        //    // TODO: add assertions to method StudentServiceTest.InitializeDataTest(StudentService)
        //}

        /// <summary>Test stub for ProcessUploadedStudentFile(String)</summary>
        [PexMethod]
        public ServiceResult ProcessUploadedStudentFileTest([PexAssumeUnderTest]StudentService target, string txt)
        {
            ServiceResult result = target.ProcessUploadedStudentFile(txt);
            return result;
            // TODO: add assertions to method StudentServiceTest.ProcessUploadedStudentFileTest(StudentService, String)
        }

        /// <summary>Test stub for SearchStudents(StudentSearchCriteria)</summary>
        [PexMethod]
        public List<Student> SearchStudentsTest(
            [PexAssumeUnderTest]StudentService target,
            StudentSearchCriteria criteria
        )
        {
            List<Student> result = target.SearchStudents(criteria);
            return result;
            // TODO: add assertions to method StudentServiceTest.SearchStudentsTest(StudentService, StudentSearchCriteria)
        }

        /// <summary>Test stub for UpdateStudent(Int32, String, String, String, Int32)</summary>
        [PexMethod]
        public void UpdateStudentTest(
            [PexAssumeUnderTest]StudentService target,
            int id,
            string firstName,
            string lastName,
            string gender,
            int graduationYear
        )
        {
            target.UpdateStudent(id, firstName, lastName, gender, graduationYear);
            // TODO: add assertions to method StudentServiceTest.UpdateStudentTest(StudentService, Int32, String, String, String, Int32)
        }

        /// <summary>Test stub for UpdateStudent(StudentDTO)</summary>
        [PexMethod]
        public bool UpdateStudentTest01(
            [PexAssumeUnderTest]StudentService target,
            StudentDTO studentDTO
        )
        {
            bool result = target.UpdateStudent(studentDTO);
            return result;
            // TODO: add assertions to method StudentServiceTest.UpdateStudentTest01(StudentService, StudentDTO)
        }
    }
}
