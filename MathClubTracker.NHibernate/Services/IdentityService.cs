using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathClubTracker.NHibernate.Services
{
    public class IdentityService : MathClubTracker.NHibernate.Services.IIdentityService
    {
        public string CurrentUser { get; set; }
    }
}
