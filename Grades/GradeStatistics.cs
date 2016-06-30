using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    class GradeStatistics
    {

        #region Constructors
        public GradeStatistics()
        {
            HighestGrade = 0;
            LowestGrade = float.MaxValue;
        }
        #endregion

        public float AverageGrade;
        public float HighestGrade;
        public float LowestGrade;


    }

}
