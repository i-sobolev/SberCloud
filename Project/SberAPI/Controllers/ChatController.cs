using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SberAPI.Models;
using SberAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SberAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ChatViewModel chat)
        {
            await Data.SberCloudContext.AddAsync(new Chat().FromViewModel(chat));
            return new OkResult();
        }

        [HttpGet]
        public async Task<ActionResult<ChatUserViewModel>> Get(int userId)
        {
            var result = await Data.SberCloudContext.ChatUsers
                .Where(x => x.UserId == userId)
                .Select(x => x.Chat.ToViewModel())
                .ToListAsync();

            if (result != null)
                return new ObjectResult(result);

            else
                return new BadRequestResult();
        }
    }
}