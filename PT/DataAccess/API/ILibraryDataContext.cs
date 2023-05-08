namespace DataAccess.API;

public interface ILibraryDataContext
{
    public List<IClient> Clients { get; set; }
    public Dictionary<string, IBook> Books { get; set; } 
    public List<ILibraryEvent> Events { get; set; }
    public List<IState> States { get; }
    
}