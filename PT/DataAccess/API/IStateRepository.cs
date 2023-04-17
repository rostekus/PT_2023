namespace DataAccess.API;

public interface IStateRepository: IRepository<IState>
{
    bool CheckAvailable(string guid);
    void ChangeAvailability(string guid);
}