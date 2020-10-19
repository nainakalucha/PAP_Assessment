using Assignment.Api;
using Assignment.Contract;
using Assignment.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System.Threading.Tasks;

namespace Assignment.Tests
{
    /// <summary>
    /// Base class for controller tests.
    /// </summary>
    public class BaseController : MapperInitiator
    {
        public ControllerContext Context { get; }
        public ApiVersion Version { get; }
        public Mock<ILogger<UserController>> UserLogger { get; }
        public Mock<IUserManager> UserManager { get; }
        protected BaseController()
        {
            Context = new ControllerContext
            {
                HttpContext = new DefaultHttpContext()
            };

            Context.HttpContext.Request.HttpContext.Items["User"] = new UserLoginDto { Id = 1 };
            Version = new ApiVersion(1, 0);
            UserManager = new Mock<IUserManager>();
            UserLogger = new Mock<ILogger<UserController>>();
            UserManager.Setup(p => p.AuthenticateUser(It.IsAny<string>(), It.IsAny<string>())).Returns(Task.FromResult<long?>(1));
        }
    }
}
