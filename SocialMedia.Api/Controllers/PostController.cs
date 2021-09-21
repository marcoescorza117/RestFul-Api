using Microsoft.AspNetCore.Mvc;
using SocialMedia.Core.Interfaces;
using SocialMedia.Infrastructure.Repositories;
using System.Threading.Tasks;

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
        public async Task<IActionResult> GetPost() {
            //NO ACOPLAR A CONTROLADOR NUESTRO REPOSITORIO
            //SE INCLUMPLE INYECCION DE DEPENDENCIAS

            //Incorrecto, tiene que hacerse con inyeccion de dependencias
            //var post = new PostRepository().GetPost();
            //return Ok(post);
            //

            //Manera correcta de implementacion :) 
            //Lo siguiente sirve para el scaffolding
            //Scaffold-DbContext "Server=(localdb)\MSSQLLocalDB;Database=SocialMedia;Integrated Security = true" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Data
            var post = await _postRepository.GetPosts();
            return Ok(post);
        
        }
    }
}
