namespace DataAccess.API;

public interface IRent : ILibraryEvent
{
    IState State { get; }
    IClient Client { get; }
    TimeSpan RentingTime { get; }
    
}