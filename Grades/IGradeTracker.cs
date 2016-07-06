using System.Collections;
using System.IO;

namespace Grades
{
    internal interface IGradeTracker : IEnumerable
    {

        #region Properties
        string Name { get; set; }
        #endregion
        #region Methods
        void AddGrade(float grade);
        GradeStatistics ComputeStatistics();
        void WriteGrades(TextWriter destination);
        #endregion
    }
}