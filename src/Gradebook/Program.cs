using System.Collections.Concurrent;
using System.ComponentModel.Design;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace Gradebook{

    class Program{
            
                    static void Main(string[] args)
        {
            /* List<double> grades = new List<double>();
             grades.Add(90);
             grades.Add(75);
             grades.Add(100);
             grades.Add(60);
             grades.Add(88);
             double counter = 0;
             Console.WriteLine($"The highest grade is {grades.Max()}");
             Console.WriteLine($"The lowest grade is {grades.Min()}");
             double highGrade = double.MinValue;
             double lowGrade = double.MaxValue;
             foreach(float grade in grades){
                 highGrade = Math.Max(grade, highGrade);
                 lowGrade = Math.Min(grade, lowGrade);
                 counter = grade + counter;
             }
             System.Console.WriteLine($"The highest number is {highGrade}");
             System.Console.WriteLine($"The lowest number is {lowGrade}");

             double avg = counter/grades.Count();
             Console.WriteLine($"The average grade is {avg}");

             double x = 24.45;
             double y = 66.54;

             double sum = x + y;
             Console.WriteLine(sum);

             Console.WriteLine("---------------------------------------------------");
             double [] numbers = new double[3];
             numbers[0] = 12.7;
             numbers[1] = 55.7;
             numbers[2] = 88.25;

             double sum1 = 0;
             foreach(double number in numbers){
                 sum1 += number;
             }
             Console.WriteLine(sum1);

             Console.WriteLine("---------------------------------------------------");

             var grades1 = new List<double> {12.7, 10.3, 6.11, 4.1, 56.1};
             double sum2 = 0.0;
             foreach(double grade in grades1){
                 sum2 += grade;
             }
             double avg2 = sum2/grades1.Count;
             System.Console.WriteLine($"Average is {avg2:N1}");*/

            Console.WriteLine("---------------------------------------------------");
            InMemoryBook book = new InMemoryBook("Scott's Gradebook");
            book.gradeadded += onGradeAdded;

            enterGrades(book);
            
            var result = book.getStats();
            System.Console.WriteLine(book.bookName);
            System.Console.WriteLine($"The average grade is {result.Average:N1}");
            System.Console.WriteLine($"The high grade is {result.Max:N1}");
            System.Console.WriteLine($"The low grade is {result.Min:N1}");
            System.Console.WriteLine($"The letter grade is {result.letter}");
        }

        private static void enterGrades(InMemoryBook book)
        {
            while (true)
            {
                Console.WriteLine("Please enter a grade. Enter 'q to quit");
                var input = Console.ReadLine();

                if (input == "q")
                {
                    break;
                }
                try
                {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        static void onGradeAdded(object sender, EventArgs e){
                            Console.WriteLine("A grade has been added");
                        }

}

}
