using DataLayer.API;

namespace DataLayerTests
{
    [TestClass]
    [DeploymentItem("LibraryDBTest.mdf")]
    public class DataLayerTests
    {
        private static string testConnectionString;

        private readonly IDataRepository _dataRepository = IDataRepository.CreateDatabase(testConnectionString);

        [ClassInitialize]
        public static void InitializeDataLayerTests(TestContext context)
        {
            string _DBRelativePath = @"LibraryDBTest.mdf";
            string _projectRootDir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string _DBPath = Path.Combine(_projectRootDir, _DBRelativePath);
            FileInfo _databaseFile = new FileInfo(_DBPath);
            Assert.IsTrue(_databaseFile.Exists, $"{Environment.CurrentDirectory}");
            testConnectionString = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={_DBPath};Integrated Security = True; Connect Timeout = 30;";
        }

        [TestMethod]
        public async Task UserTests()
        {
            int userId = 1;

            await _dataRepository.AddUser(userId, "John", "Smith");

            IUser user = await _dataRepository.GetUser(userId);

            Assert.IsNotNull(user);
            Assert.AreEqual(userId, user.id);
            Assert.AreEqual("John", user.firstName);
            Assert.AreEqual("Smith", user.lastName);

            user = await _dataRepository.GetUserAsyncMethodSyntax(userId);

            Assert.IsNotNull(user);
            Assert.AreEqual(userId, user.id);
            Assert.AreEqual("John", user.firstName);
            Assert.AreEqual("Smith", user.lastName);

            Assert.IsNotNull(await _dataRepository.GetAllUsers());
            Assert.IsTrue(await _dataRepository.GetUsersCount() > 0);

            await Assert.ThrowsExceptionAsync<Exception>(async () => await _dataRepository.GetUser(userId + 2));

            await _dataRepository.UpdateUser(userId, "Tom", "ABC");

            IUser userUpdated = await _dataRepository.GetUser(userId);

            Assert.IsNotNull(userUpdated);
            Assert.AreEqual(userId, userUpdated.id);
            Assert.AreEqual("Tom", userUpdated.firstName);
            Assert.AreEqual("ABC", userUpdated.lastName);

            await Assert.ThrowsExceptionAsync<Exception>(async () => await _dataRepository.UpdateUser(userId + 2,
                "Tom", "ABC"));

            await _dataRepository.DeleteUser(userId);
            await Assert.ThrowsExceptionAsync<Exception>(async () => await _dataRepository.GetUser(userId));
            await Assert.ThrowsExceptionAsync<Exception>(async () => await _dataRepository.DeleteUser(userId));
        }

        [TestMethod]
        public async Task ProductTests()
        {
            int productId = 1;

            await _dataRepository.AddProduct(1, "Moby Dick", "ABC", 40.0f);

            IProduct product = await _dataRepository.GetProduct(productId);

            Assert.IsNotNull(product);
            Assert.AreEqual(productId, product.id);
            Assert.AreEqual("Moby Dick", product.productName);
            Assert.AreEqual("ABC", product.productDescription);
            Assert.AreEqual(40.0f, product.price);

            Assert.IsNotNull(await _dataRepository.GetAllProducts());
            Assert.IsTrue(await _dataRepository.GetProductsCount() > 0);

            await Assert.ThrowsExceptionAsync<Exception>(async () => await _dataRepository.GetProduct(32));

            await _dataRepository.UpdateProduct(productId, "Moby Dick", "XZY", 4.5f);

            IProduct productUpdated = await _dataRepository.GetProduct(productId);

            Assert.IsNotNull(productUpdated);
            Assert.AreEqual(productId, productUpdated.id);
            Assert.AreEqual("Moby Dick", productUpdated.productName);
            Assert.AreEqual("XZY", productUpdated.productDescription);
            Assert.AreEqual(4.5f, productUpdated.price);

            await _dataRepository.DeleteProduct(productId);
            await Assert.ThrowsExceptionAsync<Exception>(async () => await _dataRepository.GetProduct(productId));
            await Assert.ThrowsExceptionAsync<Exception>(async () => await _dataRepository.DeleteProduct(productId));
        }

        [TestMethod]
        public async Task StateTests()
        {
            int productId = 1;
            int stateId = 1;

            await _dataRepository.AddProduct(1, "Moby Dick", "ABC", 40.0f);

            IProduct product = await _dataRepository.GetProduct(productId);

            await _dataRepository.AddState(stateId, productId, true);

            IState state = await _dataRepository.GetState(stateId);

            Assert.IsNotNull(state);
            Assert.AreEqual(stateId, state.stateId);
            Assert.AreEqual(productId, state.productId);
            Assert.AreEqual(true, state.available);

            Assert.IsNotNull(await _dataRepository.GetAllStates());
            Assert.IsTrue(await _dataRepository.GetStatesCount() > 0);

            await Assert.ThrowsExceptionAsync<Exception>(async () => await _dataRepository.GetState(stateId + 2));

            await Assert.ThrowsExceptionAsync<Exception>(async () => await _dataRepository.AddState(stateId, 13, false));

            await _dataRepository.UpdateState(stateId, productId, false);

            IState stateUpdated = await _dataRepository.GetState(stateId);

            Assert.IsNotNull(stateUpdated);
            Assert.AreEqual(stateId, stateUpdated.stateId);
            Assert.AreEqual(productId, stateUpdated.productId);
            Assert.AreEqual(false, stateUpdated.available);

            await Assert.ThrowsExceptionAsync<Exception>(async () => await _dataRepository.UpdateState(stateId + 2, productId, true));
            await Assert.ThrowsExceptionAsync<Exception>(async () => await _dataRepository.UpdateState(stateId, 13, false));

            await _dataRepository.DeleteState(stateId);
            await Assert.ThrowsExceptionAsync<Exception>(async () => await _dataRepository.GetState(stateId));
            await Assert.ThrowsExceptionAsync<Exception>(async () => await _dataRepository.DeleteState(stateId));

            await _dataRepository.DeleteProduct(productId);
        }

        [TestMethod]
        public async Task EventTests()
        {
            await _dataRepository.AddUser(2, "John", "Smith");
            await _dataRepository.AddProduct(1, "XYZ", "ABC", 3.99f);
            await _dataRepository.AddState(1, 1, true);
            await _dataRepository.AddEvent(1, 1, 1, "PlaceEvent");

            await _dataRepository.DeleteEvent(1);
            await _dataRepository.DeleteUser(1);
            await _dataRepository.DeleteState(1);
            await _dataRepository.DeleteProduct(1);
        }
    }
}