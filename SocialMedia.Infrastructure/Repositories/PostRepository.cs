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



    }
}
