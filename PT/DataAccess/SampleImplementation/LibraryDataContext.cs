using DataAccess.API;

namespace DataAccess.SampleImplementation;

public class LibraryDataContext : ILibraryDataContext
{
    public List<IClient> Clients { get; set; }
    public List<IBook> Books { get; set; }
    public List<ILibraryEvent> Events { get; set; }
    public List<IState> States { get; }
 
    public LibraryDataContext()
    {
        this.Clients = new List<IClient>();

        this.Books = new List<IBook>();

        this.States = new List<IState>();

        this.Events = new List<ILibraryEvent>();
    }


   
}

