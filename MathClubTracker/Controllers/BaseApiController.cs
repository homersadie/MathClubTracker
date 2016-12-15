using MathClubTracker.NHibernate;
using MathClubTracker.NHibernate.Services;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace MathClubWeb.Controllers
{
    public abstract class BaseApiController : ApiController
    {
        private NHibernateUnitOfWork MyUnitOfWork;
        protected ISession MySession;
        private IIdentityService _identityService;

        public BaseApiController()
        {
            MyUnitOfWork = (NHibernateUnitOfWork)MathClubTracker.MvcApplication.UnitOfWork;
            MySession = MyUnitOfWork.Session;
            _identityService = new IdentityService();
        }

    }
}
