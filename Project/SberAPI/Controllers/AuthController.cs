using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SberAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SberAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<UserViewModel>> Get(string login, string password)
        {
            var result = Data.SberCloudContext.Users
                .Where(x =>
                (x.Login == login && x.Password == password) |
                (x.Email == login && x.Password == password))
                .FirstOrDefault();

            if (!result.Equals(null))
                return new ObjectResult(result.ToViewModel());

            else
                return new EmptyResult();
        }
    }
}
