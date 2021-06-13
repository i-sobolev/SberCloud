using Microsoft.AspNetCore.Http;
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
    public class MessageController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<MessageViewModel>> Get(int chatId)
        {
            var result = await Data.SberCloudContext.Messages
                .Where(x => x.ChatId == chatId).Select(x => new MessageViewModel()
                { 
                    Id = x.Id,
                    Chat = x.Chat.ToViewModel(),
                    Text = x.Text,
                    TimeStamp = x.Text,
                    User = x.User.ToViewModel()
                }).ToListAsync();

            if (result != null)
                return new ObjectResult(result);

            else
                return new EmptyResult();
        }

        [HttpPost]
        public async Task<ActionResult> Post(MessageViewModel message)
        {
            await Data.SberCloudContext.AddAsync(new Message().FromViewModel(message));
            await Data.SberCloudContext.SaveChangesAsync();
            return new OkResult();
        }
    }
}