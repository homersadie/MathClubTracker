using AutoMapper;
using MathClubTracker.Domain.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathClubTracker.Domain.DomainTransferObjects
{
    public class StudentDTO : BaseDomainObject
    {

        public StudentDTO()
        {

        }

        public static StudentDTO GetStudentDTOFromStudent(Student s)
        {
            return Copy<StudentDTO, Student>(s);
        }


        public int Id { get; set; }

        public int MathGeniusId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Name {
            get
            {
                return String.Format("{0} {1}", FirstName, LastName);
            }
        }

        public string Gender { get; set; }

        public int? GraduationYear { get; set; }

        public static List<StudentDTO> StudentsToDTO(List<Student> students)
        {
            List<StudentDTO> list = new List<StudentDTO>();
            foreach (var s in students)
            {
                list.Add(Copy<StudentDTO, Student>(s));
            }
            return list;
        }

    }
}
