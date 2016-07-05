using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Synthesis;
using System.IO;

namespace Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            //SpeechSynthesizer synth = new SpeechSynthesizer();
            //synth.Speak("Hello! This is the grade book program.");


            GradeBook book = new GradeBook();
            GetBookName(book);
            AddGrades(book);
            SaveGrades(book);
            WriteResults(book);

            Console.ReadLine();
        }

        private static void WriteResults(GradeBook book)
        {
            GradeStatistics stats = book.ComputeStatistics();
            Console.WriteLine(book.Name);
            WriteResult("Highest", stats.HighestGrade);
            WriteResult("Average", stats.AverageGrade);
            WriteResult("Lowest", stats.LowestGrade);
            WriteResult(stats.Description, stats.LetterGrade);
        }

        private static void SaveGrades(GradeBook book)
        {
            //StreamWriter outputFile = File.CreateText("grades.txt");
            //book.WriteGrades(outputFile);
            //outputFile.Close();
            using (StreamWriter outputFile = File.CreateText("grades.txt"))
            {
                book.WriteGrades(outputFile);
            }
        }

        private static void AddGrades(GradeBook book)
        {
            book.AddGrade(91);
            book.AddGrade(89.5f);
            book.AddGrade(75);
        }

        private static void GetBookName(GradeBook book)
        {
            try
            {
                Console.WriteLine("Please enter a name for the Grade Book:");
                book.Name = Console.ReadLine();
            }
            catch (ArgumentException ex)
            {

                Console.WriteLine(ex.Message);
            }
        }

        static void WriteResult(string description, string result)
        {
            Console.WriteLine("{0}: {1}", description, result);
        }

        static void WriteResult(string description, float result)
        {
            //F2 : floating point, 2 digits behind comma
            Console.WriteLine("{0}: {1:F2}", description, result);
        }
    }
}
