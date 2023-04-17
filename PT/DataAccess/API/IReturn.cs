namespace DataAccess.API;

public interface IReturn : ILibraryEvent
{
    IState State { get; }
    IClient Client { get; }
}