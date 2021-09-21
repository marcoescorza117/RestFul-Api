using SocialMedia.Core.Entities;
using SocialMedia.Core.Interfaces;
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

        //retorna el listado de post
        
        public async Task<IEnumerable<Post>> GetPosts()
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
        }
    }
}
