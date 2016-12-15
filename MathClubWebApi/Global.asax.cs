using MathClubTracker.NHibernate;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MathClubWebApi
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        public static ISessionFactory CreateSessionFactory()
        {
            return NHibernateSessionProvider.SessionFactory;
        }

        public static IUnitOfWork UnitOfWork
        {
            get { return (IUnitOfWork)HttpContext.Current.Items["current.uow"]; }
            set { HttpContext.Current.Items["current.uow"] = value; }
        }

        protected WebApiApplication()
        {
            // This configures the unit or work to be on a per request basis.
            //
            BeginRequest += delegate
            {
                UnitOfWork = new NHibernateUnitOfWork(NHibernateSessionProvider.SessionFactory.OpenSession());
            };


            EndRequest += delegate
            {
                if (UnitOfWork != null)
                {
                    // Notice that we are rolling back unless
                    //    an explicit call to commit was made elsewhere.
                    //
                    UnitOfWork.Dispose();
                }
            };
        }
    }
}