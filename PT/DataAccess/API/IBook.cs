namespace DataAccess.API;

public interface IBook
{
    string Title { get; set; }
    string Author { get; set; }
    string Guid { get; } 
 
}