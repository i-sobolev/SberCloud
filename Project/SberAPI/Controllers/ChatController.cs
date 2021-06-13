using Microsoft.AspNetCore.Mvc;
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
        //public async Task<ActionResult> Post(ChatViewModel chat)
        //{
        //    await Data.SberCloudContext.AddAsync(new Chat().FromViewModel(chat));
        //    return new OkResult();
        //}

        //public async Task<ActionResult<ChatViewModel>> Get(string userId)
        //{
            
        //}
    }
}