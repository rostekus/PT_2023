using DataAccess.API;

namespace DataAccess.SampleImplementation;

internal class ClientRepository : IClientRepository
{
    private readonly LibraryDataContext _context;
    
    public ClientRepository(LibraryDataContext context)
    {
        _context = context;
    }

    public List<IClient> GetAll() => _context.Clients;
    public IClient GetById(string guid)
    {
        // check if user exists with the same guid in repository
        var client = this._context.Clients.Find(checkClient => checkClient.Guid == guid);
        if (client== null)
        {
            throw new Exception("No client with specified GUID");
        }

        return client;
    }

    public void Add(IClient entity)
    {
        this._context.Clients.Add(entity);
    }

    public void Update(IClient entity)
    {
        for (var index = 0; index < _context.Clients.Count; index++)
        {
            var user = _context.Clients[index];
            if (user.Guid != entity.Guid)
                continue;

            _context.Clients.Remove(user);
            _context.Clients.Add(entity);
            return;
        }
    }


    public void Create(IClient client)
    {
        // check if user exists with the same guid in repository
        var clientDuplicate = this._context.Clients.Find(checkClient => checkClient.Guid == client.Guid);
        if (clientDuplicate == null)
        {
            throw new Exception("Client with that GUID exists in repository");
        }
        _context.Clients.Add(client);
    }

    public void Delete(IClient client)
    {
        var foundClient = this._context.Clients.Find(checkClient => checkClient.Guid == client.Guid);
        if (client== null)
        {
            throw new Exception("No client with specified GUID");
        }

        this._context.Clients.RemoveAll(checkClient => checkClient.Guid == client.Guid);

    }
    
}