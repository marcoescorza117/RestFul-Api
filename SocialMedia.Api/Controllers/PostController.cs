using Microsoft.AspNetCore.Mvc;
using SocialMedia.Core.Interfaces;
using SocialMedia.Infrastructure.Repositories;

namespace SocialMedia.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : Controller
    {

        //tiene que generarse inyeccuion de dependencias

        private readonly IPostRepository _postRepository;

        public PostController(IPostRepository postRepository)
        {
            _postRepository = postRepository;

        }

        [HttpGet]
        public IActionResult GetPost() {
            //NO ACOPLAR A CONTROLADOR NUESTRO REPOSITORIO
            //SE INCLUMPLE INYECCION DE DEPENDENCIAS

            //Incorrecto, tiene que hacerse con inyeccion de dependencias
            var post = new PostRepository().GetPost();
            return Ok(post);
            //
        
        }
    }
}
