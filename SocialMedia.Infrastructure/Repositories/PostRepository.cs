using Microsoft.EntityFrameworkCore;
using SocialMedia.Core.Entities;
using SocialMedia.Core.Interfaces;
using SocialMedia.Infrastructure.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMedia.Infrastructure.Repositories
{
    //Implementado interface
    public class PostRepository : IPostRepository
    {

        private readonly SocialMediaContext _context;
        public PostRepository(SocialMediaContext context)
        {
            _context = context;
        }

        //esto apunta hacia la base de datos
        public async Task<IEnumerable<Post>> GetPosts()
        {
            var post = await _context.Posts.ToListAsync();
            return post;

        }

        public async Task<Post> GetPost(int id)
        {
            var post = await _context.Posts.FirstOrDefaultAsync(x => x.PostId == id);
            return post;

        }


        //metodo de guardar
        public async Task InsertPost(Post post)
        {
            _context.Posts.Add(post);
            await _context.SaveChangesAsync();
        }


        //retorna el listado de post
        /*public async Task<IEnumerable<Post>> GetPosts()
        {
           var post = Enumerable.Range(1, 588).Select(x => new Post
            {

                PostId = x,
                Description = $"Description{x}",
                Date = DateTime.Now,
                Image = $"https://fjdfjdkls.com/{x}",
                UserId = x * 2
            });

            await Task.Delay(10);
            return post;
            

            
        }*/


        //1ra forma de actualizar...
        //Contexto enlazado o no.....usando el trascking que usa el framework
        public async Task<bool> UpdatePost(Post post)
        {
            var currentPost = await GetPost(post.PostId);
            currentPost.Date = post.Date;
            currentPost.Description = post.Description;
            currentPost.Image = post.Image;

            int rowsAffected = await _context.SaveChangesAsync();
            return rowsAffected > 0;

        }


        //Metodo para eliminar
        public async Task<bool> DeletePost(int id)
        {
            var currentPost = await GetPost(id);
            _context.Posts.Remove(currentPost);

            int rowsAffected = await _context.SaveChangesAsync();
            return rowsAffected > 0;

        }






    }
}
