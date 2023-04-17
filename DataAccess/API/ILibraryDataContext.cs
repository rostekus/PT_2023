namespace DataAccess.API;

public interface ILibraryDataContext
{
    public IClientRepository Clients { get; }
    public IBookRepository Books { get; }
    public ILibraryEventRepository Events { get; }
    public IStateRepository States { get; }
    
    
}