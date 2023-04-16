namespace DataAccess.API;

public interface IState
{
    string Guid { get; }
    ICatalog Catalog { get; set; }
    bool Available { get; set; }
}