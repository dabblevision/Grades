using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Shouldly;
using Grades;

namespace Grades.Tests
{
    [TestFixture]
    public class GradeBookTests
    {
        [Test]
        public void ComputeStatisticsTest()
        {
            // arrange
            GradeBook book = new GradeBook();
            book.AddGrade(91);
            book.AddGrade(75);
            book.AddGrade(89.5f);
            // act
            GradeStatistics stats = book.ComputeStatistics();
            // assert
            stats.LowestGrade.ShouldBe(75);
            stats.HighestGrade.ShouldBe(91);
            stats.AverageGrade.ShouldBe(85.16666f, 0.005);
        }
    }
}
