using DataAccess.API;

namespace DataAccess.SampleImplementation;

internal class State :IState
{
    public string Guid { get; private set; }
    public string BookId { get; set; }
    public bool Available { get; set; }

    public State(string guid, string book, bool available)
    {
        Guid = guid;
        BookId = book;
        Available = available;
    }
}