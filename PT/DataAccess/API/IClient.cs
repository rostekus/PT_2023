namespace DataAccess.API;

public interface IClient
{
    string Guid { get; }
    string Name { get; set; }
    string Email { get; set; }     

}