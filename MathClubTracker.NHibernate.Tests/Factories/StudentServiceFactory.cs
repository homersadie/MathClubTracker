using NHibernate;
using MathClubTracker.NHibernate.Services;
using System;
using Microsoft.Pex.Framework;

namespace MathClubTracker.NHibernate.Services
{
    /// <summary>A factory for MathClubTracker.NHibernate.Services.StudentService instances</summary>
    public static partial class StudentServiceFactory
    {
        /// <summary>A factory for MathClubTracker.NHibernate.Services.StudentService instances</summary>
        [PexFactoryMethod(typeof(StudentService))]
        public static StudentService Create(ISession session_iSession)
        {
            //StudentService studentService = new StudentService(session_iSession);
            //return studentService;

            var UnitOfWork = new NHibernateUnitOfWork(NHibernateSessionProvider.SessionFactory.OpenSession());

            StudentService svc = new StudentService(UnitOfWork.Session);
            return svc;

            // TODO: Edit factory method of StudentService
            // This method should be able to configure the object in all possible ways.
            // Add as many parameters as needed,
            // and assign their values to each field by using the API.
        }
    }
}
