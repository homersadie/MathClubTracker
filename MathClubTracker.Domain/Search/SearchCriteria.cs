using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathClubTracker.Domain.Search
{
    public abstract class SearchCriteria
    {
        public int PageSize { get; set; }
        public int PageNumber { get; set; }

        public string PartialName { get; set; }

        public bool UsePages { get; set; }

    }
}
