using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Synthesis;

namespace Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            //SpeechSynthesizer synth = new SpeechSynthesizer();
            //synth.Speak("Hello! This is the grade book program.");

            
            GradeBook book = new GradeBook();

            //book.NameChanged += new NameChangedDelegate(OnNameChanged);
            book.NameChanged += OnNameChanged; //syntactic sugar

            //book.NameChanged = null; // only possible if NameChanged is a simple delegate but not an event


            book.Name = "Scott's Grade Book";
            book.Name = "Grade Book";

            book.AddGrade(91);
            book.AddGrade(89.5f);
            book.AddGrade(75);

            GradeStatistics stats = book.ComputeStatistics();
            Console.WriteLine(book.Name);
            WriteResult("Highest", stats.HighestGrade);
            WriteResult("Average", (int)stats.AverageGrade);
            WriteResult("Lowest", stats.LowestGrade);
            Console.ReadLine();




        }

        static void OnNameChanged(object sender, NameChangedEventArgs args)
        {
            Console.WriteLine($"Grade book changing name from {args.ExistingName} to {args.NewName}.");
        }

        static void WriteResult(string description, int result)
        {
            Console.WriteLine($"{description}: {result}");
        }

        static void WriteResult(string description, float result)
        {
            //F2 : floating point, 2 digits behind comma
            Console.WriteLine("{0}: {1:F2}", description, result);
        }
    }
}
