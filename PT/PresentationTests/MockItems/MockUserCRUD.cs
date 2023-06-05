using Presentation.Model.API;

namespace PresentationTests.MockItems
{
    internal class MockUserCRUD : IUserModelOperation
    {
        private readonly MockDataRepository _testRepository = new MockDataRepository();

        public MockUserCRUD() { }

        public async Task AddUser(int id, string firstName, string lastName)
        {
            await this._testRepository.AddUser(id, firstName, lastName);
        }

        public async Task<IUserModel> GetUser(int id)
        {
            return await this._testRepository.GetUser(id);
        }

        public async Task UpdateUser(int id, string firstName, string lastName)
        {
            await this._testRepository.UpdateUser(id, firstName, lastName);
        }

        public async Task DeleteUser(int id)
        {
            await this._testRepository.DeleteUser(id);
        }

        public async Task<Dictionary<int, IUserModel>> GetAllUsers()
        {
            Dictionary<int, IUserModel> result = new Dictionary<int, IUserModel>();

            foreach (IUserModel user in (await this._testRepository.GetAllUsers()).Values)
            {
                result.Add(user.Id, (IUserModel)user);
            }

            return result;
        }

        public async Task<int> GetUsersCount()
        {
            return await this._testRepository.GetUsersCount();
        }

    }
}
