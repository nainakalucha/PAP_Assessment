using Assignment.Contract;
using Assignment.Model;
using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Assignment.Api
{
    /// <summary>
    /// User controller.
    /// </summary>
    [Route("api/[controller]"), Produces("application/json"), EnableCors("AppPolicy")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly ILogger<ChatController> _logger;
        private readonly IChatManager _chatManager;
        private readonly IMapper _mapper;

        /// <summary>
        /// Create new instance of <see cref="ItemResolver"/> class.
        /// </summary>
        /// <param name="logger">Logger.</param>
        /// <param name="userService">User service.</param>
        /// <param name="appSettings">App settings.</param>
        public ChatController(ILogger<ChatController> logger, IChatManager chatManager, IMapper mapper)
        {
            _logger = logger;
            _chatManager = chatManager;
            _mapper = mapper;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetUserChat([FromQuery] string param)
        {
            List<UserChatDto> result = new List<UserChatDto>();
            try
            {
                if (param != string.Empty)
                {
                    dynamic data = JsonConvert.DeserializeObject(param);
                    UserChatDto model = JsonConvert.DeserializeObject<UserChatDto>(data.ToString());
                    if (model != null)
                    {
                        var dto = await _chatManager.GetUserChat(model);
                        result = _mapper.Map<List<UserChatDto>>(dto);
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            var obj = new { ChatResult = result };
            return StatusCode((int)HttpStatusCode.OK, obj);
        }
    }
}