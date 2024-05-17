using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Xml.XPath;
using Microsoft.VisualBasic;
namespace Gradebook{
    public delegate void gradeAddedDelegate(object sender, EventArgs args);
    public abstract class Book: namedObject
    {
            public Book(string bookname): base(bookname)
            {
                
            }

            public abstract void AddGrade(double num);
        }
    public class namedObject{

        public namedObject(string name) 
        {
            bookName = name;
        }

        public string bookName{
            get;

            set;
        }

    }
    public class InMemoryBook:Book
    {

        public List<double> grades;

        private string bookname;
        
          public InMemoryBook(string bookname):base(bookname)
          {
            this.bookname = bookname;
            grades = new List<double>();
        }
         public void Test(){
            Console.WriteLine("This is a member of the book class");
        }

        public void addLetterGrade(char letter){
            switch(letter){
                case 'A':
                    AddGrade(90);
                    break;
                case 'B':
                    AddGrade(80);
                    break;
                case 'C':
                    AddGrade(70);
                    break;
                case 'D':
                    AddGrade(60);
                    break;
                case 'E':
                    AddGrade(50);
                    break;
                default:
                    AddGrade(0);
                    break;
            }
        }

        

        public override void AddGrade(double num){
            if(num <= 100 && num >= 0){
                grades.Add(num);
             }else{
                throw new ArgumentException($"Invalid {nameof(num)}");
             }
             if(gradeadded != null){
                gradeadded(this, new EventArgs());
             }
        }

        public event gradeAddedDelegate gradeadded;

         public Statistics getStats(){
                Statistics result = new Statistics();
            
                result.Average = 0.0;
                result.Max = double.MinValue;
                result.Min = double.MaxValue;

                var index = 0;
            
            do{
                result.Max = Math.Max(grades[index], result.Max);
                result.Min = Math.Min(grades[index], result.Min);
                result.Average = grades[index] + result.Average;

                index += 1;
            }while(index != grades.Count);
            result.Average = result.Average/grades.Count;

            switch(result.Average){
                case var d when d >= 90.0:
                result.letter = 'A';
                break;

                case var d when d >= 80.0:
                result.letter = 'B';
                break;

                case var d when d >= 70.0:
                result.letter = 'C';
                break;

                case var d when d >= 60.0:
                result.letter = 'D';
                break;

                default:
                result.letter = 'F';
                break;
            }

            return result;
            
            
        }

    }

}


