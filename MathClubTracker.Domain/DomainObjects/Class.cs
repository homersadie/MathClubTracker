using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Linq;
using System.Text;

namespace MathClubTracker.Domain.DomainObjects {

    public class Class : BaseDomainObject {
    
        public Class() {
        
             MyClassStudentBag = new List<ClassStudent>();
        }
        
        [Required]
        public virtual int Id { get; protected internal set;}

        [Required]
        public virtual int Year { get; protected internal set; }

        [Required]
        public virtual int SemesterId { get; protected internal set;}

        [Required]
        [StringValidator(MinLength = 1, MaxLength = 50)]
        public virtual string Title { get; protected internal set;}

        public virtual int? CategoryId { get; protected internal set;}

        public virtual DateTime? BeginDate { get; protected internal set; }

        public virtual DateTime? EndDate { get; protected internal set; }

        public virtual int? LocationId { get; protected internal set; }

        public virtual string MeetingTime { get; protected internal set; }

        protected internal virtual IList<ClassStudent> MyClassStudentBag { get; set;}
             
        public virtual ReadOnlyCollection<ClassStudent> MyClassStudents {
           get { return new ReadOnlyCollection<ClassStudent>(MyClassStudentBag); }
        }
        
        
        
        

        
    }
}







