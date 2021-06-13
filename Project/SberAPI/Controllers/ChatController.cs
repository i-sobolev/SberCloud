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
            await Data.SberCloudContext.SaveChangesAsync();
            return new OkResult();
        }

        //[HttpGet]
        //public async Task<ActionResult<ChatUserViewModel>> Get(int userId)
        //{
        //    var result = await Data.SberCloudContext.ChatUsers
        //        .Where(x => x.UserId == userId)
        //        .Select(x => new ChatUserViewModel()
        //        {
        //            Id = x.Id,
        //            Chat = Data.SberCloudContext.Chats.Where(chat => chat.Id == x.Chat.Id).FirstOrDefault().ToViewModel(),
        //            User = Data.SberCloudContext.Users.Where(user => user.Id == x.User.Id).FirstOrDefault().ToViewModel()
        //        })
        //        .ToListAsync();

        //    if (result != null)
        //        return new ObjectResult(result);

        //    else
        //        return new BadRequestResult();
        //}

        [HttpGet]
        public async Task<ActionResult<ChatViewModel>> Get(int userId)
        {
            var chatUsers = await Data.SberCloudContext.ChatUsers.Where(x => x.UserId == userId).Select(x => x.ChatId).ToListAsync();
            
            var result = await Data.SberCloudContext.Chats
                .Where(x => chatUsers.Contains(x.Id))
                .Select(x => new ChatViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    AdminId = x.AdminId,
                    DateCreated = x.DateCreated,
                    TypeId = x.TypeId,
                    Users = x.ChatUsers.Select(x => x.User.ToViewModel()).ToList(),

                    Messages = Data.SberCloudContext.Messages
                    .Where(mes => x.Id == mes.ChatId)
                    .Select(mes => new MessageViewModel()
                    {
                        Id = mes.Id,
                        Chat = mes.Chat.ToViewModel(),
                        Text = mes.Text,
                        TimeStamp = mes.Text,
                        User = mes.User.ToViewModel()
                    }).ToList()
                }).ToListAsync();

            if (result != null)
                return new ObjectResult(result);

            else
                return new EmptyResult();
        }
    }
}