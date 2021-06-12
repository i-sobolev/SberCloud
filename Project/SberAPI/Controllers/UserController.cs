using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SberAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace SberAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<User>> Post([FromBody] UserModel user)
        {
            var isUserLoginExist = Data.SberCloudContext.Users.ToList().TrueForAll(x => x.Login != user.Login);

            if (isUserLoginExist)
            {
                var newUser = FromModel(user);

                var token = MD5
                    .Create()
                    .ComputeHash(Encoding.UTF8.GetBytes(user.Email + user.Phone));

                await Data.SberCloudContext.AddAsync(newUser);
                await Data.SberCloudContext.SaveChangesAsync();

                return new OkResult();
            }

            {
                return new ConflictResult();
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserModel>>> Get()
        {
            var result = await Data.SberCloudContext.Users.Select(x => new UserModel()
            {
                Login = x.Login,
                Password = x.Password,
                FirstName = x.FirstName,
                LastName = x.LastName,
                MiddleName = x.MiddleName,
                Email = x.Email,
                Phone = x.Phone,
                LawFirmId = x.LawFirmId,
                IpAddress = x.IpAddress,
                RegionId = x.RegionId,
                CountryId = x.CountryId,
                RoleId = x.RoleId,
            }).ToListAsync();

            return result;
        }

        private User FromModel(UserModel user)
        {
            return new User()
            {
                Login = user.Login,
                Password = user.Password,
                FirstName = user.FirstName,
                LastName = user.LastName,
                MiddleName = user.MiddleName,
                Email = user.Email,
                Phone = user.Phone,
                LawFirmId = user.LawFirmId,
                IpAddress = user.IpAddress,
                RegionId = user.RegionId,
                CountryId = user.CountryId,
                RoleId = user.RoleId,
                Country = Data.SberCloudContext.Countries.Where(x => x.Id == user.CountryId).FirstOrDefault(),
                Role = Data.SberCloudContext.Roles.Where(x => x.Id == user.RoleId).FirstOrDefault(),
                Region = Data.SberCloudContext.Regions.Where(x => x.Id == user.RegionId).FirstOrDefault(),
                LawFirm = Data.SberCloudContext.LawFirms.Where(x => x.Id == user.LawFirmId).FirstOrDefault()
            };
        }
    }
}