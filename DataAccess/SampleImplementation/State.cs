using DataAccess.API;

namespace DataAccess.SampleImplementation;

public class State :IState
{
    public string Guid { get; private set; }
    public IBook Book { get; set; }
    public bool Available { get; set; }

    public State(string guid, IBook book, bool available)
    {
        Guid = guid;
        Book = book;
        Available = available;
    }
}