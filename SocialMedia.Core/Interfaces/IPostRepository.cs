using SocialMedia.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Core.Interfaces
{
    public interface IPostRepository
    {
        //Se definen los metodos que se deben de implemenbtar en las clases

        Task<IEnumerable<Post>> GetPosts();

        Task<Post> GetPost(int id);


        Task InsertPost(Post post);
        //Task InserPost(Post Post);
        //Task InsertPost(IEnumerable<Post> posts);


        //operaciones CRUD

        Task<bool> UpdatePost(Post post);

        Task<bool> DeletePost(int id);
    }
}
