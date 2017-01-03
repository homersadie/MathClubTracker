using iText.IO.Source;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using MathClubTracker.Domain.DomainObjects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathClubTracker.NHibernate.Services
{
    public class ScannerService : BaseService
    {

        public void ProcessScanSheet(List<string> lines) 
        {

        }

        public void GradeTest(ScannedTest test, string resultDestination)
        {
            if (test.TestGradeType == ScannedTest.GradeType.DifficultyAdjusted)
            {
                test.CalculateDifficulties();
            }
            ByteArrayOutputStream baos = new ByteArrayOutputStream();
            var writer = new PdfWriter(baos);
            var pdf = new PdfDocument(writer);
            var document = new Document(pdf);
            int count = 2 + test.AnswerKey.Count();
            float[] widths = new float[count + 3];
            widths[0] = 8;
            widths[1] = 2;
            widths[count] = 3;
            widths[count + 1] = 3;
            widths[count + 2] = 3;
            for (int i = 2; i <= count - 1; i++)
            {
                widths[i] = 1;
            }

            Table scoreTable = new Table(widths);
            scoreTable.SetWidthPercent(100);
            scoreTable.AddCell(new Cell());
            scoreTable.AddCell(new Cell());
            for (int i = 1; i <= count - 2; i++)
            {
                scoreTable.AddCell(new Cell().Add(new Paragraph(i.ToString()).SetTextAlignment(TextAlignment.CENTER).SetFontSize(5)));
            }
            scoreTable.AddCell(new Cell().Add(new Paragraph("Correct")).SetFontSize(6).SetTextAlignment(TextAlignment.CENTER));
            scoreTable.AddCell(new Cell().Add(new Paragraph("Blank")).SetFontSize(6).SetTextAlignment(TextAlignment.CENTER));
            scoreTable.AddCell(new Cell().Add(new Paragraph("Score")).SetFontSize(6).SetTextAlignment(TextAlignment.CENTER));

            List<Table> Tables = new List<Table>();
            List<double> Scores = new List<double>();
            //string[] id = File.ReadAllLines(studentListFile);
            scoreTable.AddCell(new Cell().Add(new Paragraph("Answer Key").SetTextAlignment(TextAlignment.CENTER).SetFontSize(8)));
            scoreTable.AddCell(new Cell().Add(new Paragraph(" ")));

            for (int i = 0; i < test.AnswerKey.Count; i++)
            {
                scoreTable.AddCell(new Cell().Add(new Paragraph(test.AnswerKey[i]).SetTextAlignment(TextAlignment.CENTER).SetFontSize(8)));
            }
            for (int i = 0; i <= 2; i++) scoreTable.AddCell(new Cell().Add(new Paragraph(" ")));

            for (int i = 0; i < test.Students.Count(); i++)
            {
                Table pTable = new Table(widths);
                pTable.SetWidthPercent(100);
                int correct = 0;
                int blank = 0;
                double score = 0;

                pTable.AddCell(new Cell().Add(new Paragraph(test.Students[i].Id).SetFontSize(8).SetTextAlignment(TextAlignment.CENTER)));
                pTable.AddCell(new Cell().Add(new Paragraph(" ")).SetFontSize(8));
                /* comment id search
                foreach (string s in id)
                {
                    if (s.Split(',')[0].Equals(data[i, 0]))
                    {
                        pTable.AddCell(new Cell().Add(new Paragraph(s.Split(',')[1])).SetFontSize(8));
                        pTable.AddCell(new Cell().Add(new Paragraph(s.Split(',')[0])).SetFontSize(8));
                        output = s.Split(',')[1];
                        output += " ";
                        output += s.Split(',')[0];
                    }
                }
                */
                int question = 0;
                foreach (var answer in test.Students[i].Answers)
                {
                    if (answer.Equals(test.AnswerKey[question]))
                    {
                        pTable.AddCell(new Cell().Add(new Paragraph(answer.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(8).SetFontColor(iText.Kernel.Colors.WebColors.GetRGBColor("Green")));
                        correct += 1;
                        switch (test.TestGradeType)
                        {
                            case ScannedTest.GradeType.AMC:
                                score += 6;
                                break;
                            case ScannedTest.GradeType.MuAlphaTheta:
                                score += 4;
                                break;
                            case ScannedTest.GradeType.Raw:
                                score += 1;
                                break;
                            case ScannedTest.GradeType.DifficultyAdjusted:
                                score += test.Difficulties[question];
                                break;
                        }
                    }
                    else if (answer.Equals("_"))
                    {
                        pTable.AddCell(new Cell().Add(new Paragraph(answer.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(8).SetFontColor(iText.Kernel.Colors.WebColors.GetRGBColor("White")));
                        blank += 1;
                        switch (test.TestGradeType)
                        {
                            case ScannedTest.GradeType.AMC:
                                score += 1.5;
                                break;
                            case ScannedTest.GradeType.MuAlphaTheta:
                                score += 0;
                                break;
                            case ScannedTest.GradeType.Raw:
                                score += 0;
                                break;
                            case ScannedTest.GradeType.DifficultyAdjusted:
                                score += 0;
                                break;
                        }
                    }
                    else
                    {
                        switch (test.TestGradeType)
                        {
                            case ScannedTest.GradeType.AMC:
                                score += 0;
                                break;
                            case ScannedTest.GradeType.MuAlphaTheta:
                                score -= 1;
                                break;
                            case ScannedTest.GradeType.Raw:
                                score += 0;
                                break;
                            case ScannedTest.GradeType.DifficultyAdjusted:
                                score += 0;
                                break;
                        }
                        pTable.AddCell(new Cell().Add(new Paragraph(answer.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(8).SetFontColor(iText.Kernel.Colors.WebColors.GetRGBColor("Red")));
                    }
                    question++;
                }

                pTable.AddCell(new Cell().Add(new Paragraph(correct.ToString()).SetFontSize(8).SetTextAlignment(TextAlignment.CENTER)));
                pTable.AddCell(new Cell().Add(new Paragraph(blank.ToString()).SetTextAlignment(TextAlignment.CENTER).SetFontSize(8)));
                string formatString = "{0:#0}";
                switch (test.TestGradeType)
                {
                    case ScannedTest.GradeType.AMC:
                        formatString = "{0:##0.0}";
                        break;
                    case ScannedTest.GradeType.DifficultyAdjusted:
                        formatString = "{0:#0.00}";
                        break;
                }
                pTable.AddCell(new Cell().Add(new Paragraph(String.Format(formatString, score)).SetTextAlignment(TextAlignment.CENTER).SetFontSize(8)));
                Tables.Add(pTable);
                Scores.Add(score);
            }

            document.Add(scoreTable);
            while (Scores.Count() > 0)
            {
                int loc = Scores.IndexOf(Scores.Max());
                document.Add(Tables[loc]);
                Tables.RemoveAt(loc);
                Scores.RemoveAt(loc);
            }
            document.Close();
            File.WriteAllBytes(resultDestination, baos.ToArray());
            //Console.ReadLine();
        }
    }
}
