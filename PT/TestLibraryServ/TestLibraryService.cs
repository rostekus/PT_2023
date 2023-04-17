using BusinessLogic.SampleImplementation;
using DataAccess.API;
using DataAccess.SampleImplementation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace TestLibraryServ;

[TestClass]
public class TestLibraryService
{
    [TestMethod]
    public void RentAvailableBook()
    {
        var states = Substitute.For<IStateRepository>(); 
        var clients = Substitute.For<IClientRepository>();
        var books = Substitute.For<IBookRepository>();
        var events = Substitute.For<ILibraryEventRepository>();

        books.GetById("5b25789d-422a-4de7-adb3-d18a5143c8c4")
            .Returns(new Book("Test Book", "Test Author", "5b25789d-422a-4de7-adb3-d18a5143c8c4"));
        clients.GetById("8fac4984-db53-11ed-afa1-0242ac120002").Returns(new Client("8fac4984-db53-11ed-afa1-0242ac120002", "Test Name", "Test Email"));
        states.GetById("b1d90cf0-2633-497f-a065-bdb449854598").Returns(new State("b1d90cf0-2633-497f-a065-bdb449854598",
           "5b25789d-422a-4de7-adb3-d18a5143c8c4", true));
        var libraryService = new LibraryService(states, clients, books, events);
        libraryService.BorrowBook("8fac4984-db53-11ed-afa1-0242ac120002", "b1d90cf0-2633-497f-a065-bdb449854598");
    }
    
    
    [TestMethod]
    [ExpectedException(typeof(System.Exception),
        "Cannot borrow this book")]
    public void RentUnavailableBook()
    {
        var states = Substitute.For<IStateRepository>(); 
        var clients = Substitute.For<IClientRepository>();
        var books = Substitute.For<IBookRepository>();
        var events = Substitute.For<ILibraryEventRepository>();

        books.GetById("5b25789d-422a-4de7-adb3-d18a5143c8c4")
            .Returns(new Book("Test Book", "Test Author", "5b25789d-422a-4de7-adb3-d18a5143c8c4"));
        clients.GetById("8fac4984-db53-11ed-afa1-0242ac120002").Returns(new Client("8fac4984-db53-11ed-afa1-0242ac120002", "Test Name", "Test Email"));
        states.GetById("b1d90cf0-2633-497f-a065-bdb449854598").Returns(new State("b1d90cf0-2633-497f-a065-bdb449854598",
           "5b25789d-422a-4de7-adb3-d18a5143c8c4", false));
        var libraryService = new LibraryService(states, clients, books, events);
        libraryService.BorrowBook("8fac4984-db53-11ed-afa1-0242ac120002", "b1d90cf0-2633-497f-a065-bdb449854598");
    }
}