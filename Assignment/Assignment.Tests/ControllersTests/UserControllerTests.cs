using Assignment.Api;

using Assignment.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Assignment.Tests
{
    /// <summary>
    /// User controller tests.
    /// </summary>
    public class UserControllerTests : BaseController
    {
        private UserController controller;
        private IOptions<AppSettings> options;

        /// <summary>
        /// Setup.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            options = Options.Create(new AppSettings { Secret = "this is my custom Secret key for authnetication" });
            controller = new UserController(UserLogger.Object, UserManager.Object, options, Mapper)
            {
                ControllerContext = Context
            };
        }

        /// <summary>
        /// Authentication test.
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task AuthenticateUserTest()
        {
            var result = await controller.Authenticate(new UserLoginDto { UserName = "User1", UserPass = "12345" });
            var response = (ObjectResult)result;
            Assert.AreEqual(StatusCodes.Status200OK, (int)response.StatusCode);
        }
    }
}
