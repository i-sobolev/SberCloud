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
    [ApiController]
    [Route("[controller]")]
    public class RegionController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RegionViewModel>>> Get()
        {
            var result = await Data.SberCloudContext.Regions
                .Select(x => x.ToViewModel()).ToListAsync();

            return result;
        }
    }
}
