namespace DataAccess.API;

public interface IBorrow : ILibraryEvent
{
    IState State { get; }
    IClient Client { get; }
    TimeSpan RentingTime { get; }
    
}