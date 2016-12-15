using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace MathClubTracker.Domain.DomainObjects {

    public class ClassSessionStudent : BaseDomainObject {
    
        public ClassSessionStudent() {
        
        }
        
        [Required]
        public virtual int Id { get; protected internal set;}
            

      
        public virtual ClassSession MyClassSession { get; protected internal set;}

        public virtual Student MyStudent { get; protected internal set;}

        
        
        
        

        
    }
}







