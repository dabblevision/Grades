using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    // the default access modifier is "internal"
    public class GradeBook : GradeTracker
    {
        #region Fields
        protected List<float> grades; // only code in this class or a derived class can access this
        public static float MinimumGrade = 0;
        public static float MaximumGrade = 100;
        #endregion

        #region Constructors
        public GradeBook()
        {
            base.name = "Empty";
            grades = new List<float>();
        }


        #endregion

        #region Properties
        
        #endregion

        #region Methods
        public override void AddGrade(float grade)
        {
            grades.Add(grade);
        }

        public override GradeStatistics ComputeStatistics()
        {
            Console.WriteLine("GradeBook::ComputeStatics");
            GradeStatistics stats = new GradeStatistics();
            float sum = 0;

            foreach (float grade in grades)
            {
                stats.HighestGrade = Math.Max(grade, stats.HighestGrade);
                stats.LowestGrade = Math.Min(grade, stats.LowestGrade);
                sum += grade;
            }
            stats.AverageGrade = sum / grades.Count;

            return stats;
        }

        public override void WriteGrades(TextWriter destination)
        {
            for (int i = 0; i < grades.Count; i++)
            {
                destination.WriteLine(grades[i]);
            }
        }

        public override IEnumerator GetEnumerator()
        {
            return grades.GetEnumerator();
        }

        #endregion
    }
}
