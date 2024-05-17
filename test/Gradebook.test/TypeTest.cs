namespace Gradebook.test;

using System.Collections.Concurrent;
using Xunit;
using Gradebook;
using System.Runtime.CompilerServices;
using System;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using System.Security.Cryptography.X509Certificates;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;

public delegate string testDelegate(string message);
public class TypeTest
{   int count = 0;
    [Fact]
    public void delegatepointstoFunction(){

        testDelegate log = writeMessage;

        log += writeMessage;
        log += incrementCounter;

        var result = log("test");

        Assert.Equal(3, count);
    }
    string writeMessage(string message){
            count++;
            return message;
        }

    string incrementCounter(string message){
            count++;
            return message;
        }
        
     [Fact]
     public void valueTypesAlsoPassByValue(){

        var x = Getint();
        SetInt(ref x);
        Assert.Equal(42, x);
     }

    private void SetInt(ref int x)
    {
        x = 42;
    }

    private int Getint()
    {
        return 3;
    }

    [Fact]
     public void Csharpcanpassbyreference()
    {   //arrange
        //Book book = new Book("testbook");
       var book1 = new InMemoryBook("newbook");
        GetBookSetName(ref book1, "anotherbook");
       //act
     void GetBookSetName(ref InMemoryBook book, string name)
    {
        book = new InMemoryBook(name);
        book.bookName = name;
    }

        //assert
        Assert.Equal("anotherbook", book1.bookName);
    }
    
    
    
    
    [Fact]
     public void Csharpispassbyvalue()
    {   //arrange
        //Book book = new Book("testbook");
       var book1 = new InMemoryBook("newbook");
        GetBookSetName(book1, "anotherbook");
       //act
     void GetBookSetName(InMemoryBook book, string name)
    {
        book = new InMemoryBook(name);
    }

        //assert
        Assert.Equal("newbook", book1.bookName);
    }



    [Fact]
     public void changeNameMethodchangesbookname()
    {   //arrange
        //Book book = new Book("testbook");
       var book1 = GetBook("Book 1");
       changeName(book1, "newbook");
       //act
        InMemoryBook GetBook(string name)
    {
        return new InMemoryBook(name);
    }
        //assert
        Assert.Equal("newbook", book1.bookName);
    }

    private void changeName(InMemoryBook book1, string name)
    {
        book1.bookName = name;
    }

    [Fact]
     public void GetBookReturnsDifferentObjects()
    {   //arrange
        //Book book = new Book("testbook");
       var book1 = GetBook("Book 1");
       var book2 = GetBook("Book 2");

       InMemoryBook GetBook(string name)
    {
        return new InMemoryBook(name);
    }
        //act
    
        //assert
        /*Assert.Equal("Book 1", book1.bookName );
        Assert.Equal("Book 2", book2.bookName);*/
        Assert.NotSame(book1, book2);
    }

      [Fact]
     public void Twodifferentvariablescanreferencethesameobject()
    {   //arrange
        //Book book = new Book("testbook");
       var book1 = GetBook("Book 1");
       var book2 = book1;

       InMemoryBook GetBook(string name)
    {
        return new InMemoryBook(name);
    }
        //act
    
        //assert
        Assert.Same(book1, book2);
    }

     [Fact]
     public void StringsBehaveLikeValueTypes(){

        string name = "Scott";
        var upper = MakeUpperCase(name);

        Assert.Equal("SCOTT", upper);
        Assert.Equal("Scott", name);
     }

    private string MakeUpperCase(string name)
    {
        return name.ToUpper();
    }
}