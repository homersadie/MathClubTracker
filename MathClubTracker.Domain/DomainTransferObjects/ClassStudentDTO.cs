using MathClubTracker.Domain.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathClubTracker.Domain.DomainTransferObjects
{
    public class ClassStudentDTO : BaseDomainObject
    {
        public static ClassStudentDTO GetClassStudentDTOFromClassStudent(ClassStudent s)
        {
            return Copy<ClassStudentDTO, ClassStudent>(s);
        }
    }
}
