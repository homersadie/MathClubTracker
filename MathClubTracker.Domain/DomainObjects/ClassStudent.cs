using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace MathClubTracker.Domain.DomainObjects {

    public class ClassStudent : BaseDomainObject {
    
        public ClassStudent() {
        
        }
        
        [Required]
        public virtual int Id { get; protected internal set;}
            

      
        public virtual Class MyClass { get; protected internal set;}

        public virtual Student MyStudent { get; protected internal set;}

        
        
        
        

        
    }
}







