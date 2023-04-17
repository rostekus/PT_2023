using DataAccess.API;

namespace DataAccess.SampleImplementation;

public class LibraryDataContext : ILibraryDataContext
{
    internal List<IBook> _Books;
    internal List<ILibraryEvent> _Events;
    internal List<IClient> _Clients;
    internal List<IState> _States;
    
    
    public LibraryDataContext()
    {
        this._Clients = new List<IClient>();

        this._Books = new List<IBook>();

        this._States = new List<IState>();

        this._Events = new List<ILibraryEvent>();
    }
    
    public IClientRepository Clients => new ClientRepository(this);
    public IBookRepository Books => new BookRepository(this);
    public ILibraryEventRepository Events => new LibraryEventRepository(this);
    public IStateRepository States => new StateLibraryRepository(this);

}

