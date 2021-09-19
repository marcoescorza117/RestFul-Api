using SocialMedia.Core.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SocialMedia.Infrastructure.Repositories
{
    public class PostRepository
    {

        //retorna el listado de post
        public IEnumerable<Post> GetPost()
        {
            var post = Enumerable.Range(1, 58).Select(x => new Post { 
                
                PostId = x,
                Description = $"Description{x}",
                Date = DateTime.Now,
                Image = $"https://fjdfjdkls.com/{x}",
                UserId = x*2
            });

            return post;

        }
    }
}
