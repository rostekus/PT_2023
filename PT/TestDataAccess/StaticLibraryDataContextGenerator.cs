using DataAccess.API;
using DataAccess.SampleImplementation;
using TestDataAccess;

namespace TestDataAccess;

public class StaticLibraryDataContextGenerator : IDataContextGenerator
{
    public LibraryDataContext Generate()
    {
        var libraryContext = new LibraryDataContext();
        libraryContext.Clients.Add(new Client("1", "Alice", "alice@example.com"));
        libraryContext.Clients.Add(new Client("2", "Bob", "bob@example.com"));
        libraryContext.Clients.Add(new Client("3", "Charlie", "charlie@example.com"));

        libraryContext.Books.Add(new Book("Harry Pother", "Rowling", "1"));
        libraryContext.Books.Add(new Book("The Lord of the Rings", "J.R.R. Tolkien", "2"));
        libraryContext.Books.Add(new Book("To Kill a Mockingbird", "Harper Lee", "3"));
        
        libraryContext.States.Add(new State("1","1", true));
        libraryContext.States.Add(new State("1","2", true));
        libraryContext.States.Add(new State("1","2", false));

        return libraryContext;
    }
}