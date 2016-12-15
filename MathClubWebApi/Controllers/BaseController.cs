using MathClubTracker.NHibernate;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace MathClubWebApi.Controllers
{
    public class BaseController : ApiController
    {
        private NHibernateUnitOfWork MyUnitOfWork { get; set; }
        protected ISession MySession { get; set; }

        public BaseController()
        {
            MyUnitOfWork = (NHibernateUnitOfWork)MathClubWebApi.WebApiApplication.UnitOfWork;
            MySession = MyUnitOfWork.Session;


        }

    }
}
