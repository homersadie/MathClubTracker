using MathClubTracker.Domain;
using MathClubTracker.Domain.DomainObjects;
using MathClubTracker.Domain.DomainTransferObjects;
using MathClubTracker.Domain.Search;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathClubTracker.NHibernate.Services
{
    public class StudentService : BaseService
    {
        ISession MySession;
        IStudentRepository studentRepo;
        public StudentService(ISession session)
        {
            MySession = session;
            studentRepo = new StudentRepository(session);
        }

        public int GetStudentCount()
        {
            return studentRepo.GetStudentCount();
        }

        public List<Student> GetStudents()
        {
            List<Student> students = studentRepo.GetAll().ToList();
            return students;
            
        }

        public List<Student> GetStudents(int skip, int top, string orderby, out int count)
        {
            List<Student> students = studentRepo.GetPaged(skip, top, orderby).ToList();
            count = GetStudentCount();
            return students;
        }

        public ServiceResult AddStudent(int? mathGeniusId, string lastName, string firstName, string gender, int? graduationYear)
        {
            ServiceResult result = new ServiceResult();


            CheckNull("MathGeniusId", typeof(Student), mathGeniusId, result);
            CheckNull("LastName", typeof(Student), lastName, result);
            CheckNull("FirstName", typeof(Student), firstName, result);
            CheckNull("Sex", typeof(Student), gender, result);

            List<Student> students = SearchStudents(new StudentSearchCriteria { MathGeniusId = mathGeniusId });
            
            if (students.Any())
            {
                result.AddError("Students must have a unique Math Genius Id.");
            }
            if (!result.Success)
            {
                return result;
            }

            Student student = new Student()
            {
                MathGeniusId = (int)mathGeniusId,
                FirstName = firstName,
                LastName = lastName,
                GraduationYear = graduationYear,
                Gender = gender
            };

            Validate(student, result);

            studentRepo.Insert(student);

            return result;
        }



        public void InitializeData()
        {
            studentRepo.InitializeData();
        }

        public List<Student> SearchStudents(StudentSearchCriteria criteria)
        {
            return studentRepo.Search(criteria).ToList();
        }


        public void UpdateStudent(int id, string firstName, string lastName, string gender, int graduationYear)
        {
            Student oldStudent = studentRepo.Get(id);
            oldStudent.FirstName = firstName;
            oldStudent.LastName = lastName;
            oldStudent.Gender = gender;
            oldStudent.GraduationYear = graduationYear;
            studentRepo.Update(oldStudent);
        }

        public ServiceResult ProcessUploadedStudentFile(string txt)
        {
            ServiceResult result = new ServiceResult();
            string[] lines = txt.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            int cnt = 0;
            foreach (var line in lines)
            {
                cnt++;
                string[] dataLine = line.Split(new string[] { "," }, StringSplitOptions.None);
                if (dataLine.Length < 5)
                {
                    result.AddError(string.Format("Error on line {0} : {1}", cnt, "There are not five fields on this line."));
                }
                else
                {
                    try
                    {
                        ServiceResult r = AddStudent(int.Parse(dataLine[0]), dataLine[1], dataLine[2], dataLine[3], int.Parse(dataLine[4]));
                        if (!r.Success)
                        {
                            result.AddError(string.Format("Error on line {0} : {1}", cnt, r.Errors[0]));
                        }
                       
                    }
                    catch (Exception e)
                    {
                        result.AddError(string.Format("Error on line {0} : {1}", cnt, e.Message));
                    }
                }
            }
            return result;
        }

        public bool UpdateStudent(StudentDTO studentDTO)
        {
            Student student = studentRepo.Get(studentDTO.Id);
            student.FirstName = studentDTO.FirstName;
            student.LastName = studentDTO.LastName;
            student.Gender = studentDTO.Gender;
            student.GraduationYear = studentDTO.GraduationYear;
            studentRepo.Update(student);
            return true;
        }

        public StudentDTO GetByMathGeniusId(int id)
        {
            Student s = studentRepo.GetByMathGeniusId(id);
            if (s == null)
            {
                return null;
            }
            return StudentDTO.GetStudentDTOFromStudent(s);
        }

        public StudentDTO GetById(int id)
        {
            Student s = studentRepo.Get(id);
            if (s == null)
            {
                return null;
            }
            return StudentDTO.GetStudentDTOFromStudent(s);
        }

        public void DeleteStudent(int id)
        {
            Student student = studentRepo.Get(id);
            studentRepo.Remove(student);
        }

        public IList<Student> GetAttendeesByDate(DateTime sessionDate)
        {
            IList<Student> students = studentRepo.GetAttendeesByDate(sessionDate);
            return students;
        }

    }
}
