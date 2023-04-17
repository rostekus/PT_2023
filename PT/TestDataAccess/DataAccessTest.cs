using System;
using DataAccess.SampleImplementation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestDataAccess;

[TestClass]
public class DataAccessTest
{
    [TestMethod]
    public void TestIClientRepositoryGetById()
    {
    var testClient  = new Client("8fac4984-db53-11ed-afa1-0242ac120002", "Test Name", "Test Email");
    var clientRepository = new ClientRepository(new LibraryDataContext());
    clientRepository.Add(testClient);
    var clientFromRepository = clientRepository.GetById("8fac4984-db53-11ed-afa1-0242ac120002");

    Assert.IsTrue(object.Equals(testClient, clientFromRepository));
    }
    
    [TestMethod]
    public void TestIClientRepositoryGetAll()
    {
        var contextGenerator = new RandomLibraryDataContextGenerator();
        var clientRepository = new ClientRepository(contextGenerator.Generate());
        Assert.AreEqual(clientRepository.GetAll().Count, 3);
    }
    [TestMethod]
    public void TestBookRepositoryGetById()
    {
        var testBook = new Book("Test Title", "Test Author", "8fac4984-db53-11ed-afa1-0242ac120002");
        var bookRepository = new BookRepository(new LibraryDataContext());
        bookRepository.Add(testBook);
        
        var bookFromRepository = bookRepository.GetById("8fac4984-db53-11ed-afa1-0242ac120002");

        // Assert
        Assert.IsTrue(object.Equals(testBook, bookFromRepository));
    }
    
    [TestMethod]
    public void TestBookRepositoryGetAll()
    {
        var contextGenerator = new RandomLibraryDataContextGenerator();
        var bookRepository = new BookRepository(contextGenerator.Generate());

        var booksFromRepository = bookRepository.GetAll();

        Assert.AreEqual(booksFromRepository.Count, 3);
    }
    
    [TestMethod]
    public void TestStateRepositoryGetById()
    {
        // Arrange
        var testState = new State("8fac4984-db53-11ed-afa1-0242ac120002", "1", true);
        var stateRepository = new StateLibraryRepository(new LibraryDataContext());
        stateRepository.Add(testState);
        
        // Act
        var stateFromRepository = stateRepository.GetById("8fac4984-db53-11ed-afa1-0242ac120002");

        // Assert
        Assert.IsTrue(object.Equals(testState, stateFromRepository));
    }
    
    [TestMethod]
    public void TestStateRepositoryGetAll()
    {
        // Arrange
        var contextGenerator = new RandomLibraryDataContextGenerator();
        var stateRepository = new StateLibraryRepository(contextGenerator.Generate());

        // Act
        var statesFromRepository = stateRepository.GetAll();

        // Assert
        Assert.AreEqual(statesFromRepository.Count, 3);
    }
}