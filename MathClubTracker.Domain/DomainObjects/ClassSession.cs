using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace MathClubTracker.Domain.DomainObjects
{

    public class ClassSession : BaseDomainObject
    {

        public ClassSession()
        {

            MyClassSessionStudentBag = new List<ClassSessionStudent>();
        }

        [Required]
        public virtual int Id { get; protected internal set; }


        [Required]
        public virtual int LocationId { get; protected internal set; }

        [Required]
        public virtual System.DateTime SessionDate { get; protected internal set; }


        public virtual Class MyClass { get; protected internal set; }



        protected internal virtual IList<ClassSessionStudent> MyClassSessionStudentBag { get; set; }

        public virtual ReadOnlyCollection<ClassSessionStudent> MyClassSessionStudents
        {
            get { return new ReadOnlyCollection<ClassSessionStudent>(MyClassSessionStudentBag); }
        }






    }
}







