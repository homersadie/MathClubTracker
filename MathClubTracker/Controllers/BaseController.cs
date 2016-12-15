using MathClubTracker.NHibernate;
using MathClubTracker.NHibernate.Services;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MathClubTracker.Controllers
{
    public class BaseController : Controller
    {
        //
        // GET: /Base/
        private NHibernateUnitOfWork MyUnitOfWork;
        protected ISession MySession;

        public BaseController()
        {
            MyUnitOfWork = (NHibernateUnitOfWork) MathClubTracker.MvcApplication.UnitOfWork;
            MySession = MyUnitOfWork.Session;


        }

        public ServiceResult FinalizeResult(ServiceResult result)
        {
            try
            {
                MySession.Transaction.Commit();
            } catch (Exception e)
            {
                result.Errors.Add(e.Message.ToString());
            }

            return result;
        }

    }
}
