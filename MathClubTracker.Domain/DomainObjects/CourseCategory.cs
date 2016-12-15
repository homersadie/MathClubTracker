using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Linq;
using System.Text;

namespace MathClubTracker.Domain.DomainObjects {

    public class CourseCategory : BaseDomainObject {
    
        public CourseCategory() {
        
        }
        
        [Required]
        public virtual int Id { get; protected internal set;}
            

        [Required]
        [StringValidator(MinLength = 1, MaxLength = 50)]
        public virtual string CategoryName { get; protected internal set;}

      
        
        
        
        

        
    }
}







