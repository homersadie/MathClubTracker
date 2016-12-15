using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathClubTracker.NHibernate.Services
{
    public class ServiceResult
    {
        private List<string> _errors;

        public List<string> Errors { get { return _errors; } }

        public ServiceResult()
        {
            _errors = new List<string>();
        }

        public bool Success
        {
            get
            {
                return !_errors.Any();
            }
        }


        public void AddError(string message)
        {
            _errors.Add(message);
        }

        public void Merge(ServiceResult merge)
        {
            foreach(var error in merge.Errors)
            {
                _errors.Add(error);
            }
        }
    }
}
