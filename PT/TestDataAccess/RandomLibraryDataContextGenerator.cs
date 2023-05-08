using System;
using System.Linq;
using DataAccess.API;
using DataAccess.SampleImplementation;
using TestDataAccess;

namespace TestDataAccess;

internal class RandomLibraryDataContextGenerator : IDataContextGenerator
{
    private const int NumClients = 3;
    private const int NumBooks = 3;


    private readonly Random _random = new Random();

    public LibraryDataContext Generate()
    {
        var libraryContext = new LibraryDataContext();
        
        for (var i = 0; i < NumClients; i++)
        {
            libraryContext.Clients.Add(new Client(
                 (i + 1).ToString(),
                 GetRandomName(),
                 GetRandomEmail()));
        }
        
        for (var i = 0; i < NumBooks; i++)
        {
            string bookId = GetRandomClientId();
            libraryContext.Books.Add(bookId, new Book(
                GetRandomTitle(),
                GetRandomName(),
                bookId));

            libraryContext.States.Add(new State(
                GetRandomClientId(),
                bookId, GetRandomBool()
            ));
        }
        
        return libraryContext;
    }
    
    private string GetRandomName()
    {
        string[] firstNames = {"Alice", "Bob", "Charlie", "David", "Eve", "Frank"};
        string[] lastNames = {"Smith", "Johnson", "Williams", "Jones", "Brown", "Davis"};
        
        string firstName = firstNames[_random.Next(firstNames.Length)];
        string lastName = lastNames[_random.Next(lastNames.Length)];
        
        return $"{firstName} {lastName}";
    }
    
    private string GetRandomEmail()
    {
        string[] domains = {"gmail.com", "yahoo.com", "hotmail.com", "example.com"};
        string domain = domains[_random.Next(domains.Length)];
        
        return $"{GetRandomString()}@{domain}";
    }
    
    private string GetRandomTitle()
    {
        string[] titles = {"The Great Gatsby", "1984", "Pride and Prejudice", "The Catcher in the Rye"};
        
        return titles[_random.Next(titles.Length)];
    }
    
    private string GetRandomClientId()
    {
        Guid uuid = Guid.NewGuid();
        return uuid.ToString();
    }
    
    private string GetRandomString(int length = 8)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        
        return new string(Enumerable.Repeat(chars, length)
            .Select(s => s[_random.Next(s.Length)]).ToArray());
    }
    
    private bool GetRandomBool()
    {
        return _random.NextDouble() < 0.5;
    }
}
