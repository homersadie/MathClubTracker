using MathClubTracker.Domain.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathClubTracker.Domain.DomainTransferObjects
{
    public class ClassDTO : BaseDomainObject
    {
        public ClassDTO()
        {

            MyClassStudentBag = new List<ClassStudentDTO>();
        }

        public int Id { get; set; }

        public int SemesterId { get; set; }

        public string Title { get; set; }

        public int? CategoryId { get;  set; }

        protected internal IList<ClassStudentDTO> MyClassStudentBag { get; set; }

        public int Year { get; set; }

        public  int? LocationId { get; set; }
        
        public string MeetingTime { get; set; }

        public DateTime? BeginDate { get; set; }

        public DateTime? EndDate { get; set; }


        public static ClassDTO GetClassDTOFromClass(Class s)
        {
            ClassDTO dto =  Copy<ClassDTO, Class>(s);
            dto.MyClassStudentBag = new List<ClassStudentDTO>();
            foreach (var cs in s.MyClassStudentBag)
            {
                dto.MyClassStudentBag.Add(ClassStudentDTO.GetClassStudentDTOFromClassStudent(cs));
            }
            return dto;
        }

        public static List<ClassDTO> GetClassDTOListFromClassList(List<Class> list)
        {
            List<ClassDTO> classDTOList = new List<ClassDTO>();
            if (list == null)
            {
                return classDTOList;
            }
            foreach (var l in list)
            {
                classDTOList.Add(ClassDTO.GetClassDTOFromClass(l));
            }
            return classDTOList;
        }
    }
}
