using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathClubTracker.Domain.Search
{
    public class StudentSearchCriteria : SearchCriteria
    {
        public int? Id { get; set; }

        public int? MathGeniusId { get; set; }

        public int? GraduationYear { get; set; }


    }
}
