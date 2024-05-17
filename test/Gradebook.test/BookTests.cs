namespace Gradebook.test;

using System.Collections.Concurrent;
using Xunit;
using Gradebook;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;

public class BookTests
{
    [Fact]
    public void Test1()
    {   //arrange
        int x = 10;
        int y = 10;

        //act
        int actual = x + y;
        int expected = 20;

        //assert
        Assert.Equal(actual, expected);
    }

    [Fact]
    public void Test2()
    {   //arrange
        InMemoryBook book = new Gradebook.InMemoryBook("tetsbook");

        //act
        book.AddGrade(50);
        book.AddGrade(50);
        double actual = 0.0;

        foreach(double grade in book.grades){
            actual = grade + actual;
        }

        double expected = 100;

        //assert
        Assert.Equal(actual, expected);
    }

    /* [Fact]
    public void Test3()
    {   //arrange
        Book book = new Gradebook.Book("tetsbook");

        //act
        book.AddGrade(60);
        book.AddGrade(50);
        double actual = 0.0;

        foreach(double grade in book.grades){
            actual = grade + actual;
        }

        double expected = 60;

        //assert
        Assert.Equal(actual, expected);
} */

     /*[Fact]

    /*public void bookCalculatesanAverageGrade()
    {   //arrange
        Book book = new Gradebook.Book("tetsbook");

        //act
        book.AddGrade(60);
        book.AddGrade(50);
        book.AddGrade(80);
        book.AddGrade(65);
        book.AddGrade(99);

        var result = book.getStats();

        //assert
        Assert.Equal(70.8, result.Average);
        Assert.Equal(99, result.Max);
        Assert.Equal(50, result.Min);
}*/

 [Fact]

    public void ValidationWorksonAddGradeMethod()
    {   //arrange
        InMemoryBook book = new InMemoryBook("testbook");
        book.AddGrade(69);
        Assert.Equal(69, book.grades[0]);
        
}

 [Fact]

    public void getstatsmethodreturnsstats()
    {  
        InMemoryBook book = new InMemoryBook("testbook");
        book.AddGrade(10);
        book.AddGrade(20);
        book.AddGrade(30);

        var testResults = book.getStats();
        var highNum = testResults.Max;
        var lowNum = testResults.Min;
        var avg = testResults.Average;

        Assert.Equal(30, highNum);
        Assert.Equal(10, lowNum);
        Assert.Equal(20, avg);
        


        
    }

    [Fact]

    public void Validationforaddgrade()
    {  
        InMemoryBook book = new InMemoryBook("testbook");
        book.AddGrade(100);

        Assert.Equal(100, book.grades[0]);    
    }

     [Fact]

    public void AddLetterGradeAddsCorrectGrade()
    {  
        InMemoryBook book = new InMemoryBook("testbook");
        book.addLetterGrade('G');

        Assert.Equal(0, book.grades[0]);    
    }

    [Fact]

    public void getStatsComputesCorrectLetterGrade()
    {  
        InMemoryBook book = new InMemoryBook("testbook");
        book.AddGrade(100);
        book.AddGrade(100);
        book.AddGrade(100);
        book.AddGrade(100);

        book.getStats();

        var result = book.getStats();


        Assert.Equal('A', result.letter);    
    }

    

}