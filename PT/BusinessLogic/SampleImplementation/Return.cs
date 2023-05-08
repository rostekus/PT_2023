using DataAccess.API;

namespace BusinessLogic.SampleImplementation;

internal class Return : IReturn
{
    public string Guid { get; }
    public DateTime Time { get; }

    public IState State { get; }
    public IClient Client { get; }

    public Return(string guid, DateTime time, IState state, IClient client)
    {
        Guid = guid;
        Time = time;
        State = state;
        Client = client;
    }
}