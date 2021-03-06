using NHibernate.Impl;
using System;
using Microsoft.Pex.Framework;
using MathClubTracker.NHibernate;

namespace NHibernate.Impl
{
    /// <summary>A factory for NHibernate.Impl.SessionImpl instances</summary>
    public static partial class SessionImplFactory
    {
        /// <summary>A factory for NHibernate.Impl.SessionImpl instances</summary>
        [PexFactoryMethod(typeof(SessionImpl))]
        public static IDisposable Create()
        {
            var UnitOfWork = new NHibernateUnitOfWork(NHibernateSessionProvider.SessionFactory.OpenSession());
            Console.WriteLine("XXX");
            return UnitOfWork.Session;
            // TODO: Edit factory method of SessionImpl
            // This method should be able to configure the object in all possible ways.
            // Add as many parameters as needed,
            // and assign their values to each field by using the API.
        }
    }
}
