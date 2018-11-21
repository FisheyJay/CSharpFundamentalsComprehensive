using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
// C# - always pass by value - reference by value, value type by value
// args are scoped to the receiving method. changes to object properties will be visible in the calling method
namespace Grades.Tests.Types
{
    [TestClass]
    public class TypeTests
    {

        [TestMethod]
        public void UsingArrays()
        {
            float[] grades;
            grades = new float[3];

            AddGrades(grades);
            Assert.AreEqual(89.1f, grades[1]);
        }

        private void AddGrades(float[] grades)
        {
            // grades = new float[5]; fail
            grades[1] = 89.1f;
        }


        [TestMethod]
        public void UpperCaseString()
        {
            string name = "scott";
            name.ToUpper();  // does nothing for us, wasted work
            // fail () versus pass (below)
            name = name.ToUpper();
            Assert.AreEqual("SCOTT", name);
        }



        [TestMethod]
        public void AddDaysToDateTime()
        {
            DateTime date = new DateTime(2015, 1, 1);
            date.AddDays(1); // does nothing for us, wasted work
            // fail () versus pass (below)
            date = date.AddDays(1);
            Assert.AreEqual(2, date.Day);
        }



        [TestMethod]
        public void ValueTypesPassByValue()
        {
            int x = 46;
            IncrementNumber(ref x);
            Assert.AreEqual(47,x);
        }

        private void IncrementNumber(ref int number)
        {
            // this won't change the value of x in the calling method
            number += 1;
        }

        [TestMethod]
        public void ReferenceTypesPassByValue()
        {
            GradeBook book1 = new GradeBook();
            GradeBook book2 = book1;

            GiveBookAName(ref book2);
            //Assert.AreEqual("A GradeBook", book2.Name);
            Assert.AreNotEqual("A GradeBook", book2.Name);

        }

        private void GiveBookAName(ref GradeBook book)
        {
            book = new GradeBook();
            book.Name = "A GradeBook";
        }

        [TestMethod]
        public void StringComparisons()
        {
            string name1 = "Scott";
            string name2 = "scott";

            bool result = String.Equals(name1, name2, StringComparison.InvariantCultureIgnoreCase);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IntVariablesHoldAValue()
        {
            int x1 = 100;
            int x2 = x1;

            x1 = 4;

            Assert.AreNotEqual(x1, x2);
        }

        [TestMethod]
        public void GradeBookVariablesHoldAReference()
        {
            GradeBook g1 = new GradeBook();
            GradeBook g2 = g1;

            g1 = new GradeBook();

            g1.Name = "Scott's grade book";
            //Assert.AreNotEqual(g1.Name, g2.Name);
            Assert.AreEqual(g1.Name, g2.Name);

            //g1.Name = "Bill's grade book";
            //Assert.AreEqual(g1.Name, g2.Name);
        }

        // structs are value types - int = Int32 = a struct




    }
}
