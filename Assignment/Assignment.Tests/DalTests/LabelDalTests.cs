using Assignment.Contract;
using Assignment.DAL;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Assignment.Tests
{
    /// <summary>
    /// Label dal layer tests.
    /// </summary>
    public class LabelDalTests : BaseDBContextInitiator
    {
        private IUserDalLayer _userDalLayer;

        /// <summary>
        /// Setup.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            _userDalLayer = new UserDalLayer(DBContext);
        }


        /// <summary>
        /// Get labels test.
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task GetLabels()
        {
            var userId = await _userDalLayer.AuthenticateUser("User1", "12345");
            Assert.IsNotNull(userId);
            Assert.AreEqual(1, userId);
        }
    }
}
