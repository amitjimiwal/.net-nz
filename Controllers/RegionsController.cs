using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using apiNZWalks.Models.Domain;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace apiNZWalks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : Controller
    {
        // GET: /<controller>/
        [HttpGet]
        public IActionResult GetAll()
        {
            var regions = new List<Region>
            {
                new Region()
                {
                    Id=Guid.NewGuid(),
                    Name="Auckland Region",
                    Code=" ",
                    RegionImageUrl="https://dcblog.b-cdn.net/wp-content/uploads/2021/02/Full-form-of-URL-1.jpg"
                },
                new Region()
                {
                    Id=Guid.NewGuid(),
                    Name="Auckland Region",
                    Code=" ",
                    RegionImageUrl="https://dcblog.b-cdn.net/wp-content/uploads/2021/02/Full-form-of-URL-1.jpg"
                }
            };

            return Ok(regions);
        }
    }
}

