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
    public class ChatController : Controller
    {
        public async Task<ActionResult> Post([FromBody] ChatViewModel chat)
        {
            await Data.SberCloudContext.AddAsync(new Chat().FromViewModel(chat));
            return new OkResult();
        }

        public async Task<ActionResult<ChatUserViewModel>> Get(int userId)
        {
            var isUserChatExist = Data.SberCloudContext.ChatUsers.ToList().TrueForAll(x => x.UserId == userId);

            if (isUserChatExist)
            {
                var result = await Data.SberCloudContext.ChatUsers.Where(x => x.UserId == userId)
               .Select(x => x.ToViewModel()).ToListAsync();

                return new ObjectResult(result);

            }

            return new BadRequestResult();

        }

    }
}