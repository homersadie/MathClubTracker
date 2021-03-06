//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Entity Developer tool using the template for generating Repositories and a Unit of Work for NHibernate model.
// Code is generated on: 10/6/2013 4:01:09 PM
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------
using System;
using System.Linq;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Linq;
using MathClubTracker.Domain;
using MathClubTracker.Domain.Search;
using NHibernate.Criterion;
using MathClubTracker.Domain.DomainObjects;
using NHibernate.Transform;
using MathClubTracker.Domain.DomainTransferObjects;
using System.Text.RegularExpressions;

namespace MathClubTracker.NHibernate
{
    public class StudentRepository : NHibernateRepository<Student>, IStudentRepository
    {
        public StudentRepository(ISession session) : base(session)
        {
        }

        ////public virtual ICollection<Student> GetAll()
        //{
        //    return session.CreateQuery(string.Format("from Student")).List<Student>();
        //}
        public IEnumerable<Student> GetPagedFromOData(string filter, int skip, int top, string orderby)
        {
            if (filter == null)
            {
                return new List<Student>();
            }

            if (orderby == "Name")
            {
                orderby = "LastName, FirstName";
            }
            string query = "select * from student ";

            string operation = "";
            string matchpattern = "";
            string casematch = "";
            string fieldName = "";
            Regex r = new Regex(@"(.*?)\(\'(.*?)\'\,(.*?)\((.*?)\)");
            var matches = r.Matches(filter);


            if (matches.Count > 0)
            {
                operation = matches[0].Groups[1].Value;
                matchpattern = matches[0].Groups[2].Value.Replace("'", "''");
                casematch = matches[0].Groups[3].Value;
                fieldName = matches[0].Groups[4].Value;
            } else
            {
                r = new Regex(@"(.*?)\((.*?)\((.*?)\)\,\'(.*?)\'\)");
                matches = r.Matches(filter);
                if (matches.Count > 0)
                {
                    operation = matches[0].Groups[1].Value;
                    casematch = matches[0].Groups[2].Value;
                    fieldName = matches[0].Groups[3].Value;
                    matchpattern = matches[0].Groups[4].Value.Replace("'", "''");
                }
            }


                string queryPartial = "";

                queryPartial = "where ";

                if (fieldName.Equals("Name"))
                {

                    queryPartial += "(lower(firstname)";
                    switch (operation)
                    {
                        case "substringof":
                            queryPartial += " like lower('%" + matchpattern + "%')";
                            break;
                        case "startswith":
                            queryPartial += " like lower('" + matchpattern + "%')";
                            break;
                    }
                    queryPartial += " or lower(lastname)";
                    switch (operation)
                    {
                        case "substringof":
                            queryPartial += " like lower('%" + matchpattern + "%')";
                            break;
                        case "startswith":
                            queryPartial += " like lower('" + matchpattern + " % ')";
                            break;
                }
                    queryPartial += ") ";
                    query += queryPartial;
                }
                else
                {
                    queryPartial += "lower(" + fieldName + ")";
                    switch (operation)
                    {
                        case "substringof":
                            queryPartial += " like lower('%" + matchpattern + "%')";
                            break;
                        case "startswith":
                            queryPartial += " like lower('" + matchpattern + " % ')";
                            break;
                }
                    query += queryPartial;
                }
            
            if (String.IsNullOrEmpty(orderby))
            {
                query += " order by lastname";
            }
            else
            {
                string orderbyquery = "";
                foreach (string s in orderby.Split(','))
                {
                    if (orderbyquery != "")
                    {
                        orderbyquery += ", ";
                    }
                    orderbyquery += s;
                }

                query += " order by " + orderbyquery;
            }
            query = query + String.Format(" offset {0} rows fetch next {1} rows only", skip, top);
            var q = session.CreateSQLQuery(query).SetResultTransformer(Transformers.AliasToBean(typeof(Student)));

            return q.List<Student>();
        }

        public virtual IEnumerable<Student> GetPaged(int skip, int top, string orderby)
        {
            string query = "select * from student ";
            if (orderby == "Name")
            {
                orderby = "LastName, FirstName";
            }
            if (String.IsNullOrEmpty(orderby))
            {
                query += " order by lastname";
            } else
            {
                string orderbyquery = "";
                foreach (string s in orderby.Split(','))
                {
                    if (orderbyquery != "")
                    {
                        orderbyquery += ", ";
                    }
                    orderbyquery += s;
                }

                query += "order by " + orderbyquery;
            }
            query = query + String.Format(" offset {0} rows fetch next {1} rows only", skip, top);
            var q = session.CreateSQLQuery(query).SetResultTransformer(Transformers.AliasToBean(typeof(Student)));

            return q.List<Student>();
        }

        

        public new void Insert(Student s)
        {
            session.Save(s);
        }

        public new void Remove(Student s)
        {
            session.Delete(s);
        }

        public List<Student> Search(StudentSearchCriteria criteria)
        {
            var students = session.QueryOver<Student>();
            if (!String.IsNullOrEmpty(criteria.PartialName))
            {
                string pn = String.Format("%{0}%", criteria.PartialName.Substring(0, Math.Min(50, criteria.PartialName.Length)));
                Disjunction disjunction = new Disjunction();

                disjunction.Add(Restrictions.On<Student>(e => e.FirstName).IsLike(pn));
                disjunction.Add(Restrictions.On<Student>(e => e.LastName).IsLike(pn));

                students = students.Where(disjunction);
            }

            if (criteria.Id.HasValue)
            {
                students = students.Where(x => x.Id == criteria.Id);
            }

            if (criteria.MathGeniusId.HasValue)
            {
                students = students.Where(x => x.MathGeniusId == criteria.MathGeniusId);
            }

            if (criteria.GraduationYear.HasValue)
            {
                students = students.Where(x => x.GraduationYear == criteria.GraduationYear);
            }

            return students.List<Student>().ToList();
        }

        public new void Update(Student s)
        {
            session.Update(s);
        }

        //public IList<Student> GetAttendeesByDate(DateTime sessionDate)
        //{
        //    IList<Class> classList = session.QueryOver<Class>().Where(x => x.BeginDate == sessionDate).List();
        //    IList<Student> students = new List<Student>();
        //    if (classList.Count > 0)
        //    {
        //        ClassStudent cs = classList.First();

        //        students = cs.MyStudents.Select(x=>x.MyStudent).ToList();
        //    }
        //    return students;
        //}

        public int GetStudentCount()
        {
            var query = session.CreateSQLQuery("Select count(*) from student");
            return (int)query.UniqueResult();
        }

        public Student GetByMathGeniusId(int id)
        {
            var students = session.QueryOver<Student>();
            students = students.Where(x => x.MathGeniusId == id);

            return students.List().FirstOrDefault();
        }

    }
}
