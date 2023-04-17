namespace DataAccess.API;

public interface IState
{
    string Guid { get; }
    string BookId { get; set; }
    bool Available { get; set; }
}