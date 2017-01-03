using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathClubTracker.Domain.DomainObjects
{
    public class ScannedTest
    {
        public enum GradeType { AMC, Raw, MuAlphaTheta, DifficultyAdjusted }


        public int Id { get; set; }
        public ScannedTest()
        {
            Students = new List<StudentScannedTest>();
            Difficulties = new List<double>();
            TestGradeType = GradeType.Raw;
        }

        public ScannedTest(string[] lines) : this()
        {
            LoadScanFile(lines, false);
        }

        public string Title { get; set; }

        public GradeType TestGradeType { get; set; }

        public DateTime TestDate { get; set; }
        public List<string> AnswerKey { get; set; }

        public List<double> Difficulties { get; set; }

        public List<StudentScannedTest> Students { get; set; }

        public void LoadScanFile(string[] lines, bool saveData)
        {
            try
            {
                if (lines.Count() > 0)
                {

                    int cnt = 0;
                    foreach (var line in lines)
                    {
                        if (cnt == 0)
                        {
                            AnswerKey = line.Replace(",BLANK", "").Split(',').ToList();
                            AnswerKey.RemoveAt(0);
                            AnswerKey.RemoveAt(0);
                        }
                        else
                        {
                            StudentScannedTest test = new StudentScannedTest();
                            List<string> Answers = line.Replace("BLANK", "_").Split(',').ToList();
                            test.Id = Answers[0];
                            Answers.RemoveAt(0);
                            Answers.RemoveAt(0);
                            test.Answers = Answers;
                            if (test.Answers.Count > AnswerKey.Count)
                            {
                                test.Answers.RemoveRange(AnswerKey.Count, test.Answers.Count - AnswerKey.Count);
                            }
                            test.Answers = test.Answers.Select(x => x.Length > 1 ? "*" : x).ToList();
                            Students.Add(test);
                        }
                        cnt++;
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        public void CalculateDifficulties()
        {
            int cnt = 0;
            double total = Students.Count;
            foreach (var ans in AnswerKey)
            {
                double numCorrect = 0;

                foreach (var student in Students)
                {
                    if (student.Answers[cnt] == ans)
                    {
                        numCorrect++;
                    }
                }

                Difficulties.Add(total == 0 ? 0 : 1.0 - (numCorrect / total));
                cnt++;
            }
        }

    }

    public class StudentScannedTest
    {
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public List<string> Answers { get; set; }
    }

}
