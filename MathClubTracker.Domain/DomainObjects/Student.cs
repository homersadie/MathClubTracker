using System;
using System.Collections;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Collections.ObjectModel;

namespace MathClubTracker.Domain.DomainObjects
{

    /// <summary>
    /// There are no comments for MathClubTracker.Student, DataTier in the schema.
    /// </summary>
    public partial class Student : BaseDomainObject {
    
        #region Extensibility Method Definitions
        
        /// <summary>
        /// There are no comments for OnCreated in the schema.
        /// </summary>
        partial void OnCreated();
        
        #endregion
        /// <summary>
        /// There are no comments for Student constructor in the schema.
        /// </summary>
        public Student()
        {
            OnCreated();
            this.MyClassSessionStudentBag = new List<ClassSessionStudent>();
        }

    
        /// <summary>
        /// There are no comments for Id in the schema.
        /// </summary>
        public virtual int Id
        {
            get;
            set;
        }

        [Required]
        [DisplayName("Math Genius Id")]
        public virtual int MathGeniusId { get; set; }


    
        [Required]
        [DisplayName("First Name")]
        public virtual string FirstName
        {
            get;
            set;
        }

    
        [Required]
        [DisplayName("Last Name")]
        public virtual string LastName
        {
            get;
            set;
        }

    
        [Required]
        [DisplayName("Sex")]
        public virtual string Gender
        {
            get;
            set;
        }

        [DisplayName("Graduation Year")]
        public virtual int? GraduationYear
        {
            get;
            set;
        }

        protected internal virtual IList<ClassSessionStudent> MyClassSessionStudentBag { get; set; }

        public virtual ReadOnlyCollection<ClassSessionStudent> MyClassSessionStudents
        {
            get { return new ReadOnlyCollection<ClassSessionStudent>(MyClassSessionStudentBag); }
        }



    }

}
