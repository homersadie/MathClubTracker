using MathClubTracker.Domain.DomainTransferObjects;
using MathClubTracker.NHibernate.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MathClubTracker.Controllers
{
    public class CodeController : BaseController
    {
        //
        // GET: /Code/

        public JsonResult GraduationYear()
        {
            List<int> years = new List<int>();
            for (int i = 2017; i <= 2027;i++)
            {
                years.Add(i);
            }
            return Json(years, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ClassSession()
        {
            ClassService svc = new ClassService(MySession);
            return Json(ClassDTO.GetClassDTOListFromClassList(svc.GetCurrentClasses().ToList()), JsonRequestBehavior.AllowGet);
        }

    }
}
