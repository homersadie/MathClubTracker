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
using MathClubTracker.NHibernate;
using NHibernate;

namespace MathClubTracker.Controllers.WebApi
{
    public class BaseODataController : ODataController
    {
        private NHibernateUnitOfWork MyUnitOfWork;
        protected ISession MySession;


        public BaseODataController()
        {
            MyUnitOfWork = (NHibernateUnitOfWork)MathClubTracker.MvcApplication.UnitOfWork;
            MySession = MyUnitOfWork.Session;


        }
    }
}