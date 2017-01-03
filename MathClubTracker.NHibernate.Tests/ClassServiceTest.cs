using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MathClubTracker.NHibernate.Services;
using NHibernate;
using MathClubTracker.Domain.DomainObjects;
using System.Collections.Generic;
using System.Linq;

namespace MathClubTracker.NHibernate.Tests
{
    [TestClass]
    public class ClassServiceTest
    {
        ClassService svc;

        public static ISessionFactory CreateSessionFactory()
        {
            return NHibernateSessionProvider.SessionFactory;
        }

        [TestInitialize]
        public void Init()
        {
            ISessionFactory _sessionFactory = CreateSessionFactory();
            svc = new ClassService(_sessionFactory.OpenSession());
        }
    
        [TestMethod]
        public void GetCurrentClasses()
        {
            List<Class> classes = svc.GetCurrentClasses().ToList();
            Assert.IsTrue(classes.Count > 0);
        }
    }
}
