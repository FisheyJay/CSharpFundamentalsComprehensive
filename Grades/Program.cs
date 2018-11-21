using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Speech.Synthesis;
namespace Grades
{
    // classes are reference types
    class Program
    {
        // classes are the cookie cutters that form the dough into usable
        // cookie objects of a standard size and shape. Classes create the
        // OBJECTS we will use in the app.

        // invoking the constructor - new instance of gradebook
        //SpeechSynthesizer synth = new SpeechSynthesizer();
        //synth.Speak("Hello, this is the grade book program" );
        static void Main(string[] args)
        {
            IGradeTracker book = CreateGradeBook();

            //GetBookName(book);

            //book.Name = null; Unhandled Exception

            // FOR THE DELEGATE - we need to pass method that returns void and has 2 string parameters
            //book.NameChanged = new NameChangedDelegate(OnNameChanged); 
            // book.NameChanged = new NameChangedDelegate(OnNameChanged2);

            //book.NameChanged += new NameChangedDelegate(OnNameChanged);
            //book.NameChanged += new NameChangedDelegate(OnNameChanged2);
            //book.NameChanged += new NameChangedDelegate(OnNameChanged2);
            //book.NameChanged -= new NameChangedDelegate(OnNameChanged2);

            //book.NameChanged += OnNameChanged;
            //book.NameChanged += OnNameChanged2;
            //book.NameChanged += OnNameChanged2;

            // book.NameChanged = null; // not encapsulated enough because this would clear out all existing delegates
            // use an event to overcome this in GradeBook.cs public event NameChangedDelegate NameChanged;

            book.Name = "Scott's Grade Book";
            book.Name = "Scott's Grade ";
            //book.Name = "Scott's  ";
            //book.Name = "Scott's Grade Book";
            //book.Name = null;
            AddGrades(book);
            SaveGrades(book);

            //book.WriteGrades(Console.Out);

            WriteTheResults(book);

            // you CAN use return with a void method to bust out of a loop but don't return value 

            //GradeBook g1 = new GradeBook();
            //GradeBook g2 = g1;

            //g1 = new GradeBook();
            //g1.Name = "Scott's grade book";
            //Console.WriteLine(g2.Name);
        }

        private static IGradeTracker CreateGradeBook()
        {
            return new ThrowAwayGradeBook();
        }

        private static void WriteTheResults(IGradeTracker book)
        {
            GradeStatistics stats = book.ComputeStatistics();

            foreach (float grade in book)
            {
                Console.WriteLine(grade);
            }

            Console.WriteLine(book.Name);
            WriteResult("Average", stats.AverageGrade);
            WriteResult("Highest", (int)stats.HighestGrade);
            WriteResult("Lowest ", stats.LowestGrade);

            WriteResult("Grade", stats.LetterGrade);
            WriteResult(stats.Description, stats.LetterGrade);
        }

        private static void SaveGrades(IGradeTracker book)
        {
            using (StreamWriter outputFile = File.CreateText("grades.txt"))
            {
                book.WriteGrades(outputFile);
                //outputFile.Close();         no need with using has garbage disposal
                //outputFile.Dispose();
            }
        }

        private static void AddGrades(IGradeTracker book)
        {
            book.AddGrade(91);
            book.AddGrade(89.5f);
            book.AddGrade(75);
        }

        private static void GetBookName(IGradeTracker book)
        {
            try
            {
                Console.WriteLine("Please Enter a GradeBook Name.");
                book.Name = Console.ReadLine();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message + "   ---   " + ex.StackTrace);
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine("NullReferenceException   ---   " + ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            finally
            {
                Console.WriteLine("Finally, no matter what,... we will do some stuff.");
            }
        }

        // FOR THE DELEGATE - we need to pass method that returns void and has 2 string parameters
        static void OnNameChanged(object sender, NameChangedEventArgs args)
        {
            Console.WriteLine($"Gradebook changing name from {args.ExistingName} to {args.NewName}");
        }

        // FOR THE DELEGATE - we need to pass method that returns void and has 2 string parameters
        //static void OnNameChanged2(string existingName, string newName)
        //{
        //    Console.WriteLine("***");
        //}

        static void WriteResult(string description, string result)
        {
            Console.WriteLine(description + " " + result);
            Console.WriteLine("{0}: {1:C}", description, result); // currency format


        }

        static void WriteResult(string description, float result)
        {
            Console.WriteLine(description + " " + result);
            Console.WriteLine("{0}: {1:F2}", description, result);
            Console.WriteLine($"{description}: {result:F2}", description, result);  // String Interpolation
        }



    }
}
