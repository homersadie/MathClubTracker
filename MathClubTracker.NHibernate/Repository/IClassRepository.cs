using MathClubTracker.Domain.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathClubTracker.NHibernate.Repository
{
    public partial interface IClassRepository : IRepository<Class>
    {
        IList<Class> GetCurrentClasses();
    }
}
