using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMedia.Api.Controllers
{
    public class PostController : Controller
    {
        [HttpGet]
        public IActionResult GetPost() {

            return Ok(null);
        
        }
    }
}
