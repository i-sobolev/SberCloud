using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SberAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SberAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        public async Task<ActionResult<MessageViewModel>> Get(int chatId)
        {
            var result = await Data.SberCloudContext.Messages
                .Where(x => x.ChatId == chatId).Select(x => x.ToViewModel()).ToListAsync();

            if (result != null)
                return new ObjectResult(result);

            else
                return new EmptyResult();
        }

        public async Task<ActionResult> Post(MessageViewModel message)
        {

        }
    }
}