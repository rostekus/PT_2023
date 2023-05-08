using DataAccess.API;

namespace DataAccess.SampleImplementation;

internal class Borrow : IBorrow
{
    public Borrow(string guid, DateTime time, IState state, IClient client, TimeSpan rentingTime)
    {
        Guid = guid;
        Time = time;
        State = state;
        Client = client;
        RentingTime = rentingTime;
    }

    public string Guid { get; }
    public DateTime Time { get; }
    public IState State { get; }
    public IClient Client { get; }
    public TimeSpan RentingTime { get; }
}