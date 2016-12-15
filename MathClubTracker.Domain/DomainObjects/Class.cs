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
        
             MyClassSessionBag = new List<ClassSession>();
        }
        
        [Required]
        public virtual int Id { get; protected internal set;}
            

        [Required]
        public virtual int SemesterId { get; protected internal set;}

        [Required]
        [StringValidator(MinLength = 1, MaxLength = 50)]
        public virtual string Title { get; protected internal set;}

        public virtual int? CategoryId { get; protected internal set;}

      
        
        
        protected internal virtual IList<ClassSession> MyClassSessionBag { get; set;}
             
        public virtual ReadOnlyCollection<ClassSession> MyClassSessions {
           get { return new ReadOnlyCollection<ClassSession>(MyClassSessionBag); }
        }
        
        
        
        

        
    }
}







