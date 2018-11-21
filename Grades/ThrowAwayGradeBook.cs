using System;
// PolyMorphism - greek poly - many - morph - shapes
// Encapsulation is by far the most important of the three pillars of OOP
// System.Object - the ultimate base class that EVERYTHING inherits from

// It's the virtual keyword that gives us polymorphism

// Abstract classes cannot be instantiated - it is not fully "implemented."

namespace Grades
{
    public class ThrowAwayGradeBook : GradeBook
    {
        public override GradeStatistics ComputeStatistics()
        {

            Console.WriteLine("ThrowawayGradeBook::ComputeStatistics");

            float lowest = float.MaxValue;
            foreach(float grade in grades)
            {
                lowest = Math.Min(grade, lowest);
            }

            grades.Remove(lowest);

            return base.ComputeStatistics();
        }
    }
}

// Interface another way to achieve polymorphism, can never have implementation details
// defines only signatures of methods, events and properties
