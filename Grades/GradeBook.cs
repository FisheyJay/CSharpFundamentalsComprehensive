using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

// Events and Delegates: a delegate is a type that references methods
// public delegate void Writer(string message);

// a delegate is basically a type safe function pointer

namespace Grades
{
    public class GradeBook : GradeTracker
    {
        // type ctor then tab twice
        public GradeBook()
        {
            _name = "Empty";
            grades = new List<float>();
        }

        //public bool ThrowAwayLowest

        public override GradeStatistics ComputeStatistics()
        {
            Console.WriteLine("GradeBook::ComputeStatistics");

            GradeStatistics stats = new GradeStatistics();

            float sum = 0;
            foreach(float grade in grades)
            {
                stats.LowestGrade = Math.Min(grade, stats.LowestGrade);
                stats.HighestGrade = Math.Max(grade, stats.HighestGrade);

                sum += grade;

            }

            stats.AverageGrade = sum / grades.Count;

            return stats;
        }

        // class method
        public override void AddGrade(float grade)
        {
            grades.Add(grade);
        }

        //public string Name { get; set; } // adding these explicitly changes nothing,
        // they are behind the scenes, auto implemented.
        // use this for validation mainly.

        // lets prevent a blank line by creating properties and making sure Name isnt set to null
        // must create field first

        public override IEnumerator GetEnumerator()
        {
            return grades.GetEnumerator();
        }

        protected List<float> grades;

        // properties are all about states!
        // methods are all about behavior!
        public override void WriteGrades(TextWriter destination)
        {
            //for (int i = 0; i < grades.Count; i++)
            for (int i = grades.Count; i > 0; i--)
            {
                //destination.WriteLine("---------->" + grades[i]);
                destination.WriteLine("---------->" + grades[i-1]);
            }
        }
    }
}
