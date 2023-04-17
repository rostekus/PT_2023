namespace BusinessLogic.API;

public interface ILibraryBusinessLogic
{
    void BorrowBook(string userId, string stateId);
    void ReturnBook(string userId,string stateId);
}