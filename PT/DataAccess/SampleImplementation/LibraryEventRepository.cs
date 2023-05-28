using DataAccess.API;

namespace DataAccess.SampleImplementation;

internal class LibraryEventRepository : ILibraryEventRepository
{
    private readonly ILibraryDataContext _context;
    
    public LibraryEventRepository(ILibraryDataContext context)
    {
        _context = context;
    }

    public List<ILibraryEvent> GetAll() => _context.Events;
    public ILibraryEvent GetById(string guid)
    {
        // check if user exists with the same guid in repository
        var e = this._context.Events.Find(checkEvent => checkEvent.Guid == guid);
        if (e== null)
        {
            throw new Exception("No e with specified GUID");
        }

        return e;
    }

    public void Add(ILibraryEvent e)
    {
        this._context.Events.Add(e);
    }

    public void Update(ILibraryEvent e)
    {
        for (var index = 0; index < _context.Events.Count; index++)
        {
            var user = _context.Events[index];
            if (user.Guid != e.Guid)
                continue;

            _context.Events.Remove(user);
            _context.Events.Add(e);
            return;
        }
    }


    public void Create(ILibraryEvent e)
    {
        // check if user exists with the same guid in repository
        var eDuplicate = this._context.Events.Find(checkEvent => checkEvent.Guid == e.Guid);
        if (eDuplicate == null)
        {
            throw new Exception("e with that GUID exists in repository");
        }
        _context.Events.Add(e);
    }

    public void Delete(ILibraryEvent e)
    {
        var foundEvent = this._context.Events.Find(checkEvent => checkEvent.Guid == e.Guid);
        if (foundEvent== null)
        {
            throw new Exception("No e with specified GUID");
        }

        this._context.Events.RemoveAll(found => found.Guid == e.Guid);

    }
    
}