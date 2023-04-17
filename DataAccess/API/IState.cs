namespace DataAccess.API;

public interface IState
{
    string Guid { get; }
    IBook Book { get; set; }
    bool Available { get; set; }
}