using Assignment.BLL;
using Assignment.Contract;
using Moq;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Assignment.Tests
{
    /// <summary>
    /// User service tests.
    /// </summary>
    public class UserManagerTest
    {
        private Mock<IUserDalLayer> _userDalLayer;
        private IUserManager _userManager;

        /// <summary>
        /// Set up.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            _userDalLayer = new Mock<IUserDalLayer>();
            _userManager = new UserManager(_userDalLayer.Object);
        }

        /// <summary>
        /// Auth valid test.
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task Authenticate_ValidUserNameAndPassword()
        {
            string username = "User1", password = "12345";
            long? id = 1;
            _userDalLayer.Setup(p => p.AuthenticateUser(username, password)).Returns(Task.FromResult<long?>(id));
            long? userId = await _userManager.AuthenticateUser(username, password);
            Assert.IsTrue(userId.HasValue);
            Assert.AreEqual(1, userId.Value);
        }

        /// <summary>
        /// Auth invalid test.
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task Authenticate_InvalidUserNameAndPassword()
        {
            _userDalLayer.Setup(p => p.AuthenticateUser(string.Empty, string.Empty)).Returns(Task.FromResult<long?>(null));
            long? userId = await _userManager.AuthenticateUser(string.Empty, string.Empty);
            Assert.IsTrue(!userId.HasValue);
        }
    }
}
