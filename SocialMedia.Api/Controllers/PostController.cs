using Microsoft.AspNetCore.Mvc;
using SocialMedia.Core.Entities;
using SocialMedia.Core.Interfaces;
using SocialMedia.Infrastructure.Repositories;
using System.Threading.Tasks;

namespace SocialMedia.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
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

        //Obteneindoi un post
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPost(int id)
        {

            var post = await _postRepository.GetPost(id);
            return Ok(post);

        }
        
        //Insertando un post
        [HttpPost]
        public async Task<IActionResult> Post(Post post)
        {

            await _postRepository.InsertPost(post);
            return Ok(post);

        }



    }
}
