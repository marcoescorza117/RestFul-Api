using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SocialMedia.Core.DTOs;
using SocialMedia.Core.Entities;
using SocialMedia.Core.Interfaces;
using SocialMedia.Infrastructure.Repositories;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMedia.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {

        //tiene que generarse inyeccuion de dependencias

        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        public PostController(IPostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;

            //Inyeccion de dependenbcias de automapper
            _mapper = mapper;

        }

        //NO ACOPLAR A CONTROLADOR NUESTRO REPOSITORIO
        //SE INCLUMPLE INYECCION DE DEPENDENCIAS

        //Incorrecto, tiene que hacerse con inyeccion de dependencias
        //var post = new PostRepository().GetPost();
        //return Ok(post);
        //

        //Manera correcta de implementacion :) 
        //Lo siguiente sirve para el scaffolding
        //Scaffold-DbContext "Server=(localdb)\MSSQLLocalDB;Database=SocialMedia;Integrated Security = true" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Data


        [HttpGet]
        public async Task<IActionResult> GetPost() {
            
            var post = await _postRepository.GetPosts();

            //Conviertiendo enumerable de entidad de dominio a entidad Dto
            //Lambda expression
            /* var postDTOs = post.Select(x => new PostDto
             {
                 PostId = x.PostId,
                 Date = x.Date,
                 Description = x.Description,
                 Image = x.Image,
                 UserId = x.UserId

             });*/

            var postDTOs = _mapper.Map<IEnumerable<PostDto>>(post);
            return Ok(postDTOs);
        
        }

        //Obteniendo un post
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPost(int id)
        {

            var post = await _postRepository.GetPost(id);

            /*var postDto = new PostDto
            {
                PostId = post.PostId,
                Date = post.Date,
                Description = post.Description,
                Image = post.Image,
                UserId = post.UserId
                
            };*/

            var postDTOs = _mapper.Map<IEnumerable<PostDto>>(post);

            return Ok(postDTOs);

        }
        
        //Insertando un post -> DEJAR DE USAR ENTIDADES DE DOMINIO-... en este caso es al contrario
        //de una entidad tipo dto pasarla a entiedad de tipo de dominio
        [HttpPost]
        public async Task<IActionResult> Post(PostDto postDto)
        {

            /*
            if (!ModelState.IsValid)
            {
                return BadRequest();

            }*/


            //Mapeando entidad
            var post = new Post
            {

                
                Date = postDto.Date,
                Description = postDto.Description,
                Image = postDto.Image,
                UserId = postDto.UserId

            };


           // var posts = _mapper.Map<IEnumerable<Post>>(postDto); resolver este error


            await _postRepository.InsertPost(post);//?
            return Ok(post);

        }



    }
}
