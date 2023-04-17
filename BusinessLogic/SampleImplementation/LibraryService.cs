using BusinessLogic.API;
using DataAccess.API;
namespace BusinessLogic.SampleImplementation;

public class LibraryService : ILibraryBusinessLogic
{
    private IStateRepository _States;
    private  IClientRepository _Clients;
    private  IBookRepository _Books;
    private  ILibraryEventRepository _Events;

    public LibraryService(IStateRepository states, IClientRepository clients, IBookRepository books, ILibraryEventRepository events)
    {
        _Events = events;
        _Clients = clients;
        _Books = books;
        _States = states;
    }


    public void BorrowBook(string clientId, string stateId)
    {
        var state = _States.GetById(stateId);

        if (!state.Available)
        {
            throw new Exception("Cannot borrow this book");
        }

        var client = _Clients.GetById(clientId);
        
        
        IBorrow borrowBookEvent = new Borrow(Guid.NewGuid().ToString(), DateTime.Now, state, client, TimeSpan.MaxValue);
        _Events.Add(borrowBookEvent);
    }

    public void ReturnBook(string clientId, string stateId)
    {
        var state = _States.GetById(stateId);

        if (state.Available)
        {
            throw new Exception("Cannot return this book");
        }

        var client = _Clients.GetById(clientId);

        IReturn returnBookEvent = new Return(Guid.NewGuid().ToString(), DateTime.Now, state, client);
        _Events.Add(returnBookEvent);

    }
}