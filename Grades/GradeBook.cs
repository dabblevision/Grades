using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    // the default access modifier is "internal"
    public class GradeBook
    {
        #region Fields
        List<float> grades; // private by default
        private string name = "Empty";
        public static float MinimumGrade = 0;
        public static float MaximumGrade = 100;
        public event NameChangedDelegate NameChanged;
        #endregion

        #region Constructors
        public GradeBook()
        {
            grades = new List<float>();
        }


        #endregion

        #region Properties
        public string Name
        {
            get { return name; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be null or empty.");
                }
                if (name != value && NameChanged != null)
                {
                    NameChangedEventArgs args = new NameChangedEventArgs();
                    args.ExistingName = name;
                    args.NewName = value;
                    NameChanged(this, args);                            
                }
                name = value;
            }
        }
        #endregion

        #region Methods
        public void AddGrade(float grade)
        {
            grades.Add(grade);
        }

        public GradeStatistics ComputeStatistics()
        {
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

        public void WriteGrades(TextWriter destination)
        {
            for (int i = 0; i < grades.Count; i++)
            {
                destination.WriteLine(grades[i]);
            }
        }

        #endregion
    }
}
