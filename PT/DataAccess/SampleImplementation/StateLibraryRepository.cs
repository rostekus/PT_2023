using DataAccess.API;

namespace DataAccess.SampleImplementation;

public class StateLibraryRepository : IStateRepository
{
    private readonly LibraryDataContext _context;
    
    public StateLibraryRepository(LibraryDataContext context)
    {
        _context = context;
    }

    public List<IState> GetAll() => _context.States;
    public IState GetById(string guid)
    {
        // check if user exists with the same guid in repository
        var e = this._context.States.Find(checkState => checkState.Guid == guid);
        if (e== null)
        {
            throw new Exception("No State with specified GUID");
        }

        return e;
    }

    public void Add(IState e)
    {
        this._context.States.Add(e);
    }

    public void Update(IState e)
    {   

        for (var index = 0; index < _context.States.Count; index++)
        {
            var state = _context.States[index];
            if (state.Guid != e.Guid)
                continue;

            _context.States.Remove(state);
            _context.States.Add(e);
            return;
        }
    }

    public void Create(IState e)
    {
        // check if user exists with the same guid in repository
        var eDuplicate = this._context.States.Find(checkState => checkState.Guid == e.Guid);
        if (eDuplicate == null)
        {
            throw new Exception("State with that GUID exists in repository");
        }
        _context.States.Add(e);
    }

    public void Delete(IState e)
    {
        var foundState = this._context.States.Find(checkState => checkState.Guid == e.Guid);
        if (foundState== null)
        {
            throw new Exception("No State with specified GUID");
        }

        this._context.States.RemoveAll(found => found.Guid == e.Guid);

    }

    public bool CheckAvailable(string guid)
    {
        var foundState = this._context.States.Find(checkState => checkState.Guid == guid);
        if (foundState== null)
        {
            throw new Exception("No State with specified GUID");
        }

        return foundState.Available;
    }

    public void ChangeAvailability(string guid)
    {
        foreach (var state in _context.States)
        {
            if (state.Guid != guid)
                continue;

            state.Available = !state.Available;
            return;
        }
    }
}