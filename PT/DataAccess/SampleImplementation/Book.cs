using DataAccess.API;

namespace DataAccess.SampleImplementation;

public class Book : IBook
{
    public string Title { get; set; }
    public string Author { get; set; }
    public string Guid { get; private set; }

    public Book(string title, string author, string guid)
    {
        Title = title;
        Author = author;
        Guid = guid;
    }
}
