using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MathClubTracker.NHibernate;
using NHibernate;
using MathClubTracker.Domain;
using System.Collections.Generic;
using MathClubTracker.NHibernate.Services;
using MathClubTracker.Domain.Search;
using System.Linq;
using MathClubTracker.Domain.DomainObjects;
using MathClubTracker.Domain.DomainTransferObjects;

namespace MathClubTracker.Tests
{
    [TestClass]
    public class UnitTest1 : IDisposable
    {
        NHibernateUnitOfWork UnitOfWork;
        StudentService svc;

        [TestInitialize]
        public void SetUp()
        {
            UnitOfWork = new NHibernateUnitOfWork(NHibernateSessionProvider.SessionFactory.OpenSession());

            svc = new StudentService(UnitOfWork.Session);

        }

        [TestMethod]
        public void LoadDTO()
        {
            ICollection<Student> students = svc.GetStudents();
            List<StudentDTO> dto = StudentDTO.StudentsToDTO(students.ToList());
            Assert.IsTrue(dto.Any());
        }

        public void ResetUnitOfWork()
        {
            UnitOfWork.Save();
            SetUp();
        }


        [TestMethod]
        public void InsertStudent()
        {
            svc.InitializeData();
            ICollection<Student> students = svc.GetStudents();
            int beforeCount = students.Count;
            Student oldStudent = students.FirstOrDefault(x => x.LastName == "O'Donnell" && x.FirstName == "Danny");
            if (oldStudent != null)
            {
                svc.DeleteStudent(oldStudent.Id);
                ResetUnitOfWork();
            }

            string firstName = "Danny";
            string lastName = "O'Donnell";
            string gender = "M";
            int graduationYear = 1982;
            int mathGeniusId = 9991;
            svc.AddStudent(mathGeniusId, firstName, lastName, gender, graduationYear);
            ResetUnitOfWork();
            students = svc.GetStudents();
            int afterCount = students.Count;
            Assert.IsTrue(afterCount == beforeCount);
        }

        [TestMethod]
        public void UpdateStudent()
        {
            svc.InitializeData();
            ResetUnitOfWork();

            StudentSearchCriteria searchCriteria = new StudentSearchCriteria();
            searchCriteria.PartialName = "Gor";
            var students = svc.SearchStudents(searchCriteria);
            Student student = students.OrderBy(x => x.FirstName).First();
            int studentId = student.Id;
            string firstName = "Ben";
            string lastName = "Dover";
            string gender = "F";
            int graduationYear = 2013;
            svc.UpdateStudent(studentId, firstName, lastName, gender, graduationYear);

            ResetUnitOfWork();
            searchCriteria.PartialName = null;
            searchCriteria.Id = studentId;
            students = svc.SearchStudents(searchCriteria);
            student = students.OrderBy(x => x.FirstName).First();

            Assert.IsTrue(student.FirstName == firstName);
            Assert.IsTrue(student.LastName == lastName);
            Assert.IsTrue(student.Gender == gender);
            Assert.IsTrue(student.GraduationYear == graduationYear);


        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~UnitTest1() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            UnitOfWork.Dispose();
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
