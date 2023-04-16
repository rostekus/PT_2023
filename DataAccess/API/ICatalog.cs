namespace DataAccess.API;

public interface ICatalog
{
    string Title { get; set; }
    string Author { get; set; }
    string Guid { get; } 
 
}