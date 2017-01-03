using MathClubTracker.Domain.DomainObjects;
using NHibernate;
using NHibernate.Transform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathClubTracker.NHibernate.Repository
{
    public class ClassRepository : NHibernateRepository<Class>, IClassRepository
    {
        public ClassRepository(ISession session) : base(session)
        {
        }

        public IList<Class> GetCurrentClasses()
        {
           var q = session.GetNamedQuery("CurrentClasses").SetResultTransformer(Transformers.AliasToBean<Class>());

            return q.List<Class>();

        }
    }
}
