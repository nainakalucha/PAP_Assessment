using Assignment.Common;
using Assignment.Contract;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Api
{
    /// <summary>
    /// User controller.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserManager _userManager;
        private readonly AppSettings _appSettings;
        private readonly IMapper _mapper;

        /// <summary>
        /// Create new instance of <see cref="ItemResolver"/> class.
        /// </summary>
        /// <param name="logger">Logger.</param>
        /// <param name="userService">User service.</param>
        /// <param name="appSettings">App settings.</param>
        public UserController(ILogger<UserController> logger, IUserManager userManager, IOptions<AppSettings> appSettings, IMapper mapper)
        {
            _logger = logger;
            _userManager = userManager;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }

        /// <summary>
        /// Authenticate user.
        /// </summary>
        /// <param name="request">Login request.</param>
        /// <returns>Ok if successful.</returns>
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate(string username, string password)
        {
            _logger.LogInformation("Authenticate");
            long? userId = await _userManager.AuthenticateUser(username, password);
            if (!userId.HasValue)
                return BadRequest(new { message = "Username or password is incorrect" });

            // authentication successful so generate jwt token
            var token = generateJwtToken(userId.Value, username);
            return StatusCode((int)HttpStatusCode.OK, token);
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Get(long id)
        {
            var user = await _userManager.GetById(id);
            var mappedData = _mapper.Map<UserLoginDto>(user);
            return StatusCode((int)HttpStatusCode.OK, mappedData);
        }

        private string generateJwtToken(long userId, string userName)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", userId.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}