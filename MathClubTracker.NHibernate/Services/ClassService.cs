using MathClubTracker.Domain.DomainObjects;
using MathClubTracker.NHibernate.Repository;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathClubTracker.NHibernate.Services
{
    public class ClassService : BaseService
    {
        ISession MySession;
        IClassRepository classRepo;
        public ClassService(ISession session)
        {
            MySession = session;
            classRepo = new ClassRepository(session);
        }

        public IList<Class> GetCurrentClasses()
        {
            return classRepo.GetCurrentClasses();
        }
    }
}
