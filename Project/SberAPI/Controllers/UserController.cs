using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SberAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
using SberAPI.ViewModels;
using System.Net.Mail;
using System.Net;

namespace SberAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<Token>> Post([FromBody] UserViewModel user)
        {
            var isUserLoginExist = Data.SberCloudContext.Users.ToList().TrueForAll(x => x.Login == user.Login);

            if (!isUserLoginExist)
            {
                var newUser = new User().FromViewModel(user);

                var token = SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(user.Email + user.Phone));

                var totxt = Encoding.Default.GetString(token);

                await Data.SberCloudContext.AddAsync(newUser);
                await Data.SberCloudContext.SaveChangesAsync();

                return new ObjectResult(new Token() { Data = totxt });
            }

            {
                return new ConflictResult();
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserViewModel>>> Get()
        {
            var result = await Data.SberCloudContext.Users
                .Select(x => x.ToViewModel()).ToListAsync();

            return result;
        }

        [HttpPut]
        public async Task<ActionResult> Put(UserViewModel user)
        {
            var editableUser = await Data.SberCloudContext.Users
                .Where(x => x.Id == user.Id)
                .FirstOrDefaultAsync();

            var isUserLoginExist = Data.SberCloudContext.Users.ToList().TrueForAll(x => x.Login == user.Login);

            if (editableUser != null && !isUserLoginExist)
            {
                editableUser.FirstName = user.FirstName;
                editableUser.LastName = user.LastName;
                editableUser.MiddleName = user.MiddleName;
                editableUser.Country = Data.SberCloudContext.Countries.Where(x => x.Id == user.CountryId).FirstOrDefault();
                editableUser.Phone = user.Phone;
                editableUser.Email = user.Email;

                Data.SberCloudContext.SaveChanges();

                return new OkResult();
            }

            else
            {
                return new EmptyResult();
            }
        }
    }

}