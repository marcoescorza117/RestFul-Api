using Microsoft.AspNetCore.Mvc;
using SocialMedia.Infrastructure.Repositories;

namespace SocialMedia.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : Controller
    {
        [HttpGet]
        public IActionResult GetPost() {

            var post = new PostRepository().GetPost();
            return Ok(post);
        
        }
    }
}
