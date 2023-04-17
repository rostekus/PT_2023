using DataAccess.API;

namespace DataAccess.SampleImplementation;

public class Client : IClient
{
    public string Guid { get; private set; }
    public string Name { get; set; }
    public string Email { get; set; }

    public Client(string guid, string name, string email)
    {
        Guid = guid;
        Name = name;
        Email = email;
    }
}

