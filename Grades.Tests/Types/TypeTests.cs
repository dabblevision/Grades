using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shouldly;


namespace Grades.Tests.Types
{
    [TestFixture]
    class TypeTests
    {
        [Test]
        public void UsingArrays()
        {
            float[] grades;
            grades = new float[3];

            AddGrades(grades);

            grades[1].ShouldBe(89.1f);
        }

        private void AddGrades(float[] grades)
        {
            grades[1] = 89.1f;
        }

        [Test]
        public void UppercaseString()
        {
            string name = "scott";
            name.ToUpper();
            name.ShouldNotBe("SCOTT");
            name = name.ToUpper();
            name.ShouldBe("SCOTT");
        }

        [Test]
        public void AddDaysToDaytime()
        {

            DateTime date = new DateTime(2015, 1, 1);
            date.AddDays(1);
            date.Day.ShouldNotBe(2);
            date = date.AddDays(1);
            date.Day.ShouldBe(2);
        }

        [Test]
        public void ValueTypesPassByValue()
        {
            int x = 46;
            IncrementNumber(x);

            x.ShouldBe(x); 
        }

        private void IncrementNumber(int x)
        {
            x += 1;
        }


        [Test]
        public void ReferenceTypesPassByValue()
        {
            GradeBook book1 = new GradeBook();
            GradeBook book2 = book1;

            GiveBookAName(book2);
            book1.Name.ShouldBe(book2.Name);
            
        }

        private void GiveBookAName(GradeBook book)
        {
            book.Name = "A Gradebook";
        }


        [Test]
        public void StringComparisons()
        {
            string name1 = "Scott";
            string name2 = "scott";

            //StringComparison is an enum!
            bool result = String.Equals(name1, name2, StringComparison.InvariantCultureIgnoreCase);
            result.ShouldBeTrue();
        }
        [Test]
        public void IntVariablesHoldAValue()
        {
            int x1 = 100;
            int x2 = x1;

            x1 = 4;

            x1.ShouldNotBe(x2);
        }

        [Test]
        public void GradeBookVariablesHoldAReference()
        {
            GradeBook g1 = new GradeBook();
            GradeBook g2 = g1;

            g1 = new GradeBook();
            g1.Name = "Scott's grade book";
            g1.Name.ShouldNotBe(g2.Name);
        }
    }
}
