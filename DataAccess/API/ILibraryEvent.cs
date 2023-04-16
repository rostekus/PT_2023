namespace DataAccess.API;

public interface ILibraryEvent

{
    string Guid { get; }
    IState State { get; }
    IClient Client { get; }
    DateTime Time { get; }
}